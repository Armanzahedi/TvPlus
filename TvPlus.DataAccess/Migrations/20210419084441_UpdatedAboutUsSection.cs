using Microsoft.EntityFrameworkCore.Migrations;

namespace TvPlus.DataAccess.Migrations
{
    public partial class UpdatedAboutUsSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "AboutUsSections");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "95e2e186-7772-4648-a004-5fb2bdadc2b1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "654f70d3-27a3-4a07-aa5d-22091d0009e0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "e48effcf-ccc9-4726-8608-34d02121f701");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18ba7abb-5bc9-4e4f-a5c2-33dd2e80de7c", "AQAAAAEAACcQAAAAENzi0nHabLg83w9qhzmrCxqWnvATMQsXSt/BoP2sdRDT/NyHBaqUDGnhQ4Vu9ke2Dw==", "d0d2f2c5-83a9-41cf-ab36-f0954980aaa9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a4668812-f893-4f55-9c7a-b87727d7be1a", "df710675-0a8b-419b-b5e3-3b1856638e71" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "AboutUsSections",
                type: "nvarchar(max)",
                nullable: true);

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
        }
    }
}
