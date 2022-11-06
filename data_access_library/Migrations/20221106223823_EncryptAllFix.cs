using Microsoft.EntityFrameworkCore.Migrations;

namespace data_access_library.Migrations
{
    public partial class EncryptAllFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "UsersData",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SavedPassword",
                table: "Logins",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SavedLogin",
                table: "Logins",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "SavedLogin", "SavedPassword" },
                values: new object[] { "LIcEo7vzO535KFUfMfvsEA==", "Tab3LOHhxXpDxtRZn6O1Yw==" });

            migrationBuilder.UpdateData(
                table: "UsersData",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "mBpDo8SZgZxa72KY9RUYtw==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "UsersData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SavedPassword",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SavedLogin",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "SavedLogin", "SavedPassword" },
                values: new object[] { "LIcEo7vzO535KFUfMfvsEA==", "Tab3LOHhxXpDxtRZn6O1Yw==" });

            migrationBuilder.UpdateData(
                table: "UsersData",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "mBpDo8SZgZxa72KY9RUYtw==");
        }
    }
}
