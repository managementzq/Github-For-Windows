using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Business.Configuration;
using Tianyue.Business.Contract.Configuration;
using Tianyue.Domain.Configuration;

namespace Tianyue.Service.Configuration
{
    public class PermissionService
    {
        private IPermissionBusiness permissionService;

        private IPermissionBusiness ConfigurationService
        {
            get
            {
                permissionService = new PermissionBusiness();

                //if (userService == null)
                //{
                //    if (AppSettingHelper.UseADODirect)
                //    {
                //        userService = new UserBusiness();
                //    }
                //    else
                //    {
                //        ChannelFactory<IUserBusiness> channelFactory = new ChannelFactory<IUserBusiness>("BasicHttpBinding_IUserService");
                //        userService = channelFactory.CreateChannel();
                //    }
                //}

                return permissionService;
            }
        }
        
        #region  用户

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public List<UserView> GetUserList(User entity)
        {
            return ConfigurationService.GetUserList(entity);
        }

        /// <summary>
        /// 查询单个用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public User GetSingleUser(User entity)
        {
            return ConfigurationService.GetSingleUser(entity);
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        public List<UserView> GetAllUser()
        {
            return ConfigurationService.GetAllUser();
        }
        
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <returns></returns>
        public bool InsertSingleUser(User entity)
        {
            return ConfigurationService.InsertSingleUser(entity);
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <returns></returns>
        public bool UpdateSingleUser(User entity)
        {
            return ConfigurationService.UpdateSingleUser(entity);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        public bool DeleteSingleUser(User entity)
        {
            return ConfigurationService.DeleteSingleUser(entity);
        }

        #endregion
        
        #region  角色

        /// <summary>
        /// 查询角色
        /// </summary>
        /// <returns></returns>
        public List<Domain.Configuration.RoleView> GetRoleList(Role entity)
        {
            return ConfigurationService.GetRoleList(entity);
        }

        /// <summary>
        /// 查询单个角色
        /// </summary>
        /// <returns></returns>
        public Domain.Configuration.Role GetSingleRole(Role entity)
        {
            return ConfigurationService.GetSingleRole(entity);
        }

        /// <summary>
        /// 查询所有角色
        /// </summary>
        /// <returns></returns>
        public List<Domain.Configuration.RoleView> GetAllRole()
        {
            return ConfigurationService.GetAllRole();
        }

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <returns></returns>
        public bool InsertSingleRole(Role entity)
        {
            return ConfigurationService.InsertSingleRole(entity);
        }

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <returns></returns>
        public bool UpdateSingleRole(Role entity)
        {
            return ConfigurationService.UpdateSingleRole(entity);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <returns></returns>
        public bool DeleteSingleRole(Role entity)
        {
            return ConfigurationService.DeleteSingleRole(entity);
        }

        #endregion
        
        #region  页面

        /// <summary>
        /// 查询页面
        /// </summary>
        /// <returns></returns>
        public List<Domain.Configuration.FormPageView> GetFormPageList(FormPage entity)
        {
            return ConfigurationService.GetFormPageList(entity);
        }

        /// <summary>
        /// 查询单个页面
        /// </summary>
        /// <returns></returns>
        public Domain.Configuration.FormPage GetSingleFormPage(FormPage entity)
        {
            return ConfigurationService.GetSingleFormPage(entity);
        }

        /// <summary>
        /// 查询所有页面
        /// </summary>
        /// <returns></returns>
        public List<Domain.Configuration.FormPageView> GetAllFormPage()
        {
            return ConfigurationService.GetAllFormPage();
        }

        /// <summary>
        /// 新增页面
        /// </summary>
        /// <returns></returns>
        public bool InsertSingleFormPage(FormPage entity)
        {
            return ConfigurationService.InsertSingleFormPage(entity);
        }

        /// <summary>
        /// 更新页面
        /// </summary>
        /// <returns></returns>
        public bool UpdateSingleFormPage(FormPage entity)
        {
            return ConfigurationService.UpdateSingleFormPage(entity);
        }

        /// <summary>
        /// 删除页面
        /// </summary>
        /// <returns></returns>
        public bool DeleteSingleFormPage(FormPage entity)
        {
            return ConfigurationService.DeleteSingleFormPage(entity);
        }

        #endregion
        
        #region  功能目录

        /// <summary>
        /// 查询功能目录
        /// </summary>
        /// <returns></returns>
        public List<Domain.Configuration.FunctionCatalogView> GetFunctionCatalogList(FunctionCatalog entity)
        {
            return ConfigurationService.GetFunctionCatalogList(entity);
        }

        /// <summary>
        /// 查询单个功能目录
        /// </summary>
        /// <returns></returns>
        public Domain.Configuration.FunctionCatalog GetSingleFunctionCatalog(FunctionCatalog entity)
        {
            return ConfigurationService.GetSingleFunctionCatalog(entity);
        }

        /// <summary>
        /// 查询所有功能目录
        /// </summary>
        /// <returns></returns>
        public List<Domain.Configuration.FunctionCatalogView> GetAllFunctionCatalog()
        {
            return ConfigurationService.GetAllFunctionCatalog();
        }

        /// <summary>
        /// 新增功能目录
        /// </summary>
        /// <returns></returns>
        public bool InsertSingleFunctionCatalog(FunctionCatalog entity)
        {
            return ConfigurationService.InsertSingleFunctionCatalog(entity);
        }

        /// <summary>
        /// 更新功能目录
        /// </summary>
        /// <returns></returns>
        public bool UpdateSingleFunctionCatalog(FunctionCatalog entity)
        {
            return ConfigurationService.UpdateSingleFunctionCatalog(entity);
        }

        /// <summary>
        /// 删除功能目录
        /// </summary>
        /// <returns></returns>
        public bool DeleteSingleFunctionCatalog(FunctionCatalog entity)
        {
            return ConfigurationService.DeleteSingleFunctionCatalog(entity);
        }

        #endregion

    }
}
