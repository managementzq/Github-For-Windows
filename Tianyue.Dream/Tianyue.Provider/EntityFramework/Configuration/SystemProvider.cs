using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Domain.Configuration;
using Tianyue.Provider.EntityFramework.BaseClass;

namespace Tianyue.Provider.EntityFramework.Configuration
{

    public class SystemProvider : TianyueProvider<Tianyue.Domain.Configuration.User>
    {
        /// <summary>
        ///     类名，用于记录异常时出错位置
        /// </summary>
        private const string strClass = "MES.Framework.DAL.CompanyDAL";
        
        protected TianyueDbContext context;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context"></param>
        public SystemProvider(TianyueDbContext context) : base(context)
        {
            this.context = context;
        }

        /// <summary>
        /// 根据指定班别对象的值,找到匹配的记录
        /// </summary>
        /// <param name="entity">公司对象</param>
        public List<UserView> GetUserList(UserView entity)
        {
            try
            {
                Expression<Func<UserView, bool>> expression = PredicateBuilder.True<UserView>();
                if (!string.IsNullOrWhiteSpace(entity.UserUniqueId))
                {
                    expression = expression.And(t => t.UserUniqueId == entity.UserUniqueId);
                }
                if (!entity.UID.Equals(Guid.Empty))
                {
                    expression = expression.And(t => t.UID == entity.UID);
                }

                List<UserView> result = QueryMatchingList<UserView>(expression).ToList();

                return result.OrderBy(t => t.UserUniqueId).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".GetUserList>>" + e.Message);
            }
        }
        
    }
}
