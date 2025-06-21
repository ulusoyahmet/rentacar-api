using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentACarAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class car_renting_details_with_customer_added_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "CarRentingDetails",
                columns: table => new
                {
                    CarRentingDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarID = table.Column<int>(type: "int", nullable: false),
                    PickUpLocationID = table.Column<int>(type: "int", nullable: false),
                    DropOffLocationID = table.Column<int>(type: "int", nullable: false),
                    PickUpDate = table.Column<DateTime>(type: "Date", nullable: true),
                    DropOffDate = table.Column<DateTime>(type: "Date", nullable: true),
                    PickUpTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    DropOffTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    PickUpDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DropOffDescriptione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRentingDetails", x => x.CarRentingDetailID);
                    table.ForeignKey(
                        name: "FK_CarRentingDetails_Cars_CarID",
                        column: x => x.CarID,
                        principalTable: "Cars",
                        principalColumn: "CarID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarRentingDetails_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarRentingDetails_Locations_DropOffLocationID",
                        column: x => x.DropOffLocationID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarRentingDetails_Locations_PickUpLocationID",
                        column: x => x.PickUpLocationID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarRentingDetails_CarID",
                table: "CarRentingDetails",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_CarRentingDetails_CustomerID",
                table: "CarRentingDetails",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CarRentingDetails_DropOffLocationID",
                table: "CarRentingDetails",
                column: "DropOffLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_CarRentingDetails_PickUpLocationID",
                table: "CarRentingDetails",
                column: "PickUpLocationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarRentingDetails");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
