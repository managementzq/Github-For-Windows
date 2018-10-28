using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tianyue.Utility.Common;
using Tianyue.Utility.Extension;
using Tianyue.Utility.Helper;

namespace Tianyue.Logger.Log
{
    public class FileLogger
    {
        public int MaxSize = 2048;
        public string LogPath = FileHelper.GetPhysicalPath("Log");
        public string FileName = "Log";
        public bool IsAsyn = true;
        private int FileIndex = 1;
        private DateTime LastDate = DateTime.Now;

        private string GetFilePath()
        {
            if (DateTime.Now.Date > this.LastDate.Date)
                this.FileIndex = 1;
            this.LogPath = this.LogPath.EndsWith("\\") ? this.LogPath.Substring(0, this.LogPath.Length - 1) : this.LogPath;
            string str = string.Format("{0}\\{1}\\{2}{3}.log", (object)this.LogPath, (object)DateTime.Now.ToString("yyyy-MM-dd"), (object)this.FileName, (object)this.FileIndex);
            if (!System.IO.File.Exists(str))
               FileHelper.CreateFile(str, string.Empty);
            if (this.GetFileSize(str) > (long)this.MaxSize)
            {
                ++this.FileIndex;
                return this.GetFilePath();
            }
            this.LastDate = DateTime.Now;
            return str;
        }

        private long GetFileSize(string filePath)
        {
            return new FileInfo(filePath).Length / 1024L;
        }

        private void Write(string text)
        {
            if (this.IsAsyn)
                this.AsynWriteLog(text);
            else
                this.WriteLog(text);
        }

        private void WriteLog(string text)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(this.GetFilePath(), true))
                {
                    streamWriter.WriteLine(text);
                    streamWriter.Flush();
                }
            }
            catch
            {
            }
        }

        private void AsynWriteLog(string value)
        {
            Executer.TryRunByThreadPool((Action)(() => this.WriteLog(value)), true);
        }

        private string LogFormat(string content, string logLevel, Exception exception)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.AppendLine("//==========================================================================================================");
            stringBuilder.AppendFormat("系统时间：{0}", (object)DateTime.Now.ToString((IFormatProvider)CultureInfo.InvariantCulture));
            stringBuilder.Append("  ");
            stringBuilder.AppendFormat("当前线程ID：{0}", (object)Thread.CurrentThread.ManagedThreadId);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.AppendFormat("日志等级：{0}", (object)logLevel);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.AppendFormat("日志内容：{0}", (object)content);
            if (exception != null)
            {
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.AppendLine("异常信息：");
                stringBuilder.Append(exception.ToLogString());
            }
            return stringBuilder.ToString();
        }

        [Obsolete("记录消息，无任何格式处理，记录系统日志请勿使用该功能")]
        public void LogMessage(string content)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(this.GetFilePath(), true))
                {
                    streamWriter.WriteLine(content);
                    streamWriter.Flush();
                }
            }
            catch
            {
            }
        }

        public void Log(string content, string level, Exception ex)
        {
            this.Write(this.LogFormat(content, level, ex));
        }
    }
}
