using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tianyue.Utility.Extension
{
    public static class ObjectExtension
    {
        public static bool IsNotNull(this object obj)
        {
            return obj != null && obj != DBNull.Value;
        }

        public static bool IsNull(this object obj)
        {
            return obj == null || obj == DBNull.Value;
        }

        public static string ToSafeString(this object obj)
        {
            if (obj == null)
                return string.Empty;
            return obj.ToString();
        }
    }
}
