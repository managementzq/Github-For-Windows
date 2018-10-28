using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Tianyue.Utility.Extension;

namespace Tianyue.Utility.Common
{
    public class Executer
    {
        public static void TryRunByAsyn(Action fun, bool skipException = true)
        {
            Executer.TryRunSkipExceptoin((Action)(() => fun.BeginInvoke((AsyncCallback)null, (object)null)), skipException);
        }

        public static void TryRunByThreadPool(Action fun, bool skipException = true)
        {
            ThreadPool.QueueUserWorkItem((WaitCallback)(obj => Executer.TryRunSkipExceptoin(fun, skipException)));
        }

        public static void TryRunByTask(Action fun, bool skipException = true)
        {
            Task.Factory.StartNew((Action)(() => Executer.TryRunSkipExceptoin(fun, skipException)));
        }

        public static void TryRunByThread(Action fun, bool skipException = true)
        {
            Thread thread = new Thread(new ThreadStart(fun.Invoke));
            thread.IsBackground = true;
            if (skipException)
            {
                try
                {
                    thread.Start();
                }
                catch
                {
                }
            }
            else
                thread.Start();
        }

        public static void TryRunSkipExceptoin(Action fun, bool skipException = true)
        {
            if (skipException)
            {
                try
                {
                    fun();
                }
                catch (Exception ex)
                {
                    //LogHelper.Error(ex.Message, ex);
                }
            }
            else
                fun();
        }

        public static void TryRunLogExceptioin(Action fun, string message = "")
        {
            try
            {
                fun();
            }
            catch (Exception ex)
            {
                string.Format("{0}，{1}错误详情：{2}", (object)message, (object)Environment.NewLine, (object)ex.Message);
                //LogHelper.Error(message, ex);
            }
        }

        public static void TryRunThrowExceptioin(Action fun, string message = "")
        {
            try
            {
                fun();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("{0}，请尝试重新运行/重启程序，或者联系技术支持。{1}错误详情：{2}", (object)message, (object)Environment.NewLine, (object)ex.Message), ex);
            }
        }
    }
}
