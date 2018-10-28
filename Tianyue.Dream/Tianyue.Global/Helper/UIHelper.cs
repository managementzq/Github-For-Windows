using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Tianyue.Domain.Enum;

namespace Tianyue.GlobalInstallation.Helper
{


    /// <summary>
    /// UI相关方法
    /// </summary>
    public partial class UIHelper
    {
        /// <summary>
        ///     类名，用于记录异常时出错位置
        /// </summary>
        private static readonly string strClass = "MES.Framework.Utility.UIHelper";
        
        /// <summary>
        /// 绑定下拉框内容
        /// </summary>
        /// <param name="ddl">下拉框对象</param>
        /// <param name="cmbxType">内容类型</param>
        /// <param name="empty">是否在第一行包含空记录</param>
        /// <param name="obj">联动来源</param>
        public static void BindDDL(ComboBox ddl, ComboBoxType cmbxType, bool empty, object obj)
        {
            try
            {
                string strMsg = "";
                switch (cmbxType)
                {
                    // 采购单
                    case ComboBoxType.ModuleCatalog:

                    //    GlobalFacade.ConfigurationFacade.GetModuleFunctionList(moduleFunction).ToList();
                    //    IList<Po_V> lstPO = bllPO.GetActiveList();
                    //    if (empty)
                    //    {
                    //        Po_V poFirst = new Po_V();
                    //        poFirst.PoNo = "请选择";
                    //        lstPO.Insert(0, poFirst);
                    //    }
                    //    BindDDL<Po_V>(lstPO, ddl, "GUID", "PoNo");
                    //    break;
                    //case ComboBoxType.PageFunction:
                    //    CheckStockBLL bllCheckStock = new CheckStockBLL();
                    //    CheckStock_V entityCheckStock = new CheckStock_V();
                    //    if (obj != null && obj is CheckStock_V)
                    //    {
                    //        entityCheckStock = ((CheckStock_V)obj);
                    //    }
                    //    IList<CheckStock_V> lstCheckStock = bllCheckStock.GetCheckStock(entityCheckStock, true);
                    //    if (empty)
                    //    {
                    //        CheckStock_V functionFirst = new CheckStock_V();
                    //        functionFirst.CheckStockNo = "请选择";
                    //        lstCheckStock.Insert(0, functionFirst);
                    //    }
                    //    BindDDL<CheckStock_V>(lstCheckStock, ddl, "GUID", "CheckStockNo");
                    //    break;

                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(strClass + ".BindDDL>>" + ex.Message);
            }
        }



    }
}
