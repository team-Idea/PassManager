using data_access_library.Helpers;
using data_access_library.Helpers.Config;
using data_access_library.Repositories;
using Microsoft.EntityFrameworkCore;

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
