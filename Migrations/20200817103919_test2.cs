using Microsoft.EntityFrameworkCore.Migrations;

namespace Forms.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "checkPassword",
                table: "UserContext",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "checkPassword",
                table: "UserContext");
        }
    }
}
