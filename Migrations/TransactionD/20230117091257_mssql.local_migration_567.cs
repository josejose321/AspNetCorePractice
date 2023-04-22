using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace practiceAuthentication.Migrations.TransactionD
{
    public partial class mssqllocal_migration_567 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperience_Practices_PracticeId",
                table: "WorkExperience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkExperience",
                table: "WorkExperience");

            migrationBuilder.DropColumn(
                name: "WorkExperienceId",
                table: "Practices");

            migrationBuilder.RenameTable(
                name: "WorkExperience",
                newName: "WorkExperiences");

            migrationBuilder.RenameIndex(
                name: "IX_WorkExperience_PracticeId",
                table: "WorkExperiences",
                newName: "IX_WorkExperiences_PracticeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkExperiences",
                table: "WorkExperiences",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperiences_Practices_PracticeId",
                table: "WorkExperiences",
                column: "PracticeId",
                principalTable: "Practices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperiences_Practices_PracticeId",
                table: "WorkExperiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkExperiences",
                table: "WorkExperiences");

            migrationBuilder.RenameTable(
                name: "WorkExperiences",
                newName: "WorkExperience");

            migrationBuilder.RenameIndex(
                name: "IX_WorkExperiences_PracticeId",
                table: "WorkExperience",
                newName: "IX_WorkExperience_PracticeId");

            migrationBuilder.AddColumn<int>(
                name: "WorkExperienceId",
                table: "Practices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkExperience",
                table: "WorkExperience",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperience_Practices_PracticeId",
                table: "WorkExperience",
                column: "PracticeId",
                principalTable: "Practices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
