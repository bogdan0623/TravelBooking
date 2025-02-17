using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class InsertIntoCountries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES (\'Spania\')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES (\'Grecia\')");
            migrationBuilder.Sql("INSERT INTO Countries (Name) VALUES (\'Italia\')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Countries WHERE Name = \'Spania\'");
            migrationBuilder.Sql("DELETE FROM Countries WHERE Name = \'Grecia\'");
            migrationBuilder.Sql("DELETE FROM Countries WHERE Name = \'Italia\'");
        }
    }
}
