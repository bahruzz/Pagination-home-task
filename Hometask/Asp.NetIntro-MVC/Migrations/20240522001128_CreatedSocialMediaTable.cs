using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.NetIntro_MVC.Migrations
{
    public partial class CreatedSocialMediaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoftDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 22, 4, 11, 27, 819, DateTimeKind.Local).AddTicks(5376));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 22, 4, 11, 27, 819, DateTimeKind.Local).AddTicks(5377));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 22, 4, 11, 27, 819, DateTimeKind.Local).AddTicks(5378));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 22, 4, 11, 27, 819, DateTimeKind.Local).AddTicks(5364));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 22, 4, 11, 27, 819, DateTimeKind.Local).AddTicks(5366));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 22, 4, 11, 27, 819, DateTimeKind.Local).AddTicks(5367));

            migrationBuilder.InsertData(
                table: "SocialMedias",
                columns: new[] { "Id", "CreatedDate", "Name", "SoftDeleted", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 22, 4, 11, 27, 819, DateTimeKind.Local).AddTicks(5253), "Twitter", false, "www.twitter.com" },
                    { 2, new DateTime(2024, 5, 22, 4, 11, 27, 819, DateTimeKind.Local).AddTicks(5255), "Instagram", false, "www.instagram.com" },
                    { 3, new DateTime(2024, 5, 22, 4, 11, 27, 819, DateTimeKind.Local).AddTicks(5257), "Tumblr", false, "www.tumblr.com" },
                    { 4, new DateTime(2024, 5, 22, 4, 11, 27, 819, DateTimeKind.Local).AddTicks(5258), "Pinterest", false, "www.pinterest.com" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 22, 3, 27, 11, 826, DateTimeKind.Local).AddTicks(203));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 22, 3, 27, 11, 826, DateTimeKind.Local).AddTicks(205));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 22, 3, 27, 11, 826, DateTimeKind.Local).AddTicks(206));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 22, 3, 27, 11, 826, DateTimeKind.Local).AddTicks(98));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 22, 3, 27, 11, 826, DateTimeKind.Local).AddTicks(100));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 22, 3, 27, 11, 826, DateTimeKind.Local).AddTicks(101));
        }
    }
}
