using Microsoft.EntityFrameworkCore.Migrations;

namespace TvPlus.DataAccess.Migrations
{
    public partial class UpdatedVideoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "Videos",
                newName: "VideoName");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "VideoConverts",
                newName: "VideoName");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "Images",
                newName: "ImageName");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VideoName",
                table: "Videos",
                newName: "FilePath");

            migrationBuilder.RenameColumn(
                name: "VideoName",
                table: "VideoConverts",
                newName: "FilePath");

            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "Images",
                newName: "FilePath");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "c0829e5a-8fda-4598-9827-f6fbaf285d2e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "ed0b5b82-1981-473b-81f0-c672cd83f691");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "3fd1ec60-95c3-4f23-b780-91f87227003e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e69bad5-fef2-49f1-bc73-33791a8f6a2c", "AQAAAAEAACcQAAAAECmcaPlj5qcMylDs+tTDiWTdBiI9yTSw+ma6f2dVmsek0Blw5rAQ6KBFiwsDLKMhPw==", "ccf60c4e-e8ef-4879-968e-eba7dfaca653" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ba5b826e-dacb-4982-bc08-fbc741f12cb8", "0b26336f-5bbd-4be5-98be-887843a57f7c" });
        }
    }
}
