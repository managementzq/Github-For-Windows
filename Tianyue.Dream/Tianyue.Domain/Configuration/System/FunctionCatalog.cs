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
    public class FunctionCatalog
    {
        [DataMember]
        [Description("功能目录ID")]
        public Guid FCID { get; set; }

        [DataMember]
        [Description("父目录ID")]
        public Guid? PFCID { get; set; }

        [DataMember]
        [Description("页面ID")]
        public Guid? FPID { get; set; }
        
        [DataMember]
        [Description("功能名称")]
        public string FunctionName { get; set; }

        [DataMember]
        [Description("功能编码")]
        public string FunctionCode { get; set; }

        [DataMember]
        [Description("目录图标")]
        public string CatalogIcon { get; set; }

        [DataMember]
        [Description("排序")]
        public int Sequence { get; set; }

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
        public virtual FormPage formPage { get; set; }

        /// <summary>
        /// 对应的用户对象
        /// </summary>
        public virtual FunctionCatalog parentFunction { get; set; }

        public virtual ICollection<RoleFunction> lstRoleFunction { get; set; }

        public virtual ICollection<FunctionCatalog> lstChildrenFunction { get; set; }
    }


    [DataContract]
    public class FunctionCatalogView
    {

        [DataMember]
        [Description("功能目录ID")]
        public Guid FCID { get; set; }

        [DataMember]
        [Description("功能名称")]
        public string FunctionName { get; set; }

        [DataMember]
        [Description("功能编码")]
        public string FunctionCode { get; set; }

        [DataMember]
        [Description("目录图标")]
        public string CatalogIcon { get; set; }

        [DataMember]
        [Description("父目录ID")]
        public Guid? PFCID { get; set; }

        [DataMember]
        [Description("父目录编码")]
        public string ParentFunctionCode { get; set; }

        [DataMember]
        [Description("父目录名称")]
        public string ParentFunctionName { get; set; }

        [DataMember]
        [Description("页面ID")]
        public Guid? FPID { get; set; }

        [DataMember]
        [Description("页面名称")]
        public string FormPageName { get; set; }

        [DataMember]
        [Description("页面编码")]
        public string FormPageCode { get; set; }

        [DataMember]
        [Description("页面路径")]
        public string FormPageRoute { get; set; }

        [DataMember]
        [Description("页面参数")]
        public string FormPageParameter { get; set; }
        
        [DataMember]
        [Description("顺序")]
        public int Sequence { get; set; }

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
