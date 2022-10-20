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
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-QO1ORR9\SQLEXPRESS01;Initial Catalog=MusicDBContext;Integrated Security=true;Connect Timeout=2");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new ItemConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());

            //modelBuilder.SeedCategories();
            //modelBuilder.SeedItems();
            //modelBuilder.SeedUsers();
        }

        //Collections
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
