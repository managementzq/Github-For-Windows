using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tianyue.Utility.Helper
{
    public class ClassHelper
    {
        /// <summary>
        /// 插入指定类型的指定对象到数据库中
        /// </summary>
        /// <typeparam name="TSet">指定类型</typeparam>
        /// <param name="generic">指定对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        public static Hashtable TraversePropertyType<Generic>(Generic generic)
        {
            Hashtable htPropertyType = new Hashtable();
            if (generic == null)
            {
                return null;
            }

            System.Reflection.PropertyInfo[] properties = generic.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

            if (properties.Length <= 0)
            {
                return null;
            }
            foreach (System.Reflection.PropertyInfo item in properties)
            {
                string strPropertyName = item.Name;                                  
                string strPropertyType = item.PropertyType.FullName;
              
                htPropertyType.Add(strPropertyName, strPropertyType);
            }
            return htPropertyType;
        }


        //public static Dictionary<string, string> GetProperties<T>(T t)
        //{
        //    Dictionary<string, string> ret = new Dictionary<string, string>();

        //    if (t == null)
        //    {
        //        return null;
        //    }
        //    System.Reflection.PropertyInfo[] properties = t.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

        //    if (properties.Length <= 0)
        //    {
        //        return null;
        //    }
        //    foreach (System.Reflection.PropertyInfo item in properties)
        //    {
        //        string name = item.Name;                                                  //实体类字段名称  
        //        string value = ObjToStr(item.GetValue(t, null));                //该字段的值  

        //        if (item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String"))
        //        {
        //            ret.Add(name, value);        //在此可转换value的类型  
        //        }
        //    }

        //    return ret;
        //}

        ////反过来根据Dictionary来设置实体类  

        //public static T SetProperties<T>(T t, Dictionary<string, string> d)
        //{
        //    if (t == null || d == null)
        //    {
        //        return default(T);
        //    }
        //    System.Reflection.PropertyInfo[] properties = t.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

        //    if (properties.Length <= 0)
        //    {
        //        return default(T);
        //    }
        //    foreach (System.Reflection.PropertyInfo item in properties)
        //    {
        //        string name = item.Name;                                         //名称  
        //        string value = ObjToStr(item.GetValue(t, null));       //值  

        //        if (item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String"))
        //        {
        //            string val = d.Where(c => c.Key == name).FirstOrDefault().Value;
        //            if (val != null && val != value)
        //            {
        //                if (item.PropertyType.Name.StartsWith("Nullable`1"))
        //                {
        //                    item.SetValue(t, ObjToDate(val), null);
        //                }
        //                else
        //                {
        //                    item.SetValue(t, val, null);
        //                }
        //            }
        //        }
        //    }

        //    return t;
        //}

    }
}
