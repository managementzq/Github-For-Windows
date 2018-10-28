using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Business.Contract.Configuration;
using Tianyue.Domain.Configuration;
using Tianyue.Repository.Contract.Configuration;
using Tianyue.ServiceLocator;

namespace Tianyue.Business.Configuration
{
    public class PermissionBusiness : IPermissionBusiness
    {

        private IPermissionRepository permissionRepository;

        public PermissionBusiness()
        {
            permissionRepository = TianyueServiceLocator.Current.GetInstance<IPermissionRepository>("PermissionUnity");

        }

        #region 用户

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <returns></returns>
        public List<Domain.Configuration.UserView> GetUserList(User entity)
        {
            return permissionRepository.GetUserList(entity);
        }

        /// <summary>
        /// 查询单个用户
        /// </summary>
        /// <returns></returns>
        public Domain.Configuration.User GetSingleUser(User entity)
        {
            return permissionRepository.GetSingleUser(entity);
        }

        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        public List<Domain.Configuration.UserView> GetAllUser()
        {
            return permissionRepository.GetAllUser();
        }
        
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <returns></returns>
        public bool InsertSingleUser(User entity)
        {
            return permissionRepository.InsertSingleUser(entity);
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <returns></returns>
        public bool UpdateSingleUser(User entity)
        {
            return permissionRepository.UpdateSingleUser(entity);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        public bool DeleteSingleUser(User entity)
        {
            return permissionRepository.DeleteSingleUser(entity);
        }

        #endregion
        
        #region 角色

        /// <summary>
        /// 查询角色
        /// </summary>
        /// <returns></returns>
        public List<Domain.Configuration.RoleView> GetRoleList(Role entity)
        {
            return permissionRepository.GetRoleList(entity);
        }

        /// <summary>
        /// 查询单个角色
        /// </summary>
        /// <returns></returns>
        public Domain.Configuration.Role GetSingleRole(Role entity)
        {
            return permissionRepository.GetSingleRole(entity);
        }

        /// <summary>
        /// 查询所有角色
        /// </summary>
        /// <returns></returns>
        public List<Domain.Configuration.RoleView> GetAllRole()
        {
            return permissionRepository.GetAllRole();
        }

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <returns></returns>
        public bool InsertSingleRole(Role entity)
        {
            return permissionRepository.InsertSingleRole(entity);
        }

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <returns></returns>
        public bool UpdateSingleRole(Role entity)
        {
            return permissionRepository.UpdateSingleRole(entity);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <returns></returns>
        public bool DeleteSingleRole(Role entity)
        {
            return permissionRepository.DeleteSingleRole(entity);
        }

        #endregion
        
        #region 页面

        /// <summary>
        /// 查询页面
        /// </summary>
        /// <returns></returns>
        public List<Domain.Configuration.FormPageView> GetFormPageList(FormPage entity)
        {
            return permissionRepository.GetFormPageList(entity);
        }

        /// <summary>
        /// 查询单个页面
        /// </summary>
        /// <returns></returns>
        public Domain.Configuration.FormPage GetSingleFormPage(FormPage entity)
        {
            return permissionRepository.GetSingleFormPage(entity);
        }

        /// <summary>
        /// 查询所有页面
        /// </summary>
        /// <returns></returns>
        public List<Domain.Configuration.FormPageView> GetAllFormPage()
        {
            return permissionRepository.GetAllFormPage();
        }

        /// <summary>
        /// 新增页面
        /// </summary>
        /// <returns></returns>
        public bool InsertSingleFormPage(FormPage entity)
        {
            return permissionRepository.InsertSingleFormPage(entity);
        }

        /// <summary>
        /// 更新页面
        /// </summary>
        /// <returns></returns>
        public bool UpdateSingleFormPage(FormPage entity)
        {
            return permissionRepository.UpdateSingleFormPage(entity);
        }

        /// <summary>
        /// 删除页面
        /// </summary>
        /// <returns></returns>
        public bool DeleteSingleFormPage(FormPage entity)
        {
            return permissionRepository.DeleteSingleFormPage(entity);
        }

        #endregion
        
        #region 功能目录

        /// <summary>
        /// 查询功能目录
        /// </summary>
        /// <returns></returns>
        public List<Domain.Configuration.FunctionCatalogView> GetFunctionCatalogList(FunctionCatalog entity)
        {
            return permissionRepository.GetFunctionCatalogList(entity);
        }

        /// <summary>
        /// 查询单个功能目录
        /// </summary>
        /// <returns></returns>
        public Domain.Configuration.FunctionCatalog GetSingleFunctionCatalog(FunctionCatalog entity)
        {
            return permissionRepository.GetSingleFunctionCatalog(entity);
        }

        /// <summary>
        /// 查询所有功能目录
        /// </summary>
        /// <returns></returns>
        public List<Domain.Configuration.FunctionCatalogView> GetAllFunctionCatalog()
        {
            return permissionRepository.GetAllFunctionCatalog();
        }

        /// <summary>
        /// 新增功能目录
        /// </summary>
        /// <returns></returns>
        public bool InsertSingleFunctionCatalog(FunctionCatalog entity)
        {
            return permissionRepository.InsertSingleFunctionCatalog(entity);
        }

        /// <summary>
        /// 更新功能目录
        /// </summary>
        /// <returns></returns>
        public bool UpdateSingleFunctionCatalog(FunctionCatalog entity)
        {
            return permissionRepository.UpdateSingleFunctionCatalog(entity);
        }

        /// <summary>
        /// 删除功能目录
        /// </summary>
        /// <returns></returns>
        public bool DeleteSingleFunctionCatalog(FunctionCatalog entity)
        {
            return permissionRepository.DeleteSingleFunctionCatalog(entity);
        }

        #endregion

    }
}
