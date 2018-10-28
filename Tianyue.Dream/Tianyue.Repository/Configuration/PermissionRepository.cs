using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Domain.Configuration;
using Tianyue.Provider.EntityFramework.BaseClass;
using Tianyue.Provider.EntityFramework.Configuration;
using Tianyue.Repository.Contract.Configuration;

namespace Tianyue.Repository.Configuration
{
    public class PermissionRepository : IPermissionRepository
    {
        protected TianyueDbContext tianyueDbContext = new TianyueDbContext();

        #region 用户
        
        private UserProvider userProvider = null;
        private UserProvider UserProvider
        {
            get
            {
                if (userProvider == null)
                {
                    userProvider = new UserProvider(tianyueDbContext);
                }

                return userProvider;
            }
        }

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public List<UserView> GetUserList(User entity)
        {
            return UserProvider.GetUserList(entity);
        }

        /// <summary>
        /// 查询单个用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public User GetSingleUser(User entity)
        {
            return UserProvider.GetSingleUser(entity);
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        public List<UserView> GetAllUser()
        {
            return UserProvider.GetAllUser();
        }
        
        /// <summary>
        /// 新增单个用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertSingleUser(User entity)
        {
            return UserProvider.InsertSingleUser(entity);
        }

        /// <summary>
        /// 更新单个用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateSingleUser(User entity)
        {
            return UserProvider.UpdateSingleUser(entity);
        }

        /// <summary>
        /// 删除单个用户
        /// </summary>
        public bool DeleteSingleUser(User entity)
        {
            return UserProvider.DeleteSingleUser(entity);
        }

        #endregion

        #region 角色


        private RoleProvider roleProvider = null;
        private RoleProvider RoleProvider
        {
            get
            {
                if (roleProvider == null)
                {
                    roleProvider = new RoleProvider(tianyueDbContext);
                }

                return roleProvider;
            }
        }

        /// <summary>
        /// 查询角色
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public List<RoleView> GetRoleList(Role entity)
        {
            return RoleProvider.GetRoleList(entity);
        }

        /// <summary>
        /// 查询单个角色
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Role GetSingleRole(Role entity)
        {
            return RoleProvider.GetSingleRole(entity);
        }

        /// <summary>
        /// 获取所有角色
        /// </summary>
        public List<RoleView> GetAllRole()
        {
            return RoleProvider.GetAllRole();
        }

        /// <summary>
        /// 新增单个角色
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertSingleRole(Role entity)
        {
            return RoleProvider.InsertSingleRole(entity);
        }

        /// <summary>
        /// 更新单个角色
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateSingleRole(Role entity)
        {
            return RoleProvider.UpdateSingleRole(entity);
        }

        /// <summary>
        /// 删除单个角色
        /// </summary>
        public bool DeleteSingleRole(Role entity)
        {
            return RoleProvider.DeleteSingleRole(entity);
        }

        #endregion
        
        #region 页面

        private FormPageProvider formPageProvider = null;
        private FormPageProvider FormPageProvider
        {
            get
            {
                if (formPageProvider == null)
                {
                    formPageProvider = new FormPageProvider(tianyueDbContext);
                }

                return formPageProvider;
            }
        }

        /// <summary>
        /// 查询页面
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public List<FormPageView> GetFormPageList(FormPage entity)
        {
            return FormPageProvider.GetFormPageList(entity);
        }

        /// <summary>
        /// 查询单个页面
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FormPage GetSingleFormPage(FormPage entity)
        {
            return FormPageProvider.GetSingleFormPage(entity);
        }

        /// <summary>
        /// 获取所有页面
        /// </summary>
        public List<FormPageView> GetAllFormPage()
        {
            return FormPageProvider.GetAllFormPage();
        }

        /// <summary>
        /// 新增单个页面
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertSingleFormPage(FormPage entity)
        {
            return FormPageProvider.InsertSingleFormPage(entity);
        }

        /// <summary>
        /// 更新单个页面
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateSingleFormPage(FormPage entity)
        {
            return FormPageProvider.UpdateSingleFormPage(entity);
        }

        /// <summary>
        /// 删除单个页面
        /// </summary>
        public bool DeleteSingleFormPage(FormPage entity)
        {
            return FormPageProvider.DeleteSingleFormPage(entity);
        }

        #endregion
        
        #region 功能目录

        private FunctionCatalogProvider functionCatalogProvider = null;
        private FunctionCatalogProvider FunctionCatalogProvider
        {
            get
            {
                if (functionCatalogProvider == null)
                {
                    functionCatalogProvider = new FunctionCatalogProvider(tianyueDbContext);
                }

                return functionCatalogProvider;
            }
        }

        /// <summary>
        /// 查询功能目录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public List<FunctionCatalogView> GetFunctionCatalogList(FunctionCatalog entity)
        {
            return FunctionCatalogProvider.GetFunctionCatalogList(entity);
        }

        /// <summary>
        /// 查询单个功能目录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public FunctionCatalog GetSingleFunctionCatalog(FunctionCatalog entity)
        {
            return FunctionCatalogProvider.GetSingleFunctionCatalog(entity);
        }

        /// <summary>
        /// 获取所有功能目录
        /// </summary>
        public List<FunctionCatalogView> GetAllFunctionCatalog()
        {
            return FunctionCatalogProvider.GetAllFunctionCatalog();
        }

        /// <summary>
        /// 新增单个功能目录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertSingleFunctionCatalog(FunctionCatalog entity)
        {
            return FunctionCatalogProvider.InsertSingleFunctionCatalog(entity);
        }

        /// <summary>
        /// 更新单个功能目录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateSingleFunctionCatalog(FunctionCatalog entity)
        {
            return FunctionCatalogProvider.UpdateSingleFunctionCatalog(entity);
        }

        /// <summary>
        /// 删除单个功能目录
        /// </summary>
        public bool DeleteSingleFunctionCatalog(FunctionCatalog entity)
        {
            return FunctionCatalogProvider.DeleteSingleFunctionCatalog(entity);
        }

        #endregion

    }
}
