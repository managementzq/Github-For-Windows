using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Domain.Configuration;
using Tianyue.Facade.Contract;
using Tianyue.Service;

namespace Tianyue.Facade
{
    /// <summary>
    ///  各项配置
    /// </summary>
    public class ConfigurationFacade : AbstractConfigurationFacade
    {
        #region  用户

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

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <returns></returns>
        public override bool InsertSingleUser(User entity)
        {
            return TianyueRepository.PermissionService.InsertSingleUser(entity);
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <returns></returns>
        public override bool UpdateSingleUser(User entity)
        {
            return TianyueRepository.PermissionService.UpdateSingleUser(entity);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        public override bool DeleteSingleUser(User entity)
        {
            return TianyueRepository.PermissionService.DeleteSingleUser(entity);
        }

        #endregion

        #region  角色

        /// <summary>
        /// 查询角色
        /// </summary>
        /// <returns></returns>
        public override List<Domain.Configuration.RoleView> GetRoleList(Role entity)
        {
            return TianyueRepository.PermissionService.GetRoleList(entity);
        }

        /// <summary>
        /// 查询单个角色
        /// </summary>
        /// <returns></returns>
        public override Domain.Configuration.Role GetSingleRole(Role entity)
        {
            return TianyueRepository.PermissionService.GetSingleRole(entity);
        }

        /// <summary>
        /// 查询所有角色
        /// </summary>
        /// <returns></returns>
        public override List<Domain.Configuration.RoleView> GetAllRole()
        {
            return TianyueRepository.PermissionService.GetAllRole();
        }

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <returns></returns>
        public override bool InsertSingleRole(Role entity)
        {
            return TianyueRepository.PermissionService.InsertSingleRole(entity);
        }

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <returns></returns>
        public override bool UpdateSingleRole(Role entity)
        {
            return TianyueRepository.PermissionService.UpdateSingleRole(entity);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <returns></returns>
        public override bool DeleteSingleRole(Role entity)
        {
            return TianyueRepository.PermissionService.DeleteSingleRole(entity);
        }

        #endregion

        #region  页面

        /// <summary>
        /// 查询页面
        /// </summary>
        /// <returns></returns>
        public override List<Domain.Configuration.FormPageView> GetFormPageList(FormPage entity)
        {
            return TianyueRepository.PermissionService.GetFormPageList(entity);
        }

        /// <summary>
        /// 查询单个页面
        /// </summary>
        /// <returns></returns>
        public override Domain.Configuration.FormPage GetSingleFormPage(FormPage entity)
        {
            return TianyueRepository.PermissionService.GetSingleFormPage(entity);
        }

        /// <summary>
        /// 查询所有页面
        /// </summary>
        /// <returns></returns>
        public override List<Domain.Configuration.FormPageView> GetAllFormPage()
        {
            return TianyueRepository.PermissionService.GetAllFormPage();
        }

        /// <summary>
        /// 新增页面
        /// </summary>
        /// <returns></returns>
        public override bool InsertSingleFormPage(FormPage entity)
        {
            return TianyueRepository.PermissionService.InsertSingleFormPage(entity);
        }

        /// <summary>
        /// 更新页面
        /// </summary>
        /// <returns></returns>
        public override bool UpdateSingleFormPage(FormPage entity)
        {
            return TianyueRepository.PermissionService.UpdateSingleFormPage(entity);
        }

        /// <summary>
        /// 删除页面
        /// </summary>
        /// <returns></returns>
        public override bool DeleteSingleFormPage(FormPage entity)
        {
            return TianyueRepository.PermissionService.DeleteSingleFormPage(entity);
        }

        #endregion
        
        #region  功能目录

        /// <summary>
        /// 查询功能目录
        /// </summary>
        /// <returns></returns>
        public override List<Domain.Configuration.FunctionCatalogView> GetFunctionCatalogList(FunctionCatalog entity)
        {
            return TianyueRepository.PermissionService.GetFunctionCatalogList(entity);
        }

        /// <summary>
        /// 查询单个功能目录
        /// </summary>
        /// <returns></returns>
        public override Domain.Configuration.FunctionCatalog GetSingleFunctionCatalog(FunctionCatalog entity)
        {
            return TianyueRepository.PermissionService.GetSingleFunctionCatalog(entity);
        }

        /// <summary>
        /// 查询所有功能目录
        /// </summary>
        /// <returns></returns>
        public override List<Domain.Configuration.FunctionCatalogView> GetAllFunctionCatalog()
        {
            return TianyueRepository.PermissionService.GetAllFunctionCatalog();
        }

        /// <summary>
        /// 新增功能目录
        /// </summary>
        /// <returns></returns>
        public override bool InsertSingleFunctionCatalog(FunctionCatalog entity)
        {
            return TianyueRepository.PermissionService.InsertSingleFunctionCatalog(entity);
        }

        /// <summary>
        /// 更新功能目录
        /// </summary>
        /// <returns></returns>
        public override bool UpdateSingleFunctionCatalog(FunctionCatalog entity)
        {
            return TianyueRepository.PermissionService.UpdateSingleFunctionCatalog(entity);
        }

        /// <summary>
        /// 删除功能目录
        /// </summary>
        /// <returns></returns>
        public override bool DeleteSingleFunctionCatalog(FunctionCatalog entity)
        {
            return TianyueRepository.PermissionService.DeleteSingleFunctionCatalog(entity);
        }

        #endregion
    }
}
