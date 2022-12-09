using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightDataApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    flightNumber = table.Column<int>(name: "flight_Number", type: "int", nullable: false),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    airline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    departureDate = table.Column<DateTime>(name: "departure_Date", type: "datetime2", nullable: false),
                    arrivalDate = table.Column<DateTime>(name: "arrival_Date", type: "datetime2", nullable: false),
                    arrivalTerminal = table.Column<string>(name: "arrival_Terminal", type: "nvarchar(max)", nullable: false),
                    departureTerminal = table.Column<string>(name: "departure_Terminal", type: "nvarchar(max)", nullable: false),
                    seatnumber = table.Column<string>(name: "seat_number", type: "nvarchar(max)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
