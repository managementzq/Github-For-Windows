using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tianyue.Utility.Enumeration
{
    /// <summary>
    /// 日志级别
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// 微量（写日志）
        /// </summary>
        Trace,

        /// <summary>
        /// 调试（写日志）
        /// </summary>
        Debug,

        /// <summary>
        /// 信息（返回友好信息）
        /// </summary>
        Info,

        /// <summary>
        /// 警告（返回友好信息）
        /// </summary>
        Warn,

        /// <summary>
        /// 错误（写日志）
        /// </summary>
        Error,

        /// <summary>
        /// 致命（写日志）
        /// </summary>
        Fatal
    }
}
