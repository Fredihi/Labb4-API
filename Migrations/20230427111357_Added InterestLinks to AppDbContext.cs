using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb4_API.Migrations
{
    /// <inheritdoc />
    public partial class AddedInterestLinkstoAppDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestLink_Interests_InterestID",
                table: "InterestLink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterestLink",
                table: "InterestLink");

            migrationBuilder.RenameTable(
                name: "InterestLink",
                newName: "InterestLinks");

            migrationBuilder.RenameIndex(
                name: "IX_InterestLink_InterestID",
                table: "InterestLinks",
                newName: "IX_InterestLinks_InterestID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterestLinks",
                table: "InterestLinks",
                column: "InterestLinkID");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestLinks_Interests_InterestID",
                table: "InterestLinks",
                column: "InterestID",
                principalTable: "Interests",
                principalColumn: "InterestID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestLinks_Interests_InterestID",
                table: "InterestLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterestLinks",
                table: "InterestLinks");

            migrationBuilder.RenameTable(
                name: "InterestLinks",
                newName: "InterestLink");

            migrationBuilder.RenameIndex(
                name: "IX_InterestLinks_InterestID",
                table: "InterestLink",
                newName: "IX_InterestLink_InterestID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterestLink",
                table: "InterestLink",
                column: "InterestLinkID");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestLink_Interests_InterestID",
                table: "InterestLink",
                column: "InterestID",
                principalTable: "Interests",
                principalColumn: "InterestID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
