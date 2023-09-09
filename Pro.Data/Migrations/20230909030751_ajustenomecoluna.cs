using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pro.Data.Migrations
{
    /// <inheritdoc />
    public partial class ajustenomecoluna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EnderedoId",
                table: "Clientes",
                newName: "EnderecoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EnderecoId",
                table: "Clientes",
                newName: "EnderedoId");
        }
    }
}
