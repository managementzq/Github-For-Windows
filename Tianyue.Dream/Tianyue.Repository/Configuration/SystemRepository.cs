using System;
using System.Collections.Generic;
using System.Configuration;
using Tianyue.Repository.Contract.Configuration;
using Tianyue.Provider.EntityFramework.BaseClass;

namespace Tianyue.Repository.Configuration
{
    public class SystemRepository : ISystemRepository
    {
        private Provider.SqlClient.Configuration.SystemProvider sqlProvider = null;

        private Provider.SqlClient.Configuration.SystemProvider SqlProvider
        {
            get
            {
                if (sqlProvider == null)
                {
                    sqlProvider = new Provider.SqlClient.Configuration.SystemProvider(ConfigurationManager.ConnectionStrings["ECISPlatform4.1"].ConnectionString);
                }

                return sqlProvider;
            }
        }


        private Provider.EntityFramework.Configuration.SystemProvider efProvider = null;
        protected TianyueDbContext tianyueDbContext = new TianyueDbContext();

        private Provider.EntityFramework.Configuration.SystemProvider EfProvider
        {
            get
            {
                if (efProvider == null)
                {
                    efProvider = new Provider.EntityFramework.Configuration.SystemProvider(tianyueDbContext);
                }

                return efProvider;
            }
        }
        
        /// <summary>
        /// 获取服务器当前时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetServiceDate()
        {
            return SqlProvider.GetServiceDate();
        }

      
    }
}
