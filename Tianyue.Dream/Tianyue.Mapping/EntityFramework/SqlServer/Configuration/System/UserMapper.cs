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
    class UserMapper : EntityTypeConfiguration<User>
    {
        public UserMapper()
        {
            //HasMany(e => e.lstUserRole).WithRequired(e => e.user).HasForeignKey(e => e.UID);
            HasKey(e => e.UID);

            Property(t => t.UID).HasColumnName("UID");
            Property(t => t.UserName).HasColumnName("UserName");
            Property(t => t.UserUniqueId).HasColumnName("UserUniqueId");
            Property(t => t.Nickname).HasColumnName("Nickname");
            Property(t => t.Password).HasColumnName("Password");
            Property(t => t.UserType).HasColumnName("UserType");
            Property(t => t.EmailAddress).HasColumnName("EmailAddress");
            Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            Property(t => t.Description).HasColumnName("Description");
            Property(t => t.Disable).HasColumnName("Disable");
            Property(t => t.CreatedUser).HasColumnName("CreatedUser");
            Property(t => t.CreatedTime).HasColumnName("CreatedTime");
            Property(t => t.ModifiedUser).HasColumnName("ModifiedUser");
            Property(t => t.ModifiedTime).HasColumnName("ModifiedTime");

            ToTable("System_User");
        }
    }

    /// <summary>
    /// Bom结构表的映射信息（Fluent API 配置）
    /// </summary>
    class UserViewMapper : EntityTypeConfiguration<UserView>
    {
        public UserViewMapper()
        {
            HasKey(e => e.UID);

            Property(t => t.UID).HasColumnName("UID");
            Property(t => t.UserName).HasColumnName("UserName");
            Property(t => t.UserUniqueId).HasColumnName("UserUniqueId");
            Property(t => t.Nickname).HasColumnName("Nickname");
            Property(t => t.Password).HasColumnName("Password");
            Property(t => t.UserType).HasColumnName("UserType");
            Property(t => t.EmailAddress).HasColumnName("EmailAddress");
            Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            Property(t => t.Description).HasColumnName("Description");
            Property(t => t.Disable).HasColumnName("Disable");
            Property(t => t.CreatedUserGuid).HasColumnName("CreatedUserGuid");
            Property(t => t.CreatedUserName).HasColumnName("CreatedUserName");
            Property(t => t.CreatedTime).HasColumnName("CreatedTime");
            Property(t => t.ModifiedUserGuid).HasColumnName("ModifiedUserGuid");
            Property(t => t.ModifiedUserName).HasColumnName("ModifiedUserName");
            Property(t => t.ModifiedTime).HasColumnName("ModifiedTime");


            ToTable("System_User_V");
        }
    }
}
