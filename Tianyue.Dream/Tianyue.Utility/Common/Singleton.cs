using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
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
    /// <summary>
    /// Generic singleton pattern implementation
    /// Author: Minghua
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class Singleton<T> where T : class, new()
    {
        #region 实例化

        private static volatile T _instance;
        private static readonly object _objLock = new object();

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_objLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new T();
                        }
                    }
                }
                return _instance;
            }
        }

        #endregion 实例化

        #region 延时实例化

        /*
          * 相当于
          * private readonly Lazy<FrmMain> _frmMain = new Lazy<FrmMain>(() => {return new FrmMain();}, true)
          *
          */

        private static readonly Lazy<T> _lazyInstance = new Lazy<T>(() =>
        {
            Type tp = typeof(T);
            var ctors = tp.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            if (ctors.Count() != 1)
            {
                throw new InvalidOperationException(
                    string.Format("Type {0} must have exactly one constructor.", tp));
            }
            var ctor = ctors.SingleOrDefault(c => c.GetParameters().Count() == 0 && c.IsPublic);
            if (ctor == null)
            {
                throw new InvalidOperationException(
                    string.Format("The constructor for {0} must be public and take no parameters.", tp));
            }
            return (T)ctor.Invoke(null);
        },
        isThreadSafe: true);

        public static T LazyInstance
        {
            get
            {
                return _lazyInstance.Value;
            }
        }

        #endregion 延时实例化

        private static T _Instance = default(T);

        public static T GetInstance()
        {
            if ((object)Singleton<T>._Instance == null)
                Interlocked.CompareExchange<T>(ref Singleton<T>._Instance, Activator.CreateInstance<T>(), default(T));
            return Singleton<T>._Instance;
        }
    }
}
