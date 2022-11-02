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
            optionsBuilder.UseSqlServer("DefaultConnection");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new CardTypeConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new CardConfig());
            modelBuilder.ApplyConfiguration(new InfoConfig());
            modelBuilder.ApplyConfiguration(new LoginConfig());

            modelBuilder.SeedCardTypes();
            modelBuilder.SeedCategories();
            modelBuilder.SeedCreditCard();
            modelBuilder.SeedLogin();
            modelBuilder.SeedPersonalInfo();
            modelBuilder.SeedUsers();

        }

        //Collections
        public DbSet<User> Users { get; set; }
        public DbSet<Login_Item> Logins { get; set; }
        public DbSet<Credit_Card> Cards { get; set; }
        public DbSet<Personal_Info> Infos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
    }
}
