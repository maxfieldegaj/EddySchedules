using Microsoft.EntityFrameworkCore.Migrations;

namespace Eddy.Data.Migrations
{
    public partial class BizUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Businesses",
                newName: "StreetNumber");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Businesses",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Businesses",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Businesses",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StreetName",
                table: "Businesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Businesses",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "StreetName",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Businesses");

            migrationBuilder.RenameColumn(
                name: "StreetNumber",
                table: "Businesses",
                newName: "Location");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Businesses",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
