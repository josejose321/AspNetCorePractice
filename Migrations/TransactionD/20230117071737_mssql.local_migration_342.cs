using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace practiceAuthentication.Migrations.TransactionD
{
    public partial class mssqllocal_migration_342 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperience_Practices_userID",
                table: "WorkExperience");

            migrationBuilder.DropIndex(
                name: "IX_WorkExperience_userID",
                table: "WorkExperience");

            migrationBuilder.DropColumn(
                name: "userID",
                table: "WorkExperience");

            migrationBuilder.AddColumn<int>(
                name: "PracticeId",
                table: "WorkExperience",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkExperienceId",
                table: "Practices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperience_PracticeId",
                table: "WorkExperience",
                column: "PracticeId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperience_Practices_PracticeId",
                table: "WorkExperience",
                column: "PracticeId",
                principalTable: "Practices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperience_Practices_PracticeId",
                table: "WorkExperience");

            migrationBuilder.DropIndex(
                name: "IX_WorkExperience_PracticeId",
                table: "WorkExperience");

            migrationBuilder.DropColumn(
                name: "PracticeId",
                table: "WorkExperience");

            migrationBuilder.DropColumn(
                name: "WorkExperienceId",
                table: "Practices");

            migrationBuilder.AddColumn<int>(
                name: "userID",
                table: "WorkExperience",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperience_userID",
                table: "WorkExperience",
                column: "userID");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperience_Practices_userID",
                table: "WorkExperience",
                column: "userID",
                principalTable: "Practices",
                principalColumn: "ID");
        }
    }
}
