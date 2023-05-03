using Microsoft.EntityFrameworkCore.Migrations;

namespace CQRSwithMediatR.Migrations
{
    public partial class migratetooaccomodationdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisment_User_CreatedByUserId",
                table: "Advertisment");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropColumn(
                name: "CurrentLocation",
                table: "Advertisment");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                table: "Advertisment",
                newName: "UserCreatedByIdUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Advertisment_CreatedByUserId",
                table: "Advertisment",
                newName: "IX_Advertisment_UserCreatedByIdUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisment_User_UserCreatedByIdUserId",
                table: "Advertisment",
                column: "UserCreatedByIdUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisment_User_UserCreatedByIdUserId",
                table: "Advertisment");

            migrationBuilder.RenameColumn(
                name: "UserCreatedByIdUserId",
                table: "Advertisment",
                newName: "CreatedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Advertisment_UserCreatedByIdUserId",
                table: "Advertisment",
                newName: "IX_Advertisment_CreatedByUserId");

            migrationBuilder.AddColumn<string>(
                name: "CurrentLocation",
                table: "Advertisment",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Author = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisment_User_CreatedByUserId",
                table: "Advertisment",
                column: "CreatedByUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
