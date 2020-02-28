using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCalisthenicApp.Data.Migrations
{
    public partial class ChangeImageAndAllrefernceTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Images_ImageId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Images_ImageId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Programs_Images_ImageId",
                table: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Programs_ImageId",
                table: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Post_ImageId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_ImageId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Post");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "Images",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ExerciseId",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostId",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProgramId",
                table: "Images",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageId",
                table: "Exercises",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ExerciseId",
                table: "Images",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_PostId",
                table: "Images",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProgramId",
                table: "Images",
                column: "ProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Exercises_ExerciseId",
                table: "Images",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Post_PostId",
                table: "Images",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Programs_ProgramId",
                table: "Images",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Exercises_ExerciseId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Post_PostId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Programs_ProgramId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ExerciseId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_PostId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ProgramId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ProgramId",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "Programs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "Post",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "Images",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageId",
                table: "Exercises",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Programs_ImageId",
                table: "Programs",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_ImageId",
                table: "Post",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ImageId",
                table: "Exercises",
                column: "ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Images_ImageId",
                table: "Exercises",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Images_ImageId",
                table: "Post",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Programs_Images_ImageId",
                table: "Programs",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
