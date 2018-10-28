using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Tianyue.Utility.Helper
{
    /// <summary>
    /// UI相关方法
    /// </summary>
    public partial class WpfUiHelper
    {
        /// <summary>
        ///     类名，用于记录异常时出错位置
        /// </summary>
        private static readonly string strClass = "MES.Framework.Utility.UIHelper";
        
        /// <summary>
        /// 绑定下拉框内容
        /// </summary>
        /// <typeparam name="T">指定的对象</typeparam>
        /// <param name="lstEntity">对象集合，用于填充下拉框</param>
        /// <param name="ddlControl">下拉框对象</param>
        /// <param name="strValueMember">值对应的栏位</param>
        /// <param name="strDisp">显示对应的栏位</param>
        public static void BindComboBox<T>(IList<T> lstEntity, ComboBox ddlControl, string strValueMember, string strDisplayMember)
        {
            try
            {
                if (lstEntity.Count > 0)
                {
                    List<T> lstBindEntity = new List<T>();
                    lstBindEntity.Insert(0, default(T));
                    lstBindEntity.AddRange(lstEntity);
                    ddlControl.ItemsSource = null;
                    ddlControl.DisplayMemberPath = strDisplayMember;
                    ddlControl.SelectedValuePath = strValueMember;
                    ddlControl.ItemsSource = lstBindEntity;

                    ddlControl.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(strClass + ".BindComboBox>>" + ex.Message);
            }
        }
        
    }
}
