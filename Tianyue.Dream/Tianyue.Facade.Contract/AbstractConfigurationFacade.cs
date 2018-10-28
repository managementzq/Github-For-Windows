using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Domain.Configuration;

namespace Tianyue.Facade.Contract
{
    public abstract class AbstractConfigurationFacade
    {
        #region 用户

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract List<UserView> GetUserList(User entity);

        /// <summary>
        /// 查询单个用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract User GetSingleUser(User entity);

        /// <summary>
        /// 获取所有用户
        /// </summary>
        public abstract List<UserView> GetAllUser();
        
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract bool InsertSingleUser(User entity);

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract bool UpdateSingleUser(User entity);

        /// <summary>
        /// 删除用户
        /// </summary>
        public abstract bool DeleteSingleUser(User entity);
        
        #endregion
        
        #region  角色

        /// <summary>
        /// 查询角色
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract List<RoleView> GetRoleList(Role entity);

        /// <summary>
        /// 查询单个角色
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract Role GetSingleRole(Role entity);

        /// <summary>
        /// 获取所有角色
        /// </summary>
        public abstract List<RoleView> GetAllRole();

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract bool InsertSingleRole(Role entity);

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract bool UpdateSingleRole(Role entity);

        /// <summary>
        /// 删除角色
        /// </summary>
        public abstract bool DeleteSingleRole(Role entity);

        #endregion

        #region  页面

        /// <summary>
        /// 查询页面
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract List<FormPageView> GetFormPageList(FormPage entity);

        /// <summary>
        /// 查询单个页面
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract FormPage GetSingleFormPage(FormPage entity);

        /// <summary>
        /// 获取所有页面
        /// </summary>
        public abstract List<FormPageView> GetAllFormPage();

        /// <summary>
        /// 新增页面
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract bool InsertSingleFormPage(FormPage entity);

        /// <summary>
        /// 更新页面
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract bool UpdateSingleFormPage(FormPage entity);

        /// <summary>
        /// 删除页面
        /// </summary>
        public abstract bool DeleteSingleFormPage(FormPage entity);

        #endregion
        
        #region  功能目录

        /// <summary>
        /// 查询功能目录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract List<FunctionCatalogView> GetFunctionCatalogList(FunctionCatalog entity);

        /// <summary>
        /// 查询单个功能目录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract FunctionCatalog GetSingleFunctionCatalog(FunctionCatalog entity);

        /// <summary>
        /// 获取所有功能目录
        /// </summary>
        public abstract List<FunctionCatalogView> GetAllFunctionCatalog();

        /// <summary>
        /// 新增功能目录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract bool InsertSingleFunctionCatalog(FunctionCatalog entity);

        /// <summary>
        /// 更新功能目录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract bool UpdateSingleFunctionCatalog(FunctionCatalog entity);

        /// <summary>
        /// 删除功能目录
        /// </summary>
        public abstract bool DeleteSingleFunctionCatalog(FunctionCatalog entity);

        #endregion
    }
}
