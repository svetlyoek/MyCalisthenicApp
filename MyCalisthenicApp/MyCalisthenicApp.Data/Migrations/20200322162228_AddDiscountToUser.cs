namespace MyCalisthenicApp.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddDiscountToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasCoupon",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasCoupon",
                table: "AspNetUsers");
        }
    }
}
