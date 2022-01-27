using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebService.Migrations
{
    public partial class addFailedMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FailedMessage",
                table: "MailSendingReports",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FailedMessage",
                table: "MailSendingReports");
        }
    }
}
