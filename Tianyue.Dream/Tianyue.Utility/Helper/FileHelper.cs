using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tianyue.Utility.Common;
using Tianyue.Utility.Extension;

namespace Tianyue.Utility.Helper
{
    public static class FileHelper
    {
        private static readonly object _sync = new object();
        private static readonly char[] InvalidPathChars = new char[39]
        {
      '"',
      '<',
      '>',
      '|',
      char.MinValue,
      '\x0001',
      '\x0002',
      '\x0003',
      '\x0004',
      '\x0005',
      '\x0006',
      '\a',
      '\b',
      '\t',
      '\n',
      '\v',
      '\f',
      '\r',
      '\x000E',
      '\x000F',
      '\x0010',
      '\x0011',
      '\x0012',
      '\x0013',
      '\x0014',
      '\x0015',
      '\x0016',
      '\x0017',
      '\x0018',
      '\x0019',
      '\x001A',
      '\x001B',
      '\x001C',
      '\x001D',
      '\x001E',
      '\x001F',
      '*',
      '?',
      ':'
        };

        private static readonly char[] _InvalidChars = Path.GetInvalidFileNameChars();

        public static bool IsFileExists(string filePath, out string msg)
        {
            msg = string.Empty;
            //1、验证文件是否存在
            var fileInfo = new FileInfo(filePath);
            if (fileInfo.Exists)
                return true;

            var stack = new Stack<string>();
            //2、验证路径是否存在
            var checkFilePath = filePath.Replace(fileInfo.Name, string.Empty);
            var directory = new DirectoryInfo(checkFilePath);
            stack.Push(directory.FullName);
            while (directory != null && directory.Parent != null)
            {
                directory = directory.Parent;
                if (directory != null)
                    stack.Push(directory.FullName);
            }
            while (stack.Count > 0)
            {
                var path = stack.Pop();
                var dir = new DirectoryInfo(path);
                if (dir.Exists)
                    continue;

                msg = string.Format("文件{0}的路径{1}不存在", filePath, path);
                return false;
            }

            msg = string.Format("文件{0}不存在", filePath);
            return false;
        }

        public static string FileToString(string strFilePath)
        {
            return FileToString(strFilePath, Encoding.UTF8);
        }

        public static string FileToString(string strFilePath, Encoding encoding)
        {
            if (!System.IO.File.Exists(strFilePath))
                return string.Empty;

            try
            {
                using (StreamReader streamReader = new StreamReader(strFilePath, encoding))
                    return streamReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static FileStream FileToStream(string strFilePath)
        {
            Guard.ArgumentNotNullOrEmpty(strFilePath, nameof(strFilePath));
            return new FileStream(strFilePath, FileMode.Open, FileAccess.Read);
        }

        public static byte[] FileToBytes(string strFilePath, int intLength = 0, int intStart = 0)
        {
            using (FileStream stream = FileToStream(strFilePath))
            {
                int num1 = stream.Length > (long)int.MaxValue ? int.MaxValue : (int)stream.Length;
                int num2 = intLength == 0 ? num1 : intLength;
                int count = num2 >= num1 ? num1 : num2;
                byte[] buffer = new byte[count];
                stream.Read(buffer, intStart, count);
                return buffer;
            }
        }

        public static void CreateDirectory(string directoryPath)
        {
            if (string.IsNullOrEmpty(directoryPath) || Directory.Exists(directoryPath))
                return;

            Executer.TryRunLogExceptioin((Action)(() => Directory.CreateDirectory(directoryPath)), string.Format("文件夹{0}创建失败", (object)directoryPath));
        }

        public static string CreateFileDirectory(string strFilePath)
        {
            string strFilePathNew = GetFilePath(strFilePath, '\\');
            CreateDirectory(strFilePathNew);
            return strFilePathNew;
        }

        public static void CreateFile(string strFilePath)
        {
            if (string.IsNullOrEmpty(strFilePath))
                return;
            try
            {
                if (!System.IO.File.Exists(strFilePath))
                {
                    CreateDirectory(GetFilePath(strFilePath, '\\'));
                    lock (_sync)
                    {
                        using (new FileStream(strFilePath, FileMode.OpenOrCreate))
                            ;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("创建文件异常", ex);
            }
        }

        public static void CreateFile(string strFilePath, byte[] buffer)
        {
            if (string.IsNullOrEmpty(strFilePath))
                return;
            try
            {
                if (!System.IO.File.Exists(strFilePath))
                {
                    using (FileStream fileStream = new FileInfo(strFilePath).Create())
                        fileStream.Write(buffer, 0, buffer.Length);
                }
            }
            catch
            {
            }
        }

        public static void CreateFile(string strFilePath, string text)
        {
            CreateFile(strFilePath, text, Encoding.GetEncoding("utf-8"));
        }

        public static void CreateFile(string filePath, string text, Encoding encoding)
        {
            if (filePath == null || filePath == string.Empty)
                return;
            string filePath1 = GetFilePath(filePath, '\\');
            if (!Directory.Exists(filePath1))
                Directory.CreateDirectory(filePath1);
            using (FileStream fileStream = new FileInfo(filePath).Create())
            {
                using (StreamWriter streamWriter = new StreamWriter((Stream)fileStream, encoding))
                {
                    streamWriter.Write(text);
                    streamWriter.Flush();
                }
            }
        }

        public static void Open(params string[] path)
        {
            if (((IEnumerable<string>)path).IsInvalid<string>())
                return;
            string arguments = ConnectPath(path);
            try
            {
                Process.Start("explorer.exe", arguments);
            }
            catch (Exception ex)
            {
                throw new Exception("打开文件出现异常:" + arguments, ex);
            }
        }

        public static void DeleteFile(string filePath)
        {
            if (filePath.IsNullOrEmptyOrWhiteSpace())
                return;

            try
            {
                System.IO.File.Delete(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception("删除文件异常:" + filePath, ex);
            }
        }

        public static string GetFileName(string source, char separate = '\\')
        {
            if (source.IsNullOrEmptyOrWhiteSpace())
                return string.Empty;

            source = source.TrimEnd(separate);
            int num = source.LastIndexOf(separate);
            if (num > 0)
                return source.Substring(num + 1, source.Length - num - 1);

            return source;
        }

        public static string GetFilePath(string source, char separate = '\\')
        {
            if (source.IsNullOrEmptyOrWhiteSpace())
                return string.Empty;

            source = source.TrimEnd(separate);
            int num = source.LastIndexOf(separate);
            if (num > 0)
                return source.Substring(0, num + 1);
            return source;
        }

        public static string ConnectPath(char separate, params string[] path)
        {
            if (((IEnumerable<string>)path).IsInvalid<string>())
                return string.Empty;
            if (path.Length == 2)
                return string.Format("{0}{1}{2}", (object)path[0].TrimEnd(separate), (object)separate, (object)path[1].TrimStart(separate));
            if (path.Length == 1)
                return path[0];
            StringBuilder stringBuilder = new StringBuilder(32);
            foreach (string str in path)
                stringBuilder.Append(str.TrimEnd(separate).TrimStart(separate)).Append(separate);
            return stringBuilder.ToString().TrimEnd(separate);
        }

        public static string ConnectPath(params string[] path)
        {
            return ConnectPath('\\', path);
        }

        public static string ConvertLinuxPath(string linuxpath, char validChar = '_')
        {
            int index = linuxpath.IndexOfAny(InvalidPathChars);
            if (index >= 0)
                return ConvertLinuxPath(linuxpath.Replace(linuxpath[index], validChar), '_');
            return linuxpath.Replace('/', '\\');
        }

        public static string ConnectLinuxPath(string path1, string path2)
        {
            return ConnectPath('/', path1, path2);
        }

        public static string GetLinuxFileName(string source)
        {
            return GetFileName(source, '/');
        }

        public static string GetLinuxFilePath(string source)
        {
            return GetFilePath(source, '/');
        }

        public static string GetExtension(string filePath)
        {
            Guard.ArgumentNotNullOrEmpty(filePath, nameof(filePath));
            string str = string.Empty;
            try
            {
                str = Path.GetExtension(filePath).Replace(".", string.Empty);
            }
            catch (Exception ex)
            {
            }
            return str;
        }

        public static string TryGetExtension(string filename, char splitChar)
        {
            Guard.ArgumentNotNullOrEmpty(filename, "filePath");
            string[] strArray = filename.Split(splitChar);
            string str = string.Empty;
            if (((IEnumerable<string>)strArray).Any<string>())
                str = ((IEnumerable<string>)strArray).Last<string>();
            return str;
        }

        public static string GetPhysicalPath(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath))
                return string.Empty;
            relativePath = relativePath.Replace("/", "\\").Replace("~", string.Empty).Replace("~/", string.Empty);
            relativePath = relativePath.StartsWith("\\") ? relativePath.Substring(1, relativePath.Length - 1) : relativePath;
            return Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, relativePath);
        }

        public static string GetFileSize(string filePath)
        {
            Guard.ArgumentNotNullOrEmpty(filePath, nameof(filePath));
            if (!System.IO.File.Exists(filePath))
                return string.Empty;
            return GetFileSize(new FileInfo(filePath).Length, "F2");
        }

        public static long GetFileLength(string filepath)
        {
            long num = 0;
            using (FileStream fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                num = fileStream.Length;
            return num;
        }

        public static string GetFileSize(long len, string format = "F2")
        {
            if (len <= 0L)
                return "0 KB";
            string str = " B";
            double d = (double)len;
            double num = 1024.0;
            if ((double)len >= num)
            {
                d = (double)len / num;
                str = " KB";
            }
            if (d > num)
            {
                d /= num;
                str = " MB";
            }
            if (d > num)
            {
                d /= num;
                str = " GB";
            }
            if (d - Math.Truncate(d) == 0.0)
                return d.ToString("F2") + str;
            return d.ToString("F2") + str;
        }

        public static string GetFileSize(int len)
        {
            return GetFileSize((long)len, "F2");
        }

        public static IList<FileInfo> GetFiles(string folder, string extension)
        {
            return GetFiles(folder, new string[1]
            {
        extension
            });
        }

        public static IList<FileInfo> GetFiles(string folder, string[] extensions)
        {
            return (IList<FileInfo>)((IEnumerable<string>)Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories)).Select(file =>
            {
                var data = new
                {
                    file = file,
                    extension = Path.GetExtension(file)
                };
                return data;
            }).Where(_param1 => _param1.extension != null && ((IEnumerable<string>)extensions).Contains<string>(_param1.extension.ToLower())).Select(_param0 => new FileInfo(_param0.file)).ToList<FileInfo>();
        }

        public static bool IsValid(string file)
        {
            //return !TypeExtension.IsInvalid(file) && System.IO.File.Exists(file) && new FileInfo(file).Length > 0L;
            return file.IsNotNullOrEmptyOrWhiteSpace() && System.IO.File.Exists(file) && new FileInfo(file).Length > 0L;
        }

        public static bool IsValidDictory(string path)
        {
            //return !TypeExtension.IsInvalid(path) && Directory.Exists(path);
            return path.IsNotNullOrEmptyOrWhiteSpace() && Directory.Exists(path);
        }

        public static byte[] ReadFileHead(string filePath, int index = 4)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[index];
                fileStream.Read(buffer, 0, index);
                return buffer;
            }
        }

        public static string FilterInvalidFileName(string oriName)
        {
            return ((IEnumerable<char>)_InvalidChars).Aggregate<char, string>(oriName, (Func<string, char, string>)((current, invalidChar) => current.Replace(invalidChar.ToString(), string.Empty)));
        }

        public static bool IsFileInUsing(string path)
        {
            bool flag = true;
            try
            {
                using (new FileStream(path, FileMode.Open))
                    flag = false;
            }
            catch
            {
            }
            return flag;
        }

        //public static bool InputPathIsValid(string path)
        //{
        //    return IsPositiveNumber(path) && IsHasUninvalidPathChars(path);
        //}

        private static bool IsPositiveNumber(string path)
        {
            return Regex.IsMatch(path, "^[a-zA-Z]:\\\\[^\\/\\:\\*\\?\\\"\\<\\>\\|\\,]+$", RegexOptions.IgnoreCase);
        }

        //private static bool IsHasUninvalidPathChars(string path)
        //{
        //    return !((IEnumerable<char>)Path.GetInvalidPathChars()).Any<char>(new Func<char, bool>(((Enumerable)path).Contains<char>));
        //}
    }
}
