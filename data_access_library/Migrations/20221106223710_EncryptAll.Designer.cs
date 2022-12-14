// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using data_access_library;

namespace data_access_library.Migrations
{
    [DbContext(typeof(PasswordManagerDbContext))]
    [Migration("20221106223710_EncryptAll")]
    partial class EncryptAll
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("data_access_library.PasswordManagerDbContext+Login_Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsFavourite")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SavedLogin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SavedPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Logins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsFavourite = false,
                            Name = "Login1",
                            SavedLogin = "LIcEo7vzO535KFUfMfvsEA==",
                            SavedPassword = "Tab3LOHhxXpDxtRZn6O1Yw==",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("data_access_library.PasswordManagerDbContext+UserData", b =>
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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UsersData");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Login = "Login1",
                            Password = "mBpDo8SZgZxa72KY9RUYtw=="
                        });
                });

            modelBuilder.Entity("data_access_library.PasswordManagerDbContext+Login_Item", b =>
                {
                    b.HasOne("data_access_library.PasswordManagerDbContext+UserData", "User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("data_access_library.PasswordManagerDbContext+UserData", b =>
                {
                    b.Navigation("Logins");
                });
#pragma warning restore 612, 618
        }
    }
}
