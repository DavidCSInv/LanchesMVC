using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesMac.Migrations
{
    public partial class CorrigindoTabelaLanches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Lanches",
                newName: "ImagemUrl");

            migrationBuilder.RenameColumn(
                name: "ImageThumbnail",
                table: "Lanches",
                newName: "ImagemThumbnail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagemUrl",
                table: "Lanches",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "ImagemThumbnail",
                table: "Lanches",
                newName: "ImageThumbnail");
        }
    }
}
