using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneBook.DAL.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContactType",
                keyColumn: "id",
                keyValue: 1L,
                column: "created_date",
                value: new DateTime(2023, 9, 28, 9, 58, 3, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ContactType",
                keyColumn: "id",
                keyValue: 2L,
                column: "created_date",
                value: new DateTime(2023, 9, 28, 9, 58, 3, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "ContactType",
                keyColumn: "id",
                keyValue: 3L,
                column: "created_date",
                value: new DateTime(2023, 9, 28, 9, 58, 3, 0, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContactType",
                keyColumn: "id",
                keyValue: 1L,
                column: "created_date",
                value: new DateTime(2023, 9, 28, 9, 58, 3, 334, DateTimeKind.Utc).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "ContactType",
                keyColumn: "id",
                keyValue: 2L,
                column: "created_date",
                value: new DateTime(2023, 9, 28, 9, 58, 3, 334, DateTimeKind.Utc).AddTicks(700));

            migrationBuilder.UpdateData(
                table: "ContactType",
                keyColumn: "id",
                keyValue: 3L,
                column: "created_date",
                value: new DateTime(2023, 9, 28, 9, 58, 3, 334, DateTimeKind.Utc).AddTicks(706));
        }
    }
}
