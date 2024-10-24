using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class third_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PasajerosReservas");

            migrationBuilder.DropTable(
                name: "ReservasVuelos");

            migrationBuilder.AddColumn<int>(
                name: "PasajeroId",
                table: "Reservas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VueloId",
                table: "Reservas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_PasajeroId",
                table: "Reservas",
                column: "PasajeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_VueloId",
                table: "Reservas",
                column: "VueloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Pasajeros_PasajeroId",
                table: "Reservas",
                column: "PasajeroId",
                principalTable: "Pasajeros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Vuelos_VueloId",
                table: "Reservas",
                column: "VueloId",
                principalTable: "Vuelos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Pasajeros_PasajeroId",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Vuelos_VueloId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_PasajeroId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_VueloId",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "PasajeroId",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "VueloId",
                table: "Reservas");

            migrationBuilder.CreateTable(
                name: "PasajerosReservas",
                columns: table => new
                {
                    PasajerosId = table.Column<int>(type: "INTEGER", nullable: false),
                    ReservasId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasajerosReservas", x => new { x.PasajerosId, x.ReservasId });
                    table.ForeignKey(
                        name: "FK_PasajerosReservas_Pasajeros_PasajerosId",
                        column: x => x.PasajerosId,
                        principalTable: "Pasajeros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PasajerosReservas_Reservas_ReservasId",
                        column: x => x.ReservasId,
                        principalTable: "Reservas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_ReservasVuelos_Reservas_ReservasId",
                        column: x => x.ReservasId,
                        principalTable: "Reservas",
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
                name: "IX_PasajerosReservas_ReservasId",
                table: "PasajerosReservas",
                column: "ReservasId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasVuelos_VuelosId",
                table: "ReservasVuelos",
                column: "VuelosId");
        }
    }
}
