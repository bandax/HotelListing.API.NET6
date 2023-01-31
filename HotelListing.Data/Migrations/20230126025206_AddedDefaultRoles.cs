using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelListing.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "306530ad-b505-4d56-97ba-54755e1ceb2b", "c6699b07-9684-44e0-b0df-364ff915ead6", "User", "USER" },
                    { "82e1c7e3-1282-4597-ae41-4b3ee82f31b4", "a2878c9b-c77b-4f90-a6d4-d22f0e7e9239", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "306530ad-b505-4d56-97ba-54755e1ceb2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82e1c7e3-1282-4597-ae41-4b3ee82f31b4");
        }
    }
}
