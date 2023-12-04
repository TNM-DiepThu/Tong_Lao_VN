using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM_CS4.Migrations
{
    public partial class DB01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Product",
                table: "categories");

            migrationBuilder.DropIndex(
                name: "IX_categories_IdProduct",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "IdProduct",
                table: "categories");

            migrationBuilder.AddColumn<Guid>(
                name: "idCat",
                table: "products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_idCat",
                table: "products",
                column: "idCat");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Product",
                table: "products",
                column: "idCat",
                principalTable: "categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Product",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_idCat",
                table: "products");

            migrationBuilder.DropColumn(
                name: "idCat",
                table: "products");

            migrationBuilder.AddColumn<Guid>(
                name: "IdProduct",
                table: "categories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_categories_IdProduct",
                table: "categories",
                column: "IdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Product",
                table: "categories",
                column: "IdProduct",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
