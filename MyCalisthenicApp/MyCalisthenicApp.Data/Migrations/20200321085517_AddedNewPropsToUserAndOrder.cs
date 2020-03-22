namespace MyCalisthenicApp.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddedNewPropsToUserAndOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MembershipPrice",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasMembership",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MembershipPrice",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "HasMembership",
                table: "AspNetUsers");
        }
    }
}
