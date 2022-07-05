using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherTrackingApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Password = table.Column<string>(type: "varchar(32)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(32)", nullable: true),
                    IsEmailValidated = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Avatar = table.Column<string>(type: "varchar(255)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    TimeZone = table.Column<byte>(type: "tinyint", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    Latitude = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "TransportHistories",
                columns: table => new
                {
                    TransportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    StartPoint = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Velocity = table.Column<double>(type: "float", nullable: false),
                    AccurateTravelTimeInSec = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportHistories", x => x.TransportId);
                    table.ForeignKey(
                        name: "FK_TransportHistories_Accounts_UserId",
                        column: x => x.UserId,
                        principalTable: "Accounts",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingSchedules",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    StartPoint = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    EndPoint = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Velocity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingSchedules", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_BookingSchedules_Accounts_UserId",
                        column: x => x.UserId,
                        principalTable: "Accounts",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingSchedules_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteDestinations",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    TimeVisit = table.Column<int>(type: "int", nullable: false),
                    AverageTravelTimeInSec = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteDestinations", x => new { x.UserId, x.CityId });
                    table.ForeignKey(
                        name: "FK_FavoriteDestinations_Accounts_UserId",
                        column: x => x.UserId,
                        principalTable: "Accounts",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteDestinations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuggestBoards",
                columns: table => new
                {
                    SuggestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeZone = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuggestBoards", x => x.SuggestId);
                    table.ForeignKey(
                        name: "FK_SuggestBoards_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeatherStatus",
                columns: table => new
                {
                    WeatherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    WeatherName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    WeatherImage = table.Column<string>(type: "varchar(255)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    TimeStartInSec = table.Column<int>(type: "int", nullable: false),
                    TimeEndInSec = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Humidity = table.Column<float>(type: "real", nullable: false),
                    TemperatureInC = table.Column<float>(type: "real", nullable: false),
                    WindSpeed = table.Column<float>(type: "real", nullable: false),
                    Pressure = table.Column<float>(type: "real", nullable: false),
                    UvSunIndex = table.Column<float>(type: "real", nullable: false),
                    FavoriteDestinationUserId = table.Column<int>(type: "int", nullable: true),
                    FavoriteDestinationCityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherStatus", x => x.WeatherId);
                    table.ForeignKey(
                        name: "FK_WeatherStatus_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeatherStatus_FavoriteDestinations_FavoriteDestinationUserId_FavoriteDestinationCityId",
                        columns: x => new { x.FavoriteDestinationUserId, x.FavoriteDestinationCityId },
                        principalTable: "FavoriteDestinations",
                        principalColumns: new[] { "UserId", "CityId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SuggestBoardImages",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuggestId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "varchar(255)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuggestBoardImages", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_SuggestBoardImages_SuggestBoards_SuggestId",
                        column: x => x.SuggestId,
                        principalTable: "SuggestBoards",
                        principalColumn: "SuggestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingSchedules_CityId",
                table: "BookingSchedules",
                column: "CityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookingSchedules_UserId",
                table: "BookingSchedules",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteDestinations_CityId",
                table: "FavoriteDestinations",
                column: "CityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteDestinations_UserId",
                table: "FavoriteDestinations",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SuggestBoardImages_SuggestId",
                table: "SuggestBoardImages",
                column: "SuggestId");

            migrationBuilder.CreateIndex(
                name: "IX_SuggestBoards_CityId",
                table: "SuggestBoards",
                column: "CityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransportHistories_UserId",
                table: "TransportHistories",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeatherStatus_CityId",
                table: "WeatherStatus",
                column: "CityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeatherStatus_FavoriteDestinationUserId_FavoriteDestinationCityId",
                table: "WeatherStatus",
                columns: new[] { "FavoriteDestinationUserId", "FavoriteDestinationCityId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingSchedules");

            migrationBuilder.DropTable(
                name: "SuggestBoardImages");

            migrationBuilder.DropTable(
                name: "TransportHistories");

            migrationBuilder.DropTable(
                name: "WeatherStatus");

            migrationBuilder.DropTable(
                name: "SuggestBoards");

            migrationBuilder.DropTable(
                name: "FavoriteDestinations");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
