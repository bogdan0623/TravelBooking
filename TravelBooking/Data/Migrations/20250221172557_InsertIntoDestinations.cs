using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class InsertIntoDestinations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // -------------------- Spania --------------------
            // Barcelona
            migrationBuilder.Sql(@"
                INSERT INTO Destinations (Name, CityId, Description, PricePerNightPerPerson, Picture)
                SELECT
                    'H1',
                    CityId,
                    '',
                    200,
                    'wwwroot/images/f1.jpg'
                FROM Cities
                WHERE Name = 'Barcelona';
            ");

            migrationBuilder.Sql(@"
                INSERT INTO Destinations (Name, CityId, Description, PricePerNightPerPerson, Picture)
                SELECT
                    'H2',
                    CityId,
                    '',
                    200,
                    'wwwroot/images/f2.jpg'
                FROM Cities
                WHERE Name = 'Barcelona';
            ");

            // Alicante
            migrationBuilder.Sql(@"
                INSERT INTO Destinations (Name, CityId, Description, PricePerNightPerPerson, Picture)
                SELECT
                    'H3',
                    CityId,
                    '',
                    200,
                    'wwwroot/images/f3.jpg'
                FROM Cities
                WHERE Name = 'Alicante';
            ");


            // -------------------- Grecia --------------------
            // Rodos
            migrationBuilder.Sql(@"
                INSERT INTO Destinations (Name, CityId, Description, PricePerNightPerPerson, Picture)
                SELECT
                    'H4',
                    CityId,
                    '',
                    200,
                    'wwwroot/images/f4.jpg'
                FROM Cities
                WHERE Name = 'Rodos';
            ");

            // Zakynthos
            migrationBuilder.Sql(@"
                INSERT INTO Destinations (Name, CityId, Description, PricePerNightPerPerson, Picture)
                SELECT
                    'H5',
                    CityId,
                    '',
                    200,
                    'wwwroot/images/f5.jpg'
                FROM Cities
                WHERE Name = 'Zakynthos';
            ");


            // -------------------- Italia --------------------
            // Milano
            migrationBuilder.Sql(@"
                INSERT INTO Destinations (Name, CityId, Description, PricePerNightPerPerson, Picture)
                SELECT
                    'H6',
                    CityId,
                    '',
                    200,
                    'wwwroot/images/f6.jpg'
                FROM Cities
                WHERE Name = 'Milano';
            ");

            // Roma
            migrationBuilder.Sql(@"
                INSERT INTO Destinations (Name, CityId, Description, PricePerNightPerPerson, Picture)
                SELECT
                    'H7',
                    CityId,
                    '',
                    200,
                    'wwwroot/images/f7.jpg'
                FROM Cities
                WHERE Name = 'Roma';
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM Destinations");
        }
    }
}
