using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Migrations
{
    /// <inheritdoc />
    public partial class AddedImageUpload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstate_ChuDauTu1",
                table: "Property");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Seller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Property",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "LoginUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Property_ChuDauTu",
                table: "Property",
                column: "ChuDauTu_Id",
                principalTable: "ChuDauTu",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_ChuDauTu",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "LoginUser");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginUser_Id = table.Column<int>(type: "int", nullable: true),
                    News_Id = table.Column<int>(type: "int", nullable: true),
                    RealEstate_Id = table.Column<int>(type: "int", nullable: true),
                    Seller_Id = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_LoginUser",
                        column: x => x.LoginUser_Id,
                        principalTable: "LoginUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_News",
                        column: x => x.News_Id,
                        principalTable: "News",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_RealEstate",
                        column: x => x.RealEstate_Id,
                        principalTable: "Property",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Seller",
                        column: x => x.Seller_Id,
                        principalTable: "Seller",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_LoginUser_Id",
                table: "Images",
                column: "LoginUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Images_News_Id",
                table: "Images",
                column: "News_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Images_RealEstate_Id",
                table: "Images",
                column: "RealEstate_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Images_Seller_Id",
                table: "Images",
                column: "Seller_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstate_ChuDauTu1",
                table: "Property",
                column: "ChuDauTu_Id",
                principalTable: "ChuDauTu",
                principalColumn: "Id");
        }
    }
}
