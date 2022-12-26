using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace practiceAuthentication.Migrations.TransactionD
{
    public partial class mssqllocal_migration_113 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Practices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    DateToday = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Practices", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(type: "nvarchar(12)", nullable: true),
                    BeneficiaryName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    SWIFTCode = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Practices");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
