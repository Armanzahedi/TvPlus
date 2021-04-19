using Microsoft.EntityFrameworkCore.Migrations;

namespace TvPlus.DataAccess.Migrations
{
    public partial class FixedAboutUsName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AboutUsSections_AboutUse_AboutUsId",
                table: "AboutUsSections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AboutUse",
                table: "AboutUse");

            migrationBuilder.RenameTable(
                name: "AboutUse",
                newName: "AboutUs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AboutUs",
                table: "AboutUs",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "667db7a5-c349-43a7-a320-8c4aa3cfdc3c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "55370c1e-e4d7-4ad1-a000-9ec079d3902a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "b1ff0fde-481c-47f9-abd8-dd08cace8276");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fea45518-b92f-4c13-b8f2-cd93767bc668", "AQAAAAEAACcQAAAAEM6ZtvRUbvcq0fQDgkkJuUlG9rv5X5FS3rRtNT84ADc+qLpWJ0mio4llcFwQ/O82Cg==", "57177644-83e8-41ef-b9f4-d3b9625eb373" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5090fc4a-6047-4c5e-b200-aaf91d109b3f", "7ffc599b-53aa-4b31-a4e8-476d9c6b9290" });

            migrationBuilder.AddForeignKey(
                name: "FK_AboutUsSections_AboutUs_AboutUsId",
                table: "AboutUsSections",
                column: "AboutUsId",
                principalTable: "AboutUs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AboutUsSections_AboutUs_AboutUsId",
                table: "AboutUsSections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AboutUs",
                table: "AboutUs");

            migrationBuilder.RenameTable(
                name: "AboutUs",
                newName: "AboutUse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AboutUse",
                table: "AboutUse",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AboutUsSections_AboutUse_AboutUsId",
                table: "AboutUsSections",
                column: "AboutUsId",
                principalTable: "AboutUse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
