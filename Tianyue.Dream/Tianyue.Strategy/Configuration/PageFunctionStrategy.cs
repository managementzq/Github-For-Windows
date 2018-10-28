using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Domain.Configuration;
using Tianyue.Service;
using Tianyue.Strategy.Contract.Configuration;

namespace Tianyue.Strategy.Configuration
{

    public partial class FormPageStrategy : AbstractFormPageStrategy
    {
        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override List<FormPageView> GetFormPageList(FormPage entity)
        {
            return TianyueRepository.PermissionService.GetFormPageList(entity);
        }

        /// <summary>
        /// 查询单个用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override FormPage GetSingleFormPage(FormPage entity)
        {
            return TianyueRepository.PermissionService.GetSingleFormPage(entity);
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        public override List<FormPageView> GetAllFormPage()
        {
            return TianyueRepository.PermissionService.GetAllFormPage();
        }
    }
}
