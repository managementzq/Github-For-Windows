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
using System.Text.RegularExpressions;
using System.Web;
using Tianyue.Utility.Extension;

namespace Tianyue.Utility.Helper
{
    public class SystemHelper
    {
        public static string GetClientHostIP()
        {
            if (HttpContext.Current == null)
            {
                string hostName = Dns.GetHostName();
                IPAddress[] addressList = Dns.GetHostEntry(hostName).AddressList;
                if (addressList.Length > 0)
                {
                    string[] array = ((IEnumerable<IPAddress>)addressList).ToList<IPAddress>().Where<IPAddress>((Func<IPAddress, bool>)(s => !s.IsIPv6LinkLocal)).Select<IPAddress, string>((Func<IPAddress, string>)(s => s.ToString())).ToArray<string>();
                    return string.Format("{0}：{1}", (object)hostName, (object)string.Join(";", array));
                }
            }
            return HttpContext.Current.Request.UserHostAddress;
        }

        public static string GetHostName()
        {
            return Dns.GetHostName();
        }

        public static void KillProcess(string proName)
        {
            if (proName.IsNotNullOrEmptyOrWhiteSpace())
                return;
            Process[] processesByName = Process.GetProcessesByName(proName);
            if (((IEnumerable<Process>)processesByName).IsInvalid<Process>())
                return;
            foreach (Process process in processesByName)
            {
                try
                {
                    process.Kill();
                    process.Close();
                    process.Dispose();
                }
                catch
                {
                }
            }
        }

        public static void KillProcess(int id, string[] exceptPros)
        {
            List<Process> processByProtId = SystemHelper.FindProcessByProtId(id);
            if (processByProtId.IsInvalid<Process>())
                return;
            processByProtId.ForEach((Action<Process>)(p =>
            {
                if (((IEnumerable<string>)exceptPros).Contains<string>(p.ProcessName))
                    return;
                p.Kill();
                p.Close();
                p.Dispose();
            }));
        }

        public static List<Process> FindProcessByProtId(int id)
        {
            if (id <= 0)
                return (List<Process>)null;
            Process process1 = new Process();
            List<Process> processList = new List<Process>();
            try
            {
                process1.StartInfo.FileName = "cmd.exe";
                process1.StartInfo.CreateNoWindow = true;
                process1.StartInfo.UseShellExecute = false;
                process1.StartInfo.RedirectStandardOutput = true;
                process1.StartInfo.RedirectStandardInput = true;
                process1.StartInfo.RedirectStandardError = true;
                process1.Start();
                process1.StandardInput.WriteLine(string.Format("netstat -aon|findstr {0}", (object)id));
                process1.StandardInput.WriteLine("exit");
                StreamReader standardOutput = process1.StandardOutput;
                while (!standardOutput.EndOfStream)
                {
                    string line = standardOutput.ReadLine();
                    if (line.IsNotNullOrEmptyOrWhiteSpace())
                    {
                        Process process2 = SystemHelper.ReadLine(line);
                        if (process2 != null)
                            processList.Add(process2);
                    }
                }
                return processList;
            }
            catch (Exception ex)
            {
                return (List<Process>)null;
            }
            finally
            {
                process1.Close();
            }
        }

        private static Process ReadLine(string line)
        {
            line = Regex.Replace(line, "\\s+", ",").Trim(',');
            string[] strArray = line.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (strArray.Length == 0 || strArray[0] != "TCP" || strArray[3] != "LISTENING")
                return (Process)null;
            return Process.GetProcessById(strArray[4].ToSafeInt());
        }

        public static bool IsConnectedBiadu()
        {
            PingReply pingReply = new Ping().Send("www.baidu.com");
            return pingReply != null && pingReply.Status == IPStatus.Success;
        }

        [DllImport("wininet")]
        private static extern bool InternetGetConnectedState(out int connectionDescription, int reservedValue);

        public static bool IsConnectedInternet()
        {
            int connectionDescription = 0;
            return SystemHelper.InternetGetConnectedState(out connectionDescription, 0);
        }

        public static string GetCurrentDesktop()
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Shell Folders");
            if (registryKey != null)
                return registryKey.GetValue("Desktop").ToSafeString();
            return string.Empty;
        }

        public static bool IsRunAsAdmin()
        {
            return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static void SetPathEnvironment(string value)
        {
            try
            {
                string environmentVariable = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine);
                if (environmentVariable.Contains(value))
                    return;
                Environment.SetEnvironmentVariable("PATH", !environmentVariable.EndsWith(";") ? environmentVariable + ";" + value : environmentVariable + value, EnvironmentVariableTarget.Machine);
            }
            catch
            {
            }
        }
    }
}
