using Microsoft.EntityFrameworkCore.Migrations;

namespace Summitworks_EventManager.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "Events");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "Events",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
