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

    public class RoleProvider : TianyueProvider<Tianyue.Domain.Configuration.Role>
    {
        /// <summary>
        ///     类名，用于角色异常时出错位置
        /// </summary>
        private const string strClass = "MES.Framework.DAL.CompanyDAL";
        
        protected TianyueDbContext context;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context"></param>
        public RoleProvider(TianyueDbContext context) : base(context)
        {
            this.context = context;
        }

        /// <summary>
        /// 根据指定班别对象的值,找到匹配的角色
        /// </summary>
        /// <param name="entity">公司对象</param>
        public List<RoleView> GetRoleList(Role entity)
        {
            try
            {
                Expression<Func<RoleView, bool>> expression = PredicateBuilder.True<RoleView>();
                //if (!string.IsNullOrWhiteSpace(entity.RoleUniqueId))
                //{
                //    expression = expression.And(t => t.RoleUniqueId == entity.RoleUniqueId);
                //}
                if (!entity.RID.Equals(Guid.Empty))
                {
                    expression = expression.And(t => t.RID == entity.RID);
                }

                if (!string.IsNullOrWhiteSpace(entity.RoleCode))
                {
                    expression = expression.And(t => t.RoleCode.Contains(entity.RoleCode));
                }
                if (!string.IsNullOrWhiteSpace(entity.RoleName))
                {
                    expression = expression.And(t => t.RoleName.Contains(entity.RoleName));
                }

                //if (!string.IsNullOrWhiteSpace(entity.RoleType))
                //{
                //    expression = expression.And(t => t.RoleType == entity.RoleType);
                //}


                List<RoleView> result = QueryMatchingList<RoleView>(expression).ToList();

                return result.OrderBy(t => t.Sequence).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".GetRoleList>>" + e.Message);
            }
        }

        /// <summary>
        /// 根据指定班别对象的值,找到匹配的角色
        /// </summary>
        /// <param name="entity">公司对象</param>
        public List<RoleView> FuzzyQueryRoleList(Role entity)
        {
            try
            {
                Expression<Func<RoleView, bool>> expression = PredicateBuilder.True<RoleView>();
                //if (!string.IsNullOrWhiteSpace(entity.RoleUniqueId))
                //{
                //    expression = expression.And(t => t.RoleUniqueId == entity.RoleUniqueId);
                //}
                if (!entity.RID.Equals(Guid.Empty))
                {
                    expression = expression.Or(t => t.RID == entity.RID);
                }

                if (!string.IsNullOrWhiteSpace(entity.RoleCode))
                {
                    expression = expression.Or(t => t.RoleCode.Contains(entity.RoleCode));
                }
                if (!string.IsNullOrWhiteSpace(entity.RoleName))
                {
                    expression = expression.Or(t => t.RoleName.Contains(entity.RoleName));
                }

                //if (!string.IsNullOrWhiteSpace(entity.RoleType))
                //{
                //    expression = expression.And(t => t.RoleType == entity.RoleType);
                //}


                List<RoleView> result = QueryMatchingList<RoleView>(expression).ToList();

                return result.OrderBy(t => t.Sequence).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".GetRoleList>>" + e.Message);
            }
        }

        /// <summary>
        /// 根据指定班别对象的值,找到匹配的角色
        /// </summary>
        /// <param name="entity">公司对象</param>
        public RoleView GetSingleRoleView(Role entity)
        {
            try
            {
                Expression<Func<RoleView, bool>> expression = PredicateBuilder.True<RoleView>();
                //if (!string.IsNullOrWhiteSpace(entity.RoleUniqueId))
                //{
                //    expression = expression.And(t => t.RoleUniqueId == entity.RoleUniqueId);
                //}
                if (!entity.RID.Equals(Guid.Empty))
                {
                    expression = expression.And(t => t.RID == entity.RID);
                }
                if (!string.IsNullOrWhiteSpace(entity.RoleName))
                {
                    expression = expression.And(t => t.RoleName == entity.RoleName);
                }
                if (!string.IsNullOrWhiteSpace(entity.RoleCode))
                {
                    expression = expression.And(t => t.RoleCode == entity.RoleCode);
                }
                //if (!string.IsNullOrWhiteSpace(entity.RoleType))
                //{
                //    expression = expression.And(t => t.RoleType == entity.RoleType);
                //}


                IList<RoleView> result = QueryMatchingList<RoleView>(expression);

                return result.OrderBy(t => t.Sequence).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".GetSingleRole>>" + e.Message);
            }
        }

        /// <summary>
        /// 根据指定班别对象的值,找到匹配的角色
        /// </summary>
        /// <param name="entity">公司对象</param>
        public Role GetSingleRole(Role entity)
        {
            try
            {
                Expression<Func<Role, bool>> expression = PredicateBuilder.True<Role>();
                //if (!string.IsNullOrWhiteSpace(entity.RoleUniqueId))
                //{
                //    expression = expression.And(t => t.RoleUniqueId == entity.RoleUniqueId);
                //}
                if (!entity.RID.Equals(Guid.Empty))
                {
                    expression = expression.And(t => t.RID == entity.RID);
                }
                if (!string.IsNullOrWhiteSpace(entity.RoleCode))
                {
                    expression = expression.And(t => t.RoleCode.Contains(entity.RoleCode));
                }
                if (!string.IsNullOrWhiteSpace(entity.RoleName))
                {
                    expression = expression.And(t => t.RoleName.Contains(entity.RoleName));
                }
                //if (!string.IsNullOrWhiteSpace(entity.RoleName))
                //{
                //    expression = expression.And(t => t.RoleName == entity.RoleName);
                //}
                //if (!string.IsNullOrWhiteSpace(entity.RoleCode))
                //{
                //    expression = expression.And(t => t.RoleCode == entity.RoleCode);
                //}
                //if (!string.IsNullOrWhiteSpace(entity.RoleType))
                //{
                //    expression = expression.And(t => t.RoleType == entity.RoleType);
                //}
                
                IList<Role> result = QueryMatchingList<Role>(expression);

                return result.OrderBy(t => t.Sequence).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".GetSingleRole>>" + e.Message);
            }
        }
        
        /// <summary>
        /// 获取所有生效的角色
        /// </summary>
        public List<RoleView> GetAllRole()
        {
            try
            {
                Expression<Func<RoleView, bool>> expression = PredicateBuilder.True<RoleView>();
                expression = expression.And(t => t.Disable == false);
                IList<RoleView> result = QueryMatchingList<RoleView>(expression);

                return result.OrderBy(t => t.Sequence).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".GetAllRole>>" + e.Message);
            }
        }
        
        /// <summary>
        /// 新增角色
        /// </summary>
        public bool InsertSingleRole(Role entity)
        {
            try
            {
                return InsertSingle(entity);
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".InsertSingleRole>>" + e.Message);
            }
        }

        /// <summary>
        /// 更新角色
        /// </summary>
        public bool UpdateSingleRole(Role entity)
        {
            try
            {
                return UpdateSingle(entity, entity.RID);
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".UpdateSingleRole>>" + e.Message);
            }
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        public bool DeleteSingleRole(Role entity)
        {
            try
            {
                return DeleteSingle(entity);
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".DeleteSingleRole>>" + e.Message);
            }
        }
    }
}
