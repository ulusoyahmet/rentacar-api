using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentACarAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class car_booking_location_context : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarRentings_Locations_PickUpLocationID",
                table: "CarRentings");

            migrationBuilder.AddForeignKey(
                name: "FK_CarRentings_Locations_PickUpLocationID",
                table: "CarRentings",
                column: "PickUpLocationID",
                principalTable: "Locations",
                principalColumn: "LocationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarRentings_Locations_PickUpLocationID",
                table: "CarRentings");

            migrationBuilder.AddForeignKey(
                name: "FK_CarRentings_Locations_PickUpLocationID",
                table: "CarRentings",
                column: "PickUpLocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
