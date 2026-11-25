using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apartments.Migrations.ProjectDBMigrations
{
    /// <inheritdoc />
    public partial class apartmentmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartmentType = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApartmentNumber = table.Column<byte>(type: "tinyint", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float(6)", precision: 6, scale: 2, nullable: false),
                    Beds = table.Column<byte>(type: "tinyint", nullable: false),
                    Bathrooms = table.Column<byte>(type: "tinyint", nullable: false),
                    SquareFeet = table.Column<short>(type: "smallint", nullable: false),
                    HasPool = table.Column<bool>(type: "bit", nullable: false),
                    HasGym = table.Column<bool>(type: "bit", nullable: false),
                    HasParking = table.Column<bool>(type: "bit", nullable: false),
                    HasEvCharging = table.Column<bool>(type: "bit", nullable: false),
                    SpotsAvailable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasPet = table.Column<bool>(type: "bit", nullable: false),
                    PetNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartments_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_AddressId",
                table: "Apartments",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_ApartmentType",
                table: "Apartments",
                column: "ApartmentType");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_Beds",
                table: "Apartments",
                column: "Beds");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_Name",
                table: "Apartments",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_Price",
                table: "Apartments",
                column: "Price");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartments");
        }
    }
}
