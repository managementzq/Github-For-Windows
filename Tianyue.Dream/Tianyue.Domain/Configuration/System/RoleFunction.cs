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
    public class RoleFunction
    {
        [DataMember]
        [Description("ID")]
        public Guid RFID { get; set; }

        [DataMember]
        [Description("角色ID")]
        public Guid RID { get; set; }
        
        [DataMember]
        [Description("功能ID")]
        public Guid FCID { get; set; }
        
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
        public virtual Role role { get; set; }
        
        /// <summary>
        /// 对应的用户对象
        /// </summary>
        public virtual FunctionCatalog function { get; set; }
    }


    [DataContract]
    public class RoleFunctionView
    {
        [DataMember]
        [Description("ID")]
        public Guid RFID { get; set; }

        [DataMember]
        [Description("角色ID")]
        public Guid RID { get; set; }

        [DataMember]
        [Description("角色名称")]
        public string RoleName { get; set; }

        //[DataMember]
        //[Description("角色编码")]
        //public string RoleCode { get; set; }

        [DataMember]
        [Description("功能ID")]
        public Guid CFID { get; set; }

        [DataMember]
        [Description("功能名称")]
        public string FunctionName { get; set; }
        
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
