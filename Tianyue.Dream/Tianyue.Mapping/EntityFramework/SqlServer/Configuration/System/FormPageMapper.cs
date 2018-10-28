using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Domain.Configuration;

namespace Tianyue.Mapping.EntityFramework.SqlServer
{
    /// <summary>
    /// Bom结构表的映射信息（Fluent API 配置）
    /// </summary>
    class FormPageMapper : EntityTypeConfiguration<FormPage>
    {
        public FormPageMapper()
        {
            HasKey(e => e.FPID);

            Property(t => t.FPID).HasColumnName("FPID");
            Property(t => t.FormPageName).HasColumnName("FormPageName");
            Property(t => t.FormPageCode).HasColumnName("FormPageCode");
            Property(t => t.FormPageRoute).HasColumnName("FormPageRoute");
            Property(t => t.FormPageParameter).HasColumnName("FormPageParameter");
            Property(t => t.Sequence).HasColumnName("Sequence");
            Property(t => t.Description).HasColumnName("Description");
            Property(t => t.Disable).HasColumnName("Disable");
            Property(t => t.CreatedUser).HasColumnName("CreatedUser");
            Property(t => t.CreatedTime).HasColumnName("CreatedTime");
            Property(t => t.ModifiedUser).HasColumnName("ModifiedUser");
            Property(t => t.ModifiedTime).HasColumnName("ModifiedTime");

            ToTable("System_FormPage");
        }
    }

    /// <summary>
    /// Bom结构表的映射信息（Fluent API 配置）
    /// </summary>
    class FormPageViewMapper : EntityTypeConfiguration<FormPageView>
    {
        public FormPageViewMapper()
        {
            HasKey(e => e.FPID);
            
            Property(t => t.FPID).HasColumnName("FPID");
            Property(t => t.FormPageName).HasColumnName("FormPageName");
            Property(t => t.FormPageCode).HasColumnName("FormPageCode");
            Property(t => t.FormPageRoute).HasColumnName("FormPageRoute");
            Property(t => t.FormPageParameter).HasColumnName("FormPageParameter");
            Property(t => t.Sequence).HasColumnName("Sequence");
            Property(t => t.Description).HasColumnName("Description");
            Property(t => t.Disable).HasColumnName("Disable");
            Property(t => t.CreatedUserGuid).HasColumnName("CreatedUserGuid");
            Property(t => t.CreatedUserName).HasColumnName("CreatedUserName");
            Property(t => t.CreatedTime).HasColumnName("CreatedTime");
            Property(t => t.ModifiedUserGuid).HasColumnName("ModifiedUserGuid");
            Property(t => t.ModifiedUserName).HasColumnName("ModifiedUserName");
            Property(t => t.ModifiedTime).HasColumnName("ModifiedTime");
            
            ToTable("System_FormPage_V");
        }
    }
}
