using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class InsertIntoImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            INSERT INTO Images (Name, DestinationId) SELECT 'HotelBitzaro_Zakynthos_2.jpg', DestinationId FROM Destinations WHERE Name like ('%Bitzaro%');
            INSERT INTO Images (Name, DestinationId) SELECT 'HotelBitzaro_Zakynthos_3.jpg', DestinationId FROM Destinations WHERE Name like ('%Bitzaro%');
            INSERT INTO Images (Name, DestinationId) SELECT 'HotelMaya_Alicante_1.jpg', DestinationId FROM Destinations WHERE Name like ('%Maya%');
            INSERT INTO Images (Name, DestinationId) SELECT 'HotelMaya_Alicante_2.jpg', DestinationId FROM Destinations WHERE Name like ('%Maya%');
            INSERT INTO Images (Name, DestinationId) SELECT 'HotelMaya_Alicante_3.jpg', DestinationId FROM Destinations WHERE Name like ('%Maya%');
            INSERT INTO Images (Name, DestinationId) SELECT 'HotelMythos_Milano_1.jpg', DestinationId FROM Destinations WHERE Name like ('%Mythos%');
            INSERT INTO Images (Name, DestinationId) SELECT 'HotelMythos_Milano_2.jpg', DestinationId FROM Destinations WHERE Name like ('%Mythos%');
            INSERT INTO Images (Name, DestinationId) SELECT 'HotelMythos_Milano_3.jpg', DestinationId FROM Destinations WHERE Name like ('%Mythos%');
            INSERT INTO Images (Name, DestinationId) SELECT 'HotelPricipessaIsabella_Roma_1.jpg', DestinationId FROM Destinations WHERE Name like ('%Isabella%');
            INSERT INTO Images (Name, DestinationId) SELECT 'HotelPricipessaIsabella_Roma_2.jpg', DestinationId FROM Destinations WHERE Name like ('%Isabella%');
            INSERT INTO Images (Name, DestinationId) SELECT 'HotelPricipessaIsabella_Roma_3.jpg', DestinationId FROM Destinations WHERE Name like ('%Isabella%');
            INSERT INTO Images (Name, DestinationId) SELECT 'HotelRhodos_Rodos_1.jpg', DestinationId FROM Destinations WHERE Name like ('%Rhodos%');
            INSERT INTO Images (Name, DestinationId) SELECT 'HotelRhodos_Rodos_2.jpg', DestinationId FROM Destinations WHERE Name like ('%Rhodos%');
            INSERT INTO Images (Name, DestinationId) SELECT 'HotelRhodos_Rodos_3.jpg', DestinationId FROM Destinations WHERE Name like ('%Rhodos%');
            INSERT INTO Images (Name, DestinationId) SELECT 'HotelSamba_Barcelona_1.jpg', DestinationId FROM Destinations WHERE Name like ('%Samba%');
            INSERT INTO Images (Name, DestinationId) SELECT 'HotelSamba_Barcelona_2.jpg', DestinationId FROM Destinations WHERE Name like ('%Samba%');
            INSERT INTO Images (Name, DestinationId) SELECT 'HotelSamba_Barcelona_3.jpg', DestinationId FROM Destinations WHERE Name like ('%Samba%');
            INSERT INTO Images (Name, DestinationId) SELECT 'HotelAmaika_Barcelona_1.jpg', DestinationId FROM Destinations WHERE Name like ('%Amaika%');
            INSERT INTO Images (Name, DestinationId) SELECT 'HotelAmaika_Barcelona_2.jpg', DestinationId FROM Destinations WHERE Name like ('%Amaika%');
            INSERT INTO Images (Name, DestinationId) SELECT 'HotelAmaika_Barcelona_3.jpg', DestinationId FROM Destinations WHERE Name like ('%Amaika%');
            INSERT INTO Images (Name, DestinationId) SELECT 'HotelBitzaro_Zakynthos_1.jpg', DestinationId FROM Destinations WHERE Name like ('%Bitzaro%');
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM Images");
        }
    }
}
