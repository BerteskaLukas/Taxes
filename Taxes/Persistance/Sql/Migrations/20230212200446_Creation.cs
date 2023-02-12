using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sql.Migrations
{
    /// <inheritdoc />
    public partial class Creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Municipalities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxeTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxeOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MunicipalityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxeTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxeOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxeOrders_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxeOrders_TaxeOrders_ParentId",
                        column: x => x.ParentId,
                        principalTable: "TaxeOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaxeOrders_TaxeTypes_TaxeTypeId",
                        column: x => x.TaxeTypeId,
                        principalTable: "TaxeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Value = table.Column<double>(type: "float", nullable: false),
                    MunicipalityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxeTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taxes_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Taxes_TaxeTypes_TaxeTypeId",
                        column: x => x.TaxeTypeId,
                        principalTable: "TaxeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Municipalities",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[] { new Guid("a5c94773-4a0d-429d-9730-0489cf6b5f0d"), new DateTime(2023, 2, 12, 20, 4, 46, 759, DateTimeKind.Utc).AddTicks(4219), "Copenhagen" });

            migrationBuilder.InsertData(
                table: "TaxeTypes",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("6fa81744-71b4-41da-8f38-53102ef99943"), new DateTime(2023, 2, 12, 20, 4, 46, 759, DateTimeKind.Utc).AddTicks(4056), "Yearly" },
                    { new Guid("aeaa5f81-f6c9-4905-9309-99e6998f658c"), new DateTime(2023, 2, 12, 20, 4, 46, 759, DateTimeKind.Utc).AddTicks(4073), "Daily" },
                    { new Guid("cca3f6e8-4687-489e-be62-d0ab1ad65033"), new DateTime(2023, 2, 12, 20, 4, 46, 759, DateTimeKind.Utc).AddTicks(4069), "Monthly" },
                    { new Guid("edcd5ed2-47f6-434b-92e6-02f47a0c2082"), new DateTime(2023, 2, 12, 20, 4, 46, 759, DateTimeKind.Utc).AddTicks(4071), "Weekly" }
                });

            migrationBuilder.InsertData(
                table: "TaxeOrders",
                columns: new[] { "Id", "CreatedAt", "MunicipalityId", "ParentId", "TaxeTypeId" },
                values: new object[] { new Guid("5d2e7de1-f1c2-4cda-b81e-968a116a9334"), new DateTime(2023, 2, 12, 20, 4, 46, 759, DateTimeKind.Utc).AddTicks(4260), new Guid("a5c94773-4a0d-429d-9730-0489cf6b5f0d"), null, new Guid("6fa81744-71b4-41da-8f38-53102ef99943") });

            migrationBuilder.InsertData(
                table: "Taxes",
                columns: new[] { "Id", "CreatedAt", "EndDate", "MunicipalityId", "StartDate", "TaxeTypeId", "Value" },
                values: new object[,]
                {
                    { new Guid("a5c94773-4a0d-429d-9730-0489cf6b5f0d"), new DateTime(2023, 2, 12, 20, 4, 46, 759, DateTimeKind.Utc).AddTicks(4235), new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a5c94773-4a0d-429d-9730-0489cf6b5f0d"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cca3f6e8-4687-489e-be62-d0ab1ad65033"), 0.40000000000000002 },
                    { new Guid("ac2cc175-4f71-456a-bf4d-3548d7af9f4b"), new DateTime(2023, 2, 12, 20, 4, 46, 759, DateTimeKind.Utc).AddTicks(4242), new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a5c94773-4a0d-429d-9730-0489cf6b5f0d"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6fa81744-71b4-41da-8f38-53102ef99943"), 0.20000000000000001 },
                    { new Guid("e1296797-f320-48a2-bd6a-f4b14ab93912"), new DateTime(2023, 2, 12, 20, 4, 46, 759, DateTimeKind.Utc).AddTicks(4245), null, new Guid("a5c94773-4a0d-429d-9730-0489cf6b5f0d"), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("aeaa5f81-f6c9-4905-9309-99e6998f658c"), 0.10000000000000001 },
                    { new Guid("f686e7c2-61f3-4b94-afd7-01a92f3dad8b"), new DateTime(2023, 2, 12, 20, 4, 46, 759, DateTimeKind.Utc).AddTicks(4247), null, new Guid("a5c94773-4a0d-429d-9730-0489cf6b5f0d"), new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("aeaa5f81-f6c9-4905-9309-99e6998f658c"), 0.10000000000000001 }
                });

            migrationBuilder.InsertData(
                table: "TaxeOrders",
                columns: new[] { "Id", "CreatedAt", "MunicipalityId", "ParentId", "TaxeTypeId" },
                values: new object[,]
                {
                    { new Guid("063f535c-4fe0-4003-86be-18c03425969c"), new DateTime(2023, 2, 12, 20, 4, 46, 759, DateTimeKind.Utc).AddTicks(4263), new Guid("a5c94773-4a0d-429d-9730-0489cf6b5f0d"), new Guid("5d2e7de1-f1c2-4cda-b81e-968a116a9334"), new Guid("cca3f6e8-4687-489e-be62-d0ab1ad65033") },
                    { new Guid("4e5e0fa7-f3f2-4d8d-8d44-a5509e1ebd41"), new DateTime(2023, 2, 12, 20, 4, 46, 759, DateTimeKind.Utc).AddTicks(4266), new Guid("a5c94773-4a0d-429d-9730-0489cf6b5f0d"), new Guid("063f535c-4fe0-4003-86be-18c03425969c"), new Guid("edcd5ed2-47f6-434b-92e6-02f47a0c2082") },
                    { new Guid("91daae9b-479a-45c9-965c-79231b89c3da"), new DateTime(2023, 2, 12, 20, 4, 46, 759, DateTimeKind.Utc).AddTicks(4333), new Guid("a5c94773-4a0d-429d-9730-0489cf6b5f0d"), new Guid("4e5e0fa7-f3f2-4d8d-8d44-a5509e1ebd41"), new Guid("aeaa5f81-f6c9-4905-9309-99e6998f658c") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaxeOrders_MunicipalityId",
                table: "TaxeOrders",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxeOrders_ParentId",
                table: "TaxeOrders",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxeOrders_TaxeTypeId",
                table: "TaxeOrders",
                column: "TaxeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxes_MunicipalityId",
                table: "Taxes",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Taxes_TaxeTypeId",
                table: "Taxes",
                column: "TaxeTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxeOrders");

            migrationBuilder.DropTable(
                name: "Taxes");

            migrationBuilder.DropTable(
                name: "Municipalities");

            migrationBuilder.DropTable(
                name: "TaxeTypes");
        }
    }
}
