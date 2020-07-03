using Microsoft.EntityFrameworkCore.Migrations;

namespace HolidayManagement.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    OfficeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.OfficeName);
                });

            migrationBuilder.CreateTable(
                name: "StaffStatus",
                columns: table => new
                {
                    Status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffStatus", x => x.Status);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    OfficesOfficeName = table.Column<string>(nullable: true),
                    StaffStatusStatus = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffID);
                    table.ForeignKey(
                        name: "FK_Staff_Office_OfficesOfficeName",
                        column: x => x.OfficesOfficeName,
                        principalTable: "Office",
                        principalColumn: "OfficeName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Staff_StaffStatus_StaffStatusStatus",
                        column: x => x.StaffStatusStatus,
                        principalTable: "StaffStatus",
                        principalColumn: "Status",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Staff_OfficesOfficeName",
                table: "Staff",
                column: "OfficesOfficeName");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_StaffStatusStatus",
                table: "Staff",
                column: "StaffStatusStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Office");

            migrationBuilder.DropTable(
                name: "StaffStatus");
        }
    }
}
