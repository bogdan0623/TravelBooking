using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class InsertintoCities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO Cities (Name, CountryId)
                SELECT 
                    'Barcelona',
                    CountryId
                FROM Countries
                WHERE Name = 'Spania';
            ");

            migrationBuilder.Sql(@"
                INSERT INTO Cities (Name, CountryId)
                SELECT 
                    'Alicante',
                    CountryId
                FROM Countries
                WHERE Name = 'Spania';
            ");

            migrationBuilder.Sql(@"
                INSERT INTO Cities (Name, CountryId)
                SELECT 
                    'Milano',
                    CountryId
                FROM Countries
                WHERE Name = 'Italia';
            ");

            migrationBuilder.Sql(@"
                INSERT INTO Cities (Name, CountryId)
                SELECT 
                    'Roma',
                    CountryId
                FROM Countries
                WHERE Name = 'Italia';
            ");

            migrationBuilder.Sql(@"
                INSERT INTO Cities (Name, CountryId)
                SELECT 
                    'Zakynthos',
                    CountryId
                FROM Countries
                WHERE Name = 'Grecia';
            ");

            migrationBuilder.Sql(@"
                INSERT INTO Cities (Name, CountryId)
                SELECT 
                    'Rodos',
                    CountryId
                FROM Countries
                WHERE Name = 'Grecia';
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Cities WHERE Name = 'Barcelona'");
            migrationBuilder.Sql("DELETE FROM Cities WHERE Name = 'Alicante'");
            migrationBuilder.Sql("DELETE FROM Cities WHERE Name = 'Milano'");
            migrationBuilder.Sql("DELETE FROM Cities WHERE Name = 'Roma'");
            migrationBuilder.Sql("DELETE FROM Cities WHERE Name = 'Zakynthos'");
            migrationBuilder.Sql("DELETE FROM Cities WHERE Name = 'Rodos'");
        }
    }
}
