using Microsoft.EntityFrameworkCore.Migrations;

namespace News.Migrations
{
    public partial class NewsModelDbContextNewsContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "News",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "News");
        }
    }
}
