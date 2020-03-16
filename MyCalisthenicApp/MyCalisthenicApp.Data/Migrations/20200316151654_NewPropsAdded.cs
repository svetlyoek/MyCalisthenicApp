namespace MyCalisthenicApp.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class NewPropsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikesCount",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Programs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Post",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Post");

            migrationBuilder.AddColumn<int>(
                name: "LikesCount",
                table: "Products",
                type: "int",
                nullable: true);
        }
    }
}
