using Microsoft.EntityFrameworkCore.Migrations;

namespace inlämningsuppgift.Migrations
{
    public partial class changedimageurlname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "imageUrl",
                table: "images",
                newName: "url");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "url",
                table: "images",
                newName: "imageUrl");
        }
    }
}
