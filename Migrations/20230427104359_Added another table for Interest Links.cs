using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb4_API.Migrations
{
    /// <inheritdoc />
    public partial class AddedanothertableforInterestLinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InterestLink",
                table: "Interests");

            migrationBuilder.CreateTable(
                name: "InterestLink",
                columns: table => new
                {
                    InterestLinkID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterestID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestLink", x => x.InterestLinkID);
                    table.ForeignKey(
                        name: "FK_InterestLink_Interests_InterestID",
                        column: x => x.InterestID,
                        principalTable: "Interests",
                        principalColumn: "InterestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "InterestLink",
                columns: new[] { "InterestLinkID", "InterestID", "Link" },
                values: new object[,]
                {
                    { 1, 1, "https://en.wikipedia.org/wiki/Skateboarding" },
                    { 2, 2, "https://www.ibm.com/topics/software-development" },
                    { 3, 3, "https://en.wikipedia.org/wiki/Surfing" },
                    { 4, 4, "https://en.wikipedia.org/wiki/Snowboarding" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterestLink_InterestID",
                table: "InterestLink",
                column: "InterestID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestLink");

            migrationBuilder.AddColumn<string>(
                name: "InterestLink",
                table: "Interests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestID",
                keyValue: 1,
                column: "InterestLink",
                value: "https://en.wikipedia.org/wiki/Skateboarding");

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestID",
                keyValue: 2,
                column: "InterestLink",
                value: "https://www.ibm.com/topics/software-development");

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestID",
                keyValue: 3,
                column: "InterestLink",
                value: "https://en.wikipedia.org/wiki/Surfing");

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestID",
                keyValue: 4,
                column: "InterestLink",
                value: "https://en.wikipedia.org/wiki/Snowboarding");
        }
    }
}
