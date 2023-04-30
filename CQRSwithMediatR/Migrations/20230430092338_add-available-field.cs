using Microsoft.EntityFrameworkCore.Migrations;

namespace CQRSwithMediatR.Migrations
{
    public partial class addavailablefield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Advertisment",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Advertisment");
        }
    }
}
