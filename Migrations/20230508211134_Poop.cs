using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb4_API.Migrations
{
    /// <inheritdoc />
    public partial class Poop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterestDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInterests",
                columns: table => new
                {
                    UserInterestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    InterestID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterests", x => x.UserInterestID);
                    table.ForeignKey(
                        name: "FK_UserInterests_Interests_InterestID",
                        column: x => x.InterestID,
                        principalTable: "Interests",
                        principalColumn: "InterestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInterests_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterestLinks",
                columns: table => new
                {
                    InterestLinkID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserInterestID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestLinks", x => x.InterestLinkID);
                    table.ForeignKey(
                        name: "FK_InterestLinks_UserInterests_UserInterestID",
                        column: x => x.UserInterestID,
                        principalTable: "UserInterests",
                        principalColumn: "UserInterestID");
                });

            migrationBuilder.InsertData(
                table: "InterestLinks",
                columns: new[] { "InterestLinkID", "Link", "UserInterestID" },
                values: new object[,]
                {
                    { 1, "https://en.wikipedia.org/wiki/Skateboarding", null },
                    { 2, "https://www.ibm.com/topics/software-development", null },
                    { 3, "https://en.wikipedia.org/wiki/Surfing", null },
                    { 4, "https://en.wikipedia.org/wiki/Snowboarding", null }
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestID", "InterestDesc", "Name" },
                values: new object[,]
                {
                    { 1, "Skateboarding", "Skateboarding" },
                    { 2, "Developing Software on the computer", "Computers" },
                    { 3, "Riding a board on waves in the water", "Surfing" },
                    { 4, "Riding a board on snow", "Snowboarding" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "Peter", "Ingvarsson", "070252542" },
                    { 2, "Adrian", "Lundell", "070632175" },
                    { 3, "Sam", "Svensson", "070154323" }
                });

            migrationBuilder.InsertData(
                table: "UserInterests",
                columns: new[] { "UserInterestID", "InterestID", "UserID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterestLinks_UserInterestID",
                table: "InterestLinks",
                column: "UserInterestID");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_InterestID",
                table: "UserInterests",
                column: "InterestID");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_UserID",
                table: "UserInterests",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestLinks");

            migrationBuilder.DropTable(
                name: "UserInterests");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
