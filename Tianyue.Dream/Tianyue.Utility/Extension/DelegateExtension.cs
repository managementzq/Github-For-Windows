using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tianyue.Utility.Extension
{
    /// <summary>
    /// Func and Predicate Extension
    /// Author: Minghua
    /// </summary>
    public static class DelegateExtension
    {
        public static Predicate<T> ToPredicate<T>(this Func<T, bool> source)
        {
            Predicate<T> result = new Predicate<T>(source);
            return result;
        }
    }
}
