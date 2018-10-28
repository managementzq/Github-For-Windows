using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Utility.Common;

namespace Tianyue.Utility.Helper
{
    /// <summary>
    /// Create Instance Helper
    /// Author: Minghua
    /// </summary>
    public class InstanceHelper
    {
        public static T GetInstance<T>() where T : new()
        {
            using (new CodeTimer(string.Format("new {0}()", typeof(T).FullName)))
            {
                try
                {
                    return new T();
                }
                catch (Exception ex)
                {
                    //LogExcept.Log.Error(ex);
                    return default(T);
                }
            }
        }

        public static T GetInstance<T>(Type t) where T : new()
        {
            using (new CodeTimer(string.Format("(T)Activator.CreateInstance({0})", t.FullName)))
            {
                try
                {
                    return (T)Activator.CreateInstance(t);
                }
                catch (Exception ex)
                {
                    //LogExcept.Log.Error(ex);
                    return default(T);
                }
            }
        }

        public static T GetInstance<T>(Type t, string pvid, string userName) where T : new()
        {
            try
            {
                return (T)Activator.CreateInstance(t, pvid, userName);
            }
            catch (Exception ex)
            {
                //LogExcept.Log.Error(ex);
                return default(T);
            }
        }
    }
}
