using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tianyue.Logger.Exception1
{

    /// <summary>
    /// 错误日志拦截
    /// </summary>
    public class ExceptionLoggingBehavior 
    {
        //public override IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        //{
        //    using (new CodeTimer(input.MethodBase.DeclaringType.FullName + "." + input.MethodBase.Name))
        //    {
        //        IMethodReturn rt = getNext.Invoke().Invoke(input, getNext);
        //        if (rt.Exception != null && input.Arguments != null)
        //        {
        //            List<string> args = new List<string>();
        //            for (int i = 0; i < input.Arguments.Count; i++)
        //            {
        //                if (input.Arguments[i] == null)
        //                    continue;
        //                args.Add(input.Arguments[i].ToString());
        //            }

        //            ////日志打印
        //            //LogRepository.Log.Error("AOP ERROR: {0}-{1}={2}={3}({4})",
        //            //        rt.Exception.Message,
        //            //        input.MethodBase.DeclaringType.FullName,
        //            //        input.Target.ToString(),
        //            //        input.MethodBase.Name.ToString(),
        //            //        string.Join(",", args)
        //            //        );
        //            //LogRepository.Log.Error(rt.Exception);
        //        }
        //        return rt;
        //    }
        //}
    }
}
