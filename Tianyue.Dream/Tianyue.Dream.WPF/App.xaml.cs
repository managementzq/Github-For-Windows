using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Tianyue.Business;

namespace Tianyue.Dream.WPF
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            App.Current.DispatcherUnhandledException += new System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(Current_DispatcherUnhandledException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            //MessageBox.Show("未知异常", e.Exception.AllMessage(), MessageBoxButton.OK, MessageBoxImage.Error);
            //LogHelper.Error(e.Exception.Message, e.Exception);
            //e.Handled = true;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
                //MessageBox.Show("未知异常", ex.AllMessage(), MessageBoxButton.OK, MessageBoxImage.Error);
                //LogHelper.Error(ex.Message, ex);
            }
        }


        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    //Xceed.Wpf.Toolkit.Licenser.LicenseKey = "DGF37-deds5-23dgv-we3dr";
        //    //Xceed.Wpf.Toolkit.Licenser.
        //    base.OnStartup(e);
        //}


        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                //GlobalData.log = LogManager.GetLogger("MES.Logging");

                bool isDebug = false;

#if DEBUG
                // 调试用代码
                isDebug = true;

#endif
                //MessageBox.Show(isDebug.ToString());
                if (isDebug)
                {

                }
                else if (e.Args.Length > 0 && e.Args[0] == "updated")//通过autoupdater执行
                {
                    //MessageBox.Show(e.Args[0]);
                }
                else
                {
                    AutoUpdate();
                    this.Shutdown();
                    return;
                }

                InitialSystemInfo();

                Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
                // 李纳修改
                // 根据配置进行判断，应启动哪个窗口
                Window window;
                window = new LoginWindow();
                
                bool? dialogResult = window.ShowDialog();
                if ((dialogResult.HasValue == true) &&
                    (dialogResult.Value == true))
                {
                    base.OnStartup(e);
                    Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                }
                else
                {
                    this.Shutdown();
                }
            }
            catch (Exception ex)
            {
                //LogHelper.LogMsg(ex.Message, true);
                this.Shutdown();
            }
        }

        /// <summary>
        ///     set system info
        /// </summary>
        private void InitialSystemInfo()
        {
            try
            {
                TianyueRegisterUnity.RegistTianyue();
                //TianyueRegisterUnity.RegistEcis40();

                //GlobalData._Language = ConfigurationManager.AppSettings["Language"];
                ////GlobalData.DBName = ConfigurationManager.AppSettings["DB_Name"];
                //GlobalData.DBType = ConfigurationManager.AppSettings["DB_Type"];
                ////GlobalData.ConnStr = ConfigurationManager.ConnectionStrings["SQLContext"].ConnectionString;
                //GlobalData.ConnStr = ConfigurationManager.AppSettings["context"];
                //GlobalData.MESServicePath = ConfigurationManager.AppSettings["SyncServicePath"];

                //LanguageHelper.GetLanguageInfo();
            }
            catch (Exception e)
            {
                throw new Exception("Program.InitialSystemInfo>>" + e.Message);
            }
        }

        private void AutoUpdate()
        {
            try
            {
                string strPath = AppDomain.CurrentDomain.BaseDirectory;
                //if (File.Exists(strPath + @"AutoUpdater.exe") && File.Exists(strPath + @"AutoUpdater.exe.config") && File.Exists(strPath + @"MES.Service.dll"))
                //{
                //    File.Copy(strPath + @"AutoUpdater.exe", strPath + @"AutoUpdater2.exe", true);
                //    File.Copy(strPath + @"AutoUpdater.exe.config", strPath + @"AutoUpdater2.exe.config", true);
                //    Process.Start(strPath + @"AutoUpdater2.exe");
                //}
                //else
                //{
                //    throw new Exception("Can't found AutoUpdater.exe/AutoUpdater.exe.config/MES.Service.dll !");
                //}
            }
            catch (Exception e)
            {
                throw new Exception("AutoUpdate Failed!>>" + e.Message);
            }
        }
    }
}
