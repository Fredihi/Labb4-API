using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb4_API.Migrations
{
    /// <inheritdoc />
    public partial class plshelp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestLinks_UserInterests_UserInterestID",
                table: "InterestLinks");

            migrationBuilder.AlterColumn<int>(
                name: "UserInterestID",
                table: "InterestLinks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "InterestLinks",
                keyColumn: "InterestLinkID",
                keyValue: 1,
                column: "UserInterestID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "InterestLinks",
                keyColumn: "InterestLinkID",
                keyValue: 2,
                column: "UserInterestID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "InterestLinks",
                keyColumn: "InterestLinkID",
                keyValue: 3,
                column: "UserInterestID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "InterestLinks",
                keyColumn: "InterestLinkID",
                keyValue: 4,
                column: "UserInterestID",
                value: 4);

            migrationBuilder.AddForeignKey(
                name: "FK_InterestLinks_UserInterests_UserInterestID",
                table: "InterestLinks",
                column: "UserInterestID",
                principalTable: "UserInterests",
                principalColumn: "UserInterestID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestLinks_UserInterests_UserInterestID",
                table: "InterestLinks");

            migrationBuilder.AlterColumn<int>(
                name: "UserInterestID",
                table: "InterestLinks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "InterestLinks",
                keyColumn: "InterestLinkID",
                keyValue: 1,
                column: "UserInterestID",
                value: null);

            migrationBuilder.UpdateData(
                table: "InterestLinks",
                keyColumn: "InterestLinkID",
                keyValue: 2,
                column: "UserInterestID",
                value: null);

            migrationBuilder.UpdateData(
                table: "InterestLinks",
                keyColumn: "InterestLinkID",
                keyValue: 3,
                column: "UserInterestID",
                value: null);

            migrationBuilder.UpdateData(
                table: "InterestLinks",
                keyColumn: "InterestLinkID",
                keyValue: 4,
                column: "UserInterestID",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_InterestLinks_UserInterests_UserInterestID",
                table: "InterestLinks",
                column: "UserInterestID",
                principalTable: "UserInterests",
                principalColumn: "UserInterestID");
        }
    }
}
