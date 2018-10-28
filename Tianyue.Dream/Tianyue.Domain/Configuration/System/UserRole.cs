using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tianyue.Domain.Configuration
{

    [DataContract]
    public class UserRole
    {
        [DataMember]
        [Description("ID")]
        public Guid URID { get; set; }

        [DataMember]
        [Description("用户ID")]
        public Guid UID { get; set; }

        [DataMember]
        [Description("角色ID")]
        public Guid RID { get; set; }
        
        [DataMember]
        [Description("描述备注")]
        public string Description { get; set; }

        [DataMember]
        [Description("是否启用： 0 启用，1 禁用")]
        public bool Disable { get; set; }

        [DataMember]
        [Description("创建人")]
        public Guid CreatedUser { get; set; }

        [DataMember]
        [Description("创建时间")]
        public DateTime CreatedTime { get; set; }

        [DataMember]
        [Description("创建人")]
        public Guid? ModifiedUser { get; set; }

        [DataMember]
        [Description("修改时间")]
        public DateTime? ModifiedTime { get; set; }
        
        /// <summary>
        /// 对应的用户对象
        /// </summary>
        public virtual User user { get; set; }
        
        /// <summary>
        /// 对应的用户对象
        /// </summary>
        public virtual Role role { get; set; }
    }


    [DataContract]
    public class UserRoleView
    {
        [DataMember]
        [Description("ID")]
        public Guid URID { get; set; }

        [DataMember]
        [Description("用户ID")]
        public Guid UID { get; set; }

        [DataMember]
        [Description("用户名")]
        public string UserName { get; set; }
        
        [DataMember]
        [Description("角色ID")]
        public Guid RID { get; set; }

        [DataMember]
        [Description("角色名称")]
        public string RoleName { get; set; }

        [DataMember]
        [Description("描述备注")]
        public string Description { get; set; }

        [DataMember]
        [Description("是否启用： 0 启用，1 禁用")]
        public bool Disable { get; set; }

        [DataMember]
        [Description("创建人Guid")]
        public Guid CreatedUserGuid { get; set; }

        [DataMember]
        [Description("创建人")]
        public string CreatedUserName { get; set; }

        [DataMember]
        [Description("创建时间")]
        public DateTime CreatedTime { get; set; }

        [DataMember]
        [Description("创建人Guid")]
        public Guid? ModifiedUserGuid { get; set; }

        [DataMember]
        [Description("修改人")]
        public string ModifiedUserName { get; set; }

        [DataMember]
        [Description("修改时间")]
        public DateTime? ModifiedTime { get; set; }

        //public virtual UserProfile UserProfile { get; set; }
    }
}
