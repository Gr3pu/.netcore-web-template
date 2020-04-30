using Microsoft.EntityFrameworkCore.Migrations;

namespace Templates.WebApp.Migrations
{
    public partial class somedata2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Agreements",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Agreements",
                table: "AspNetUsers");
        }
    }
}
