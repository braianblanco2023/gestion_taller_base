using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallerAppRazor.Migrations
{
    /// <inheritdoc />
    public partial class RegistrosMayo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Taller",
                table: "Registros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Taller",
                table: "Registros");
        }
    }
}
