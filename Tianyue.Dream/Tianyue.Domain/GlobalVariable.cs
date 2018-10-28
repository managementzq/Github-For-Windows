using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Domain.Configuration;

namespace Tianyue.Domain
{
    [Serializable]
    public class GlobalVariable
    {
        /// <summary>
        /// 当前登录责任用户信息. 
        /// </summary>
        public static User UserEntity { get; set; }
        
        ///// <summary>
        ///// 用户当前登录区域
        ///// </summary>
        //public static string LoginArea { get; set; }

        ///// <summary>
        ///// 当前用户登录科室
        ///// </summary>
        //public static string LoginDept { get; set; }

        ///// <summary>
        ///// 是否为抢救(留观)模式
        ///// </summary>
        //public static bool IsEmgModel { get; set; }

        //#region 患者

        ///// <summary>
        ///// 当前患者
        ///// </summary>
        //public static Guid SeletedPvid { get; set; }

        ///// <summary>
        ///// 当前患者PatientID 
        ///// </summary>
        //public static string SeletedPatientID { get; set; }

        ///// <summary>
        ///// 当前患者所在病区
        ///// </summary>
        //public static string SeletedPatWardArea { get; set; }


        //#endregion

        //public static bool PatReadonly { get; set; }

        ///// <summary>
        ///// 当前输液患者
        ///// </summary>
        //public static Guid SeletedIfid { get; set; }

        ///// <summary>
        ///// 当前用户所有权限列表
        ///// </summary>
        //public static List<string> CurrentUserPermissions { get; set; }
        
        ///// <summary>
        ///// 长期医嘱是否可用
        ///// </summary>
        //public static bool IsShowLongOrder { get; set; }

        ///// <summary>
        ///// 管培生登录
        ///// </summary>
        //public static bool IsTraineeLogon { get; set; }

        //public static List<string> Roles { get; set; }
        ///// <summary>
        ///// 与角色对应的OpenPage
        ///// </summary>
        //public static List<string> OpenPages { get; set; }
        ///// <summary>
        ///// 病历是否关闭病历刷新功能
        ///// </summary>
        //public static bool CloseSwitchPatient { get; set; }
        /////病历是否更改
        //public static bool EmrIsModified { get; set; }

    }
}
