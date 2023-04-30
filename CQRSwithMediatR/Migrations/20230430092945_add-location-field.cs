using Microsoft.EntityFrameworkCore.Migrations;

namespace CQRSwithMediatR.Migrations
{
    public partial class addlocationfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrentLocation",
                table: "Advertisment",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentLocation",
                table: "Advertisment");
        }
    }
}
