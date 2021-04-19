using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TvPlus.DataAccess.Migrations
{
    public partial class AddedAboutUsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutUse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AboutUsSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutUsId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUsSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboutUsSections_AboutUse_AboutUsId",
                        column: x => x.AboutUsId,
                        principalTable: "AboutUse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "3adbee38-5fac-44a6-a324-40fe2b502204");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "845e549e-b910-418e-a480-953fac981038");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "c30a104f-3b10-4e81-ba5c-27065475bc98");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24d442cc-d4d3-4d93-8a6e-76cc0d5fdf79", "AQAAAAEAACcQAAAAEEfWnRhxEPGYA+Z/ygV+z+aSGUEAILJsx3r+pc3rgVWUpLJ2bp4PvaVcNdR7ancDmA==", "ea82ba49-99a9-4e45-9c73-04a730c704d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "be510de0-065f-4055-a8b2-3bc238448241", "a8f3b103-2808-4b4e-b930-e08423edb3fb" });

            migrationBuilder.CreateIndex(
                name: "IX_AboutUsSections_AboutUsId",
                table: "AboutUsSections",
                column: "AboutUsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUsSections");

            migrationBuilder.DropTable(
                name: "AboutUse");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "30a22c1e-e5af-49d3-9fa3-f50acd379b2e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "6335d5e9-6ab8-4458-87a7-e2432c57d643");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "6cb504d0-3e5d-450a-b1c8-17b658440219");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "047859d7-7c95-4ffa-9d3a-086f5b13b1d2", "AQAAAAEAACcQAAAAEJUGRtSwesypZ4P7KtlFIYqS8+EQWQ7Y4QRxzsmGwTB2WauemJUD9RQCzvWj/BsFMA==", "0c6ed2c3-e9f0-442e-b3c1-a9b0953cf19a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5ab77fc0-f106-4c64-8e95-0c87ab761c87", "55b08d93-6aad-478a-acc3-06ba2852bf6a" });
        }
    }
}
