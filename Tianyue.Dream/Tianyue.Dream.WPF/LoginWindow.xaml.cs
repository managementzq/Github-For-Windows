using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tianyue.Domain;
using Tianyue.Domain.Configuration;
using Tianyue.Dream.WPF.Properties;
using Tianyue.Facade;
using Tianyue.Wpf.Control;

namespace Tianyue.Dream.WPF
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void txtPassword_Loaded(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.RememberMe)
            {
                cbRememberMe.IsChecked = true;
                txtUserId.Text = Settings.Default.LastLogonUser;
                try
                {
                    txtPassword.Password = Settings.Default.LastPassword;
                }
                catch
                {
                    txtPassword.Password = "";
                }
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string strMsg = "";
                //UserBLL bll = new UserBLL();
                string strUserId = txtUserId.Text;
                string strPassword = txtPassword.Password;
                User queryUser = new User();
                queryUser.UserUniqueId = strUserId;
                User userEntity = GlobalFacade.ConfigurationFacade.GetSingleUser(queryUser);
                if (userEntity == null)
                {
                    //TianyueMessageBox.Info("用户名错误！");

                    MessageBox.Show("用户名错误！");

                    txtUserId.Text = "";
                    txtUserId.Focus();

                    txtPassword.Clear();
                }
                else if(userEntity.Password != strPassword)
                {
                    //TianyueMessageBox.Info("密码错误！");
                    MessageBox.Show("密码错误！");

                    txtPassword.Clear();
                    txtPassword.Focus();
                }
                else
                {
                    //记住我
                    bool blRememberMe = cbRememberMe.IsChecked == null ? false : (bool)cbRememberMe.IsChecked;
                    if (blRememberMe)
                    {
                        Settings.Default.LastPassword = txtPassword.Password;
                        Settings.Default.LastLogonUser = txtUserId.Text;
                        Settings.Default.RememberMe = true;
                        Settings.Default.Save();
                    }
                    else
                    {
                        Settings.Default.LastPassword = "";
                        Settings.Default.LastLogonUser = "";
                        Settings.Default.RememberMe = false;
                        Settings.Default.Save();
                    }

                    GlobalVariable.UserEntity = userEntity;
                    InitialSystemInfo();


                    DialogResult = true;
                }
            }
            catch (Exception ex)
            {
                //LogHelper.LogMsg("btnLogin_Click>>" + ex.Message, true);
            }
        }


        /// <summary>
        ///     set system info
        /// </summary>
        private void InitialSystemInfo()
        {
            try
            {
                //GlobalVariable._Language = ConfigurationManager.AppSettings["Language"];
                ////GlobalData.DBName = ConfigurationManager.AppSettings["DB_Name"];
                //GlobalVariable.DBType = ConfigurationManager.AppSettings["DB_Type"];
                ////GlobalData.ConnStr = ConfigurationManager.ConnectionStrings["SQLContext"].ConnectionString;
                //GlobalVariable.ConnStr = ConfigurationManager.AppSettings["context"];
                //GlobalVariable.MESServicePath = ConfigurationManager.AppSettings["SyncServicePath"];

                //LanguageHelper.GetLanguageInfo();
            }
            catch (Exception e)
            {
                throw new Exception("Program.InitialSystemInfo>>" + e.Message);
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUserId.Focus();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnLogin_Click(null, null);
            }
        }

        private void txtUserId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtPassword.Focus();
                txtPassword.SelectAll();
            }
        }

      
    }
}
