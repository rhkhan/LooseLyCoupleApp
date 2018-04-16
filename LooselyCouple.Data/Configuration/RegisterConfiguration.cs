using LooselyCouple.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooselyCouple.Data.Configuration
{
    public class RegisterConfiguration : EntityTypeConfiguration<Register>
    {
        public RegisterConfiguration()
        {
            ToTable("AspNetUsers");
           // Property(c => c.Name).IsRequired().HasMaxLength(10);
        }
    }
}
