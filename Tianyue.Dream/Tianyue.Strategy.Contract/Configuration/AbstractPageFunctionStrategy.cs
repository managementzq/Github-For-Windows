using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Domain.Configuration;

namespace Tianyue.Strategy.Contract.Configuration
{

    public abstract partial class AbstractFormPageStrategy
    {
        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract List<FormPageView> GetFormPageList(FormPage entity);

        /// <summary>
        /// 查询单个用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract FormPage GetSingleFormPage(FormPage entity);

        /// <summary>
        /// 获取所有用户
        /// </summary>
        public abstract List<FormPageView> GetAllFormPage();
    }
}
