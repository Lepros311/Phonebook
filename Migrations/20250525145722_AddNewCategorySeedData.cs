using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phonebook.Migrations
{
    /// <inheritdoc />
    public partial class AddNewCategorySeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CategoryName",
                value: "");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CategoryName",
                value: "Friends");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "CategoryName",
                value: "Family");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "CategoryName",
                value: "Coworkers");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 5, "Other" });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 2,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 3,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 4,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 5,
                column: "CategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 6,
                column: "CategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 7,
                column: "CategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 8,
                column: "CategoryId",
                value: 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CategoryName",
                value: "Friends");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CategoryName",
                value: "Family");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "CategoryName",
                value: "Coworkers");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "CategoryName",
                value: "Other");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 2,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 3,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 4,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 5,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 6,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 7,
                column: "CategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 8,
                column: "CategoryId",
                value: 4);
        }
    }
}
