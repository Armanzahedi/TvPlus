using Microsoft.EntityFrameworkCore.Migrations;

namespace TvPlus.DataAccess.Migrations
{
    public partial class AddedVideoConvert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoConvert_Videos_VideoId",
                table: "VideoConvert");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoConvert",
                table: "VideoConvert");

            migrationBuilder.RenameTable(
                name: "VideoConvert",
                newName: "VideoConverts");

            migrationBuilder.RenameIndex(
                name: "IX_VideoConvert_VideoId",
                table: "VideoConverts",
                newName: "IX_VideoConverts_VideoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoConverts",
                table: "VideoConverts",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_VideoConverts_Videos_VideoId",
                table: "VideoConverts",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoConverts_Videos_VideoId",
                table: "VideoConverts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoConverts",
                table: "VideoConverts");

            migrationBuilder.RenameTable(
                name: "VideoConverts",
                newName: "VideoConvert");

            migrationBuilder.RenameIndex(
                name: "IX_VideoConverts_VideoId",
                table: "VideoConvert",
                newName: "IX_VideoConvert_VideoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoConvert",
                table: "VideoConvert",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "74611e2b-5a21-4d07-b090-142208ee0244");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "504e275d-2448-4173-9635-42440dc9d847");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "d2c5a144-4bb7-4bc7-9a99-8477028c17ab");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "112830f0-08c6-4109-b063-e6ea7ca48f2d", "AQAAAAEAACcQAAAAEKEsB3k34ebMBddlhmg1C1wlD/XAVV+PyIQ1q4LIw02gAL7CI1r1zc/NRgWV3l4F1w==", "d01d003f-852d-4670-a88d-e4a406f5322a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e3cbbaa0-e8c8-43c1-9f22-126114d2f97b", "c41c82ea-9b91-45df-a880-c65c17f420ea" });

            migrationBuilder.AddForeignKey(
                name: "FK_VideoConvert_Videos_VideoId",
                table: "VideoConvert",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
