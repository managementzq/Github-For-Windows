using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tianyue.Utility.Extension
{
    public static class StringExtension
    {
        public static bool IsNotNullOrEmptyOrWhiteSpace(this string value)
        {
            bool flag = value.IsNullOrEmpty();
            if (!flag)
                flag = value.Trim().IsNullOrEmpty();
            return !flag;
        }

        public static bool IsNullOrEmptyOrWhiteSpace(this string value)
        {
            bool flag = value.IsNullOrEmpty();
            if (!flag)
                flag = value.Trim().IsNullOrEmpty();
            return flag;
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static byte[] ToBytes(this string value, Encoding encode)
        {
            return encode.GetBytes(value);
        }
        
        public static byte[] ToBytes(this string value)
        {
            return value.ToBytes(Encoding.Default);
        }

        public static byte[] ToASCIIBytes(this string value)
        {
            return value.ToBytes(Encoding.ASCII);
        }
        
        /// <summary>
        /// 将字符串转为8 位无符号整数
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static byte ToSafeByte(this string strValue)
        {
            byte bytResult;

            if (byte.TryParse(strValue, out bytResult))
                return bytResult;

            return 0;
        }

        /// <summary>
        /// 将字符串转为16 位有符号整数
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static short ToInt16(this string strValue)
        {
            short shrtResult;

            if (short.TryParse(strValue, out shrtResult))
                return shrtResult;

            throw new InvalidCastException("不能将字符串\"" + strValue + "\"转换为短整形数字。");
        }

        /// <summary>
        /// 将字符串转为16 位有符号整数
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static short ToSafeInt16(this string strValue)
        {
            short shrtResult;

            if (short.TryParse(strValue, out shrtResult))
                return shrtResult;

            return 0;
        }

        /// <summary>
        /// 将字符串转为 32 位有符号整数
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static int ToInt(this string strValue)
        {
            int intResult;
            if (int.TryParse(strValue, out intResult))
                return intResult;

            throw new InvalidCastException("不能将字符串\"" + strValue + "\"转换为整形数字。");
        }

        /// <summary>
        /// 将字符串转为 32 位有符号整数
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static int ToSafeInt(this string strValue)
        {
            if (strValue.Contains(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator))
                return (int)strValue.ToSafeDouble();

            int intResult;

            if (int.TryParse(strValue, out intResult))
                return intResult;

            return 0;
        }

        /// <summary>
        /// 将字符串转为64 位有符号整数
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static long ToInt64(this string strValue)
        {
            long lngResult;

            if (long.TryParse(strValue, out lngResult))
                return lngResult;

            throw new InvalidCastException("不能将字符串\"" + strValue + "\"转换为长整形数字。");
        }

        /// <summary>
        /// 将字符串转为64 位有符号整数
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static long ToSafeInt64(this string strValue)
        {
            if (strValue.Contains(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator))
                return (long)strValue.ToSafeDouble();

            long lngResult;

            if (long.TryParse(strValue, out lngResult))
                return lngResult;

            return 0;
        }

        /// <summary>
        /// 将字符串转为64 位无符号整数
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static ulong ToSafeUlong(this string strValue)
        {
            if (string.IsNullOrWhiteSpace(strValue))
                return 0;

            if (strValue.Contains(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator))
                return (ulong)strValue.ToSafeDouble();

            ulong ulngResult;

            if (ulong.TryParse(strValue, out ulngResult))
                return ulngResult;

            return 0;
        }

        /// <summary>
        /// 将字符串转为数字型 128bit
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static Decimal ToDecimal(this string strValue)
        {
            Decimal dcmlResult;

            if (Decimal.TryParse(strValue, out dcmlResult))
                return dcmlResult;

            throw new InvalidCastException("不能将字符串\"" + strValue + "\"转换为Decimal数字。");
        }

        /// <summary>
        /// 将字符串转为数字型 128bit
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static Decimal ToSafeDecimal(this string strValue)
        {
            Decimal dcmlResult;

            if (Decimal.TryParse(strValue, out dcmlResult))
                return dcmlResult;

            return new Decimal(0);
        }

        /// <summary>
        /// 将字符串转为双精度实型64bit
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static double ToDouble(this string strValue)
        {
            double dblResult;

            if (double.TryParse(strValue, out dblResult))
                return dblResult;

            throw new InvalidCastException("不能将字符串\"" + strValue + "\"转换为double数字。");
        }

        /// <summary>
        /// 将字符串转为双精度实型64bit
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static double ToSafeDouble(this string strValue)
        {
            double dblResult;

            if (double.TryParse(strValue, out dblResult))
                return dblResult;

            return 0.0;
        }

        /// <summary>
        /// Str转DateTime
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime? ToNullableDateTime(this string datetime)
        {
            if (string.IsNullOrEmpty(datetime))
            {
                return null;
            }
            else
            {
                DateTime dt;
                if (DateTime.TryParse(datetime, out dt))
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
        }

        public static DateTime ToDateTime(this string datetime)
        {
            if (string.IsNullOrEmpty(datetime))
            {
                return DateTime.MinValue;
            }
            else
            {
                DateTime dt;
                if (DateTime.TryParse(datetime, out dt))
                {
                    return dt;
                }
                else
                {
                    return DateTime.MinValue;
                }
            }
        }


    }
}
