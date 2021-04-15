using Microsoft.EntityFrameworkCore.Migrations;

namespace TvPlus.DataAccess.Migrations
{
    public partial class tablename3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Center_People_Centers_Id",
                table: "Center_People");

            migrationBuilder.DropForeignKey(
                name: "FK_Center_Posts_Centers_Id",
                table: "Center_Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Center_SpecialEvents_Centers_Id",
                table: "Center_SpecialEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_Center_Tags_Centers_Id",
                table: "Center_Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Center_Tags",
                table: "Center_Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Center_SpecialEvents",
                table: "Center_SpecialEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Center_Posts",
                table: "Center_Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Center_People",
                table: "Center_People");

            migrationBuilder.RenameTable(
                name: "Center_Tags",
                newName: "Centers_Tags");

            migrationBuilder.RenameTable(
                name: "Center_SpecialEvents",
                newName: "Centers_SpecialEvents");

            migrationBuilder.RenameTable(
                name: "Center_Posts",
                newName: "Centers_Posts");

            migrationBuilder.RenameTable(
                name: "Center_People",
                newName: "Centers_People");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Centers_Tags",
                table: "Centers_Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Centers_SpecialEvents",
                table: "Centers_SpecialEvents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Centers_Posts",
                table: "Centers_Posts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Centers_People",
                table: "Centers_People",
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
                name: "FK_Centers_People_Centers_Id",
                table: "Centers_People",
                column: "Id",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Centers_Posts_Centers_Id",
                table: "Centers_Posts",
                column: "Id",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Centers_SpecialEvents_Centers_Id",
                table: "Centers_SpecialEvents",
                column: "Id",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Centers_Tags_Centers_Id",
                table: "Centers_Tags",
                column: "Id",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Centers_People_Centers_Id",
                table: "Centers_People");

            migrationBuilder.DropForeignKey(
                name: "FK_Centers_Posts_Centers_Id",
                table: "Centers_Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Centers_SpecialEvents_Centers_Id",
                table: "Centers_SpecialEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_Centers_Tags_Centers_Id",
                table: "Centers_Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Centers_Tags",
                table: "Centers_Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Centers_SpecialEvents",
                table: "Centers_SpecialEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Centers_Posts",
                table: "Centers_Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Centers_People",
                table: "Centers_People");

            migrationBuilder.RenameTable(
                name: "Centers_Tags",
                newName: "Center_Tags");

            migrationBuilder.RenameTable(
                name: "Centers_SpecialEvents",
                newName: "Center_SpecialEvents");

            migrationBuilder.RenameTable(
                name: "Centers_Posts",
                newName: "Center_Posts");

            migrationBuilder.RenameTable(
                name: "Centers_People",
                newName: "Center_People");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Center_Tags",
                table: "Center_Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Center_SpecialEvents",
                table: "Center_SpecialEvents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Center_Posts",
                table: "Center_Posts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Center_People",
                table: "Center_People",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "03345db0-858d-41bb-ba77-7832e7b62781");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "9c464218-a0dc-4ebc-8199-ee77e201f8c3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "148dafcc-5e68-4f17-bf05-e866f0d0784b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60667e27-1d4a-4414-bc5a-f6be77ef4c84", "AQAAAAEAACcQAAAAEPlmWccRGAHyh9xOSs+5220/WNh0lYB+5sFIoWTIRZXYLqYor53/TkFqPNWMCKRQ2A==", "1ca04e2a-1086-49b9-aaa1-bc7eab7bd2c0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cfe552c3-56ed-4655-9a3e-818d40f77e88", "2fc58851-9a4e-4087-8d61-54fe8b3bd96b" });

            migrationBuilder.AddForeignKey(
                name: "FK_Center_People_Centers_Id",
                table: "Center_People",
                column: "Id",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Center_Posts_Centers_Id",
                table: "Center_Posts",
                column: "Id",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Center_SpecialEvents_Centers_Id",
                table: "Center_SpecialEvents",
                column: "Id",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Center_Tags_Centers_Id",
                table: "Center_Tags",
                column: "Id",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
