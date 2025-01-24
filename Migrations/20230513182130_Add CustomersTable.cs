using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallerAppRazor.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Patente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Año = table.Column<int>(type: "int", nullable: false),
                    Combustible = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kilometraje = table.Column<int>(type: "int", nullable: false),
                    Titular_Dueño = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    condicionIngreso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    servicioRealizado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    costoServicio = table.Column<int>(type: "int", nullable: false),
                    costoRepuestos = table.Column<int>(type: "int", nullable: false),
                    costoTotal = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Talleres",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talleres", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropTable(
                name: "Talleres");
        }
    }
}
