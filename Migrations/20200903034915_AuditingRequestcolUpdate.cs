using Microsoft.EntityFrameworkCore.Migrations;

namespace AuditorService.Migrations
{
    public partial class AuditingRequestcolUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Request_Comment",
                table: "AuditRequests");

            migrationBuilder.DropColumn(
                name: "Response_Comment",
                table: "AuditRequests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Request_Comment",
                table: "AuditRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Response_Comment",
                table: "AuditRequests",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
