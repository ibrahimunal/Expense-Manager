using Microsoft.EntityFrameworkCore.Migrations;

namespace Forms.Migrations.Expense
{
    public partial class ExpenseUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "catalouge",
                table: "ExpenseList",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ExpenseList",
                type: "nvarchar(20)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ExpenseList");

            migrationBuilder.AlterColumn<string>(
                name: "catalouge",
                table: "ExpenseList",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");
        }
    }
}
