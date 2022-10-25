using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace data_access_library.Migrations
{
    public partial class CardTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateExpired",
                table: "Cards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 26, 0, 51, 13, 429, DateTimeKind.Local).AddTicks(636),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 26, 0, 48, 50, 923, DateTimeKind.Local).AddTicks(8279));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateExpired",
                table: "Cards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 26, 0, 48, 50, 923, DateTimeKind.Local).AddTicks(8279),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 10, 26, 0, 51, 13, 429, DateTimeKind.Local).AddTicks(636));
        }
    }
}
