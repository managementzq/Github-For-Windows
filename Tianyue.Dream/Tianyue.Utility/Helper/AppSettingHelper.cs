using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tianyue.Utility.Helper
{

    public class ConfigHelper
    {
        public static bool ContainsAppSettings(string key)
        {
            try
            {
                return ConfigHelper.GetAppConfig(key).Length > 0;
            }
            catch
            {
                return false;
            }
        }

        public static string GetAppConfig(string strKey)
        {
            if (string.IsNullOrEmpty(strKey))
                return string.Empty;

            string strAppSetting = ConfigurationManager.AppSettings[strKey];
            return string.IsNullOrEmpty(strAppSetting) ? string.Empty : strAppSetting.Trim();
        }

        /// <summary>
        /// 是否启用自动回收物理内存
        /// </summary>
        public static bool UseAutoFlushMemory
        {
            get
            {
                var mem = GetAppConfig("UseAutoFlushMemory");
                if (string.IsNullOrEmpty(mem))
                {
                    return false;
                }
                else
                {
                    return mem.Equals(bool.TrueString);
                }
            }
        }

        /// <summary>
        /// 是否直连数据库
        /// </summary>
        public static bool UseADODirect
        {
            get
            {
                var ado = GetAppConfig("UseADODirect");
                if (string.IsNullOrEmpty(ado))
                {
                    return false;
                }
                else
                {
                    return ado.Equals(bool.TrueString);
                }
            }
        }

        /// <summary>
        /// 床卡是否启用扩展提示块
        /// </summary>
        public static bool BedCardSupperTooltip
        {
            get
            {
                return GetAppConfig("BedCardSupperTooltip").Equals(bool.TrueString);
            }
        }

        private static int _rtimeRedColor = 0;
        private static int _rtimeYellowColor = 0;
        private static int _rtimeTriage = 0;
        private static int _redColor = 0;
        private static int _orangeColor = 0;
        private static int _yellowColor = 0;
        private static int _greenColor = 0;

        /// <summary>
        /// 滞留时间红色时间(默认2) ，单位：小时
        /// </summary>
        public static int RTimeRedColor
        {
            get
            {
                if (_rtimeRedColor == 0)
                {
                    if (!int.TryParse(GetAppConfig("RTimeRedColor"), out _rtimeRedColor))
                    {
                        _rtimeRedColor = 2;
                    }
                }
                return _rtimeRedColor;
            }
        }

        /// <summary>
        /// 滞留时间黄色时间（默认12），单位：小时
        /// </summary>
        public static int RTimeYellowColor
        {
            get
            {
                if (_rtimeYellowColor == 0)
                {
                    if (!int.TryParse(GetAppConfig("RTimeYellowColor"), out _rtimeYellowColor))
                    {
                        _rtimeYellowColor = 12;
                    }
                }
                return _rtimeYellowColor;
            }
        }

        /// <summary>
        /// 分诊滞留时间时间（默认10），单位：分钟
        /// </summary>
        public static int RTimeTriage
        {
            get
            {
                if (_rtimeTriage == 0)
                {
                    if (!int.TryParse(GetAppConfig("RTimeTriage"), out _rtimeTriage))
                    {
                        _rtimeTriage = 10;
                    }
                }
                return _rtimeTriage;
            }
        }
        
        public static string WristbandPrinterName
        {
            get
            {
                return GetAppConfig("WristbandPrinterName");
            }
        }

        public static string InHospitalApplicationPrinterName
        {
            get
            {
                return GetAppConfig("InHospitalApplicationPrinterName");
            }
        }

        public static string BloodApplyPrinterName
        {
            get
            {
                return GetAppConfig("BloodApplyPrinterName");
            }
        }

        public static string SeatCardPrinterName
        {
            get
            {
                return GetAppConfig("SeatCardPrinterName");
            }
        }

        /// <summary>
        /// 电子病历水印 1:启用 0:不用
        /// </summary>
        public static bool IsShowEmrBGImage
        {
            get
            {
                return GetAppConfig("IsShowEmrBGImage") == "1";
            }
        }

        /// <summary>
        /// 从配置文件中获取 时间轴 配置  1启用  0不启用
        /// </summary>
        public static bool IsShowUcTimeLine
        {
            get
            {
                return GetAppConfig("IsShowUcTimeLine") == "1";
            }
        }
    }
}
