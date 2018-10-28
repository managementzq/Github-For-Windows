using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tianyue.Utility.Helper
{
    public class CharacterHelper
    {
        //全角转半角的函数(DBC case)
        /// <summary>
        /// 全角转半角的函数(DBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>半角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>
        public static string ToDBC(string input)
        {
            var c = input.ToCharArray();
            for (var i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }

            return new string(c);
        }

        //判断字符是否为全角字符
        /// <summary>
        /// 判断字符是否为全角字符
        /// </summary>
        /// <param name="c">任意字符</param>
        /// <returns>全角字符返回true,半角返回false</returns>
        private static bool IsCharSBC(char c)
        {
            return c > 65280 && c < 65375;
        }

        //判断字符串是否包含全角字符
        /// <summary>
        /// 判断字符串是否包含全角字符
        /// </summary>
        /// <param name="s">任意字符串</param>
        /// <returns>全角字符返回true,半角返回false</returns>
        public static bool IsContainsSBC(string s)
        {
            foreach (var c in s)
            {
                if (IsCharSBC(c))
                    return true;
            }

            return false;
        }

        //半角转全角的函数(SBC case)
        /// <summary>
        /// 半角转全角的函数(SBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>全角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>        
        public static string ToSBC(string input)
        {
            //半角转全角：
            var c = input.ToCharArray();
            for (var i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }

            return new string(c);
        }
    }
}
