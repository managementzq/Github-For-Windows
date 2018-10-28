using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Tianyue.Utility.Extension;

namespace Tianyue.Utility.Common
{
    public static class Guard
    {
        public static void ArgumentNotNull(object value, string argumentName)
        {
            if (value == null)
                //throw new ArgumentNullException(argumentName, string.Format(DefaultErrorMessages.ArgumentNotNull, (object)argumentName));
                throw new ArgumentNullException(argumentName, string.Format("", (object)argumentName));
        }

        public static void ArgumentNotNullOrEmpty(string value, string argumentName)
        {
            if (value.IsNullOrEmptyOrWhiteSpace())
                //throw new ArgumentNullException(argumentName, string.Format(DefaultErrorMessages.ArgumentNotNullOrEmpty, (object)argumentName));
                throw new ArgumentNullException(argumentName, string.Format("", (object)argumentName));
        }
    }
}
