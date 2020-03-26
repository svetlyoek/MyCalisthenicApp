namespace MyCalisthenicApp.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class CollectionOfUserNamesLikesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LikesUsersNames",
                table: "Programs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LikesUsersNames",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LikesUsersNames",
                table: "Post",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LikesUsersNames",
                table: "Comments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikesUsersNames",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "LikesUsersNames",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LikesUsersNames",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "LikesUsersNames",
                table: "Comments");
        }
    }
}
