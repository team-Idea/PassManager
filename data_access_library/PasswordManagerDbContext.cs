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
        public PasswordManagerDbContext()
        {
            //this.Database.EnsureDeleted();
            //this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //MSSQLLocalDB
            //data source needs to be changed to specific source
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=MusicDBContext;Integrated Security=true;Connect Timeout=2");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new ElementConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new CardConfig());
            modelBuilder.ApplyConfiguration(new InfoConfig());
            modelBuilder.ApplyConfiguration(new LoginConfig());

            //modelBuilder.SeedCategories();
            //modelBuilder.SeedItems();
            //modelBuilder.SeedUsers();
        }

        //Collections
        public DbSet<User> Users { get; set; }
        public DbSet<Login_Item> Logins { get; set; }
        public DbSet<Credit_Card> Cards { get; set; }
        public DbSet<Personal_Info> Infos { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
