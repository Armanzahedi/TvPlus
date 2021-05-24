using Microsoft.EntityFrameworkCore.Migrations;

namespace TvPlus.DataAccess.Migrations
{
    public partial class AddedSubscriptionRelatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "ca4c3b03-ffb2-4c31-a76a-680302401949");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "4d24decc-8499-4e40-b0af-70cc3d1bd30b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c18a9a73-ae53-487c-9dcd-1794533e0bae", "AQAAAAEAACcQAAAAEOxbLq+X3eZ62/NazjP2aNimuAvhL5LNrYNU0XyX/OWpssZ69dZ1H/edlmK8rjj0Dg==", "98049d6d-4ad4-4821-b2dd-d6baac7bf170" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "47433b6c-b4a9-45e1-83d6-a02598a3d71a", "9321a915-cea7-48ba-8a32-58f6be128cdf" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "0c64af3f-b97d-4a70-b6fc-d9cc0c32f647");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "c23f8781-ba4b-406b-be31-b7e0d10c1cd9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "29bd76db-5835-406d-ad1d-7a0901448abd", "dc358be9-6a17-4ad6-ba16-93bcf500e721", "Superuser", "SUPERUSER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65210ef5-3b51-44ac-91bc-e34ba3ddbe84", "AQAAAAEAACcQAAAAEPnk354D86VqHLQFlFxSes4xNYdvB5KcR11h7xatwtezrwwBx9fAFb13WjfgdROp3Q==", "dafe3d29-595e-4266-9199-4dd7852d6a74" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "03762546-8422-4307-b7eb-bf696aa0a7f9", "2f63ae32-671b-4983-9b55-6382bcbe23cf" });
        }
    }
}
