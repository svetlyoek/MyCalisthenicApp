namespace MyCalisthenicApp.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RemovedPropsForLIkes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserVoteId",
                table: "Programs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserVoteId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserVoteId",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserVoteId",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
