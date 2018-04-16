using LooselyCouple.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooselyCouple.Data.Configuration
{
    public class RolePermissionConfiguration:EntityTypeConfiguration<RolePermission>
    {
        public RolePermissionConfiguration() 
        {
            ToTable("AspNetRolePermission");
            HasKey(r => new { r.RoleId, r.PermissionId });
        }
    }
}
