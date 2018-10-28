using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tianyue.Wpf.Control
{
    /// <summary>
    /// 通知消息类型
    /// </summary>
    public enum EnumNotifyType
    {
        [Description("错误")]
        Error,
        [Description("警告")]
        Warning,
        [Description("提示信息")]
        Info,
        [Description("询问信息")]
        Question,
    }
}
