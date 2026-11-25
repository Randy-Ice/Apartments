using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apartments.Migrations.ProjectDBMigrations
{
    /// <inheritdoc />
    public partial class clientapartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Apartments",
                type: "decimal(6,2)",
                precision: 6,
                scale: 2,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(6)",
                oldPrecision: 6,
                oldScale: 2);

            migrationBuilder.CreateTable(
                name: "ClientToApartment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateOnly>(type: "date", nullable: false),
                    ManagementContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientToApartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientToApartment_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientToApartment_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientToApartment_ApartmentId",
                table: "ClientToApartment",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientToApartment_TenantId",
                table: "ClientToApartment",
                column: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientToApartment");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Apartments",
                type: "float(6)",
                precision: 6,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)",
                oldPrecision: 6,
                oldScale: 2);
        }
    }
}
