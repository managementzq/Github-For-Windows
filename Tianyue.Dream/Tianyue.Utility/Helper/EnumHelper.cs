using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Utility.Common;
using Tianyue.Utility.Extension;

namespace Tianyue.Utility.Helper
{
    /// <summary>
    /// 枚举类型帮助类
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// 释放内存
        /// </summary>
        public static void Dispose()
        {
            CommonCacheManager.EnumDescriptionCache.Clear();
            CommonCacheManager.EnumValueStrCache.Clear();
        }

        public static string GetDescription(this Enum value, Boolean nameInstead = true)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name.IsNullOrEmptyOrWhiteSpace())
            {
                return null;
            }

            EnumTypeName etn = new EnumTypeName();
            etn.EnumType = type;
            etn.Name = name;

            string desc;
            if (CommonCacheManager.EnumDescriptionCache.TryGetValue(etn, out desc))
            {
                return desc;
            }
            else
            {
                FieldInfo field = type.GetField(name);
                DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

                if (attribute.IsNull())
                {
                    if (nameInstead)
                    {
                        return name;
                    }
                    return null;
                }
                else
                {
                    desc = attribute.Description;
                    CommonCacheManager.EnumDescriptionCache.Add(etn, desc);
                    return desc;
                }
            }
        }

        public static object GetDefultValue(this Enum value, Boolean nameInstead = true)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);

            FieldInfo field = type.GetField(name);
            DefaultValueAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DefaultValueAttribute)) as DefaultValueAttribute;

            return attribute.Value;
        }

        public static Dictionary<int, string> EnumToDictionary(Type enumType, Func<Enum, String> getText)
        {
            Dictionary<Int32, String> enumDic = new Dictionary<int, string>();
            Array enumValues = Enum.GetValues(enumType);
            foreach (Enum enumValue in enumValues)
            {
                Int32 key = Convert.ToInt32(enumValue);
                String value = getText(enumValue);
                enumDic.Add(key, value);
            }
            return enumDic;
        }

        public static string GetDescription(Type type, object value, Boolean nameInstead = true)
        {
            string name = Enum.GetName(type, Convert.ToInt32(value));
            if (name == null)
            {
                return null;
            }

            FieldInfo field = type.GetField(name);
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            if (attribute == null && nameInstead == true)
            {
                return name;
            }
            return attribute == null ? null : attribute.Description;
        }


        public static int GetEnumValue(Type enumType, string name)
        {
            return (int)Enum.Parse(enumType, name);
        }
    }

}
