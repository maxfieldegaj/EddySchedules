using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Eddy.Data.Migrations
{
    public partial class EddyInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    BusinessId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Businesses_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    IsManager = table.Column<bool>(nullable: false),
                    ID = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CurrentlyEmployed = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    PlaceOfBusinessId = table.Column<int>(nullable: true),
                    RequestedOff = table.Column<DateTime>(nullable: true),
                    ShiftID = table.Column<int>(nullable: true),
                    Manager_PlaceOfBusinessId = table.Column<int>(nullable: true),
                    Manager_RequestedOff = table.Column<DateTime>(nullable: true),
                    Manager_ShiftID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.ID);
                    table.ForeignKey(
                        name: "FK_People_Businesses_PlaceOfBusinessId",
                        column: x => x.PlaceOfBusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_People_Businesses_Manager_PlaceOfBusinessId",
                        column: x => x.Manager_PlaceOfBusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeID = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    TradePending = table.Column<bool>(nullable: false),
                    Assigned = table.Column<bool>(nullable: false),
                    PlaceOfBusinessId = table.Column<int>(nullable: true),
                    PersonID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Schedules_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedules_Businesses_PlaceOfBusinessId",
                        column: x => x.PlaceOfBusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_BusinessId",
                table: "Businesses",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_People_PlaceOfBusinessId",
                table: "People",
                column: "PlaceOfBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_People_ShiftID",
                table: "People",
                column: "ShiftID");

            migrationBuilder.CreateIndex(
                name: "IX_People_Manager_PlaceOfBusinessId",
                table: "People",
                column: "Manager_PlaceOfBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_People_Manager_ShiftID",
                table: "People",
                column: "Manager_ShiftID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_PersonID",
                table: "Schedules",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_PlaceOfBusinessId",
                table: "Schedules",
                column: "PlaceOfBusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Schedules_ShiftID",
                table: "People",
                column: "ShiftID",
                principalTable: "Schedules",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Schedules_Manager_ShiftID",
                table: "People",
                column: "Manager_ShiftID",
                principalTable: "Schedules",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Businesses_PlaceOfBusinessId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Businesses_Manager_PlaceOfBusinessId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Businesses_PlaceOfBusinessId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Schedules_ShiftID",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Schedules_Manager_ShiftID",
                table: "People");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
