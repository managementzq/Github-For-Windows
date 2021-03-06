﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Facade.Contract;
using Tianyue.Service;
using Tianyue.Strategy.Configuration;

namespace Tianyue.Facade
{
    /// <summary>
    /// 预警
    /// </summary>
    public class SystemFacade : AbstractSystemFacade
    {
        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public override DateTime GetServiceDate()
        {
            return TianyueRepository.SystemService.GetServiceDate();
        }

        //UserStrategy user = new UserStrategy();

        //public override List<User> GetAllUsers()
        //{
        //    return user.GetUserList();
        //}

        //public override List<UserEntity> GetDoctorUsers()
        //{
        //    return UIRepository.UserSrv.GetDoctorUsers();
        //}

        //public override List<UserEntity> GetNurseUsers()
        //{
        //    return UIRepository.UserSrv.GetNurseUsers();
        //}

        //public override List<UserEntity> GetAdminUsers()
        //{
        //    return UIRepository.UserSrv.GetAdminUsers();
        //}

        //public override UserEntity GetUserById(int id)
        //{
        //    return UIRepository.UserSrv.GetUserById(id);
        //}

        ///// <summary>
        ///// 获取患者登录所有区域
        ///// </summary>
        ///// <returns></returns>
        //public override List<Core.Dict.WardAreaEntity> GetAllAreas()
        //{
        //    return UIRepository.DictSrv.GetWardArea();
        //}

        //public override UserPackage Login(string userName)
        //{
        //    return UIRepository.UserSrv.Login(userName);
        //}

        //public override bool ChangePassowrd(string userName, string encrptPassword)
        //{
        //    return UIRepository.UserSrv.ChangePassowrd(userName, encrptPassword);
        //}
    }
}
