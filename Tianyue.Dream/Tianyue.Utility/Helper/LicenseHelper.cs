using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Utility.Common;
using Tianyue.Utility.Extension;

namespace Tianyue.Utility.Helper
{
    public static class LicenseHelper
    {
        //private static LogRepository Logger = new LogRepository();
        /// <summary>
        /// License授权逻辑（硬件信息）
        /// </summary>
        /// <returns></returns>
        public static bool IsAuthorized(string SysName, string HosName, DateTime Now, ref DateTime exDate, ref double DaysRemaining, ref string msg)
        {
#if DEBUG
            return true;
#else
            var flag = true;

            //try
            //{
            //    var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "License.lic");
            //    if (!File.Exists(filePath))
            //    {
            //        LogRepository.Log.Info("Cannot find license file. Please contact the administrator.");
            //        msg = "未找到注册文件，请联系管理员。";
            //        return (flag = false);
            //    }
            //    exDate = DateTime.MinValue;
            //    CheckLicense.Check(filePath, out exDate);

            //    var licenseText = File.ReadAllText(filePath);
            //    var doc = new XmlDocument();
            //    doc.LoadXml(licenseText);

            //    //验证系统名称
            //    var configuration = doc.SelectSingleNode("/configuration/Configuration");
            //    if (configuration == null || string.IsNullOrEmpty(configuration.InnerText))
            //    {
            //        LogRepository.Log.Info("Cannot find Configuration. Please contact the administrator.");
            //        msg = "注册信息有误，请联系管理员。";
            //        return (flag = false);
            //    }
            //    if (configuration.InnerText != SysName)
            //    {
            //        LogRepository.Log.Info("Configuration Error. Please contact the administrator.");
            //        msg = "注册信息有误，请联系管理员。";
            //        return (flag = false);
            //    }

            //    //验证医院名称
            //    var issueUnit = doc.SelectSingleNode("/configuration/IssueUnit");
            //    if (issueUnit == null || string.IsNullOrEmpty(issueUnit.InnerText))
            //    {
            //        LogRepository.Log.Info("Cannot find IssueUnit. Please contact the administrator.");
            //        msg = "当前注册信息无效，请联系管理员。";
            //        return (flag = false);
            //    }
            //    if (issueUnit.InnerText.Trim() != HosName.Split('|')[0].Trim())
            //    {
            //        LogRepository.Log.Info("IssueUnit Error. Please contact the administrator.");
            //        msg = "当前注册信息无效，请联系管理员。";
            //        return (flag = false);
            //    }

            //    //验证有效日期
            //    if (exDate < Now)
            //    {
            //        LogRepository.Log.Info("The license has expired. Please contact the administrator.");
            //        msg = "您已超出有效期使用范围，请联系相关人员。";
            //        return (flag = false);
            //    }
            //    DaysRemaining = (exDate - Now).TotalDays;
            //}
            //catch (LicenseException ex)
            //{
            //    switch (ex.ErrorType)
            //    {
            //        case ArrowType.Expire: //已经超出有效期
            //            //LogRepository.Log.Info("The license has expired. Please contact the administrator." + Environment.NewLine + ex);
            //            msg = "您已超出有效期使用范围，请联系相关人员。";
            //            break;
            //        case ErrorType.LicenseFileInvalid: //License文件无效
            //            //LogRepository.Log.Info("Invalid license file. Please contact the administrator." + Environment.NewLine + ex);
            //            msg = "无效的License";
            //            break;
            //        case ErrorType.LicenseFileNotFound: //未找到License文件
            //            //LogRepository.Log.Info("Cannot find license file. Please contact the administrator." + Environment.NewLine + ex);
            //            msg = "未找到注册文件，请联系管理员。";
            //            break;
            //        case ErrorType.SiteCodeNotMatch:  //信息不匹配                        
            //            //LogRepository.Log.Info("The license file does not match the machine. Please contact the administrator." + Environment.NewLine + ex);
            //            msg = "当前License与您本地环境信息不匹配，请更换正确的注册文件。";
            //            break;
            //        default:
            //            msg = "检查License出错！";
            //            //LogRepository.Log.Info("Failed to parse license file. Please contact with administrator." + Environment.NewLine + ex);
            //            break;
            //    }

            //    flag = false;

            //}
            //catch (Exception ex)
            //{
            //    //LogRepository.Log.Info("Failed to parse license file. Please contact with administrator." + Environment.NewLine + ex);
            //    msg = "检查License出错！";
            //    return (flag = false);
            //}

            return flag;
#endif
        }

    }

}
