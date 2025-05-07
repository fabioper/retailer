using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Retailer.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                schema: "retailer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_ProductId",
                schema: "retailer",
                table: "SaleItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItems_Products_ProductId",
                schema: "retailer",
                table: "SaleItems",
                column: "ProductId",
                principalSchema: "retailer",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleItems_Products_ProductId",
                schema: "retailer",
                table: "SaleItems");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "retailer");

            migrationBuilder.DropIndex(
                name: "IX_SaleItems_ProductId",
                schema: "retailer",
                table: "SaleItems");
        }
    }
}
