using Microsoft.EntityFrameworkCore.Migrations;

namespace Eddy.Data.Migrations
{
    public partial class MoreUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentifierString",
                table: "Businesses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentifierString",
                table: "Businesses");
        }
    }
}
