using Microsoft.EntityFrameworkCore.Migrations;

namespace CQRSwithMediatR.Migrations
{
    public partial class Initial_transport_sharing_economy_structures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    AccountType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Advertisment",
                columns: table => new
                {
                    AdvertismentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedTime = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisment", x => x.AdvertismentId);
                    table.ForeignKey(
                        name: "FK_Advertisment_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AdvertismentBookedIdAdvertismentId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserBookedByIdUserId = table.Column<int>(type: "INTEGER", nullable: true),
                    BookedTime = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Booking_Advertisment_AdvertismentBookedIdAdvertismentId",
                        column: x => x.AdvertismentBookedIdAdvertismentId,
                        principalTable: "Advertisment",
                        principalColumn: "AdvertismentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_User_UserBookedByIdUserId",
                        column: x => x.UserBookedByIdUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisment_CreatedByUserId",
                table: "Advertisment",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_AdvertismentBookedIdAdvertismentId",
                table: "Booking",
                column: "AdvertismentBookedIdAdvertismentId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserBookedByIdUserId",
                table: "Booking",
                column: "UserBookedByIdUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Advertisment");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
