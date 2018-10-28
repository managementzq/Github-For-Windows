using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Domain.Configuration;

namespace Tianyue.Repository.Contract.Configuration
{
    public interface IPermissionRepository
    {
        #region 用户
        
        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        List<UserView> GetUserList(User entity);

        /// <summary>
        /// 查询单个用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        User GetSingleUser(User entity);

        /// <summary>
        /// 获取所有用户
        /// </summary>
        List<UserView> GetAllUser();

        /// <summary>
        /// 新增单个用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool InsertSingleUser(User entity);

        /// <summary>
        /// 更新单个用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool UpdateSingleUser(User entity);

        /// <summary>
        /// 删除单个用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool DeleteSingleUser(User entity);

        #endregion
        
        #region 角色

        /// <summary>
        /// 查询单个角色
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Role GetSingleRole(Role entity);

        /// <summary>
        /// 查询角色
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        List<RoleView> GetRoleList(Role entity);

        /// <summary>
        /// 获取所有角色
        /// </summary>
        List<RoleView> GetAllRole();

        /// <summary>
        /// 新增单个角色
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool InsertSingleRole(Role entity);

        /// <summary>
        /// 更新单个角色
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool UpdateSingleRole(Role entity);

        /// <summary>
        /// 删除单个角色
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool DeleteSingleRole(Role entity);

        #endregion

        #region 页面

        /// <summary>
        /// 查询单个页面
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        FormPage GetSingleFormPage(FormPage entity);

        /// <summary>
        /// 查询页面
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        List<FormPageView> GetFormPageList(FormPage entity);

        /// <summary>
        /// 获取所有页面
        /// </summary>
        List<FormPageView> GetAllFormPage();

        /// <summary>
        /// 新增单个页面
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool InsertSingleFormPage(FormPage entity);

        /// <summary>
        /// 更新单个页面
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool UpdateSingleFormPage(FormPage entity);

        /// <summary>
        /// 删除单个页面
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool DeleteSingleFormPage(FormPage entity);

        #endregion
        
        #region 功能目录

        /// <summary>
        /// 查询单个功能目录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        FunctionCatalog GetSingleFunctionCatalog(FunctionCatalog entity);

        /// <summary>
        /// 查询功能目录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        List<FunctionCatalogView> GetFunctionCatalogList(FunctionCatalog entity);

        /// <summary>
        /// 获取所有功能目录
        /// </summary>
        List<FunctionCatalogView> GetAllFunctionCatalog();

        /// <summary>
        /// 新增单个功能目录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool InsertSingleFunctionCatalog(FunctionCatalog entity);

        /// <summary>
        /// 更新单个功能目录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool UpdateSingleFunctionCatalog(FunctionCatalog entity);

        /// <summary>
        /// 删除单个功能目录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool DeleteSingleFunctionCatalog(FunctionCatalog entity);

        #endregion
    }
}
