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
    public class FormPage
    {
        [DataMember]
        [Description("页面ID")]
        public Guid FPID { get; set; }

        [DataMember]
        [Description("页面名称")]
        public string FormPageName { get; set; }

        [DataMember]
        [Description("页面编码")]
        public string FormPageCode { get; set; }

        /// <summary>
        /// 页面路径
        /// </summary>
        [DataMember]
        [Description("页面路径")]
        public string FormPageRoute { get; set; }

        [DataMember]
        [Description("页面参数")]
        public string FormPageParameter { get; set; }

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
        
        public virtual ICollection<FunctionCatalog> lstFunctionCatalog { get; set; }
    }


    [DataContract]
    public class FormPageView
    {
        [DataMember]
        [Description("页面ID")]
        public Guid FPID { get; set; }

        [DataMember]
        [Description("页面名称")]
        public string FormPageName { get; set; }

        [DataMember]
        [Description("页面编码")]
        public string FormPageCode { get; set; }

        /// <summary>
        /// 页面路径
        /// </summary>
        [DataMember]
        [Description("页面路径")]
        public string FormPageRoute { get; set; }

        [DataMember]
        [Description("页面参数")]
        public string FormPageParameter { get; set; }

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
