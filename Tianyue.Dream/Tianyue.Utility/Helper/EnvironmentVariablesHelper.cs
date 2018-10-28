using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tianyue.Utility.Helper
{
    /// <summary>
    /// 系统环境变量帮助类
    /// </summary>
    public class EnvironmentVariablesHelper
    {
        /// <summary>
        /// 设置系统环境变量
        /// </summary>
        /// <param name="name">变量名</param>
        /// <param name="strValue">值</param>
        public static void SetSysEnvironment(string name, string strValue)
        {
            OpenSysEnvironment().SetValue(name, strValue);
        }

        /// <summary>
        /// 检测系统环境变量是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool CheckSysEnvironmentExist(string name)
        {
            if (string.IsNullOrEmpty(GetSysEnvironmentByName(name)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 添加到PATH环境变量最后（会检测路径是否存在，存在就不重复）
        /// </summary>
        /// <param name="strPath"></param>
        public static void SetPathAfter(string strPath)
        {
            string pathlist;
            pathlist = GetSysEnvironmentByName("PATH");
            //检测是否以;结尾
            if (pathlist.Substring(pathlist.Length - 1, 1) != ";")
            {
                SetSysEnvironment("PATH", pathlist + ";");
                pathlist = GetSysEnvironmentByName("PATH");
            }

            bool isPathExist = IsExistInPath(strPath, pathlist);
            if (!isPathExist)
            {
                SetSysEnvironment("PATH", pathlist + strPath + ";");
            }
        }

        /// <summary>
        /// 替换或追加环境变量Path路径至最后
        /// </summary>
        /// <param name="oldPath"></param>
        /// <param name="newPath"></param>
        public static void ReplacePathLast(string oldPath, string newPath)
        {
            string pathlist = GetSysEnvironmentByName("PATH");
            //检测是否以;结尾
            if (pathlist.Substring(pathlist.Length - 1, 1) != ";")
            {
                SetSysEnvironment("PATH", pathlist + ";");
                pathlist = GetSysEnvironmentByName("PATH");
            }
            string[] list = pathlist.Split(';');

            bool isPathExist = IsExistInPath(oldPath, pathlist);
            if (isPathExist)
            {
                //存在,则替换
                pathlist = pathlist.Replace(oldPath, newPath);
                SetSysEnvironment("PATH", pathlist);
            }
            else
            {
                //不存在
                SetPathAfter(newPath);
            }
        }

        /// <summary>
        /// 添加到PATH环境变量最前（会检测路径是否存在，存在就不重复）
        /// </summary>
        /// <param name="strPath"></param>
        public static void SetPathBefore(string strPath)
        {
            string pathlist;
            pathlist = GetSysEnvironmentByName("PATH");

            string[] list = pathlist.Split(';');
            bool isPathExist = IsExistInPath(strPath, pathlist);

            if (!isPathExist)
            {
                SetSysEnvironment("PATH", strPath + ";" + pathlist);
            }
        }

        /// <summary>
        /// 判断Path中路径是否已存在
        /// </summary>
        /// <param name="strPath"></param>
        /// <param name="pathlist"></param>
        /// <returns></returns>
        private static bool IsExistInPath(string strPath, string pathlist)
        {
            bool isPathExist = false;

            string[] list = pathlist.Split(';');
            foreach (string item in list)
            {
                if (item == strPath)
                {
                    isPathExist = true;
                }
            }
            return isPathExist;
        }

        [DllImport("Kernel32.DLL ", SetLastError = true)]
        public static extern bool SetEnvironmentVariable(string lpName, string lpValue);

        public static string GetSysEnvironmentByName(string name)
        {
            string result = string.Empty;
            try
            {
                result = OpenSysEnvironment().GetValue(name).ToString();//读取
            }
            catch (Exception)
            {
                return string.Empty;
            }
            return result;
        }

        public static RegistryKey OpenSysEnvironment()
        {
            RegistryKey regLocalMachine = Registry.LocalMachine;
            RegistryKey regSYSTEM = regLocalMachine.OpenSubKey("SYSTEM", true);//打开HKEY_LOCAL_MACHINE下的SYSTEM
            RegistryKey regControlSet001 = regSYSTEM.OpenSubKey("ControlSet001", true);//打开ControlSet001
            RegistryKey regControl = regControlSet001.OpenSubKey("Control", true);//打开Control
            RegistryKey regManager = regControl.OpenSubKey("Session Manager", true);//打开Control
            RegistryKey regEnvironment = regManager.OpenSubKey("Environment", true);

            return regEnvironment;
        }
    }
}
