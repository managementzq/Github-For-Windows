using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tianyue.Utility.Extension
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// 时间格式化：1900-01-01
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string ToDateString(this DateTime time)
        {
            return time.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 时间格式化：1900-01-01 00:00
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string ToDateHHmmString(this DateTime time)
        {
            return time.ToString("yyyy-MM-dd HH:mm");
        }

        /// <summary>
        /// 时间格式化：00:00
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string ToTimeHHmmString(this DateTime time)
        {
            return time.ToString("HH:mm");
        }

        /// <summary>
        /// 时间格式化：1900-01-01 00:00:00
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string ToDateTimeString(this DateTime time)
        {
            return time.ToString("yyyy-MM-dd HH:mm:ss");
        }


        /// <summary>
        /// 时间格式化：2015-01-01 00：00：00
        /// </summary>
        /// <param name="startDt"></param>
        /// <returns></returns>
        public static DateTime FormatWithMinHours(this DateTime startDt)
        {
            string t = startDt.ToDateString() + " 00:00:00";
            return DateTime.Parse(t);
        }

        /// <summary>
        /// 时间格式化：2015-01-01 23：59：59
        /// </summary>
        /// <param name="startDt"></param>
        /// <returns></returns>
        public static DateTime FormatWithMaxHours(this DateTime endDt)
        {
            string t = endDt.ToDateString() + " 23:59:59";
            return DateTime.Parse(t);
        }

    }
}
