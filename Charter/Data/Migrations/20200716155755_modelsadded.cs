using Microsoft.EntityFrameworkCore.Migrations;

namespace Charter.Data.Migrations
{
    public partial class modelsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba5cf4a4-344e-40ba-b978-6316b13bacb9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "51008f8a-dce2-414c-abde-c2cafed7e39c", "6df5d667-b0e2-448d-81f3-3602fe0bdb72", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ca9ff310-ebeb-4e51-b05a-f7c3b92c3511", "8e706753-84c6-4863-9757-ded54f9838c1", "Captain", "CAPTAIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51008f8a-dce2-414c-abde-c2cafed7e39c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca9ff310-ebeb-4e51-b05a-f7c3b92c3511");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ba5cf4a4-344e-40ba-b978-6316b13bacb9", "923ee1e7-8ce6-4dac-bb6f-887a73382ac4", "Admin", "ADMIN" });
        }
    }
}
