using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tianyue.Utility.Helper
{
    /// <summary>
    /// 输入校验
    /// </summary>
    public class InputValidationHelper
    {
        /// <summary>
        /// 基础校验
        /// </summary>
        /// <param name="val">值</param>
        /// <param name="maxlen">最大长度</param>
        /// <param name="rules">正则表达式规则</param>
        /// <returns></returns>
        private static bool BasicValidate(string val, int maxlen, string rules)
        {
            try
            {
                if (string.IsNullOrEmpty(val))
                    return false;
                if (Regex.IsMatch(val, rules))
                {
                    if (maxlen != 0)
                    {
                        return val.Length <= maxlen;
                    }

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                string errStr = string.Format("BasicValidate failed. val {0} ,maxlen {1} ,rules {2}.", val, maxlen, rules);
                //LogRepository.WriteDB(null, "", "", "", "", errStr, 0, "", false);
                //LogRepository.WriteDB(null, "", "", "", "", ex.StackTrace, 0, "", false);
                return false;
            }

        }

        #region 数字输入校验

        /// <summary>
        /// 只允许输入数字
        /// </summary>
        /// <param name="val">输入值</param>
        /// <param name="maxlen">长度（默认为0，表示不限制）</param>
        /// <returns></returns>
        public bool OnlyNumber(string val, int maxlen = 0)
        {
            return BasicValidate(val, maxlen, "^[0-9]+$");
        }

        /// <summary>
        /// 正整数
        /// </summary>
        /// <param name="val">输入的值</param>
        /// <param name="min">最小值（默认为0，表示不限制）</param>
        /// <param name="max">最大值（默认为0，表示不限制）</param>
        /// <returns></returns>
        public bool PositiveInteger(string val, int min = 0, int max = 0)
        {
            try
            {
                if (string.IsNullOrEmpty(val))
                    return false;
                if (Regex.IsMatch(val, "^[0-9]*[1 - 9][0 - 9]*$"))
                {
                    if (min > 0)
                    {
                        if (int.Parse(val) < min)
                        {
                            return false;
                        }
                    }

                    if (max > 0)
                    {
                        if (int.Parse(val) > min)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                string errStr = string.Format("BasicValidate PositiveInteger failed. val {0} ,min {1} ,max {2}.", val, min, max);
                //LogRepository.WriteDB(null, "", "", "", "", errStr, 0, "", false);
                //LogRepository.WriteDB(null, "", "", "", "", ex.StackTrace, 0, "", false);
                return false;
            }
        }

        /// <summary>
        /// 正数(含小数点）
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool PositiveNumber(string val, double min = 0, double max = 0)
        {
            try
            {
                if (string.IsNullOrEmpty(val))
                    return false;
                if (Regex.IsMatch(val, @"^[1-9]\d*\.\d*|0\.\d*[1-9]\d*$ "))
                {
                    if (min > 0)
                    {
                        if (double.Parse(val) < min)
                        {
                            return false;
                        }
                    }

                    if (max > 0)
                    {
                        if (double.Parse(val) > min)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                string errStr = string.Format("BasicValidate PositiveInteger failed. val {0} ,min {1} ,max {2}.", val, min, max);
                //LogRepository.WriteDB(null, "", "", "", "", errStr, 0, "", false);
                //LogRepository.WriteDB(null, "", "", "", "", ex.StackTrace, 0, "", false);
                return false;
            }
        }

        #endregion

        //　只能输入由数字和26个英文字母组成的字符串："^[A-Za-z0-9]+$"
        /// <summary>
        /// 只允许输入字母
        /// </summary>
        /// <param name="val">输入值</param>
        /// <param name="len">最大长度（默认为0，表示不限制）</param>
        /// <returns></returns>
        public bool OnlyLetters(string val, int maxlen = 0)
        {
            return BasicValidate(val, maxlen, "^[A-Za-z]+$");
        }

        /// <summary>
        /// 只允许输入数字和字母
        /// </summary>
        /// <param name="val">输入值</param>
        /// <param maxlen="len">最大长度（默认为0，表示不限制）</param>
        /// <returns></returns>
        public bool OnlyNumberAndLetters(string val, int maxlen = 0)
        {
            return BasicValidate(val, maxlen, "^[A-Za-z0-9]+$");
        }

    }
}
