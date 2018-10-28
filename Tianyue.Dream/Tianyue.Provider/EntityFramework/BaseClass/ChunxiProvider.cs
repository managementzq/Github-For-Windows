using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
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
    /// <typeparam name="T">实体对象类型</typeparam>
    public abstract class ChunxiProvider<T> : IChunxiProvider<T> where T : class
    {
        /// <summary>
        ///     类名，用于记录异常时出错位置
        /// </summary>
        private const string strClass = "MES.Framework.DAL.BaseDAL";

        protected DbContext baseContext;
        protected IDbSet<T> objectSet;

        public ChunxiProvider(DbContext context)
        {
            this.baseContext = context;
            this.objectSet = this.baseContext.Set<T>();
        }

        /// <summary>  
        /// 执行原始SQL命令  
        /// </summary>  
        /// <param name="commandText">SQL命令</param>  
        /// <param name="parameters">参数</param>  
        /// <returns>影响的记录数</returns>  
        public Object[] ExecuteSqlNonQuery<TSet>(string commandText, params Object[] parameters)
        {
            var results = baseContext.Database.SqlQuery<TSet>(commandText, parameters);
            //results.Single();
            return parameters;
        }

        /// <summary>  
        /// 执行原始SQL命令  
        /// </summary>  
        /// <param name="commandText">SQL命令</param>  
        /// <param name="parameters">参数</param>  
        /// <returns>影响的记录数</returns>  
        public Object[] ExecuteSqlNonQuery(string commandText, params Object[] parameters)
        {
            var results = baseContext.Database.SqlQuery<T>(commandText, parameters);
            //results.Single();
            return parameters;
        }

        /// <summary>  
        /// 执行原始SQL命令  
        /// </summary>  
        /// <param name="commandText">SQL命令</param>  
        /// <param name="parameters">参数</param>  
        /// <returns>抓取的数据表</returns>  
        public DataTable ExecuteSqlQuery(string commandText, params Object[] parameters)
        {
            using (var conn = baseContext.Database.Connection)
            {
                var cmd = conn.CreateCommand();

                conn.Open();
                cmd.CommandText = commandText;
                foreach (IDataParameter param in parameters)
                {
                    cmd.Parameters.Add(param);
                }

                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                ds.Tables.Add(dt);
                ds.Load(reader, LoadOption.OverwriteChanges, dt);
                ds.EnforceConstraints = false;
                return dt;
            }
        }

        protected IDbSet<TSet> GetDAL<TSet>() where TSet : class
        {
            return this.baseContext.Set<TSet>();
        }

        public TSet Get<TSet>(object id) where TSet : class
        {
            return GetDAL<TSet>().Find(id);
        }

        /// <summary>
        /// 删除指定对象，不立即提交
        /// </summary>
        /// <typeparam name="TSet">要删除的实体对象类型</typeparam>
        /// <param name="t">要删除的对象</param>
        public virtual void DeleteWithTrans<TSet>(TSet t) where TSet : class
        {
            GetDAL<TSet>().Remove(t);
            //return baseContext.SaveChanges() > 0;
        }

        public IList<TSet> GetAll<TSet>() where TSet : class
        {
            return GetDAL<TSet>().ToList<TSet>(); ;
        }

        /// <summary>
        /// 插入指定类型的指定对象到数据库中
        /// </summary>
        /// <typeparam name="TSet">指定类型</typeparam>
        /// <param name="t">指定对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        public virtual bool Insert<TSet>(TSet t) where TSet : class
        {
            //ArgumentValidation.CheckForNullReference(t, "传入的对象t为空");

            GetDAL<TSet>().Add(t);
            return baseContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 插入指定类型的指定对象到数据库中，不立即提交
        /// </summary>
        /// <typeparam name="TSet">指定类型</typeparam>
        /// <param name="t">指定对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        public virtual void InsertWithTrans<TSet>(TSet t) where TSet : class
        {
            //ArgumentValidation.CheckForNullReference(t, "传入的对象t为空");

            GetDAL<TSet>().Add(t);
        }

        /// <summary>
        /// 更新指定类型的对象属性到数据库中
        /// </summary>
        /// <typeparam name="TSet">指定类型</typeparam>
        /// <param name="t">指定对象</param>
        /// <param name="key">主键的值</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        public virtual bool Update<TSet>(TSet t, object key) where TSet : class
        {
            //ArgumentValidation.CheckForNullReference(t, "传入的对象t为空");

            bool result = false;
            TSet existing = GetDAL<TSet>().Find(key);
            if (existing != null)
            {
                baseContext.Entry(existing).CurrentValues.SetValues(t);
                result = baseContext.SaveChanges() > 0;
            }
            return result;
        }

        /// <summary>
        /// 更新指定类型的对象属性到数据库中，不立即提交
        /// </summary>
        /// <typeparam name="TSet">指定类型</typeparam>
        /// <param name="t">指定对象</param>
        /// <param name="key">主键的值</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        public virtual void UpdateWithTrans<TSet>(TSet t, object key) where TSet : class
        {
            //ArgumentValidation.CheckForNullReference(t, "传入的对象t为空");

            //bool result = false;
            TSet existing = GetDAL<TSet>().Find(key);
            if (existing != null)
            {
                baseContext.Entry(existing).CurrentValues.SetValues(t);
                //result = baseContext.SaveChanges() > 0;
            }
            //return result;
        }

        /// <summary>
        /// 根据条件，返回符合条件的指定类型记录
        /// </summary>
        /// <param name="whereCondition">查询条件</param>
        /// <returns>存在则返回符合条件的记录,否则返回默认值</returns>
        public IList<TSet> Find<TSet>(Expression<Func<TSet, bool>> whereCondition) where TSet : class
        {
            return GetDAL<TSet>().Where(whereCondition).ToList<TSet>();
        }

        /// <summary>
        /// 提交变更
        /// </summary>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        public virtual bool SubmitTrans()
        {
            int result = baseContext.SaveChanges();
            return result > 0;
        }

        /// <summary>
        /// 根据指定主键值返回记录
        /// </summary>
        /// <param name="id">主键值</param>
        /// <returns>存在则返回指定的对象,否则返回默认值</returns>
        public T Get(object id)
        {
            return objectSet.Find(id);
        }

        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <returns>返回所有记录</returns>
        public IList<T> GetAll()
        {
            return objectSet.ToList<T>(); ;
        }

        /// <summary>
        /// 根据条件，返回符合条件的记录
        /// </summary>
        /// <param name="whereCondition">查询条件</param>
        /// <returns>存在则返回符合条件的记录,否则返回默认值</returns>
        public IList<T> Find(Expression<Func<T, bool>> whereCondition)
        {
            return objectSet.Where(whereCondition).ToList<T>();
        }

        /// <summary>
        /// 插入指定对象到数据库中
        /// </summary>
        /// <param name="t">指定的对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        public virtual bool Insert(T t)
        {
            //ArgumentValidation.CheckForNullReference(t, "传入的对象t为空");

            objectSet.Add(t);
            return baseContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 根据指定对象的ID,从数据库中删除指定对象
        /// </summary>
        /// <param name="id">对象的ID</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool Delete(object id)
        {
            T obj = objectSet.Find(id);
            objectSet.Remove(obj);
            return baseContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 从数据库中删除指定对象
        /// </summary>
        /// <param name="t">指定对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool Delete(T t)
        {
            objectSet.Remove(t);
            return baseContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 更新对象属性到数据库中
        /// </summary>
        /// <param name="t">指定的对象</param>
        /// <param name="key">主键的值</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        public virtual bool Update(T t, object key)
        {
            //ArgumentValidation.CheckForNullReference(t, "传入的对象t为空");

            bool result = false;
            T existing = objectSet.Find(key);
            if (existing != null)
            {
                baseContext.Entry(existing).CurrentValues.SetValues(t);
                result = baseContext.SaveChanges() > 0;
            }
            return result;
        }

        /// <summary>
        /// 根据实例内容更新指定字段
        /// </summary>
        /// <typeparam name="TSet">实例类型，不能是视图实例</typeparam>
        /// <param name="ht">需要更新的字段列表</param>
        /// <param name="t">实例对象，保存需要更新的值</param>
        /// <param name="key">主键值</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        public virtual bool Update<TSet>(Hashtable ht, TSet t) where TSet : class
        {
            GetDAL<TSet>().Attach(t);
            var stateEntry = ((IObjectContextAdapter)baseContext).ObjectContext.ObjectStateManager.GetObjectStateEntry(t);

            foreach (DictionaryEntry de in ht)
            {
                stateEntry.SetModifiedProperty(de.Key.ToString());
            }

            return baseContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 根据实例内容更新指定字段，不立即提交，最后统一提交
        /// </summary>
        /// <typeparam name="TSet">实例类型，不能是视图实例</typeparam>
        /// <param name="ht">需要更新的字段列表</param>
        /// <param name="t">实例对象，保存需要更新的值</param>
        /// <param name="key">主键值</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        public virtual void UpdateWithTrans<TSet>(Hashtable ht, TSet t) where TSet : class
        {
            GetDAL<TSet>().Attach(t);
            var stateEntry = ((IObjectContextAdapter)baseContext).ObjectContext.ObjectStateManager.GetObjectStateEntry(t);

            foreach (DictionaryEntry de in ht)
            {
                stateEntry.SetModifiedProperty(de.Key.ToString());
            }
        }

        /// <summary>
        /// 用指定类型对象内容更新旧对象各属性值，根据属性名称匹配
        /// </summary>
        /// <typeparam name="TNew">保存新值得类型</typeparam>
        /// <param name="news">保存新值得对象</param>
        /// <param name="old">需要更新的对象</param>
        /// <returns></returns>
        public virtual bool Update<TNew>(TNew news, T old)
        {
            //ArgumentValidation.CheckForNullReference(t, "传入的对象t为空");

            bool result = false;

            baseContext.Entry(old).CurrentValues.SetValues(news);
            result = baseContext.SaveChanges() > 0;

            return result;
        }

        /// <summary>
        /// 根据条件查询数据库,如果存在返回第一个对象
        /// </summary>
        /// <param name="match">条件表达式</param>
        /// <returns>存在则返回指定的第一个对象,否则返回默认值</returns>
        public virtual T FindSingle(Expression<Func<T, bool>> match)
        {
            return objectSet.FirstOrDefault(match);
        }

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
