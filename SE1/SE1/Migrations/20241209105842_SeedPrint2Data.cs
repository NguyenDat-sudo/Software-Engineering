using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SE1.Migrations
{
    /// <inheritdoc />
    public partial class SeedPrint2Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Printer2s",
                columns: new[] { "Id", "Active", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "active", "A4-502", "HP Color LaserJet Pro" },
                    { 2, "active", "C6-102", "Brother MFC-J23188WC" },
                    { 3, "active", "B1-212", "HP DeskJet 2440" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Printer2s",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Printer2s",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Printer2s",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
