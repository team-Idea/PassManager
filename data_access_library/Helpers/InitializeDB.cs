using Microsoft.EntityFrameworkCore;
using data_access_library;
using static data_access_library.PasswordManagerDbContext;

namespace data_access_library.Helpers
{
    public static class InitializeDb
    {
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category
                {
                   Id = 1,
                   Name = "Logins"
                },
                new Category
                {
                   Id = 2,
                   Name = "Secure Notes"
                },
                new Category
                {
                   Id = 1,
                   Name = "Credit card"
                }
            });
        }
        public static void SeedItems(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(new Item[]
            {
                new Item
                {
                   Id = 1,
                   Name = "Login1",
                   SavedLogin = "Log11",
                   SavedPass = "Pass11",
                   UserId = 1,
                   CategoryId = 1,
                   IsFavourite = false

                },
                new Item
                {
                   Id = 2,
                   Name = "Note1",
                   SavedLogin = "Note For secret",
                   SavedPass = "NotePass1",
                   UserId = 1,
                   CategoryId = 2,
                   IsFavourite = true
                },
                new Item
                {
                   Id = 1,
                   Name = "Card1",
                   SavedLogin = "CardNum1",
                   SavedPass = "Svv1",
                   UserId = 1,
                   CategoryId = 3,
                   IsFavourite = false
                }
            });
        }
        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category
                {
                   Id = 1,
                   Name = "User1"
                }
            });
        }
    }
}
