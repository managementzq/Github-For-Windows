using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tianyue.Global
{

    //全局数据缓存
    /// <summary>
    /// 全局数据缓存
    /// </summary>
    public class GloablData
    {
        private GloablData()
        {
            //_clientConfigPath = Application.StartupPath + "\\client.config";
        }

        public static void Reset()
        {
            if (_instance == null)
                return;
            //_instance.Workshop = string.Empty;
            _instance.UserId = string.Empty;
            _instance.IsAdmin = false;
            _instance.IsSuperAdmin = false;
            //_instance.CurrentTeam = null;
            _instance.ExpirationTime = DateTime.MinValue;
            //_instance.UserClientConfig = null;
            //_instance.UserLogin = null;
            //_instance.SystemLanguage = null;
            //_instance.CommonLanguage = null;
        }

        private static GloablData _instance;
        public static GloablData Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GloablData();

                return _instance;
            }
        }



        //Ip地址
        /// <summary>
        /// Ip地址
        /// </summary>
        public string IpAddress
        {
            get
            {
                var ips = Dns.GetHostAddresses(HostName);
                foreach (var ip in ips)
                {
                    if (ip.IsIPv6LinkLocal)
                        continue;

                    return ip.ToString();
                }
                return "";
            }
        }

        //主机名称
        /// <summary>
        /// 主机名称
        /// </summary>
        public string HostName
        {
            get
            {
                return Dns.GetHostName();
            }
        }


        //private readonly DateTime _today = DateTime.MinValue;
        ////数据库服务器上的当天日期
        ///// <summary>
        ///// 数据库服务器上的当天日期
        ///// </summary>
        //public DateTime Today
        //{
        //    get
        //    {
        //        return _today == DateTime.MinValue ? DT.DateTime().DateTime : _today;
        //    }
        //}
        //private Dictionary<string, DatabaseSetting> _dictDatabaseSettings;
        //public Dictionary<string, DatabaseSetting> DictDatabaseSettings
        //{
        //    get
        //    {
        //        if (_dictDatabaseSettings == null)
        //            _dictDatabaseSettings = new Dictionary<string, DatabaseSetting>();
        //        var getDatabaseSettingsResult = ClientUpdateService.GetDatabaseSettings();
        //        if (getDatabaseSettingsResult.Result)
        //        {
        //            if (getDatabaseSettingsResult.DatabaseSettings != null && getDatabaseSettingsResult.DatabaseSettings.Count() > 0)
        //            {
        //                foreach (var databaseSetting in getDatabaseSettingsResult.DatabaseSettings)
        //                    _dictDatabaseSettings[databaseSetting.Key] = databaseSetting;
        //            }
        //        }
        //        return _dictDatabaseSettings;
        //    }
        //}

        //“配置数据库”连接字符串
        /// <summary>
        /// “配置数据库”连接字符串
        /// </summary>
        private string _configDbConn = string.Empty;
        //“配置数据库”连接字符串
        /// <summary>
        /// “配置数据库”连接字符串
        /// </summary>
        //public string ConfigDbConn
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(_configDbConn))
        //        {
        //            if (DictDatabaseSettings == null || DictDatabaseSettings.Count <= 0)
        //                return _configDbConn;

        //            if (DictDatabaseSettings.ContainsKey(AppSetting.ClientDbKey))
        //            {
        //                _configDbConn = DictDatabaseSettings[AppSetting.ClientDbKey].Value;
        //                SystemConfigBll.UpdateConnectionString(_configDbConn);
        //            }
        //        }
        //        return _configDbConn;
        //    }
        //    set
        //    {
        //        _configDbConn = value;
        //        SystemConfigBll.UpdateConnectionString(_configDbConn);
        //    }
        //}


        //private SysMapping _teamCodeTimeSetting;
        //public DateTime DateTimeFrom
        //{
        //    get
        //    {
        //        if (_teamCodeTimeSetting == null)
        //            _teamCodeTimeSetting = SysMappingBll.QueryTeamCodeTimeSetting();
        //        var dtTemp = DateTime.Parse(_teamCodeTimeSetting.Map01);
        //        var dtDb = DT.DateTime().DateTime;
        //        return new DateTime(dtDb.Year, dtDb.Month, dtDb.Day, dtTemp.Hour, dtTemp.Minute, dtTemp.Second);
        //    }
        //}
        //public DateTime DateTimeTo
        //{
        //    get
        //    {
        //        if (_teamCodeTimeSetting == null)
        //            _teamCodeTimeSetting = SysMappingBll.QueryTeamCodeTimeSetting();
        //        var dtTemp = DateTime.Parse(_teamCodeTimeSetting.Map02);
        //        var dtDb = DT.DateTime().DateTime;
        //        return new DateTime(dtDb.Year, dtDb.Month, dtDb.Day, dtTemp.Hour, dtTemp.Minute, dtTemp.Second);
        //    }
        //}

        ////车间
        ///// <summary>
        ///// 车间
        ///// </summary>
        //public string Workshop { get; set; }

        //private readonly string _clientConfigPath = string.Empty;
        //public ClientConfig ClientConfig
        //{
        //    get
        //    {
        //        if (!File.Exists(_clientConfigPath))
        //        {
        //            XmlHelper.XmlSerializeToFile(new ClientConfig(), _clientConfigPath, Encoding.UTF8);
        //        }
        //        return XmlHelper.XmlDeserializeFromFile<ClientConfig>(_clientConfigPath, Encoding.UTF8);
        //    }
        //    set
        //    {
        //        XmlHelper.XmlSerializeToFile(value, _clientConfigPath, Encoding.UTF8);
        //    }
        //}

        //当前工号
        /// <summary>
        /// 当前工号
        /// </summary>
        public string UserId { get; set; }

        //当前用户是否是管理员
        /// <summary>
        /// 当前用户是否是管理员
        /// </summary>
        public bool IsAdmin { get; set; }

        // 当前用户是否是超级管理员
        /// <summary>
        /// 当前用户是否是超级管理员
        /// </summary>
        public bool IsSuperAdmin { get; set; }

        //private DutyTeamCode _currentTeam;
        ////当前班别
        ///// <summary>
        ///// 当前班别
        ///// </summary>
        //public DutyTeamCode CurrentTeam
        //{
        //    get
        //    {
        //        if (_currentTeam == null)
        //            _currentTeam = DutyTeamCodeBll.QueryCurrentDutyTeamCode(Workshop, DateTimeFrom, DateTimeTo);
        //        if (_currentTeam != null)
        //        {
        //            if (!ClientUpdateService.EqualsCurrentTeamCode(_currentTeam.TeamCode, Workshop).Result)
        //            {
        //                if (SetStatusBarTeamCode != null)
        //                    SetStatusBarTeamCode("");
        //                _currentTeam = DutyTeamCodeBll.QueryCurrentDutyTeamCode(Workshop, DateTimeFrom, DateTimeTo);
        //                if (_currentTeam != null)
        //                    if (SetStatusBarTeamCode != null)
        //                        SetStatusBarTeamCode(_currentTeam.TeamCode);
        //            }
        //        }
        //        return _currentTeam;
        //    }
        //    set
        //    {
        //        _currentTeam = value;
        //    }
        //}

        //失效日期
        /// <summary>
        /// 失效日期
        /// </summary>
        public DateTime ExpirationTime { get; set; }

        //public Action<string> SetStatusBarTeamCode { get; set; }

        ////客户端配置
        ///// <summary>
        ///// 客户端配置
        ///// </summary>
        //public UserClientConfig UserClientConfig { get; set; }

        ////登录信息
        ///// <summary>
        ///// 登录信息
        ///// </summary>
        //public UserLogin UserLogin { get; set; }

        ////是否已退出
        ///// <summary>
        ///// 是否已退出
        ///// </summary>
        //public bool IsExisted
        //{
        //    get
        //    {
        //        return UserLogin == null;
        //    }
        //}


        ////系统语言
        ///// <summary>
        ///// 系统语言
        ///// </summary>
        //public DictionaryItem SystemLanguage { get; set; }

        ////通用语言包
        ///// <summary>
        ///// 通用语言包
        ///// </summary>
        //public Language CommonLanguage { get; set; }

        //private SetupServiceSoapClient _clientUpdateService;
        //public SetupServiceSoapClient ClientUpdateService
        //{
        //    get
        //    {
        //        if (_clientUpdateService == null)
        //            _clientUpdateService = new SetupServiceSoapClient();

        //        return _clientUpdateService;
        //    }
        //}

        //public Dictionary<string, SystemFuncConfig> DictFormType { get; set; }
    }
}
