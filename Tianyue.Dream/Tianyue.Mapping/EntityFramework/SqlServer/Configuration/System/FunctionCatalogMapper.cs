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
    class FunctionCatalogMapper : EntityTypeConfiguration<FunctionCatalog>
    {
        public FunctionCatalogMapper()
        {
            HasKey(e => e.FCID);

            this.HasRequired(o => o.formPage).WithMany(o => o.lstFunctionCatalog).HasForeignKey(o => o.FPID);
            this.HasRequired(o => o.parentFunction).WithMany(o => o.lstChildrenFunction).HasForeignKey(o => o.PFCID);

            //// Relationships
            //this.HasRequired(t => t.parentFunction)
            //    .WithRequiredDependent(t => t.parentFunction);

            Property(t => t.FCID).HasColumnName("FCID");
            Property(t => t.PFCID).HasColumnName("PFCID");
            Property(t => t.FPID).HasColumnName("FPID");
            Property(t => t.FunctionName).HasColumnName("FunctionName");
            Property(t => t.FunctionCode).HasColumnName("FunctionCode");
            Property(t => t.CatalogIcon).HasColumnName("CatalogIcon");
            Property(t => t.Sequence).HasColumnName("Sequence");
            Property(t => t.Description).HasColumnName("Description");
            Property(t => t.Disable).HasColumnName("Disable");
            Property(t => t.CreatedUser).HasColumnName("CreatedUser");
            Property(t => t.CreatedTime).HasColumnName("CreatedTime");
            Property(t => t.ModifiedUser).HasColumnName("ModifiedUser");
            Property(t => t.ModifiedTime).HasColumnName("ModifiedTime");

            ToTable("System_FunctionCatalog");
        }
    }

    /// <summary>
    /// Bom结构表的映射信息（Fluent API 配置）
    /// </summary>
    class FunctionCatalogViewMapper : EntityTypeConfiguration<FunctionCatalogView>
    {
        public FunctionCatalogViewMapper()
        {
            HasKey(e => e.FCID);

            Property(t => t.FCID).HasColumnName("FCID");
            Property(t => t.FPID).HasColumnName("FPID");
            Property(t => t.FunctionName).HasColumnName("FunctionName");
            Property(t => t.FunctionCode).HasColumnName("FunctionCode");
            Property(t => t.CatalogIcon).HasColumnName("CatalogIcon");
            Property(t => t.PFCID).HasColumnName("PFCID");
            Property(t => t.ParentFunctionCode).HasColumnName("ParentFunctionCode");
            Property(t => t.ParentFunctionName).HasColumnName("ParentFunctionName");
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
            
            ToTable("System_FunctionCatalog_V");
        }
    }
}
