using Microsoft.EntityFrameworkCore;
using data_access_library;
using static data_access_library.PasswordManagerDbContext;
using System;

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
                   Id = 3,
                   Name = "Credit card"
                }
            });
        }
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
        public static void SeedPersonalInfo(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personal_Info>().HasData(

                new Personal_Info
                {
                    Id = 2,
                    Name = "Note1",
                    Country = "Ukraine",
                    FirstName = "John",
                    LastName= "Wick",
                    FathersName = "Blaskovich",
                    UserName = "username1",
                    Company = "Company1",
                    Email = "blabla22@gmail.com",
                    PhoneNumber = "+380991232288",
                    UserId = 1,
                    CategoryId = 2,
                    IsFavourite = true
                }
            );
        }
        public static void SeedCreditCard(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Credit_Card>().HasData(

                new Credit_Card
                {
                    Id = 3,
                    Name = "Card1",
                    CardHolder = "John Wick",
                    CardNumber = "0000 0000 0000 9000",
                    CartTypeId = 1,
                    UserId = 1,
                    CategoryId = 3,
                    DateExpired = new DateTime(2026, 01, 01),
                    CVV = "123"

                }
            );
        }


        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
            
                new User
                {
                   Id = 1,
                   Login = "Login1",
                   Password = "1111"
                  
                }
            );
        }
        public static void SeedCardTypes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardType>().HasData(new CardType[]
            {
                new CardType
                {
                    Id = 1,
                    Name = "Visa"

                },
                new CardType
                {
                    Id = 2,
                    Name = "MasterCard"

                }

            }

            );
        }
    }
}
