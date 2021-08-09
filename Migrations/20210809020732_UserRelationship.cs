using Microsoft.EntityFrameworkCore.Migrations;

namespace Courses.Migrations
{
    public partial class UserRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserRegisterOfApplicationUser",
                table: "UserRegisters",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserRegisters_UserRegisterOfApplicationUser",
                table: "UserRegisters",
                column: "UserRegisterOfApplicationUser",
                unique: true,
                filter: "[UserRegisterOfApplicationUser] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRegisters_AspNetUsers_UserRegisterOfApplicationUser",
                table: "UserRegisters",
                column: "UserRegisterOfApplicationUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRegisters_AspNetUsers_UserRegisterOfApplicationUser",
                table: "UserRegisters");

            migrationBuilder.DropIndex(
                name: "IX_UserRegisters_UserRegisterOfApplicationUser",
                table: "UserRegisters");

            migrationBuilder.DropColumn(
                name: "UserRegisterOfApplicationUser",
                table: "UserRegisters");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
