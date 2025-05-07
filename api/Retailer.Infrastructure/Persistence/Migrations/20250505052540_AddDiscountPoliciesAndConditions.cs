using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Retailer.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDiscountPoliciesAndConditions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                schema: "retailer",
                table: "SaleItems",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Discount",
                schema: "retailer",
                columns: table => new
                {
                    SaleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PolicyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => new { x.SaleId, x.Id });
                    table.ForeignKey(
                        name: "FK_Discount_Sales_SaleId",
                        column: x => x.SaleId,
                        principalSchema: "retailer",
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscountPolicies",
                schema: "retailer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    DiscountPolicyType = table.Column<string>(type: "character varying(34)", maxLength: 34, nullable: false),
                    FixedAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    Percentage = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountPolicies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountConditions",
                schema: "retailer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DiscountPolicyId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountConditions_DiscountPolicies_DiscountPolicyId",
                        column: x => x.DiscountPolicyId,
                        principalSchema: "retailer",
                        principalTable: "DiscountPolicies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MinimumTotalDiscountConditions",
                schema: "retailer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MinTotal = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinimumTotalDiscountConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MinimumTotalDiscountConditions_DiscountConditions_Id",
                        column: x => x.Id,
                        principalSchema: "retailer",
                        principalTable: "DiscountConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDiscountConditions",
                schema: "retailer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDiscountConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDiscountConditions_DiscountConditions_Id",
                        column: x => x.Id,
                        principalSchema: "retailer",
                        principalTable: "DiscountConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscountConditions_DiscountPolicyId",
                schema: "retailer",
                table: "DiscountConditions",
                column: "DiscountPolicyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discount",
                schema: "retailer");

            migrationBuilder.DropTable(
                name: "MinimumTotalDiscountConditions",
                schema: "retailer");

            migrationBuilder.DropTable(
                name: "ProductDiscountConditions",
                schema: "retailer");

            migrationBuilder.DropTable(
                name: "DiscountConditions",
                schema: "retailer");

            migrationBuilder.DropTable(
                name: "DiscountPolicies",
                schema: "retailer");

            migrationBuilder.DropColumn(
                name: "ProductId",
                schema: "retailer",
                table: "SaleItems");
        }
    }
}
