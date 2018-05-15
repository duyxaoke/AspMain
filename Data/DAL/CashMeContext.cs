
using Core.Data;
using Data.Mapping;
using Microsoft.AspNet.Identity.EntityFramework;
using Shared.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Data.DAL
{
    public class CashMeContext : IdentityDbContext<ApplicationUser, IdentityRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        public CashMeContext() : base("name=DbConnect")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CashMeContext, CashMeInitializer>());//initial database use test data            
        }

        public static CashMeContext Create()
        {
            return new CashMeContext();
        }

        //DbContext
        public DbSet<Message> Message { get; set; }
        public DbSet<Config> Config { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuInRoles> MenuInRoles { get; set; }

        //Auth

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new ConfigMap());
            modelBuilder.Configurations.Add(new MenuMap());
            modelBuilder.Configurations.Add(new MenuInRolesMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
