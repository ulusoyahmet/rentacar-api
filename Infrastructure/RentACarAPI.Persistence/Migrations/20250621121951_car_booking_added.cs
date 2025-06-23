using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentACarAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class car_booking_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarRentingDetails_Locations_DropOffLocationID",
                table: "CarRentingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CarRentingDetails_Locations_PickUpLocationID",
                table: "CarRentingDetails");

            migrationBuilder.CreateTable(
                name: "CarBookings",
                columns: table => new
                {
                    CarBookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarID = table.Column<int>(type: "int", nullable: false),
                    PickUpLocationID = table.Column<int>(type: "int", nullable: false),
                    DropOffLocationID = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    LicenseYear = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBookings", x => x.CarBookingID);
                    table.ForeignKey(
                        name: "FK_CarBookings_Cars_CarID",
                        column: x => x.CarID,
                        principalTable: "Cars",
                        principalColumn: "CarID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarBookings_Locations_DropOffLocationID",
                        column: x => x.DropOffLocationID,
                        principalTable: "Locations",
                        principalColumn: "LocationID");
                    table.ForeignKey(
                        name: "FK_CarBookings_Locations_PickUpLocationID",
                        column: x => x.PickUpLocationID,
                        principalTable: "Locations",
                        principalColumn: "LocationID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarBookings_CarID",
                table: "CarBookings",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_CarBookings_DropOffLocationID",
                table: "CarBookings",
                column: "DropOffLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_CarBookings_PickUpLocationID",
                table: "CarBookings",
                column: "PickUpLocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_CarRentingDetails_Locations_DropOffLocationID",
                table: "CarRentingDetails",
                column: "DropOffLocationID",
                principalTable: "Locations",
                principalColumn: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_CarRentingDetails_Locations_PickUpLocationID",
                table: "CarRentingDetails",
                column: "PickUpLocationID",
                principalTable: "Locations",
                principalColumn: "LocationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarRentingDetails_Locations_DropOffLocationID",
                table: "CarRentingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CarRentingDetails_Locations_PickUpLocationID",
                table: "CarRentingDetails");

            migrationBuilder.DropTable(
                name: "CarBookings");

            migrationBuilder.AddForeignKey(
                name: "FK_CarRentingDetails_Locations_DropOffLocationID",
                table: "CarRentingDetails",
                column: "DropOffLocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarRentingDetails_Locations_PickUpLocationID",
                table: "CarRentingDetails",
                column: "PickUpLocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
