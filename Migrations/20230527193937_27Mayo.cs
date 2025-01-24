using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallerAppRazor.Migrations
{
    /// <inheritdoc />
    public partial class _27Mayo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "tipoServicio",
                table: "Registros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tipoServicio",
                table: "Registros");
        }
    }
}
