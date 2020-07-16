using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Charter.Data.Migrations
{
    public partial class dbsetsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51008f8a-dce2-414c-abde-c2cafed7e39c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca9ff310-ebeb-4e51-b05a-f7c3b92c3511");

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "captains",
                columns: table => new
                {
                    CaptainId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BusinessName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    Longitude = table.Column<double>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_captains", x => x.CaptainId);
                    table.ForeignKey(
                        name: "FK_captains_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "insurances",
                columns: table => new
                {
                    InsuranceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    AmountDue = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insurances", x => x.InsuranceId);
                });

            migrationBuilder.CreateTable(
                name: "baits",
                columns: table => new
                {
                    BaitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaitType = table.Column<string>(nullable: true),
                    BaitCost = table.Column<double>(nullable: false),
                    DeathCount = table.Column<int>(nullable: false),
                    CaptainId = table.Column<int>(nullable: true),
                    CaptainsModelCaptainId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_baits", x => x.BaitId);
                    table.ForeignKey(
                        name: "FK_baits_captains_CaptainsModelCaptainId",
                        column: x => x.CaptainsModelCaptainId,
                        principalTable: "captains",
                        principalColumn: "CaptainId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: true),
                    AddressModelAddressId = table.Column<int>(nullable: true),
                    CaptainId = table.Column<int>(nullable: true),
                    CaptainsModelCaptainId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_clients_address_AddressModelAddressId",
                        column: x => x.AddressModelAddressId,
                        principalTable: "address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_clients_captains_CaptainsModelCaptainId",
                        column: x => x.CaptainsModelCaptainId,
                        principalTable: "captains",
                        principalColumn: "CaptainId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "boats",
                columns: table => new
                {
                    BoatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoatMake = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Engine = table.Column<string>(nullable: true),
                    EngineHours = table.Column<int>(nullable: false),
                    UsageAmountHours = table.Column<int>(nullable: false),
                    GasCotst = table.Column<double>(nullable: false),
                    FuelCapacity = table.Column<double>(nullable: false),
                    CaptainId = table.Column<int>(nullable: true),
                    CaptainsModelCaptainId = table.Column<int>(nullable: true),
                    InsuranceId = table.Column<int>(nullable: true),
                    InsurancesModelInsuranceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boats", x => x.BoatId);
                    table.ForeignKey(
                        name: "FK_boats_captains_CaptainsModelCaptainId",
                        column: x => x.CaptainsModelCaptainId,
                        principalTable: "captains",
                        principalColumn: "CaptainId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_boats_insurances_InsurancesModelInsuranceId",
                        column: x => x.InsurancesModelInsuranceId,
                        principalTable: "insurances",
                        principalColumn: "InsuranceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "252c55d8-c3ee-43fc-b284-a3baa6a9fc17", "0014e887-6dde-4f3b-9f0e-afc20e55cd45", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "779f3218-919a-4f53-84d5-aa0df1eaeb5e", "91576450-11d9-4eb3-87b2-7c7f8d17966b", "Captain", "CAPTAIN" });

            migrationBuilder.CreateIndex(
                name: "IX_baits_CaptainsModelCaptainId",
                table: "baits",
                column: "CaptainsModelCaptainId");

            migrationBuilder.CreateIndex(
                name: "IX_boats_CaptainsModelCaptainId",
                table: "boats",
                column: "CaptainsModelCaptainId");

            migrationBuilder.CreateIndex(
                name: "IX_boats_InsurancesModelInsuranceId",
                table: "boats",
                column: "InsurancesModelInsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_captains_IdentityUserId",
                table: "captains",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_clients_AddressModelAddressId",
                table: "clients",
                column: "AddressModelAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_clients_CaptainsModelCaptainId",
                table: "clients",
                column: "CaptainsModelCaptainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "baits");

            migrationBuilder.DropTable(
                name: "boats");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "insurances");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "captains");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "252c55d8-c3ee-43fc-b284-a3baa6a9fc17");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "779f3218-919a-4f53-84d5-aa0df1eaeb5e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "51008f8a-dce2-414c-abde-c2cafed7e39c", "6df5d667-b0e2-448d-81f3-3602fe0bdb72", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ca9ff310-ebeb-4e51-b05a-f7c3b92c3511", "8e706753-84c6-4863-9757-ded54f9838c1", "Captain", "CAPTAIN" });
        }
    }
}
