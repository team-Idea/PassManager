﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using data_access_library;

namespace data_access_library.Migrations
{
    [DbContext(typeof(PasswordManagerDbContext))]
    partial class PasswordManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("data_access_library.PasswordManagerDbContext+CardType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("CardTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Visa"
                        },
                        new
                        {
                            Id = 2,
                            Name = "MasterCard"
                        });
                });

            modelBuilder.Entity("data_access_library.PasswordManagerDbContext+Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Logins"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Secure Notes"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Credit card"
                        });
                });

            modelBuilder.Entity("data_access_library.PasswordManagerDbContext+Credit_Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CVV")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CardHolder")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CartTypeId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateExpired")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 10, 26, 0, 51, 13, 429, DateTimeKind.Local).AddTicks(636));

                    b.Property<bool>("IsFavourite")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartTypeId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            CVV = "123",
                            CardHolder = "John Wick",
                            CardNumber = "0000 0000 0000 9000",
                            CartTypeId = 1,
                            CategoryId = 3,
                            DateExpired = new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsFavourite = false,
                            Name = "Card1",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("data_access_library.PasswordManagerDbContext+Login_Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsFavourite")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SavedLogin")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SavedPassword")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Logins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            IsFavourite = false,
                            Name = "Login1",
                            SavedLogin = "Log11",
                            SavedPassword = "Pass11",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("data_access_library.PasswordManagerDbContext+Personal_Info", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FathersName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsFavourite")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Infos");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Company = "Company1",
                            Country = "Ukraine",
                            Email = "blabla22@gmail.com",
                            FathersName = "Blaskovich",
                            FirstName = "John",
                            IsFavourite = true,
                            LastName = "Wick",
                            Name = "Note1",
                            PhoneNumber = "+380991232288",
                            UserId = 1,
                            UserName = "username1"
                        });
                });

            modelBuilder.Entity("data_access_library.PasswordManagerDbContext+User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Login = "Login1",
                            Password = "1111"
                        });
                });

            modelBuilder.Entity("data_access_library.PasswordManagerDbContext+Credit_Card", b =>
                {
                    b.HasOne("data_access_library.PasswordManagerDbContext+CardType", "CardType")
                        .WithMany("Cards")
                        .HasForeignKey("CartTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("data_access_library.PasswordManagerDbContext+Category", "Category")
                        .WithMany("Cards")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("data_access_library.PasswordManagerDbContext+User", "User")
                        .WithMany("Cards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CardType");

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("data_access_library.PasswordManagerDbContext+Login_Item", b =>
                {
                    b.HasOne("data_access_library.PasswordManagerDbContext+Category", "Category")
                        .WithMany("Logins")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("data_access_library.PasswordManagerDbContext+User", "User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("data_access_library.PasswordManagerDbContext+Personal_Info", b =>
                {
                    b.HasOne("data_access_library.PasswordManagerDbContext+Category", "Category")
                        .WithMany("Infos")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("data_access_library.PasswordManagerDbContext+User", "User")
                        .WithMany("Infos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("data_access_library.PasswordManagerDbContext+CardType", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("data_access_library.PasswordManagerDbContext+Category", b =>
                {
                    b.Navigation("Cards");

                    b.Navigation("Infos");

                    b.Navigation("Logins");
                });

            modelBuilder.Entity("data_access_library.PasswordManagerDbContext+User", b =>
                {
                    b.Navigation("Cards");

                    b.Navigation("Infos");

                    b.Navigation("Logins");
                });
#pragma warning restore 612, 618
        }
    }
}
