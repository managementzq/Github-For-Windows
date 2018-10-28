using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tianyue.Provider.EntityFramework.BaseClass
{

    /// <summary>
    /// 数据访问层基类实现层
    /// </summary>
    /// <typeparam name="Generic">实体对象类型</typeparam>
    public abstract class TianyueProvider<Generic> where Generic : class
    {
        /// <summary>
        ///     类名，用于记录异常时出错位置
        /// </summary>
        private const string strClass = "MES.Framework.DAL.BaseDAL";

        /// <summary>
        /// 上下文
        /// </summary>
        protected DbContext baseContext;

        /// <summary>
        /// 泛型DbSet
        /// </summary>
        protected DbSet<Generic> genericDbSet;

        public TianyueProvider(DbContext dbContext)
        {
            this.baseContext = dbContext;
            this.genericDbSet = this.baseContext.Set<Generic>();
        }

        /// <summary>
        /// 根据泛型的实体实例化泛型上下文
        /// </summary>
        /// <typeparam name="Generic"></typeparam>
        /// <returns></returns>
        protected IDbSet<Generic> InstantiateGenericDbContext<Generic>() where Generic : class
        {
            return this.baseContext.Set<Generic>();
        }

        #region SqlCommand

        /// <summary>  
        /// 执行原始SQL命令  
        /// </summary>  
        /// <param name="strSqlCommandText">SQL命令</param>  
        /// <param name="objectParameters">参数</param>  
        /// <returns>影响的记录数</returns>  
        public Object[] ExecuteSqlCommand<GenericElement>(string strSqlCommandText, params Object[] objectParameter)
        {
            DbRawSqlQuery<GenericElement> genericDbRaw = baseContext.Database.SqlQuery<GenericElement>(strSqlCommandText, objectParameter);
            return objectParameter;
        }

        /// <summary>  
        /// 执行原始SQL命令  
        /// </summary>  
        /// <param name="strSqlCommandText">SQL命令</param>  
        /// <param name="objectParameter">参数</param>  
        /// <returns>影响的记录数</returns>  
        public Object[] ExecuteSqlCommand(string strSqlCommandText, params Object[] objectParameter)
        {
            DbRawSqlQuery<Generic> genericDbRaw = baseContext.Database.SqlQuery<Generic>(strSqlCommandText, objectParameter);
            //results.Single();
            return objectParameter;
        }

        /// <summary>  
        /// 执行原始SQL命令  
        /// </summary>  
        /// <param name="strSqlCommandText">SQL命令</param>  
        /// <param name="objectParameter">参数</param>  
        /// <returns>抓取的数据表</returns>  
        public DataTable ExecuteSqlCommandQuery(string strSqlCommandText, params Object[] objectParameter)
        {
            using (DbConnection connection = baseContext.Database.Connection)
            {
                DbCommand command = connection.CreateCommand();

                connection.Open();
                command.CommandText = strSqlCommandText;
                foreach (IDataParameter param in objectParameter)
                {
                    command.Parameters.Add(param);
                }

                DbDataReader dbDataReader = command.ExecuteReader(CommandBehavior.SequentialAccess);
                DataSet dataSet = new DataSet();
                DataTable dataTable = new DataTable();
                dataSet.Tables.Add(dataTable);
                dataSet.Load(dbDataReader, LoadOption.OverwriteChanges, dataTable);
                dataSet.EnforceConstraints = false;
                return dataTable;
            }
        }

        #endregion

        #region  Query

        /// <summary>
        /// 根据条件查询数据库,如果存在返回第一个对象
        /// </summary>
        /// <param name="expression">条件表达式</param>
        /// <returns>存在则返回指定的第一个对象,否则返回默认值</returns>
        public virtual Generic QueryFirstSingle(Expression<Func<Generic, bool>> expression)
        {
            return genericDbSet.FirstOrDefault(expression);
        }

        /// <summary>
        /// 根据 ID查询单条数据， ID理论上应该唯一
        /// </summary>
        /// <typeparam name="Generic"></typeparam>
        /// <param name="objectID"></param>
        /// <returns></returns>
        public Generic QuerySingle<Generic>(object objectID) where Generic : class
        {
            return InstantiateGenericDbContext<Generic>().Find(objectID);
        }

        /// <summary>
        /// 查询所有的数据
        /// </summary>
        /// <typeparam name="Generic"></typeparam>
        /// <returns></returns>
        public IList<Generic> QueryAll<Generic>() where Generic : class
        {
            return InstantiateGenericDbContext<Generic>().ToList<Generic>(); ;
        }

        /// <summary>
        /// 根据条件，返回符合条件的指定类型记录
        /// </summary>
        /// <param name="expression">查询条件</param>
        /// <returns>存在则返回符合条件的记录,否则返回默认值</returns>
        public IList<Generic> QueryMatchingList<Generic>(Expression<Func<Generic, bool>> expression) where Generic : class
        {
            return InstantiateGenericDbContext<Generic>().Where(expression).ToList<Generic>();
        }

        /// <summary>
        /// 根据指定主键值返回记录
        /// </summary>
        /// <param name="objectID">主键值</param>
        /// <returns>存在则返回指定的对象,否则返回默认值</returns>
        public Generic QuerySingle(object objectID)
        {
            return genericDbSet.Find(objectID);
        }

        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <returns>返回所有记录</returns>
        public IList<Generic> QueryAll()
        {
            return genericDbSet.ToList<Generic>(); ;
        }

        /// <summary>
        /// 根据条件，返回符合条件的记录
        /// </summary>
        /// <param name="expression">查询条件</param>
        /// <returns>存在则返回符合条件的记录,否则返回默认值</returns>
        public IList<Generic> QueryMatchingList(Expression<Func<Generic, bool>> expression)
        {
            return genericDbSet.Where(expression).ToList<Generic>();
        }

        #endregion

        #region 单实体CUD

        /// <summary>
        /// 插入指定类型的指定对象到数据库中
        /// </summary>
        /// <typeparam name="TSet">指定类型</typeparam>
        /// <param name="generic">指定对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        public virtual bool InsertSingle<Generic>(Generic generic) where Generic : class
        {
            //ArgumentValidation.CheckForNullReference(t, "传入的对象t为空");
            InstantiateGenericDbContext<Generic>().Add(generic);
            return baseContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 更新指定类型的对象属性到数据库中
        /// </summary>
        /// <typeparam name="TSet">指定类型</typeparam>
        /// <param name="generic">指定对象</param>
        /// <param name="objectKey">主键的值</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        public virtual bool UpdateSingle<Generic>(Generic generic, object objectKey) where Generic : class
        {
            //ArgumentValidation.CheckForNullReference(t, "传入的对象t为空");
            bool blExecuteResult = false;
            Generic generictDbSet = InstantiateGenericDbContext<Generic>().Find(objectKey);
            if (generictDbSet != null)
            {
                baseContext.Entry(generictDbSet).CurrentValues.SetValues(generic);
                blExecuteResult = baseContext.SaveChanges() > 0;
            }
            return blExecuteResult;
        }

        /// <summary>
        /// 插入指定对象到数据库中
        /// </summary>
        /// <param name="generic">指定的对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        public virtual bool InsertSingle(Generic generic)
        {
            //ArgumentValidation.CheckForNullReference(t, "传入的对象t为空");

            genericDbSet.Add(generic);
            return baseContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 根据指定对象的ID,从数据库中删除指定对象
        /// </summary>
        /// <param name="objectID">对象的ID</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool DeleteSingle(object objectID)
        {
            Generic generictDbSet = genericDbSet.Find(objectID);
            genericDbSet.Remove(generictDbSet);
            return baseContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 从数据库中删除指定对象
        /// </summary>
        /// <param name="generic">指定对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool DeleteSingle(Generic generic)
        {
            genericDbSet.Remove(generic);
            return baseContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 更新对象属性到数据库中
        /// </summary>
        /// <param name="generic">指定的对象</param>
        /// <param name="objectKey">主键的值</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        public virtual bool UpdateSingle(Generic generic, object objectKey)
        {
            //ArgumentValidation.CheckForNullReference(t, "传入的对象t为空");

            bool blExecuteResult = false;
            Generic generictDbSet = genericDbSet.Find(objectKey);
            if (generictDbSet != null)
            {
                baseContext.Entry(generictDbSet).CurrentValues.SetValues(generic);
                blExecuteResult = baseContext.SaveChanges() > 0;
            }
            return blExecuteResult;
        }

        /// <summary>
        /// 根据实例内容更新指定字段
        /// </summary>
        /// <typeparam name="TSet">实例类型，不能是视图实例</typeparam>
        /// <param name="hashtable">需要更新的字段列表</param>
        /// <param name="generic">实例对象，保存需要更新的值</param>
        /// <param name="key">主键值</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        public virtual bool UpdateSingle<Generic>(Hashtable hashtable, Generic generic) where Generic : class
        {
            InstantiateGenericDbContext<Generic>().Attach(generic);
            ObjectStateEntry objectStateEntry = ((IObjectContextAdapter)baseContext).ObjectContext.ObjectStateManager.GetObjectStateEntry(generic);

            foreach (DictionaryEntry dictionaryEntry in hashtable)
            {
                objectStateEntry.SetModifiedProperty(dictionaryEntry.Key.ToString());
            }

            return baseContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 用指定类型对象内容更新旧对象各属性值，根据属性名称匹配
        /// </summary>
        /// <typeparam name="TNew">保存新值得类型</typeparam>
        /// <param name="genericNew">保存新值得对象</param>
        /// <param name="genericOld">需要更新的对象</param>
        /// <returns></returns>
        public virtual bool UpdateSingle<GenericNew>(GenericNew genericNew, Generic genericOld)
        {
            //ArgumentValidation.CheckForNullReference(t, "传入的对象t为空");

            bool result = false;

            baseContext.Entry(genericOld).CurrentValues.SetValues(genericNew);
            result = baseContext.SaveChanges() > 0;

            return result;
        }

        ///// <summary>
        ///// 用指定类型对象内容更新旧对象各属性值，根据属性名称匹配
        ///// </summary>
        ///// <typeparam name="TNew">保存新值得类型</typeparam>
        ///// <param name="news">保存新值得对象</param>
        ///// <param name="old">需要更新的对象</param>
        ///// <returns></returns>
        //public virtual bool UpdateSingle<TNew>(TNew news, Generic old)
        //{
        //    //ArgumentValidation.CheckForNullReference(t, "传入的对象t为空");

        //    bool blExecuteResult = false;

        //    baseContext.Entry(old).CurrentValues.SetValues(news);
        //    blExecuteResult = baseContext.SaveChanges() > 0;

        //    return blExecuteResult;
        //}

        #endregion

        #region 事务CUD

        /// <summary>
        /// 删除指定对象，不立即提交
        /// </summary>
        /// <typeparam name="TSet">要删除的实体对象类型</typeparam>
        /// <param name="generic">要删除的对象</param>
        public virtual void TransactionDeleteSingle<Generic>(Generic generic) where Generic : class
        {
            InstantiateGenericDbContext<Generic>().Remove(generic);
        }

        /// <summary>
        /// 插入指定类型的指定对象到数据库中，不立即提交
        /// </summary>
        /// <typeparam name="TSet">指定类型</typeparam>
        /// <param name="generic">指定对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        public virtual void TransactionInsertSingle<Generic>(Generic generic) where Generic : class
        {
            //ArgumentValidation.CheckForNullReference(t, "传入的对象t为空");

            InstantiateGenericDbContext<Generic>().Add(generic);
        }

        /// <summary>
        /// 更新指定类型的对象属性到数据库中，不立即提交
        /// </summary>
        /// <typeparam name="TSet">指定类型</typeparam>
        /// <param name="generic">指定对象</param>
        /// <param name="objectKey">主键的值</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        public virtual void TransactionUpdateSingle<Generic>(Generic generic, object objectKey) where Generic : class
        {
            //ArgumentValidation.CheckForNullReference(t, "传入的对象t为空");

            Generic generictDbSet = InstantiateGenericDbContext<Generic>().Find(objectKey);
            if (generictDbSet != null)
            {
                baseContext.Entry(generictDbSet).CurrentValues.SetValues(generic);
            }
        }

        /// <summary>
        /// 根据实例内容更新指定字段，不立即提交，最后统一提交
        /// </summary>
        /// <typeparam name="TSet">实例类型，不能是视图实例</typeparam>
        /// <param name="hashtable">需要更新的字段列表</param>
        /// <param name="generic">实例对象，保存需要更新的值</param>
        /// <param name="key">主键值</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        public virtual void TransactionUpdateSingle<Generic>(Hashtable hashtable, Generic generic) where Generic : class
        {
            InstantiateGenericDbContext<Generic>().Attach(generic);
            ObjectStateEntry objectStateEntry = ((IObjectContextAdapter)baseContext).ObjectContext.ObjectStateManager.GetObjectStateEntry(generic);

            foreach (DictionaryEntry dictionaryEntry in hashtable)
            {
                objectStateEntry.SetModifiedProperty(dictionaryEntry.Key.ToString());
            }
        }

        /// <summary>
        /// 提交变更
        /// </summary>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        public virtual bool SubmitTransaction()
        {
            int inrSaveResult = baseContext.SaveChanges();
            return inrSaveResult > 0;
        }

        #endregion

        ///// <summary>
        ///// 根据条件表达式返回可查询的记录源
        ///// </summary>
        ///// <param name="match">查询条件</param>
        ///// <param name="orderByProperty">排序表达式</param>
        ///// <param name="isDescending">如果为true则为降序，否则为升序</param>
        ///// <returns></returns>
        //public virtual IQueryable<T> GetQueryable(Expression<Func<T, bool>> match, string sortPropertyName, bool isDescending = true)
        //{
        //    IQueryable<T> query = this.objectSet;
        //    if (match != null)
        //    {
        //        query = query.Where(match);
        //    }
        //    return query.OrderBy(sortPropertyName, isDescending);
        //}

        ///// <summary>
        ///// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        ///// </summary>
        ///// <param name="match">条件表达式</param>
        ///// <param name="info">分页实体</param>
        ///// <param name="orderByProperty">排序表达式</param>
        ///// <param name="isDescending">如果为true则为降序，否则为升序</param>
        ///// <returns>指定对象的集合</returns>
        //public virtual ICollection<T> FindWithPager(Expression<Func<T, bool>> match, PagerInfo info)
        //{
        //    int pageindex = (info.CurrenetPageIndex < 1) ? 1 : info.CurrenetPageIndex;
        //    int pageSize = (info.PageSize <= 0) ? 20 : info.PageSize;

        //    int excludedRows = (pageindex - 1) * pageSize;

        //    IQueryable<T> query = GetQueryable().Where(match);
        //    info.RecordCount = query.Count();

        //    return query.Skip(excludedRows).Take(pageSize).ToList();
        //}
    }
}
