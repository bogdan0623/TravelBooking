using Microsoft.EntityFrameworkCore.Migrations;
using TravelBooking.Models;

#nullable disable

namespace TravelBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class InsertIntoStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Statuses VALUES (1, 'Pending')");
            migrationBuilder.Sql("INSERT INTO Statuses VALUES (2, 'Approved')");
            migrationBuilder.Sql("INSERT INTO Statuses VALUES (3, 'Rejected')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Statuses WHERE StatusId = 1");
            migrationBuilder.Sql("DELETE FROM Statuses WHERE StatusId = 2");
            migrationBuilder.Sql("DELETE FROM Statuses WHERE StatusId = 3");
        }
    }
}
