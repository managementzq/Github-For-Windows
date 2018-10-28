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

    public class FunctionCatalogProvider : TianyueProvider<Tianyue.Domain.Configuration.FunctionCatalog>
    {
        /// <summary>
        ///     类名，用于导航目录异常时出错位置
        /// </summary>
        private const string strClass = "Tianyue.Provider.EntityFramework.Configuration.FunctionCatalogProvider";

        protected TianyueDbContext context;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context"></param>
        public FunctionCatalogProvider(TianyueDbContext context) : base(context)
        {
            this.context = context;
        }

        /// <summary>
        /// 根据指定班别对象的值,找到匹配的导航目录
        /// </summary>
        /// <param name="entity">公司对象</param>
        public List<FunctionCatalogView> GetFunctionCatalogList(FunctionCatalog entity)
        {
            try
            {
                Expression<Func<FunctionCatalogView, bool>> expression = PredicateBuilder.True<FunctionCatalogView>();
                //if (!string.IsNullOrWhiteSpace(entity.FunctionCatalogUniqueId))
                //{
                //    expression = expression.And(t => t.FunctionCatalogUniqueId == entity.FunctionCatalogUniqueId);
                //}
                if (!entity.FCID.Equals(Guid.Empty))
                {
                    expression = expression.And(t => t.FCID == entity.FCID);
                }
                if (entity.FPID != null)
                {
                    expression = expression.And(t => t.FPID == entity.FPID);
                }
                if (entity.PFCID != null)
                {
                    expression = expression.And(t => t.PFCID == entity.PFCID);
                }
                if (!string.IsNullOrWhiteSpace(entity.FunctionName))
                {
                    expression = expression.And(t => t.FunctionName.Contains(entity.FunctionName));
                }
                if (!string.IsNullOrWhiteSpace(entity.FunctionCode))
                {
                    expression = expression.And(t => t.FunctionCode.Contains(entity.FunctionCode));
                }
                //if (!string.IsNullOrWhiteSpace(entity.FunctionCode))
                //{
                //    expression = expression.And(t => t.FunctionCode == entity.FunctionCode);
                //}
                ////if (!string.IsNullOrWhiteSpace(entity.FunctionCatalogType))
                //{
                //    expression = expression.And(t => t.FunctionCatalogType == entity.FunctionCatalogType);
                //}


                List<FunctionCatalogView> result = QueryMatchingList<FunctionCatalogView>(expression).ToList();

                return result.OrderBy(t => t.Sequence).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".GetFunctionCatalogList>>" + e.Message);
            }
        }

        /// <summary>
        /// 根据指定班别对象的值,找到匹配的导航目录
        /// </summary>
        /// <param name="entity">公司对象</param>
        public FunctionCatalogView GetSingleFunctionCatalogView(FunctionCatalog entity)
        {
            try
            {
                Expression<Func<FunctionCatalogView, bool>> expression = PredicateBuilder.True<FunctionCatalogView>();
                //if (!string.IsNullOrWhiteSpace(entity.FunctionCatalogUniqueId))
                //{
                //    expression = expression.And(t => t.FunctionCatalogUniqueId == entity.FunctionCatalogUniqueId);
                //}
                if (!entity.FCID.Equals(Guid.Empty))
                {
                    expression = expression.And(t => t.FCID == entity.FCID);
                }
                if (!string.IsNullOrWhiteSpace(entity.FunctionName))
                {
                    expression = expression.And(t => t.FunctionName.Contains(entity.FunctionName));
                }
                if (!string.IsNullOrWhiteSpace(entity.FunctionCode))
                {
                    expression = expression.And(t => t.FunctionCode.Contains(entity.FunctionCode));
                }
                //if (!string.IsNullOrWhiteSpace(entity.FunctionCatalogType))
                //{
                //    expression = expression.And(t => t.FunctionCatalogType == entity.FunctionCatalogType);
                //}


                IList<FunctionCatalogView> result = QueryMatchingList<FunctionCatalogView>(expression);

                return result.OrderBy(t => t.Sequence).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".GetSingleFunctionCatalog>>" + e.Message);
            }
        }

        /// <summary>
        /// 根据指定班别对象的值,找到匹配的导航目录
        /// </summary>
        /// <param name="entity">公司对象</param>
        public FunctionCatalog GetSingleFunctionCatalog(FunctionCatalog entity)
        {
            try
            {
                Expression<Func<FunctionCatalog, bool>> expression = PredicateBuilder.True<FunctionCatalog>();
                //if (!string.IsNullOrWhiteSpace(entity.FunctionCatalogUniqueId))
                //{
                //    expression = expression.And(t => t.FunctionCatalogUniqueId == entity.FunctionCatalogUniqueId);
                //}
                if (!entity.FCID.Equals(Guid.Empty))
                {
                    expression = expression.And(t => t.FCID == entity.FCID);
                }
                if (!string.IsNullOrWhiteSpace(entity.FunctionName))
                {
                    expression = expression.And(t => t.FunctionName.Contains(entity.FunctionName));
                }
                if (!string.IsNullOrWhiteSpace(entity.FunctionCode))
                {
                    expression = expression.And(t => t.FunctionCode.Contains(entity.FunctionCode));
                }
                //if (!string.IsNullOrWhiteSpace(entity.FunctionCatalogType))
                //{
                //    expression = expression.And(t => t.FunctionCatalogType == entity.FunctionCatalogType);
                //}

                IList<FunctionCatalog> result = QueryMatchingList<FunctionCatalog>(expression);

                return result.OrderBy(t => t.Sequence).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".GetSingleFunctionCatalog>>" + e.Message);
            }
        }
        
        /// <summary>
        /// 获取所有生效的导航目录
        /// </summary>
        public List<FunctionCatalogView> GetAllFunctionCatalog()
        {
            try
            {
                Expression<Func<FunctionCatalogView, bool>> expression = PredicateBuilder.True<FunctionCatalogView>();
                expression = expression.And(t => t.Disable == false);
                IList<FunctionCatalogView> result = QueryMatchingList<FunctionCatalogView>(expression);

                return result.OrderBy(t => t.Sequence).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".GetAllFunctionCatalog>>" + e.Message);
            }
        }


        /// <summary>
        /// 新增导航目录
        /// </summary>
        public bool InsertSingleFunctionCatalog(FunctionCatalog entity)
        {
            try
            {
                return InsertSingle(entity);
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".InsertSingleFunctionCatalog>>" + e.Message);
            }
        }

        /// <summary>
        /// 更新导航目录
        /// </summary>
        public bool UpdateSingleFunctionCatalog(FunctionCatalog entity)
        {
            try
            {
                return UpdateSingle(entity, entity.FCID);
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".UpdateSingleFunctionCatalog>>" + e.Message);
            }
        }

        /// <summary>
        /// 删除导航目录
        /// </summary>
        public bool DeleteSingleFunctionCatalog(FunctionCatalog entity)
        {
            try
            {
                return DeleteSingle(entity);
            }
            catch (Exception e)
            {
                throw new Exception(strClass + ".DeleteSingleFunctionCatalog>>" + e.Message);
            }
        }
    }
}
