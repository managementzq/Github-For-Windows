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
    public class CodeTimer : IDisposable
    {
        private readonly string _messageId;
        private readonly Stopwatch _stopwatch;

        private const string FORMATBEGIN = ">>[{0}]";
        private const string FORMATEND = "<<[{0}] - TraceTimer:{1}";
#if DEBUG
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable = true;
#else
        public bool IsEnable = false;
#endif

        public CodeTimer(string messageId)
        {
            if (IsEnable)
            {
                _messageId = messageId;
                _stopwatch = Stopwatch.StartNew();
                //LogRepository.Log.Trace(string.Format(FORMATBEGIN, messageId));
            }
        }

        public void Dispose()
        {
            if (IsEnable)
            {
                _stopwatch.Stop();
                //LogRepository.Log.Trace(FORMATEND, _messageId, _stopwatch.Elapsed.ToPerformanceTime());
            }
        }
    }
}
