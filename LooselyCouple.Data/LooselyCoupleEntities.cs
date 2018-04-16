using LooselyCouple.Data.Configuration;
using LooselyCouple.Model.Models;
//using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooselyCouple.Data //, AspRoles,int, UserLogin, UserRole, UserClaim
{
    public class LooselyCoupleEntities : DbContext //IdentityDbContext<Register>  // IdentityDbContext<ApplicationUser> // DbContext //IdentityDbContext<ApplicationUser>
    {
        public LooselyCoupleEntities():base("DefaultConnection"){}

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        public DbSet<AspRoles> aspRoles { get; set; }
        public DbSet<Register> users { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Permission> permissions { get; set; }
        public DbSet<RolePermission> rolePermissions { get; set; }
        public DbSet<Appointment> appointments { get; set; }

        public static LooselyCoupleEntities Create()
        {
            return new LooselyCoupleEntities();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new RegisterConfiguration());
            modelBuilder.Configurations.Add(new AspRolesConfiguration());
            modelBuilder.Configurations.Add(new UserRoleConfiguration());
            modelBuilder.Configurations.Add(new PermissionConfiguration());
            modelBuilder.Configurations.Add(new RolePermissionConfiguration());
            modelBuilder.Configurations.Add(new AppointmentConfiguration());
            //modelBuilder.Entity<UserRole>().ToTable("UserRole");
            //modelBuilder.Entity<UserLogin>().ToTable("AspNetUserLogins");

            modelBuilder.Entity<UserLogin>().HasKey<string>(l => l.UserId);
            //modelBuilder.Entity<UserRole>().HasKey(r => new { r.RoleId, r.UserId });

            modelBuilder.Entity<UserClaim>().ToTable("AspNetUserClaims");
            modelBuilder.Entity<UserClaim>().Property(u => u.ClaimType).HasMaxLength(150);
            modelBuilder.Entity<UserClaim>().Property(u => u.ClaimValue).HasMaxLength(500);
            //modelBuilder.IncludeMetadataInDatabase = false // To avoid migration in code-first if table changes

            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            //modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            //modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}
