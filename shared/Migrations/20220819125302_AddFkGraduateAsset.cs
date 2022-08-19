using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shared.Migrations
{
    public partial class AddFkGraduateAsset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Graduates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Graduates_ImageId",
                table: "Graduates",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Graduates_Asset_ImageId",
                table: "Graduates",
                column: "ImageId",
                principalTable: "Asset",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Graduates_Asset_ImageId",
                table: "Graduates");

            migrationBuilder.DropIndex(
                name: "IX_Graduates_ImageId",
                table: "Graduates");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Graduates");
        }
    }
}
