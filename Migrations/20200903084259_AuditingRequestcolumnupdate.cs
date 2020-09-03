using Microsoft.EntityFrameworkCore.Migrations;

namespace AuditorService.Migrations
{
    public partial class AuditingRequestcolumnupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuditorPortfolioID",
                table: "AuditRequests");

            migrationBuilder.AddColumn<string>(
                name: "AuditPortfolioID",
                table: "AuditRequests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuditPortfolioID",
                table: "AuditRequests");

            migrationBuilder.AddColumn<string>(
                name: "AuditorPortfolioID",
                table: "AuditRequests",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
