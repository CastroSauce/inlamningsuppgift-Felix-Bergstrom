using Microsoft.EntityFrameworkCore.Migrations;

namespace inlämningsuppgift.Migrations
{
    public partial class addedonhomepagepropertytoproductandcat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "onHomepage",
                table: "products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "onHomepage",
                table: "catagories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "onHomepage",
                table: "products");

            migrationBuilder.DropColumn(
                name: "onHomepage",
                table: "catagories");
        }
    }
}
