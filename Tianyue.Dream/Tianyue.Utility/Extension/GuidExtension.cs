using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tianyue.Utility.Extension
{
    public static class GuidExtension
    {
        public static bool IsNotNullOrEmpty(this Guid guid)
        {
            return guid != null && guid != Guid.Empty;
        }

        public static bool IsNullOrEmpty(this Guid guid)
        {
            return guid == null || guid == Guid.Empty;
        }
    }
}
