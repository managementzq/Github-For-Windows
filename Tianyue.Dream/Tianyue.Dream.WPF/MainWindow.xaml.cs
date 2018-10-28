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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tianyue.Domain;
using Tianyue.Domain.Configuration;

namespace Tianyue.Dream.WPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region 加载目录

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            User user = GlobalVariable.UserEntity;
            var lstUserRole = user.lstUserRole.ToList();
            List<FunctionCatalog> lstAllFunctionCatalog = new List<FunctionCatalog>();
            List<FunctionCatalog> lstNavigationCatalog = new List<FunctionCatalog>();
            foreach (var userRole in lstUserRole)
            {
                var lstRoleFunction = userRole.role.lstRoleFunction.ToList();

                foreach (var roleFunction in lstRoleFunction)
                {
                    //导航栏目录
                    if (roleFunction.function.PFCID == null && (!lstNavigationCatalog.Exists(nc => nc.FCID == roleFunction.function.FCID)))
                    {
                        lstNavigationCatalog.Add(roleFunction.function);
                    }

                    if (!lstAllFunctionCatalog.Exists(nc => nc.FCID == roleFunction.function.FCID))
                    {
                        lstAllFunctionCatalog.Add(roleFunction.function);
                    }
                }
            }

            List<TabItem> lstAllTabItem = new List<TabItem>();
            lstAllTabItem = LoadModuleCatalog(lstNavigationCatalog, lstAllFunctionCatalog);
            foreach(TabItem tabItem in lstAllTabItem)
            {
                this.tcModuleCatalog.Items.Refresh();
                tcModuleCatalog.Items.Add(tabItem);
            }
        }

        ///// <summary>
        ///// 获取用户权限
        ///// </summary>
        //private void GetUserPermission()
        //{
        //    User user = GlobalVariable.UserEntity;
        //    var lstUserRole = user.lstUserRole.ToList();
        //    List<ModuleFunction> lstModuleFunction = new List<ModuleFunction>();
        //    List<ModuleCatalog> lstModuleCatalog = new List<ModuleCatalog>();
        //    foreach (var ur in lstUserRole)
        //    {
        //        var lstRoleFunction = ur.role.lstRoleFunction.ToList();

        //        foreach (var rf in lstRoleFunction)
        //        {
        //            lstModuleFunction.Add(rf.function);
        //            if (lstModuleCatalog.Exists(mc => mc.MCID == rf.function.module.MCID))
        //            {
        //                lstModuleCatalog.Add(rf.function.module);
        //            }
        //        }
        //    }

        //    // PS：参数x对应最外层的testList
        //    // 参数i对应最外层testList内元素的位置索引（第几个元素）
        //    // 参数z对应内层的testList
        //    // lstModuleFunction.Where((x, i) => lstModuleFunction.FindIndex(z => z.MCID == x.MCID) == i);

        //}

        private List<TabItem> LoadModuleCatalog(List<FunctionCatalog> lstNavigationCatalog, List<FunctionCatalog> lstAllFunctionCatalog)
        {
            List<TabItem> lstTabItem = new List<TabItem>();
            try
            {
                foreach (FunctionCatalog navigationCatalog in lstNavigationCatalog)
                {
                    List<FunctionCatalog> lstFunctionCatalog = new List<FunctionCatalog>();
                    lstFunctionCatalog = lstAllFunctionCatalog.FindAll(f => f.PFCID == navigationCatalog.FCID);

                    TabItem tabItem = new TabItem();
                    //tabItem.Name = ti
                    tabItem.Header = navigationCatalog.FunctionName;
                    tabItem.Height = 120;
                    tabItem.Width = 120;
                    tabItem.Margin = new Thickness(0, 0, 0, 0);
                    tabItem.FontWeight = FontWeights.Bold;
                    //获取App.xaml中的样式
                    tabItem.Style = (Style)this.FindResource("NavigationTabItemStyle");
                    //图标
                    TextBlock tbIcon = new TextBlock();
                    tbIcon.Text = StringToIcon(navigationCatalog.CatalogIcon);
                    //tbIcon.Text = "\uf085";
                    //tbIcon.FontSize = 36;
                    //tbIcon.Foreground = Brushes.Red;
                    tbIcon.Style = (Style)this.FindResource("VectorIcon");

                    //画刷将图标画出来
                    VisualBrush vbIcon = new VisualBrush();
                    vbIcon.Visual = tbIcon;
                    tabItem.Background = vbIcon;
                    
                    tabItem.Content = LoadCatalogDetailCatalog(lstFunctionCatalog);

                    lstTabItem.Add(tabItem);
                }

                return lstTabItem;
            }
            catch(Exception excp)
            {
                return lstTabItem;
            }



        }

        private string StringToIcon(string strIconCode)
        {
            string strIconString = "";//转换后
            string[] strArray = strIconCode.Split(new string[] { "\\u" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in strArray)
            {
                strIconString += (char)Convert.ToInt32(str.Substring(0, 4), 16) + str.Substring(4);
            }
            return strIconString;
        }
        
        private StackPanel LoadCatalogDetailCatalog(List<FunctionCatalog> lstFunctionCatalog)
        {
            StackPanel spCatalogDetailCatalog = new StackPanel();

            foreach (FunctionCatalog catalogFunction in lstFunctionCatalog)
            {
                Label lblDetailCatalog = new Label();
                lblDetailCatalog.Name = "lbl" + catalogFunction.FunctionCode;
                lblDetailCatalog.Content = catalogFunction.FunctionName;
                lblDetailCatalog.Foreground = Brushes.Red;
                lblDetailCatalog.Margin = new Thickness(0, 6, 0, 6);
                lblDetailCatalog.Tag = catalogFunction.formPage.FormPageRoute;
                lblDetailCatalog.MouseLeftButtonDown += new MouseButtonEventHandler(Label_MouseDown);
                spCatalogDetailCatalog.Children.Add(lblDetailCatalog);
            }

            return spCatalogDetailCatalog;
        }

        

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Label lblClickedCatalog = e.Source as Label;
                string strPageUrl = lblClickedCatalog.Tag.ToString() ;
                
                this.frmPageMain.Source = new Uri(strPageUrl, UriKind.RelativeOrAbsolute);
            }
            catch (Exception excp)
            {

            }

        }

        #endregion


        #region 控件事件

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        #endregion

        private bool __isLeftHide = false;
        private void spliter_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Left Bar hide and show
            __isLeftHide = !__isLeftHide;
            if (__isLeftHide)
            {
                this.gridForm.ColumnDefinitions[0].Width = new GridLength(1d);
            }
            else
            {
                this.gridForm.ColumnDefinitions[0].Width = new GridLength(200d);
            }
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
