using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class first_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pasajeros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NroDoc = table.Column<int>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false),
                    ReservasId = table.Column<int>(type: "INTEGER", nullable: true),
                    FechaReserva = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EstadoReserva = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasajeros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pasajeros_Pasajeros_ReservasId",
                        column: x => x.ReservasId,
                        principalTable: "Pasajeros",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vuelos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Capacidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Origen = table.Column<string>(type: "TEXT", nullable: false),
                    Destino = table.Column<string>(type: "TEXT", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaLlegada = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReservasVuelos",
                columns: table => new
                {
                    ReservasId = table.Column<int>(type: "INTEGER", nullable: false),
                    VuelosId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservasVuelos", x => new { x.ReservasId, x.VuelosId });
                    table.ForeignKey(
                        name: "FK_ReservasVuelos_Pasajeros_ReservasId",
                        column: x => x.ReservasId,
                        principalTable: "Pasajeros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservasVuelos_Vuelos_VuelosId",
                        column: x => x.VuelosId,
                        principalTable: "Vuelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pasajeros_ReservasId",
                table: "Pasajeros",
                column: "ReservasId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasVuelos_VuelosId",
                table: "ReservasVuelos",
                column: "VuelosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservasVuelos");

            migrationBuilder.DropTable(
                name: "Pasajeros");

            migrationBuilder.DropTable(
                name: "Vuelos");
        }
    }
}
