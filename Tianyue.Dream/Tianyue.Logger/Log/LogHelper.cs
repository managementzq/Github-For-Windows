using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Utility.Enumeration;

namespace Tianyue.Logger.Log
{
    public static class LogHelper
    {
        public static ILog logger;

        /// <summary>
        ///   Save message info to log file, popup messagebox if necessary
        /// </summary>
        /// <param name="strMessage">meesage info</param>
        public static void LogMessage(string strMessage, LogLevel enumLogLevel)
        {
            try
            {
                switch (enumLogLevel)
                {
                    //case LogLevel.Trace:
                    //    logger.Trace(strMsg, e);
                    //    break;
                    case LogLevel.Debug:
                        logger.Debug(strMessage);
                        break;
                    case LogLevel.Info:
                        logger.Info(strMessage);
                        break;
                    case LogLevel.Warn:
                        logger.Warn(strMessage);
                        break;
                    case LogLevel.Error:
                        logger.Error(strMessage);
                        break;
                    case LogLevel.Fatal:
                        logger.Fatal(strMessage);
                        break;
                }
            }
            catch (Exception ex)
            {
                //logger.Info(strClass + ".LogMsg>>" + ex.Message + ">>" + strMsg);
            }
        }

        /// <summary>
        ///     save message info to log file, popup messagebox if necessary
        /// </summary>
        /// <param name="strMessage">meesage info</param>
        public static void LogException(string strMessage, LogLevel enumLogLevel, Exception excp)
        {
            try
            {
                switch (enumLogLevel)
                {
                    //case LogLevel.Trace:
                    //    logger.Trace(strMsg, e);
                    //    break;
                    case LogLevel.Debug:
                        logger.Debug(strMessage, excp);
                        break;
                    case LogLevel.Info:
                        logger.Info(strMessage, excp);
                        break;
                    case LogLevel.Warn:
                        logger.Warn(strMessage, excp);
                        break;
                    case LogLevel.Error:
                        logger.Error(strMessage, excp);
                        break;
                    case LogLevel.Fatal:
                        logger.Fatal(strMessage, excp);
                        break;
                }
            }
            catch (Exception ex)
            {
                //logger.Info(strClass + ".LogMsg>>" + ex.Message + ">>" + strMsg);
            }
        }
        
        /// <summary>
        /// 记录日志并抛出错误
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="strMessage"></param>
        /// <param name="inner"></param>
        /// <param name="enumLogLevel"></param>
        public static void LogThrowException(string strMessage , Exception inner, LogLevel enumLogLevel)
        {
           
                    //throw new ThrowException(inner, enumLogLevel);
            
            
        }


       
    }

    public abstract class ThrowException : Exception
    {
        public ThrowException()
        {
        }

        public ThrowException(string message, Exception excp)
            : base(message, excp)
        {
            //LogException(message, LogLevel.Error, excp);
        }
    }
}
