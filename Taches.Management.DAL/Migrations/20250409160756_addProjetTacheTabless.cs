using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taches.Management.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addProjetTacheTabless : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taches_AspNetUsers_applicationUserId",
                table: "Taches");

            migrationBuilder.DropIndex(
                name: "IX_Taches_applicationUserId",
                table: "Taches");

            migrationBuilder.DropColumn(
                name: "applicationUserId",
                table: "Taches");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Taches",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Taches_UserId",
                table: "Taches",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Taches_AspNetUsers_UserId",
                table: "Taches",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taches_AspNetUsers_UserId",
                table: "Taches");

            migrationBuilder.DropIndex(
                name: "IX_Taches_UserId",
                table: "Taches");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Taches");

            migrationBuilder.AddColumn<string>(
                name: "applicationUserId",
                table: "Taches",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Taches_applicationUserId",
                table: "Taches",
                column: "applicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Taches_AspNetUsers_applicationUserId",
                table: "Taches",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
