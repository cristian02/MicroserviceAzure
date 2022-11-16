using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Product.Migrations
{
    public partial class FourMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "productsId",
                table: "OrderDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_productsId",
                table: "OrderDetail",
                column: "productsId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Products_productsId",
                table: "OrderDetail",
                column: "productsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Products_productsId",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_productsId",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "productsId",
                table: "OrderDetail");
        }
    }
}
