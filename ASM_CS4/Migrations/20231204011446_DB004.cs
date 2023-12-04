using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASM_CS4.Migrations
{
    public partial class DB004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Cart_Details",
                newName: "IdCart");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_Details_UserId",
                table: "Cart_Details",
                newName: "IX_Cart_Details_IdCart");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdCart",
                table: "Cart_Details",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_Details_IdCart",
                table: "Cart_Details",
                newName: "IX_Cart_Details_UserId");
        }
    }
}
