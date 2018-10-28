using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tianyue.QueryObject.User
{
    public class UserProfile
    {

        [DataMember]
        [Description("用户Guid")]
        public Guid UID { get; set; }


        [DataMember]
        [Description("用户简况")]
        public Guid UPID { get; set; }


    }
}
