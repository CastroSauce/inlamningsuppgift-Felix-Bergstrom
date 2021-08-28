using Microsoft.EntityFrameworkCore.Migrations;

namespace inlämningsuppgift.Migrations
{
    public partial class addedcatagorytoproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_catagories_CatagoryId",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "CatagoryId",
                table: "products",
                newName: "catagoryId");

            migrationBuilder.RenameIndex(
                name: "IX_products_CatagoryId",
                table: "products",
                newName: "IX_products_catagoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_catagories_catagoryId",
                table: "products",
                column: "catagoryId",
                principalTable: "catagories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_catagories_catagoryId",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "catagoryId",
                table: "products",
                newName: "CatagoryId");

            migrationBuilder.RenameIndex(
                name: "IX_products_catagoryId",
                table: "products",
                newName: "IX_products_CatagoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_catagories_CatagoryId",
                table: "products",
                column: "CatagoryId",
                principalTable: "catagories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
