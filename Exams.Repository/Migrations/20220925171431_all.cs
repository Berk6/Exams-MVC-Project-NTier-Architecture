using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exams.Repository.Migrations
{
    public partial class all : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_AspNetUsers_UserId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "check",
                table: "TestModels");

            migrationBuilder.DropColumn(
                name: "QuestionPoint",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Questions",
                newName: "CreaterId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_UserId",
                table: "Questions",
                newName: "IX_Questions_CreaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_AspNetUsers_CreaterId",
                table: "Questions",
                column: "CreaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_AspNetUsers_CreaterId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "CreaterId",
                table: "Questions",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_CreaterId",
                table: "Questions",
                newName: "IX_Questions_UserId");

            migrationBuilder.AddColumn<bool>(
                name: "check",
                table: "TestModels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "QuestionPoint",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_AspNetUsers_UserId",
                table: "Questions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
