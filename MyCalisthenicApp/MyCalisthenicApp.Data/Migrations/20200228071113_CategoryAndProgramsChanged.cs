namespace MyCalisthenicApp.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class CategoryAndProgramsChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programs_ProgramCategories_CategoryId",
                table: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Programs_CategoryId",
                table: "Programs");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_CategoryId",
                table: "Programs",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Programs_ProgramCategories_CategoryId",
                table: "Programs",
                column: "CategoryId",
                principalTable: "ProgramCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programs_ProgramCategories_CategoryId",
                table: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Programs_CategoryId",
                table: "Programs");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_CategoryId",
                table: "Programs",
                column: "CategoryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Programs_ProgramCategories_CategoryId",
                table: "Programs",
                column: "CategoryId",
                principalTable: "ProgramCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
