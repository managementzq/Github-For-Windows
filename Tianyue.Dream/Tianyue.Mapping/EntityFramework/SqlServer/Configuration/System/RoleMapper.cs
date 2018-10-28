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
    class RoleMapper : EntityTypeConfiguration<Role>
    {
        public RoleMapper()
        {
            //HasMany(e => e.lstRoleFunction).WithRequired(e => e.role).HasForeignKey(e => e.RID);
            HasKey(e => e.RID);

            Property(t => t.RID).HasColumnName("RID");
            Property(t => t.RoleName).HasColumnName("RoleName");
            Property(t => t.RoleCode).HasColumnName("RoleCode");
            Property(t => t.Sequence).HasColumnName("Sequence");
            Property(t => t.Description).HasColumnName("Description");
            Property(t => t.Disable).HasColumnName("Disable");
            Property(t => t.CreatedUser).HasColumnName("CreatedUser");
            Property(t => t.CreatedTime).HasColumnName("CreatedTime");
            Property(t => t.ModifiedUser).HasColumnName("ModifiedUser");
            Property(t => t.ModifiedTime).HasColumnName("ModifiedTime");

            ToTable("System_Role");
        }
    }

    /// <summary>
    /// Bom结构表的映射信息（Fluent API 配置）
    /// </summary>
    class RoleViewMapper : EntityTypeConfiguration<RoleView>
    {
        public RoleViewMapper()
        {
            HasKey(e => e.RID);

            Property(t => t.RID).HasColumnName("RID");
            Property(t => t.RoleName).HasColumnName("RoleName");
            Property(t => t.RoleCode).HasColumnName("RoleCode");
            Property(t => t.Sequence).HasColumnName("Sequence");
            Property(t => t.Description).HasColumnName("Description");
            Property(t => t.Disable).HasColumnName("Disable");
            Property(t => t.CreatedUserGuid).HasColumnName("CreatedUserGuid");
            Property(t => t.CreatedUserName).HasColumnName("CreatedUserName");
            Property(t => t.CreatedTime).HasColumnName("CreatedTime");
            Property(t => t.ModifiedUserGuid).HasColumnName("ModifiedUserGuid");
            Property(t => t.ModifiedUserName).HasColumnName("ModifiedUserName");
            Property(t => t.ModifiedTime).HasColumnName("ModifiedTime");


            ToTable("System_Role_V");
        }
    }
}
