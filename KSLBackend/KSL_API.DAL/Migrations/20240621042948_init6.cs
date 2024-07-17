using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KSL_API.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdMarcacao",
                table: "ItensMarcacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdMarcacao",
                table: "ItensMarcacoes");
        }
    }
}
