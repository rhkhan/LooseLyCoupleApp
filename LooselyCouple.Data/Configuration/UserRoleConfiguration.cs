using LooselyCouple.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooselyCouple.Data.Configuration
{
    public class UserRoleConfiguration : EntityTypeConfiguration<UserRole>
    {
        public UserRoleConfiguration()
        {
            ToTable("AspNetUserRoles");
            HasKey(r => new { r.roleId, r.userId });
           // Property(c => c.Name).IsRequired().HasMaxLength(10);
        }
    }
}
