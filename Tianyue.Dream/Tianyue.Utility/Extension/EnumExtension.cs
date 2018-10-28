using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Utility.Common;

namespace Tianyue.Utility.Extension
{
    public static class EnumExtension
    {
        public static int Value(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name == null)
            {
                return -1;
            }
            FieldInfo field = type.GetField(name);
            return (int)field.GetValue(null);
        }

        /// <summary>
        /// 获取枚举对应的值并以string类型返回
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ValueStr(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name.IsNullOrEmpty())
            {
                return string.Empty;
            }

            EnumTypeName etn = new EnumTypeName();
            etn.EnumType = type;
            etn.Name = name;

            string vs;
            if (CommonCacheManager.EnumValueStrCache.TryGetValue(etn, out vs))
            {
                return vs;
            }
            else
            {
                FieldInfo field = type.GetField(name);
                vs = ((int)field.GetValue(null)).ToString();
                CommonCacheManager.EnumValueStrCache.Add(etn, vs);
                return vs;
            }
        }

    }
}
