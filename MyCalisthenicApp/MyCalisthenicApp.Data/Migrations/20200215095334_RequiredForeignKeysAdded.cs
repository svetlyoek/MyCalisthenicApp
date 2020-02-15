using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCalisthenicApp.Data.Migrations
{
    public partial class RequiredForeignKeysAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Images_ImageId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Programs_ProgramCategories_CategoryId",
                table: "Programs");

            migrationBuilder.DropForeignKey(
                name: "FK_Programs_Images_ImageId",
                table: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Programs_CategoryId",
                table: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Programs_ImageId",
                table: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_ImageId",
                table: "Exercises");

            migrationBuilder.AlterColumn<string>(
                name: "ProgramCategoryId",
                table: "ProgramSubCategories",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageId",
                table: "Programs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Programs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Post",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Post",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryAddressId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "Images",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProgramSubCategoryId",
                table: "Exercises",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageId",
                table: "Exercises",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CityId",
                table: "Addresses",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Programs_CategoryId",
                table: "Programs",
                column: "CategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Programs_ImageId",
                table: "Programs",
                column: "ImageId",
                unique: true);

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
                name: "FK_Programs_ProgramCategories_CategoryId",
                table: "Programs",
                column: "CategoryId",
                principalTable: "ProgramCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Programs_Images_ImageId",
                table: "Programs",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Images_ImageId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Programs_ProgramCategories_CategoryId",
                table: "Programs");

            migrationBuilder.DropForeignKey(
                name: "FK_Programs_Images_ImageId",
                table: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Programs_CategoryId",
                table: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Programs_ImageId",
                table: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_ImageId",
                table: "Exercises");

            migrationBuilder.AlterColumn<string>(
                name: "ProgramCategoryId",
                table: "ProgramSubCategories",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ImageId",
                table: "Programs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Programs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Post",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Post",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryAddressId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "Images",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProgramSubCategoryId",
                table: "Exercises",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ImageId",
                table: "Exercises",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CityId",
                table: "Addresses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Programs_CategoryId",
                table: "Programs",
                column: "CategoryId",
                unique: true,
                filter: "[CategoryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_ImageId",
                table: "Programs",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ImageId",
                table: "Exercises",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Images_ImageId",
                table: "Exercises",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Programs_ProgramCategories_CategoryId",
                table: "Programs",
                column: "CategoryId",
                principalTable: "ProgramCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Programs_Images_ImageId",
                table: "Programs",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
