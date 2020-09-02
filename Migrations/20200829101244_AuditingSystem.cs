using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuditorService.Migrations
{
    public partial class AuditingSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditPortfolios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditorPortfolioID = table.Column<string>(nullable: true),
                    AuditorID = table.Column<string>(maxLength: 50, nullable: false),
                    AuditorName = table.Column<string>(maxLength: 100, nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    ClientName = table.Column<string>(nullable: true),
                    Created_Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditPortfolios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditorPortfolioID = table.Column<string>(nullable: true),
                    AuditRequestID = table.Column<string>(nullable: true),
                    AuditorID = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>(nullable: false),
                    Request = table.Column<string>(nullable: true),
                    Created_Timestamp = table.Column<DateTime>(nullable: false),
                    Request_Comment = table.Column<string>(nullable: true),
                    Response_Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    UserRoleType = table.Column<string>(nullable: true),
                    Created_Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditPortfolios");

            migrationBuilder.DropTable(
                name: "AuditRequests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
