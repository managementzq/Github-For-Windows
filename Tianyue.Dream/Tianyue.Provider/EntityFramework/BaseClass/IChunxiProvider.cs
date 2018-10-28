using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tianyue.Provider.EntityFramework.BaseClass
{

    /// <summary>
    /// 数据访问层基类接口
    /// </summary>
    /// <typeparam name="T">实体对象类型</typeparam>
    public interface IChunxiProvider<T> where T : class
    {
        /// <summary>
        /// 根据指定主键值返回记录
        /// </summary>
        /// <param name="id">主键值</param>
        /// <returns>存在则返回指定的对象,否则返回默认值</returns>
        T Get(object id);

        /// <summary>
        /// 返回当前上下文中指定ID对应的指定类型的记录
        /// </summary>
        /// <typeparam name="TSet">指定类型</typeparam>
        /// <param name="id">指定ID</param>
        /// <returns>当前上下文中指定ID对应的指定类型的记录</returns>
        TSet Get<TSet>(object id) where TSet : class;

        /// <summary>
        /// 返回当前上下文中满足条件的指定类型的记录
        /// </summary>
        /// <typeparam name="TSet">指定类型</typeparam>
        /// <param name="whereCondition">查询条件</param>
        /// <returns>当前上下文中满足条件的指定类型的记录</returns>
        IList<TSet> Find<TSet>(Expression<Func<TSet, bool>> whereCondition) where TSet : class;

        /// <summary>
        /// 返回当前上下文中指定类型的所有记录
        /// </summary>
        /// <typeparam name="TSet">指定类型</typeparam>
        /// <returns>当前上下文中指定类型的所有记录</returns>
        IList<TSet> GetAll<TSet>() where TSet : class;

        /// <summary>  
        /// 执行原始SQL命令  
        /// </summary>  
        /// <param name="commandText">SQL命令</param>  
        /// <param name="parameters">参数</param>  
        /// <returns>影响的记录数</returns>  
        Object[] ExecuteSqlNonQuery(string commandText, params Object[] parameters);

        /// <summary>  
        /// 执行原始SQL命令  
        /// </summary>  
        /// <param name="commandText">SQL命令</param>  
        /// <param name="parameters">参数</param>  
        /// <returns>影响的记录数</returns>  
        Object[] ExecuteSqlNonQuery<TSet>(string commandText, params Object[] parameters);

        /// <summary>  
        /// 执行原始SQL命令  
        /// </summary>  
        /// <param name="commandText">SQL命令</param>  
        /// <param name="parameters">参数</param>  
        /// <returns>影响的记录数</returns>  
        DataTable ExecuteSqlQuery(string commandText, params Object[] parameters);

        /// <summary>
        /// 插入指定类型的指定对象到数据库中
        /// </summary>
        /// <typeparam name="TSet">指定类型</typeparam>
        /// <param name="t">指定对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        bool Insert<TSet>(TSet t) where TSet : class;

        /// <summary>
        /// 更新指定类型的对象属性到数据库中
        /// </summary>
        /// <typeparam name="TSet">指定类型</typeparam>
        /// <param name="t">指定对象</param>
        /// <param name="key">主键的值</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        bool Update<TSet>(TSet t, object key) where TSet : class;

        /// <summary>
        /// 删除指定对象，不立即提交
        /// </summary>
        /// <typeparam name="TSet">要删除的实体对象类型</typeparam>
        /// <param name="t">要删除的对象</param>
        void DeleteWithTrans<TSet>(TSet t) where TSet : class;

        /// <summary>
        /// 插入指定类型的指定对象到数据库中，不立即提交
        /// </summary>
        /// <typeparam name="TSet">指定类型</typeparam>
        /// <param name="t">指定对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        void InsertWithTrans<TSet>(TSet t) where TSet : class;

        /// <summary>
        /// 更新指定类型的对象属性到数据库中，不立即提交
        /// </summary>
        /// <typeparam name="TSet">指定类型</typeparam>
        /// <param name="t">指定对象</param>
        /// <param name="key">主键的值</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        void UpdateWithTrans<TSet>(TSet t, object key) where TSet : class;

        /// <summary>
        /// 提交变更
        /// </summary>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        bool SubmitTrans();

        /// <summary>
        /// 根据条件，返回符合条件的记录
        /// </summary>
        /// <param name="whereCondition">查询条件</param>
        /// <returns>存在则返回符合条件的记录,否则返回默认值</returns>
        IList<T> Find(Expression<Func<T, bool>> whereCondition);

        /// <summary>
        /// 返回所有记录
        /// </summary>
        /// <returns>返回所有记录</returns>
        IList<T> GetAll();

        /// <summary>
        /// 插入指定对象到数据库中
        /// </summary>
        /// <param name="t">指定的对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        bool Insert(T t);

        /// <summary>
        /// 根据指定对象的ID,从数据库中删除指定对象
        /// </summary>
        /// <param name="id">对象的ID</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        bool Delete(object id);

        /// <summary>
        /// 从数据库中删除指定对象
        /// </summary>
        /// <param name="t">指定对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        bool Delete(T t);

        /// <summary>
        /// 更新对象属性到数据库中
        /// </summary>
        /// <param name="t">指定的对象</param>
        /// <param name="key">主键的值</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        bool Update(T t, object key);

        /// <summary>
        /// 根据实例内容更新指定字段，实例的GUID需指定，不立即提交，最后统一提交
        /// </summary>
        /// <typeparam name="TSet">实例类型，不能是视图实例</typeparam>
        /// <param name="ht">需要更新的字段列表</param>
        /// <param name="t">实例对象，保存需要更新的值，GUID需指定，更新指定GUID对应的记录</param>
        /// <param name="key">主键值</param>
        void UpdateWithTrans<TSet>(Hashtable ht, TSet t) where TSet : class;

        /// <summary>
        /// 根据实例内容更新指定字段，实例的GUID需指定
        /// </summary>
        /// <typeparam name="TSet">实例类型，不能是视图实例</typeparam>
        /// <param name="ht">需要更新的字段列表，实例的字段名</param>
        /// <param name="t">实例对象，保存需要更新的值，GUID需指定，更新指定GUID对应的记录</param>
        /// <param name="key">主键值</param>
        /// <returns>返回是否更新成功</returns>
        bool Update<TSet>(Hashtable ht, TSet t) where TSet : class;

        ///// <summary>
        ///// 查询数据库,返回指定ID的对象
        ///// </summary>
        ///// <param name="id">ID主键的值</param>
        ///// <returns>存在则返回指定的对象,否则返回Null</returns>
        //T FindByID(object id);

        /// <summary>
        /// 根据条件查询数据库,如果存在返回第一个对象
        /// </summary>
        /// <param name="match">条件表达式</param>
        /// <returns>存在则返回指定的第一个对象,否则返回默认值</returns>
        T FindSingle(Expression<Func<T, bool>> match);

        ///// <summary>
        ///// 返回可查询的记录源
        ///// </summary>
        ///// <returns></returns>
        //IQueryable<T> GetQueryable();

        ///// <summary>
        ///// 根据条件表达式返回可查询的记录源
        ///// </summary>
        ///// <param name="match">查询条件</param>
        ///// <param name="orderByProperty">排序表达式</param>
        ///// <param name="isDescending">如果为true则为降序，否则为升序</param>
        ///// <returns></returns>
        //IQueryable<T> GetQueryable(Expression<Func<T, bool>> match, string sortPropertyName, bool isDescending = true);

        ///// <summary>
        ///// 根据条件查询数据库,并返回对象集合
        ///// </summary>
        ///// <param name="match">条件表达式</param>
        ///// <returns></returns>
        //ICollection<T> Find(Expression<Func<T, bool>> match);

        ///// <summary>
        ///// 根据条件查询数据库,并返回对象集合
        ///// </summary>
        ///// <param name="match">条件表达式</param>
        ///// <param name="orderByProperty">排序表达式</param>
        ///// <param name="isDescending">如果为true则为降序，否则为升序</param>
        ///// <returns></returns>
        //ICollection<T> Find<TKey>(Expression<Func<T, bool>> match, Expression<Func<T, TKey>> orderByProperty, bool isDescending = true);

        ///// <summary>
        ///// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        ///// </summary>
        ///// <param name="match">条件表达式</param>
        ///// <param name="info">分页实体</param>
        ///// <param name="orderByProperty">排序表达式</param>
        ///// <param name="isDescending">如果为true则为降序，否则为升序</param>
        ///// <returns>指定对象的集合</returns>
        //ICollection<T> FindWithPager(Expression<Func<T, bool>> match, PagerInfo info);

        ///// <summary>
        ///// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        ///// </summary>
        ///// <param name="match">条件表达式</param>
        ///// <param name="info">分页实体</param>
        ///// <param name="orderByProperty">排序表达式</param>
        ///// <param name="isDescending">如果为true则为降序，否则为升序</param>
        ///// <returns>指定对象的集合</returns>
        //ICollection<T> FindWithPager<TKey>(Expression<Func<T, bool>> match, PagerInfo info, Expression<Func<T, TKey>> orderByProperty, bool isDescending = true);
    }
}
