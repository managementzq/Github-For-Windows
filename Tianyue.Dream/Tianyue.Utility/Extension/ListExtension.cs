using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tianyue.Utility.Extension
{
    public static class ListExtension
    {

        /// <summary>    
        /// 转化一个DataTable   
        /// </summary> 
        /// <typeparam name="T"></typeparam>    
        /// <param name="list"></param>    
        /// <returns></returns>    
        public static DataTable ToDataTable<T>(this IEnumerable<T> list)
        {

            //创建属性的集合    
            List<PropertyInfo> pList = new List<PropertyInfo>();
            //获得反射的入口    

            Type type = typeof(T);
            DataTable dt = new DataTable();
            //把所有的public属性加入到集合 并添加DataTable的列    
            System.Array.ForEach<PropertyInfo>(type.GetProperties(), p => { pList.Add(p); dt.Columns.Add(p.Name, p.PropertyType); });
            foreach (var item in list)
            {
                //创建一个DataRow实例    
                DataRow row = dt.NewRow();
                //给row 赋值    
                pList.ForEach(p => row[p.Name] = p.GetValue(item, null));
                //加入到DataTable    
                dt.Rows.Add(row);
            }
            return dt;
        }

        /// <summary>
        /// 将泛类型集合List类转换成DataTable
        /// </summary>
        /// <param name="list">泛类型集合</param>
        /// <returns></returns>
        public static DataTable ListToDataTable<T>(List<T> entitys)
        {
            //检查实体集合不能为空
            if (entitys == null || entitys.Count < 1)
            {
                throw new Exception("需转换的集合为空");
            }
            //取出第一个实体的所有Propertie
            Type entityType = entitys[0].GetType();
            PropertyInfo[] entityProperties = entityType.GetProperties();

            //生成DataTable的structure
            //生产代码中，应将生成的DataTable结构Cache起来，此处略
            DataTable dt = new DataTable();
            for (int i = 0; i < entityProperties.Length; i++)
            {
                //dt.Columns.Add(entityProperties[i].Name, entityProperties[i].PropertyType);
                dt.Columns.Add(entityProperties[i].Name);
            }
            //将所有entity添加到DataTable中
            foreach (object entity in entitys)
            {
                //检查所有的的实体都为同一类型
                if (entity.GetType() != entityType)
                {
                    throw new Exception("要转换的集合元素类型不一致");
                }
                object[] entityValues = new object[entityProperties.Length];
                for (int i = 0; i < entityProperties.Length; i++)
                {
                    entityValues[i] = entityProperties[i].GetValue(entity, null);
                }
                dt.Rows.Add(entityValues);
            }
            return dt;
        }

        /// <summary>    
        /// 将泛型集合类转换成DataTable    
        /// </summary>    
        /// <typeparam name="T">集合项类型</typeparam>    
        /// <param name="list">集合</param>    
        /// <returns>数据集(表)</returns>    
        public static DataTable ToDataTable<T>(IList<T> list)
        {
            return ToDataTable<T>(list, null);

        }

        /// <summary>    
        /// 将泛型集合类转换成DataTable    
        /// </summary>    
        /// <typeparam name="T">集合项类型</typeparam>    
        /// <param name="list">集合</param>    
        /// <param name="propertyName">需要返回的列的列名</param>    
        /// <returns>数据集(表)</returns>    
        public static DataTable ToDataTable<T>(IList<T> list, params string[] propertyName)
        {
            List<string> propertyNameList = new List<string>();
            if (propertyName != null)
                propertyNameList.AddRange(propertyName);
            DataTable result = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    if (propertyNameList.Count == 0)
                    {
                        result.Columns.Add(pi.Name, pi.PropertyType);
                    }
                    else
                    {
                        if (propertyNameList.Contains(pi.Name))
                            result.Columns.Add(pi.Name, pi.PropertyType);
                    }
                }

                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        if (propertyNameList.Count == 0)
                        {
                            object obj = pi.GetValue(list[i], null);
                            tempList.Add(obj);
                        }
                        else
                        {
                            if (propertyNameList.Contains(pi.Name))
                            {
                                object obj = pi.GetValue(list[i], null);
                                tempList.Add(obj);
                            }
                        }
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }

        public static void ForEach<T>(this IEnumerable<T> souce, Action<T> action)
        {
            if (souce.IsInvalid<T>())
                return;
            foreach (T obj in souce)
                action(obj);
        }

        public static T FindFirst<T>(this IEnumerable<T> source) where T : class
        {
            if (source.IsInvalid<T>())
                return default(T);
            using (IEnumerator<T> enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext())
                    return enumerator.Current;
            }
            return default(T);
        }

        public static object FindFirst(this IEnumerable source)
        {
            if (source.IsInvalid())
                return (object)null;
            IEnumerator enumerator = source.GetEnumerator();
            try
            {
                if (enumerator.MoveNext())
                    return enumerator.Current;
            }
            finally
            {
                (enumerator as IDisposable)?.Dispose();
            }
            return (object)null;
        }

        public static IEnumerable<Ttarget> ConvertAll<Ttarget>(this IEnumerable @this) where Ttarget : class
        {
            if (@this == null)
                return (IEnumerable<Ttarget>)null;
            IEnumerable<Ttarget> targets = @this as IEnumerable<Ttarget>;
            if (targets != null)
                return targets;
            Collection<Ttarget> collection = new Collection<Ttarget>();
            foreach (object thi in @this)
            {
                Ttarget target = thi as Ttarget;
                if ((object)target == null)
                    throw new ArgumentException("invalid Target:" + (object)typeof(Ttarget));
                collection.Add(target);
            }
            return (IEnumerable<Ttarget>)collection;
        }

        public static IEnumerable<Ttarget> ConvertAllyield<Ttarget>(this IEnumerable @this) where Ttarget : class
        {
            if (@this != null)
            {
                IEnumerator enumerator = @this.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        object item = enumerator.Current;
                        Ttarget titem = item as Ttarget;
                        yield return titem;
                    }
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    disposable?.Dispose();
                }
            }
        }

        public static List<T> ToList<T>(this IEnumerator<T> source)
        {
            List<T> objList = new List<T>();
            if (source == null)
                return objList;
            while (source.MoveNext())
                objList.Add(source.Current);
            return objList;
        }

        public static bool IsValid<T>(this IEnumerable<T> source)
        {
            return source != null && source.Any<T>();
        }

        public static bool IsValid(this IEnumerable @this)
        {
            if (@this == null)
                return false;
            IEnumerator enumerator = @this.GetEnumerator();
            try
            {
                if (enumerator.MoveNext())
                {
                    object current = enumerator.Current;
                    return true;
                }
            }
            finally
            {
                (enumerator as IDisposable)?.Dispose();
            }
            return false;
        }

        public static bool IsInvalid<T>(this IEnumerable<T> source)
        {
            return !source.IsValid<T>();
        }

        public static bool IsInvalid(this IEnumerable @this)
        {
            return !@this.IsValid();
        }

        public static void AddRange<T>(this ICollection<T> @this, IEnumerable<T> values)
        {
            foreach (T obj in values)
                @this.Add(obj);
        }

        public static T GetSafeValue<T>(this IList<T> @this, int index, T defaultValue)
        {
            if (@this.IsInvalid<T>() || @this.Count > index)
                return defaultValue;
            return @this[index];
        }

        public static bool HasItems<T>(this T[] array)
        {
            return (array != null) && (array.Length > 0);
        }

        /// <summary>
        /// 是否包含数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool HasItems<T>(this List<T> list)
        {
            return (list != null) && (list.Count > 0);
        }

        public static bool HasItems<T>(this ICollection<T> col)
        {
            return col != null && col.Count > 0;
        }

        /// <summary>
        /// 基本上和List<T>的ForEach方法一致。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="col"></param>
        /// <param name="handler"></param>
        public static void Each<T>(this IEnumerable<T> col, Action<T> handler)
        {
            foreach (var item in col)
            {
                handler(item);
            }
        }

        /// <summary>
        /// 带索引的遍历方法。
        /// </summary>
        public static void Each<T>(this IEnumerable<T> col, Action<T, int> handler)
        {
            int index = 0;
            foreach (var item in col)
            {
                handler(item, index++);
            }
        }

        /// <summary>
        /// 可以半途中断执行的遍历方法。
        /// </summary>
        public static void Each<T>(this IEnumerable<T> col, Func<T, bool> handler)
        {
            foreach (var item in col)
            {
                if (!handler(item)) break;
            }
        }

        /// <summary>
        /// 可以半途中段的带索引的遍历方法。
        /// </summary>
        public static void Each<T>(this IEnumerable<T> col, Func<T, int, bool> handler)
        {
            int index = 0;
            foreach (var item in col)
            {
                if (!handler(item, index++)) break;
            }
        }

        public static void Each<T>(this IEnumerable col, Action<object> handler)
        {
            foreach (var item in col)
            {
                handler(item);
            }
        }

        public static void Each<T>(this IEnumerable col, Action<object, int> handler)
        {
            int index = 0;
            foreach (var item in col)
            {
                handler(item, index++);
            }
        }

        public static void Each<T>(this IEnumerable col, Func<object, bool> handler)
        {
            foreach (var item in col)
            {
                if (!handler(item)) break;
            }
        }

        public static void Each<T>(this IEnumerable col, Func<object, int, bool> handler)
        {
            int index = 0;
            foreach (var item in col)
            {
                if (!handler(item, index++)) break;
            }
        }

        /*
         using (IDataReader reader = ...)
        {
            List<Customer> customers = reader.Select(r => new Customer {
                CustomerId = r["id"] is DBNull ? null : r["id"].ToString(),
                CustomerName = r["name"] is DBNull ? null : r["name"].ToString()
            }).ToList();
        }
         */

        public static IEnumerable<T> Select<T>(this IDataReader reader, Func<IDataReader, T> projection)
        {
            while (reader.Read())
            {
                yield return projection(reader);
            }
        }
    }
}
