using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class second_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pasajeros_Pasajeros_ReservasId",
                table: "Pasajeros");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservasVuelos_Pasajeros_ReservasId",
                table: "ReservasVuelos");

            migrationBuilder.DropIndex(
                name: "IX_Pasajeros_ReservasId",
                table: "Pasajeros");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Pasajeros");

            migrationBuilder.DropColumn(
                name: "EstadoReserva",
                table: "Pasajeros");

            migrationBuilder.DropColumn(
                name: "FechaReserva",
                table: "Pasajeros");

            migrationBuilder.DropColumn(
                name: "ReservasId",
                table: "Pasajeros");

            migrationBuilder.AlterColumn<string>(
                name: "Origen",
                table: "Vuelos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Destino",
                table: "Vuelos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaReserva = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EstadoReserva = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PasajerosReservas_ReservasId",
                table: "PasajerosReservas",
                column: "ReservasId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservasVuelos_Reservas_ReservasId",
                table: "ReservasVuelos",
                column: "ReservasId",
                principalTable: "Reservas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservasVuelos_Reservas_ReservasId",
                table: "ReservasVuelos");

            migrationBuilder.DropTable(
                name: "PasajerosReservas");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.AlterColumn<string>(
                name: "Origen",
                table: "Vuelos",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Destino",
                table: "Vuelos",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Pasajeros",
                type: "TEXT",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "EstadoReserva",
                table: "Pasajeros",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaReserva",
                table: "Pasajeros",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservasId",
                table: "Pasajeros",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pasajeros_ReservasId",
                table: "Pasajeros",
                column: "ReservasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pasajeros_Pasajeros_ReservasId",
                table: "Pasajeros",
                column: "ReservasId",
                principalTable: "Pasajeros",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservasVuelos_Pasajeros_ReservasId",
                table: "ReservasVuelos",
                column: "ReservasId",
                principalTable: "Pasajeros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
