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
    class UserRoleMapper : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMapper()
        {
            HasKey(e => e.URID);
            
            this.HasRequired(o => o.user).WithMany(o => o.lstUserRole).HasForeignKey(o => o.UID);
            this.HasRequired(o => o.role).WithMany(o => o.lstUserRole).HasForeignKey(o => o.RID);

            Property(t => t.URID).HasColumnName("URID");
            Property(t => t.UID).HasColumnName("UID");
            Property(t => t.RID).HasColumnName("RID");
            Property(t => t.Description).HasColumnName("Description");
            Property(t => t.Disable).HasColumnName("Disable");
            Property(t => t.CreatedUser).HasColumnName("CreatedUser");
            Property(t => t.CreatedTime).HasColumnName("CreatedTime");
            Property(t => t.ModifiedUser).HasColumnName("ModifiedUser");
            Property(t => t.ModifiedTime).HasColumnName("ModifiedTime");

            ToTable("System_UserRole");
        }
    }

    /// <summary>
    /// Bom结构表的映射信息（Fluent API 配置）
    /// </summary>
    class UserRoleViewMapper : EntityTypeConfiguration<UserRoleView>
    {
        public UserRoleViewMapper()
        {
            HasKey(e => e.URID);

            Property(t => t.URID).HasColumnName("URID");
            Property(t => t.UID).HasColumnName("UID");
            Property(t => t.UserName).HasColumnName("UserName");
            Property(t => t.RID).HasColumnName("RID");
            Property(t => t.RoleName).HasColumnName("RoleName");
            Property(t => t.Description).HasColumnName("Description");
            Property(t => t.Disable).HasColumnName("Disable");
            Property(t => t.CreatedUserGuid).HasColumnName("CreatedUserGuid");
            Property(t => t.CreatedUserName).HasColumnName("CreatedUserName");
            Property(t => t.CreatedTime).HasColumnName("CreatedTime");
            Property(t => t.ModifiedUserGuid).HasColumnName("ModifiedUserGuid");
            Property(t => t.ModifiedUserName).HasColumnName("ModifiedUserName");
            Property(t => t.ModifiedTime).HasColumnName("ModifiedTime");
            
            ToTable("System_UserRole_V");
        }
    }
}
