using Microsoft.EntityFrameworkCore.Migrations;

namespace TvPlus.DataAccess.Migrations
{
    public partial class AddedIsTopTenToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTopTen",
                table: "Centers_Posts");

            migrationBuilder.DropColumn(
                name: "IsTrendTv",
                table: "Centers_Posts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "db5c91a5-8e61-4231-9d41-2e7e756aacaa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "985fc0d5-f1db-4cc7-b230-8ef0111ca6e6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "fdf25138-39d4-4ca7-9982-b274f1ab7740");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b86d3156-cd78-4067-8b5e-7ce35d6c7278", "AQAAAAEAACcQAAAAEN5NPSOYc6LF7CIqMzbMkmeIA9zl7+CM0zRRwbf3gmjARcVJdU5MAPVXSBayPGm3uQ==", "f1ce536d-149a-4399-af09-ab5fc240e137" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5a881e13-7728-40ea-a12b-4560fddadfc9", "f4df2aa9-3451-48a9-8d50-052533b62901" });
        }
    }
}
