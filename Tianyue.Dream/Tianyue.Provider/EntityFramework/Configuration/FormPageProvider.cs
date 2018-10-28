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

    public class FormPageProvider : TianyueProvider<Tianyue.Domain.Configuration.FormPage>
    {
        /// <summary>
        ///     类名，用于页面异常时出错位置
        /// </summary>
        private const string strClass = "Tianyue.Provider.EntityFramework.Configuration.FormPageProvider";

        protected TianyueDbContext context;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context"></param>
        public FormPageProvider(TianyueDbContext context) : base(context)
        {
            this.context = context;
        }
        
        /// <summary>
        /// ID查询单条数据， ID理论上应该唯一
        /// </summary>
        /// <param name="entity">对象</param>
        public FormPage GetSingleFormPage(FormPage entity)
        {
            try
            {
                Expression<Func<FormPage, bool>> expression = PredicateBuilder.True<FormPage>();
                //if (!string.IsNullOrWhiteSpace(entity.PageCode))
                //{
                //    expression = expression.And(t => t.PageCode.Contains(entity.PageCode));
                //}
                if (!entity.FPID.Equals(Guid.Empty))
                {
                    expression = expression.And(t => t.FPID == entity.FPID);
                }
                //if (!string.IsNullOrWhiteSpace(entity.PageName))
                //{
                //    expression = expression.And(t => t.PageName.Contains(entity.PageName));
                //}

                FormPage pageFunction = QueryFirstSingle(expression);
                //IList<FormPage> result = QueryMatchingList<FormPage>(expression);

                return pageFunction;
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".GetSingleFormPage>>" + e.Message);
            }
        }
        
        /// <summary>
        /// 根据指定页面对象的值,找到匹配的页面
        /// </summary>
        /// <param name="entity">页面对象</param>
        public List<FormPageView> GetFormPageList(FormPage entity)
        {
            try
            {
                Expression<Func<FormPageView, bool>> expression = PredicateBuilder.True<FormPageView>();
                if (!string.IsNullOrWhiteSpace(entity.FormPageCode))
                {
                    expression = expression.And(t => t.FormPageCode.Contains(entity.FormPageCode));
                }
                if (!entity.FPID.Equals(Guid.Empty))
                {
                    expression = expression.And(t => t.FPID == entity.FPID);
                }
                if (!string.IsNullOrWhiteSpace(entity.FormPageName))
                {
                    expression = expression.And(t => t.FormPageName.Contains(entity.FormPageName));
                }

                List<FormPageView> result = QueryMatchingList<FormPageView>(expression).ToList();

                return result.OrderBy(t => t.Sequence).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".GetFormPageList>>" + e.Message);
            }
        }
        
        /// <summary>
        /// 获取所有生效的页面
        /// </summary>
        public List<FormPageView> GetAllFormPage()
        {
            try
            {
                Expression<Func<FormPageView, bool>> expression = PredicateBuilder.True<FormPageView>();
                IList<FormPageView> result = QueryMatchingList<FormPageView>(expression);

                return result.OrderBy(t => t.Sequence).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".GetAllFormPage>>" + e.Message);
            }
        }

        /// <summary>
        /// 新增页面
        /// </summary>
        public bool InsertSingleFormPage(FormPage entity)
        {
            try
            {
                return InsertSingle(entity);
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".InsertSingleFormPage>>" + e.Message);
            }
        }

        /// <summary>
        /// 更新页面
        /// </summary>
        public bool UpdateSingleFormPage(FormPage entity)
        {
            try
            {
                return UpdateSingle(entity,entity.FPID);
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".UpdateSingleFormPage>>" + e.Message);
            }
        }

        /// <summary>
        /// 删除页面
        /// </summary>
        public bool DeleteSingleFormPage(FormPage entity)
        {
            try
            {
                return DeleteSingle(entity);
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".DeleteSingleFormPage>>" + e.Message);
            }
        }

    }
}
