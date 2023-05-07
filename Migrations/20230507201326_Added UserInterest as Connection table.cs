using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb4_API.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserInterestasConnectiontable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestLinks_Users_UserID",
                table: "InterestLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_Interests_InterestLinks_InterestLinkID",
                table: "Interests");

            migrationBuilder.DropIndex(
                name: "IX_Interests_InterestLinkID",
                table: "Interests");

            migrationBuilder.DropIndex(
                name: "IX_InterestLinks_UserID",
                table: "InterestLinks");

            migrationBuilder.DeleteData(
                table: "InterestLinks",
                keyColumn: "InterestLinkID",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "InterestLinkID",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "InterestID",
                table: "InterestLinks");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "InterestLinks");

            migrationBuilder.CreateTable(
                name: "UserInterests",
                columns: table => new
                {
                    UserInterestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    InterestLinkID = table.Column<int>(type: "int", nullable: false),
                    InterestID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterests", x => x.UserInterestID);
                    table.ForeignKey(
                        name: "FK_UserInterests_InterestLinks_InterestLinkID",
                        column: x => x.InterestLinkID,
                        principalTable: "InterestLinks",
                        principalColumn: "InterestLinkID",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "UserInterests",
                columns: new[] { "UserInterestID", "InterestID", "InterestLinkID", "UserID" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 2, 2 },
                    { 3, 3, 3, 3 },
                    { 4, 4, 4, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_InterestID",
                table: "UserInterests",
                column: "InterestID");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_InterestLinkID",
                table: "UserInterests",
                column: "InterestLinkID");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_UserID",
                table: "UserInterests",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInterests");

            migrationBuilder.AddColumn<int>(
                name: "InterestLinkID",
                table: "Interests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InterestID",
                table: "InterestLinks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "InterestLinks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "InterestLinks",
                keyColumn: "InterestLinkID",
                keyValue: 1,
                columns: new[] { "InterestID", "UserID" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "InterestLinks",
                keyColumn: "InterestLinkID",
                keyValue: 2,
                columns: new[] { "InterestID", "UserID" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "InterestLinks",
                keyColumn: "InterestLinkID",
                keyValue: 3,
                columns: new[] { "InterestID", "UserID" },
                values: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "InterestLinks",
                keyColumn: "InterestLinkID",
                keyValue: 4,
                columns: new[] { "InterestID", "UserID" },
                values: new object[] { 4, 3 });

            migrationBuilder.InsertData(
                table: "InterestLinks",
                columns: new[] { "InterestLinkID", "InterestID", "Link", "UserID" },
                values: new object[] { 5, 4, "", 2 });

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestID",
                keyValue: 1,
                column: "InterestLinkID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestID",
                keyValue: 2,
                column: "InterestLinkID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestID",
                keyValue: 3,
                column: "InterestLinkID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Interests",
                keyColumn: "InterestID",
                keyValue: 4,
                column: "InterestLinkID",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Interests_InterestLinkID",
                table: "Interests",
                column: "InterestLinkID");

            migrationBuilder.CreateIndex(
                name: "IX_InterestLinks_UserID",
                table: "InterestLinks",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestLinks_Users_UserID",
                table: "InterestLinks",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_InterestLinks_InterestLinkID",
                table: "Interests",
                column: "InterestLinkID",
                principalTable: "InterestLinks",
                principalColumn: "InterestLinkID");
        }
    }
}
