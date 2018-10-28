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

    public class UserProvider : TianyueProvider<Tianyue.Domain.Configuration.User>
    {
        /// <summary>
        ///     类名，用于用户异常时出错位置
        /// </summary>
        private const string strClass = "MES.Framework.DAL.CompanyDAL";
        
        protected TianyueDbContext context;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context"></param>
        public UserProvider(TianyueDbContext context) : base(context)
        {
            this.context = context;
        }

        /// <summary>
        /// 根据指定班别对象的值,找到匹配的用户
        /// </summary>
        /// <param name="entity">公司对象</param>
        public List<UserView> GetUserList(User entity)
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
                if (!string.IsNullOrWhiteSpace(entity.Nickname))
                {
                    expression = expression.And(t => t.Nickname.Contains(entity.Nickname));
                }
                if (!string.IsNullOrWhiteSpace(entity.UserName))
                {
                    expression = expression.And(t => t.UserName.Contains(entity.UserName));
                }
                if (!string.IsNullOrWhiteSpace(entity.UserUniqueId))
                {
                    expression = expression.And(t => t.UserUniqueId.Contains(entity.UserUniqueId));
                }
                //if (!string.IsNullOrWhiteSpace(entity.UserType))
                //{
                //    expression = expression.And(t => t.UserType.Contains(entity.UserType));
                //}
                //if (!string.IsNullOrWhiteSpace(entity.Nickname))
                //{
                //    expression = expression.And(t => t.Nickname == entity.Nickname);
                //}
                //if (!string.IsNullOrWhiteSpace(entity.UserName))
                //{
                //    expression = expression.And(t => t.UserName == entity.UserName);
                //}
                //if (!string.IsNullOrWhiteSpace(entity.Password))
                //{
                //    expression = expression.And(t => t.Password == entity.Password);
                //}
                if (!string.IsNullOrWhiteSpace(entity.UserType))
                {
                    expression = expression.And(t => t.UserType == entity.UserType);
                }


                List<UserView> result = QueryMatchingList<UserView>(expression).ToList();

                return result.OrderBy(t => t.UserUniqueId).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".GetUserList>>" + e.Message);
            }
        }
        
        /// <summary>
        /// 根据指定班别对象的值,找到匹配的用户
        /// </summary>
        /// <param name="entity">公司对象</param>
        public UserView GetSingleUserView(User entity)
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
                if (!string.IsNullOrWhiteSpace(entity.Nickname))
                {
                    expression = expression.And(t => t.Nickname.Contains(entity.Nickname));
                }
                if (!string.IsNullOrWhiteSpace(entity.UserName))
                {
                    expression = expression.And(t => t.UserName.Contains(entity.UserName));
                }
                if (!string.IsNullOrWhiteSpace(entity.UserUniqueId))
                {
                    expression = expression.And(t => t.UserUniqueId.Contains(entity.UserUniqueId));
                }
                if (!string.IsNullOrWhiteSpace(entity.UserType))
                {
                    expression = expression.And(t => t.UserType == entity.UserType);
                }


                IList<UserView> result = QueryMatchingList<UserView>(expression);

                return result.OrderBy(t => t.UserUniqueId).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".GetSingleUser>>" + e.Message);
            }
        }

        /// <summary>
        /// 根据指定班别对象的值,找到匹配的用户
        /// </summary>
        /// <param name="entity">公司对象</param>
        public User GetSingleUser(User entity)
        {
            try
            {
                Expression<Func<User, bool>> expression = PredicateBuilder.True<User>();
                if (!string.IsNullOrWhiteSpace(entity.UserUniqueId))
                {
                    expression = expression.And(t => t.UserUniqueId == entity.UserUniqueId);
                }
                if (!entity.UID.Equals(Guid.Empty))
                {
                    expression = expression.And(t => t.UID == entity.UID);
                }
                if (!string.IsNullOrWhiteSpace(entity.Nickname))
                {
                    expression = expression.And(t => t.Nickname.Contains(entity.Nickname));
                }
                if (!string.IsNullOrWhiteSpace(entity.UserName))
                {
                    expression = expression.And(t => t.UserName.Contains(entity.UserName));
                }
                if (!string.IsNullOrWhiteSpace(entity.UserUniqueId))
                {
                    expression = expression.And(t => t.UserUniqueId.Contains(entity.UserUniqueId));
                }
                if (!string.IsNullOrWhiteSpace(entity.UserType))
                {
                    expression = expression.And(t => t.UserType == entity.UserType);
                }
                
                IList<User> result = QueryMatchingList<User>(expression);

                return result.OrderBy(t => t.UserUniqueId).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".GetSingleUser>>" + e.Message);
            }
        }
        
        /// <summary>
        /// 获取所有生效的用户
        /// </summary>
        public List<UserView> GetAllUser()
        {
            try
            {
                Expression<Func<UserView, bool>> expression = PredicateBuilder.True<UserView>();
                expression = expression.And(t => t.Disable == false);
                IList<UserView> result = QueryMatchingList<UserView>(expression);

                return result.OrderBy(t => t.UserUniqueId).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".GetAllUser>>" + e.Message);
            }
        }
        
        /// <summary>
        /// 新增用户
        /// </summary>
        public bool InsertSingleUser(User entity)
        {
            try
            {
                return InsertSingle(entity);
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".InsertSingleUser>>" + e.Message);
            }
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        public bool UpdateSingleUser(User entity)
        {
            try
            {
                return UpdateSingle(entity, entity.UID);
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".UpdateSingleUser>>" + e.Message);
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        public bool DeleteSingleUser(User entity)
        {
            try
            {
                return DeleteSingle(entity);
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".DeleteSingleUser>>" + e.Message);
            }
        }

    }
}
