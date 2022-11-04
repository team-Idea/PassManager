using data_access_library.Helpers;
using data_access_library.Helpers.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace data_access_library
{
    public partial class PasswordManagerDbContext : DbContext
    {
        // Update-database -Project data_access_library
        // Add-migration (migrationName) -Project data_access_library
        public PasswordManagerDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //MSSQLLocalDB
            //data source needs to be changed to specific source
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PassDB;Integrated Security=true;Connect Timeout=2");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new LoginConfig());

            modelBuilder.SeedLogin();
            modelBuilder.SeedUsers();

        }

        //Collections
        public DbSet<User> Users { get; set; }
        public DbSet<Login_Item> Logins { get; set; }
    }
}
