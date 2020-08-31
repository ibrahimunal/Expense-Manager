using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Forms.Migrations.Expense
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenseList",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    amount = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    catalouge = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseList", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseList");
        }
    }
}
