using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.IO;
using Tianyue.Utility.Extension;

namespace Tianyue.Utility.Helper
{
    public class CryptographyHelper
    {
        public const string DESKEY = "#s^XLY_DESKEY_1986,11+15";
        private const string AESSALT = "gsf4jvkyhye5/d7k8OrLgM==";
        private const string AESRGBIV = "Rkb4jvUy/ye7Cd7k89QQgQ==";
        private const int ENCRYPTSIZE = 802400;
        private const int DECRYPTSIZE = 802416;

        public static string MD5Encrypt(string strValue)
        {
            if (string.IsNullOrEmpty(strValue))
                return string.Empty;

            MD5 md5 = (MD5)new MD5CryptoServiceProvider();
            byte[] bytes = strValue.ToBytes(Encoding.Unicode);
            byte[] hash = md5.ComputeHash(bytes);
            StringBuilder stringBuilder = new StringBuilder();
            int length = hash.Length;
            for (int index = 0; index < length; ++index)
                stringBuilder.Append(hash[index].ToString("x").PadLeft(2, '0'));
            md5.Clear();
            return stringBuilder.ToString();
        }

        public static string EncodeDES(string text, string key = "#s^XLY_DESKEY_1986,11+15")
        {
            //if ( !TypeExtension.IsValid(text))
            //    return string.Empty;

            if (string.IsNullOrEmpty(text))
                return string.Empty;

            if (key.Length != 24)
                return string.Empty;
            try
            {
                TripleDESCryptoServiceProvider cryptoServiceProvider = new TripleDESCryptoServiceProvider();
                cryptoServiceProvider.Key = Encoding.ASCII.GetBytes(key);
                cryptoServiceProvider.Mode = CipherMode.ECB;
                ICryptoTransform encryptor = cryptoServiceProvider.CreateEncryptor();
                byte[] bytes = Encoding.Default.GetBytes(text);
                byte[] inArray = encryptor.TransformFinalBlock(bytes, 0, bytes.Length);
                encryptor.Dispose();
                return Convert.ToBase64String(inArray);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string DecodeDES(string text, string key = "#s^XLY_DESKEY_1986,11+15")
        {
            if (string.IsNullOrEmpty(text) || key.Length != 24)
                return string.Empty;
            TripleDESCryptoServiceProvider cryptoServiceProvider = new TripleDESCryptoServiceProvider();
            cryptoServiceProvider.Key = Encoding.ASCII.GetBytes(key);
            cryptoServiceProvider.Mode = CipherMode.ECB;
            cryptoServiceProvider.Padding = PaddingMode.PKCS7;
            using (ICryptoTransform decryptor = cryptoServiceProvider.CreateDecryptor())
            {
                try
                {
                    byte[] inputBuffer = Convert.FromBase64String(text);
                    return Encoding.Default.GetString(decryptor.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length));
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        public static string AESEncrypt(string encryptString, string key)
        {
            return Convert.ToBase64String(CryptographyHelper.AESEncrypt(Encoding.Default.GetBytes(encryptString), key));
        }

        public static byte[] AESEncrypt(byte[] encryptByte, string key)
        {
            return CryptographyHelper.CreateICrypto(encryptByte, key, CryptographyHelper.CryptographyType.Encrypt);
        }

        public static string AESDecrypt(string encryptString, string key)
        {
            return Encoding.Default.GetString(CryptographyHelper.AESDecrypt(Convert.FromBase64String(encryptString), key));
        }

        public static byte[] AESDecrypt(byte[] encryptByte, string key)
        {
            return CryptographyHelper.CreateICrypto(encryptByte, key, CryptographyHelper.CryptographyType.Decrypt);
        }

        private static byte[] CreateICrypto(byte[] source, string key, CryptographyHelper.CryptographyType iCrypto)
        {
            //if (((IEnumerable<byte>)source).IsInvalid<byte>())
            //    throw new Exception("加解密数据源不可以为空!");
            if (string.IsNullOrEmpty(key))
                throw new Exception("密钥不可以为空");
            Rijndael rijndael = Rijndael.Create();
            byte[] array;
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(key, Convert.FromBase64String("gsf4jvkyhye5/d7k8OrLgM=="));
                ICryptoTransform transform = (ICryptoTransform)null;
                if (iCrypto == CryptographyHelper.CryptographyType.Encrypt)
                    transform = rijndael.CreateEncryptor(passwordDeriveBytes.GetBytes(32), Convert.FromBase64String("Rkb4jvUy/ye7Cd7k89QQgQ=="));
                if (iCrypto == CryptographyHelper.CryptographyType.Decrypt)
                    transform = rijndael.CreateDecryptor(passwordDeriveBytes.GetBytes(32), Convert.FromBase64String("Rkb4jvUy/ye7Cd7k89QQgQ=="));
                CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, transform, CryptoStreamMode.Write);
                cryptoStream.Write(source, 0, source.Length);
                cryptoStream.FlushFinalBlock();
                array = memoryStream.ToArray();
                memoryStream.Close();
                memoryStream.Dispose();
                cryptoStream.Close();
                cryptoStream.Dispose();
            }
            catch (IOException ex)
            {
                throw ex;
            }
            catch (CryptographicException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                rijndael.Clear();
            }
            return array;
        }

        public static string AESEncryptFile(string encryptpath, string key, bool isHiddenTempFile = false)
        {
            string str = encryptpath + ".xly";
            if (System.IO.File.Exists(str))
                System.IO.File.Delete(str);
            try
            {
                using (FileStream fileStream1 = new FileStream(encryptpath, FileMode.Open, FileAccess.Read))
                {
                    if (fileStream1.Length == 0L)
                        throw new Exception("不允许对无内容文件加密!");
                    using (FileStream fileStream2 = new FileStream(str, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        //if (isHiddenTempFile && File.IsValid(str))
                        //    System.IO.File.SetAttributes(str, FileAttributes.Hidden);
                        int num = ((int)fileStream1.Length - 1) / 802400 + 1;
                        for (int index = 0; index < num; ++index)
                        {
                            int count = 802400;
                            if (index == num - 1)
                                count = (int)(fileStream1.Length - (long)(index * 802400));
                            byte[] numArray = new byte[count];
                            fileStream1.Read(numArray, 0, count);
                            byte[] buffer = CryptographyHelper.AESEncrypt(numArray, key);
                            fileStream2.Write(buffer, 0, buffer.Length);
                            fileStream2.Flush();
                        }
                        fileStream2.Close();
                        fileStream2.Dispose();
                    }
                    fileStream1.Close();
                    fileStream1.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return str;
        }

        public static string AESDecryptFile(string decryptpath, string key)
        {
            //string path = decryptpath.TrimEnd(".xly", StringComparison.Ordinal);
            string path = decryptpath;
            try
            {
                using (FileStream fileStream1 = new FileStream(decryptpath, FileMode.Open, FileAccess.Read))
                {
                    if (fileStream1.Length > 0L)
                    {
                        using (FileStream fileStream2 = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            int num = ((int)fileStream1.Length - 1) / 802416 + 1;
                            for (int index = 0; index < num; ++index)
                            {
                                int count = 802416;
                                if (index == num - 1)
                                    count = (int)(fileStream1.Length - (long)(index * 802416));
                                byte[] numArray = new byte[count];
                                fileStream1.Read(numArray, 0, count);
                                byte[] buffer = CryptographyHelper.AESDecrypt(numArray, key);
                                fileStream2.Write(buffer, 0, buffer.Length);
                                fileStream2.Flush();
                            }
                            fileStream2.Close();
                            fileStream2.Dispose();
                        }
                        fileStream1.Close();
                        fileStream1.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "";
        }

        public enum CryptographyType
        {
            Encrypt,
            Decrypt,
        }
    }
}
