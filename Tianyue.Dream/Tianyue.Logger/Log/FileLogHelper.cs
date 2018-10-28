using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Utility.Extension;
using Tianyue.Utility.Helper;

namespace Tianyue.Logger.Log
{
    public static class FileLogHelper
    {
        private static FileLogger _logger = new FileLogger();

        static FileLogHelper()
        {
            FileLogHelper._logger.LogPath = FileHelper.GetPhysicalPath("Log");
        }

        public static string LogPath
        {
            set
            {
                FileLogHelper._logger.LogPath = value;
            }
        }

        public static void Info(string message, Exception exception = null)
        {
            FileLogHelper._logger.Log(message, FileLogHelper.LogLevel.Info.GetDescription(), exception);
        }

        public static void Debug(string message, Exception exception = null)
        {
            FileLogHelper._logger.Log(message, FileLogHelper.LogLevel.Debug.GetDescription(), exception);
        }

        public static void Warn(string message, Exception exception = null)
        {
            FileLogHelper._logger.Log(message, FileLogHelper.LogLevel.Warn.GetDescription(), exception);
        }

        public static void Error(string message, Exception exception = null)
        {
            FileLogHelper._logger.Log(message, FileLogHelper.LogLevel.Error.GetDescription(), exception);
        }

        public static void Fatal(string message, Exception exception = null)
        {
            FileLogHelper._logger.Log(message, FileLogHelper.LogLevel.Fatal.GetDescription(), exception);
        }

        private enum LogLevel
        {
            Info,
            Debug,
            Warn,
            Error,
            Fatal,
        }
    }
}
