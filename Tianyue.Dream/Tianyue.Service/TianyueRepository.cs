using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Service.Configuration;

namespace Tianyue.Service
{
    public class TianyueRepository
    {

        private static SystemService systemServie;

        /// <summary>
        /// 系统服务
        /// </summary>
        public static SystemService SystemService
        {
            get
            {
                if (systemServie == null)
                    systemServie = new SystemService();

                return systemServie;
            }
        }
        
        private static PermissionService permissionService;
        /// <summary>
        /// 权限管理服务
        /// </summary>
        public static PermissionService PermissionService
        {
            get
            {
                if (permissionService == null)
                    permissionService = new PermissionService();

                return permissionService;
            }
        }
    }
}
