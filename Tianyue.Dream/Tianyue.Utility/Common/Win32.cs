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
    public static class Win32
    {
        [DllImport("kernel32.dll")]
        public static extern void CloseHandle(IntPtr hObject);

        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        public static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, byte[] lpReturnedString, uint nSize, string lpFileName);

        [DllImport("kernel32.dll", EntryPoint = "GetDiskFreeSpaceExA")]
        public static extern int GetDiskFreeSpaceEx(string lpRootPathName, out long lpFreeBytesAvailable, out long lpTotalNumberOfBytes, out long lpTotalNumberOfFreeBytes);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string className, string windowName);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr handlerParent, int handlerChildAfter, string childClassName, string childWindowName);

        public static IntPtr FindWindowByText(string windowName)
        {
            return FindWindow((string)null, windowName);
        }

        public static IntPtr FindWindowByText(IntPtr handlerParent, string childWindowName)
        {
            return FindWindowEx(handlerParent, 0, (string)null, childWindowName);
        }

        public static IntPtr FindWindowByText(IntPtr handlerParent, int handlerChildAfter, string childWindowName)
        {
            return FindWindowEx(handlerParent, handlerChildAfter, (string)null, childWindowName);
        }

        public static IntPtr FindWindowByClass(string className)
        {
            return FindWindow((string)null, className);
        }

        public static IntPtr FindWindowByClass(IntPtr handlerParent, string childClassName)
        {
            return FindWindowEx(handlerParent, 0, childClassName, (string)null);
        }

        public static IntPtr FindWindowByClass(IntPtr handlerParent, int handlerChildAfter, string childClassName)
        {
            return FindWindowEx(handlerParent, handlerChildAfter, childClassName, (string)null);
        }

        public static IntPtr FindWindowByClass(int handlerChildAfter, string childClassName)
        {
            return FindWindowEx(IntPtr.Zero, handlerChildAfter, childClassName, (string)null);
        }

        public static bool HideWindow(IntPtr handlerWindow)
        {
            return ShowWindow(handlerWindow, 0U);
        }

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr handlerWindow, uint cmd);

        [DllImport("user32.dll")]
        public static extern bool SetWindowLong(IntPtr handlerWindow, int nIndex, int newLong);

    }
}
