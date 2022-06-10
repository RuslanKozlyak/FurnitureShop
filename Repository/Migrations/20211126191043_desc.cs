using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class desc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductDescription",
                table: "Furniture",
                newName: "ShortDescription");

            migrationBuilder.AddColumn<string>(
                name: "LongDescription",
                table: "Furniture",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LongDescription",
                table: "Furniture");

            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "Furniture",
                newName: "ProductDescription");
        }
    }
}
