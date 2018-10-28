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
    public class User
    {
        public User()
        {
        }

        [DataMember]
        [Description("用户Guid")]
        public Guid UID { get; set; }

        [DataMember]
        [Description("用户名")]
        public string UserName { get; set; }

        [DataMember]
        [Description("用户唯一ID")]
        public string UserUniqueId { get; set; }

        [DataMember]
        [Description("昵称")]
        public string Nickname { get; set; }

        [DataMember]
        [Description("密码:MD5加密")]
        public string Password { get; set; }

        [DataMember]
        [Description("用户类型")]
        public string UserType { get; set; }

        [DataMember]
        [Description("邮箱地址")]
        public string EmailAddress { get; set; }

        [DataMember]
        [Description("电话号码")]
        public string PhoneNumber { get; set; }

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
        
        public virtual ICollection<UserRole> lstUserRole { get; set; }

    }


    [DataContract]
    public class UserView
    {
        [DataMember]
        [Description("用户Guid")]
        public Guid UID { get; set; }

        [DataMember]
        [Description("用户名")]
        public string UserName { get; set; }

        [DataMember]
        [Description("用户名")]
        public string UserUniqueId { get; set; }

        [DataMember]
        [Description("昵称")]
        public string Nickname { get; set; }

        [DataMember]
        [Description("密码:MD5加密")]
        public string Password { get; set; }

        [DataMember]
        [Description("用户类型")]
        public string UserType { get; set; }

        [DataMember]
        [Description("邮箱地址")]
        public string EmailAddress { get; set; }

        [DataMember]
        [Description("电话号码")]
        public string PhoneNumber { get; set; }

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
