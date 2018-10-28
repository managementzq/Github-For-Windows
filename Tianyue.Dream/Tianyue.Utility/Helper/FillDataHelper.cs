using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tianyue.Utility.Common;
using Tianyue.Utility.Extension;

namespace Tianyue.Utility.Helper
{
    /// <summary>
    /// Fill Data Helper
    /// Author: Minghua
    /// </summary>
    public static class FillDataHelper
    {
        public static string GetTxtIfNotEmpty<T>(this T txtBox, Predicate<T> input) where T : TextBoxBase
        {
            if (input.Invoke(txtBox))
            {
                return txtBox.Text.TrimEnd();
            }
            else
            {
                return null;
            }
        }

        public static string GetTxtIfNotEmpty<T>(this T txtBox) where T : TextBoxBase
        {
            Predicate<T> input = p => !string.IsNullOrWhiteSpace(p.Text);
            return GetTxtIfNotEmpty(txtBox, input);
        }

        public static string GetControlTxtIfNotEmpty<T>(this T txtBox, Predicate<T> input) where T : Control
        {
            if (input.Invoke(txtBox))
            {
                return txtBox.Text.TrimEnd();
            }
            else
            {
                return null;
            }
        }

        public static string GetControlTxtIfNotEmpty<T>(this T txtBox) where T : Control
        {
            Predicate<T> input = p => !string.IsNullOrWhiteSpace(p.Text);
            return GetControlTxtIfNotEmpty(txtBox, input);
        }

        public static DateTime? GetDateTimeIfNotEmpty<T>(this T dtPicker, Predicate<T> input) where T : DateTimePicker
        {
            if (input.Invoke(dtPicker))
            {
                return dtPicker.Value;
            }
            else
            {
                return null;
            }
        }

        public static DateTime? GetDateTimeIfNotEmpty<T>(this T dtPicker) where T : DateTimePicker
        {
            Predicate<T> input = p => !string.IsNullOrWhiteSpace(p.Text);
            return GetDateTimeIfNotEmpty(dtPicker, input);
        }
    }

}
