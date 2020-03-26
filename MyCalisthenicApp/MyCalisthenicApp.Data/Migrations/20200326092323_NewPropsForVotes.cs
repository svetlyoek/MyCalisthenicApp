namespace MyCalisthenicApp.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class NewPropsForVotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserVoteId",
                table: "Programs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserVoteId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserVoteId",
                table: "Post",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserVoteId",
                table: "Comments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserVoteId",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "UserVoteId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserVoteId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "UserVoteId",
                table: "Comments");
        }
    }
}
