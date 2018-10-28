using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Domain.Configuration;

namespace Tianyue.Business.Contract.Configuration
{
    [ServiceContract]
    public interface ISystemBusiness
    {
        /// <summary>
        /// 获取服务器当前时间
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        DateTime GetServiceDate();
        
    }
}
