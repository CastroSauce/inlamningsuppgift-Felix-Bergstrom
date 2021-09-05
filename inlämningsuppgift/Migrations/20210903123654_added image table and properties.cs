using Microsoft.EntityFrameworkCore.Migrations;

namespace inlämningsuppgift.Migrations
{
    public partial class addedimagetableandproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "imageId",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "imageId",
                table: "catagories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    altText = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_imageId",
                table: "products",
                column: "imageId");

            migrationBuilder.CreateIndex(
                name: "IX_catagories_imageId",
                table: "catagories",
                column: "imageId");

            migrationBuilder.AddForeignKey(
                name: "FK_catagories_images_imageId",
                table: "catagories",
                column: "imageId",
                principalTable: "images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_products_images_imageId",
                table: "products",
                column: "imageId",
                principalTable: "images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_catagories_images_imageId",
                table: "catagories");

            migrationBuilder.DropForeignKey(
                name: "FK_products_images_imageId",
                table: "products");

            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropIndex(
                name: "IX_products_imageId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_catagories_imageId",
                table: "catagories");

            migrationBuilder.DropColumn(
                name: "imageId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "imageId",
                table: "catagories");
        }
    }
}
