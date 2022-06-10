using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_HumanId",
                table: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_Order_HumanId",
                table: "Order",
                column: "HumanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_HumanId",
                table: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_Order_HumanId",
                table: "Order",
                column: "HumanId",
                unique: true);
        }
    }
}
