using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Business.Contract.Configuration;
using Tianyue.Domain.Configuration;
using Tianyue.Repository.Contract.Configuration;
using Tianyue.ServiceLocator;

namespace Tianyue.Business.Configuration
{
    public class SystemBusiness : ISystemBusiness
    {

        private ISystemRepository systemRepository;

        public SystemBusiness()
        {
            systemRepository = TianyueServiceLocator.Current.GetInstance<ISystemRepository>("meeBed");
        }

        /// <summary>
        /// 获取服务器当前时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetServiceDate()
        {
            //return exCommonRep.GetServiceDate();
            return systemRepository.GetServiceDate();
        }


    }
}
