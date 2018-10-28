using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Facade.Contract;
using Tianyue.Service;

namespace Tianyue.Facade
{
    /// <summary>
    /// 系统服务
    /// </summary>
    public class GlobalFacade
    {
        private static SystemFacade _systemFacade;

        /// <summary>
        /// 公共服务
        /// </summary>
        public static SystemFacade SystemFacade
        {
            get
            {
                if (_systemFacade == null)
                    _systemFacade = new SystemFacade();
                return _systemFacade;
            }
        }


        private static ConfigurationFacade _configurationFacade;

        /// <summary>
        /// 基础配置服务
        /// </summary>
        public static ConfigurationFacade ConfigurationFacade
        {
            get
            {
                if (_configurationFacade == null)
                    _configurationFacade = new ConfigurationFacade();
                return _configurationFacade;
            }
        }

    }
}
