using Microsoft.EntityFrameworkCore.Migrations;

namespace TvPlus.DataAccess.Migrations
{
    public partial class UpdatedCenter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTopTen",
                table: "Centers_Posts");

            migrationBuilder.DropColumn(
                name: "IsTrendTv",
                table: "Centers_Posts");

            migrationBuilder.AddColumn<bool>(
                name: "IsTopTen",
                table: "Centers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrendTv",
                table: "Centers",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTopTen",
                table: "Centers");

            migrationBuilder.DropColumn(
                name: "IsTrendTv",
                table: "Centers");

            migrationBuilder.AddColumn<bool>(
                name: "IsTopTen",
                table: "Centers_Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrendTv",
                table: "Centers_Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "8b3dee11-73f0-4527-9e1e-57b12f4bfde5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "567a2748-df94-4b5b-8a3e-4234b21c162c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "8fbc061f-73ea-448d-85fd-06998f8b561d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f5025df-638f-465b-8db5-28063e98ce47", "AQAAAAEAACcQAAAAEAbLZGSREZkG2p9r3P/i1Sf+hvI+LnDkg/YdxyMnZoUIKOvrwQ0CTE+xgncshvDC0A==", "a82b5668-bdf1-4593-845d-5c1d15841f00" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ea2296d5-d00b-49bf-b6de-21e9b41e7dd5", "449dd09d-9962-497d-a09c-2f5966af4773" });
        }
    }
}
