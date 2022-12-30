using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPnetWebApp.Migrations
{
    public partial class yeees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PairRecords_Users_PairedUserId",
                table: "PairRecords");

            migrationBuilder.DropIndex(
                name: "IX_PairRecords_PairedUserId",
                table: "PairRecords");

            migrationBuilder.CreateIndex(
                name: "IX_PairRecords_UserId",
                table: "PairRecords",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PairRecords_Users_UserId",
                table: "PairRecords",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PairRecords_Users_UserId",
                table: "PairRecords");

            migrationBuilder.DropIndex(
                name: "IX_PairRecords_UserId",
                table: "PairRecords");

            migrationBuilder.CreateIndex(
                name: "IX_PairRecords_PairedUserId",
                table: "PairRecords",
                column: "PairedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PairRecords_Users_PairedUserId",
                table: "PairRecords",
                column: "PairedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
