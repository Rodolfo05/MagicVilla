using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AgregarNumeroVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NumeroVillas",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    VillaId = table.Column<int>(type: "int", nullable: false),
                    DetalleEspecial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumeroVillas", x => x.VillaNo);
                    table.ForeignKey(
                        name: "FK_NumeroVillas_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 17, 23, 39, 41, 39, DateTimeKind.Local).AddTicks(1973), new DateTime(2023, 9, 17, 23, 39, 41, 39, DateTimeKind.Local).AddTicks(1918) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 17, 23, 39, 41, 39, DateTimeKind.Local).AddTicks(2056), new DateTime(2023, 9, 17, 23, 39, 41, 39, DateTimeKind.Local).AddTicks(2050) });

            migrationBuilder.CreateIndex(
                name: "IX_NumeroVillas_VillaId",
                table: "NumeroVillas",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NumeroVillas");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 11, 22, 4, 59, 319, DateTimeKind.Local).AddTicks(2634), new DateTime(2023, 9, 11, 22, 4, 59, 319, DateTimeKind.Local).AddTicks(2543) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion" },
                values: new object[] { new DateTime(2023, 9, 11, 22, 4, 59, 319, DateTimeKind.Local).AddTicks(2642), new DateTime(2023, 9, 11, 22, 4, 59, 319, DateTimeKind.Local).AddTicks(2639) });
        }
    }
}
