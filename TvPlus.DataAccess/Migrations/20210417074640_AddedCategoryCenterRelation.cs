using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TvPlus.DataAccess.Migrations
{
    public partial class AddedCategoryCenterRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CenterCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CenterId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CenterCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CenterCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CenterCategories_Centers_CenterId",
                        column: x => x.CenterId,
                        principalTable: "Centers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "a5827808-c60d-457c-b5d7-9e33ab1986c6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "fff1afd4-cd2a-4721-a2ea-83af71297597");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "82cccc07-9989-4adf-8e00-b5ad94872f90");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c11481da-a196-48f1-8fc8-1106065d17c5", "AQAAAAEAACcQAAAAEGnLZIRgI8pJI75FYsgSnH6dvoc39wifVgyh5HBElCfEabohXE23St+Jk8WueoZWmA==", "ee6a5730-2718-4266-80b7-b96f08b336bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2b22ec8c-0019-49c8-821e-7d0663c836f2", "ea5f2a4d-efce-4dd7-be7c-01b15686a218" });

            migrationBuilder.CreateIndex(
                name: "IX_CenterCategories_CategoryId",
                table: "CenterCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CenterCategories_CenterId",
                table: "CenterCategories",
                column: "CenterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CenterCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "63a4300e-9900-4595-845c-b106dbc2856f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "06a7a862-7b5f-4391-be2d-1c9089037c40");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "eda2b9d0-81c3-4306-8977-b4bd5d58461b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "45f07337-0d27-4cef-99ba-18c746e1f7ab", "AQAAAAEAACcQAAAAECtHkLwDaG3XpdtezS8DzYcq79qXF1GxSL60gKzFBt1Rq3JhsoJx4+bluR+t5/Vjzg==", "3e98e5d0-2499-489f-a1da-3b48c6e50cb7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d479e82b-6d66-4612-9aeb-3e5b2179cbd6", "c7109370-e4be-4547-819f-fd5d7bbc5664" });
        }
    }
}
