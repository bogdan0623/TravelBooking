﻿using Microsoft.EntityFrameworkCore.Migrations;

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
                INSERT INTO Destinations (Name, CityId, Description, PricePerNightPerPerson)
                SELECT
                    'H1',
                    CityId,
                    '',
                    200.0
                FROM Cities
                WHERE Name = 'Barcelona';
            ");

            migrationBuilder.Sql(@"
                INSERT INTO Destinations (Name, CityId, Description, PricePerNightPerPerson)
                SELECT
                    'H2',
                    CityId,
                    '',
                    200.0
                FROM Cities
                WHERE Name = 'Barcelona';
            ");

            // Alicante
            migrationBuilder.Sql(@"
                INSERT INTO Destinations (Name, CityId, Description, PricePerNightPerPerson)
                SELECT
                    'H3',
                    CityId,
                    '',
                    200.0
                FROM Cities
                WHERE Name = 'Alicante';
            ");


            // -------------------- Grecia --------------------
            // Rodos
            migrationBuilder.Sql(@"
                INSERT INTO Destinations (Name, CityId, Description, PricePerNightPerPerson)
                SELECT
                    'H4',
                    CityId,
                    '',
                    200.0
                FROM Cities
                WHERE Name = 'Rodos';
            ");

            // Zakynthos
            migrationBuilder.Sql(@"
                INSERT INTO Destinations (Name, CityId, Description, PricePerNightPerPerson)
                SELECT
                    'H5',
                    CityId,
                    '',
                    200.0
                FROM Cities
                WHERE Name = 'Zakynthos';
            ");


            // -------------------- Italia --------------------
            // Milano
            migrationBuilder.Sql(@"
                INSERT INTO Destinations (Name, CityId, Description, PricePerNightPerPerson)
                SELECT
                    'H6',
                    CityId,
                    '',
                    200.0
                FROM Cities
                WHERE Name = 'Milano';
            ");

            // Roma
            migrationBuilder.Sql(@"
                INSERT INTO Destinations (Name, CityId, Description, PricePerNightPerPerson)
                SELECT
                    'H7',
                    CityId,
                    '',
                    200.0
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
