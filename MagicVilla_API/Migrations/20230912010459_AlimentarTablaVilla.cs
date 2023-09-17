using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AlimentarTablaVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenUrl", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[,]
                {
                    { 1, "", "detalle 1", new DateTime(2023, 9, 11, 22, 4, 59, 319, DateTimeKind.Local).AddTicks(2634), new DateTime(2023, 9, 11, 22, 4, 59, 319, DateTimeKind.Local).AddTicks(2543), "", 200, "Vira", 10, 3000.0 },
                    { 2, "", "detalle 2", new DateTime(2023, 9, 11, 22, 4, 59, 319, DateTimeKind.Local).AddTicks(2642), new DateTime(2023, 9, 11, 22, 4, 59, 319, DateTimeKind.Local).AddTicks(2639), "", 2330, "Monstaf", 20, 2000.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
