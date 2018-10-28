using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tianyue.Utility.Extension
{
    public static class ExceptionExtension
    {
        public static string ToLogString(this Exception ex)
        {
            if (ex == null)
                return string.Empty;
            StringBuilder stringBuilder1 = new StringBuilder();
            stringBuilder1.Append("  >>异常消息（Message）：").AppendLine(ex.Message);
            stringBuilder1.Append("  >>异常来源（Source）：").AppendLine(ex.Source);
            stringBuilder1.Append("  >>异常类型（ExceptionType）：").AppendLine(ex.GetType().ToString());
            stringBuilder1.Append("  >>原生异常类型（BaseExceptionType）：").AppendLine(ex.GetBaseException().GetType().ToString());
            stringBuilder1.Append("  >>出错的方法签名（TargetSite）：").Append((object)ex.TargetSite);
            if (ex.Data.Count > 0)
            {
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("  >>自定义数据（Data）：");
                StringBuilder stringBuilder2 = new StringBuilder();
                foreach (DictionaryEntry dictionaryEntry in ex.Data)
                    stringBuilder2.Append("Key：" + dictionaryEntry.Key + "，Value：" + dictionaryEntry.Value + "; ");
                stringBuilder1.Append((object)stringBuilder2);
            }
            if (!string.IsNullOrEmpty(ex.StackTrace))
            {
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("  >>堆栈信息（StackTrace）：");
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append(ex.StackTrace);
            }
            if (ex.InnerException != null)
            {
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append(">>========================== 内部异常（InnerException）==========================");
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append(ex.InnerException.ToLogString());
            }
            return stringBuilder1.ToString();
        }

        public static string AllMessage(this Exception ex)
        {
            if (ex == null)
                return string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(ex.Message);
            if (ex.InnerException != null)
            {
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append(">").Append(ex.InnerException.AllMessage());
            }
            return stringBuilder.ToString();
        }

    }
}
