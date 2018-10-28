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
    class RoleFunctionMapper : EntityTypeConfiguration<RoleFunction>
    {
        public RoleFunctionMapper()
        {
            HasKey(e => e.RFID);

            this.HasRequired(o => o.role).WithMany(o => o.lstRoleFunction).HasForeignKey(o => o.RID);
            this.HasRequired(o => o.function).WithMany(o => o.lstRoleFunction).HasForeignKey(o => o.FCID);

            Property(t => t.RFID).HasColumnName("RFID");
            Property(t => t.RID).HasColumnName("RID");
            Property(t => t.FCID).HasColumnName("FCID");
            Property(t => t.Description).HasColumnName("Description");
            Property(t => t.Disable).HasColumnName("Disable");
            Property(t => t.CreatedUser).HasColumnName("CreatedUser");
            Property(t => t.CreatedTime).HasColumnName("CreatedTime");
            Property(t => t.ModifiedUser).HasColumnName("ModifiedUser");
            Property(t => t.ModifiedTime).HasColumnName("ModifiedTime");

            ToTable("System_RoleFunction");
        }
    }

    /// <summary>
    /// Bom结构表的映射信息（Fluent API 配置）
    /// </summary>
    class RoleFunctionViewMapper : EntityTypeConfiguration<RoleFunctionView>
    {
        public RoleFunctionViewMapper()
        {
            HasKey(e => e.RFID);

            Property(t => t.RFID).HasColumnName("RFID");
            Property(t => t.RID).HasColumnName("RID");
            Property(t => t.RoleName).HasColumnName("RoleName");
            Property(t => t.CFID).HasColumnName("FCID");
            Property(t => t.FunctionName).HasColumnName("FunctionName");
            Property(t => t.Description).HasColumnName("Description");
            Property(t => t.Disable).HasColumnName("Disable");
            Property(t => t.CreatedUserGuid).HasColumnName("CreatedUserGuid");
            Property(t => t.CreatedUserName).HasColumnName("CreatedUserName");
            Property(t => t.CreatedTime).HasColumnName("CreatedTime");
            Property(t => t.ModifiedUserGuid).HasColumnName("ModifiedUserGuid");
            Property(t => t.ModifiedUserName).HasColumnName("ModifiedUserName");
            Property(t => t.ModifiedTime).HasColumnName("ModifiedTime");


            ToTable("System_RoleFunction_V");
        }
    }
}
