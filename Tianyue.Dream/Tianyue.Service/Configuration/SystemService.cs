using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Business.Configuration;
using Tianyue.Business.Contract.Configuration;

namespace Tianyue.Service.Configuration
{
    public class SystemService
    {
        private ISystemBusiness systemService;

        private ISystemBusiness CommService
        {
            get
            {
                if (systemService == null)
                {
                    systemService = new SystemBusiness();

                    //if (AppSettingCfg.UseADODirect)
                    //{
                    //    globalService = new GlobalBusiness();
                    //}
                    //else
                    //{
                    //ChannelFactory<IGlobalBusiness> channelFactory = new ChannelFactory<IGlobalBusiness>("BasicHttpBinding_ICommonService");
                    //globalService = channelFactory.CreateChannel();
                    //}
                }

                return systemService;
            }
        }

        /// <summary>
        /// 获取服务器当前时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetServiceDate()
        {
            //TODO: 获取服务器时间，如果需要读取HIS的，则需要有开关配置
            //return exCommonRep.GetServiceDate();
            return systemService.GetServiceDate();
        }
    }
}
