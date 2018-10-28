using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Domain.Configuration;
using Tianyue.Service;
using Tianyue.Strategy.Contract.Configuration;

namespace Tianyue.Strategy.Configuration
{

    public partial class UserStrategy : AbstractUserStrategy
    {
        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override List<UserView> GetUserList(User entity)
        {
            return TianyueRepository.PermissionService.GetUserList(entity);
        }

        /// <summary>
        /// 查询单个用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override User GetSingleUser(User entity)
        {
            return TianyueRepository.PermissionService.GetSingleUser(entity);
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        public override List<UserView> GetAllUser()
        {
            return TianyueRepository.PermissionService.GetAllUser();
        }
    }
}
