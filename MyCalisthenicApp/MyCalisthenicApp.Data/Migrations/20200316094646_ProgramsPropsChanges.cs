namespace MyCalisthenicApp.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ProgramsPropsChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ProgramCategories_CategoryId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CategoryId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "ProgramId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProgramId",
                table: "Comments",
                column: "ProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Programs_ProgramId",
                table: "Comments",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Programs_ProgramId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ProgramId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ProgramId",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CategoryId",
                table: "Comments",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ProgramCategories_CategoryId",
                table: "Comments",
                column: "CategoryId",
                principalTable: "ProgramCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
