using Microsoft.EntityFrameworkCore;
using data_access_library;
using static data_access_library.PasswordManagerDbContext;
using System;

namespace data_access_library.Helpers
{
    public static class InitializeDb
    {
        public static void SeedLogin(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login_Item>().HasData(
            
                new Login_Item
                {
                   Id = 1,
                   Name = "Login1",
                   SavedLogin = "Log11",
                   SavedPassword = "Pass11",
                   UserId = 1,
                   CategoryId = 1
                   
                }
            );
        }

        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginItem>().HasData(
            
                new LoginItem
                {
                   Id = 1,
                   Login = "Login1",
                   Password = "1111"
                  
                }
            );
        }
    }
}
