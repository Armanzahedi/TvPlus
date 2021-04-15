using Microsoft.EntityFrameworkCore.Migrations;

namespace TvPlus.DataAccess.Migrations
{
    public partial class tablenames2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Centers_Id",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Centers_Id",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialEvents_Centers_Id",
                table: "SpecialEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Centers_Id",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpecialEvents",
                table: "SpecialEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Center_Tags");

            migrationBuilder.RenameTable(
                name: "SpecialEvents",
                newName: "Center_SpecialEvents");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Center_Posts");

            migrationBuilder.RenameTable(
                name: "People",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "Center_SpecialEvents",
                newName: "SpecialEvents");

            migrationBuilder.RenameTable(
                name: "Center_Posts",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "Center_People",
                newName: "People");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpecialEvents",
                table: "SpecialEvents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "f6e80302-3064-45e6-83f2-623d0273b713");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "91f11784-0701-451d-a599-1173a9de5ad6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "c5b3ae6f-dc7d-42b6-955a-b4731d800867");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef4d6e2b-917b-487d-9ee8-223a83c64b19", "AQAAAAEAACcQAAAAEI3F6Z31E6+nilAYGQzy2xTNhl6uFAeuR3WKviPmFqiRfRBh5Pjp5XFA1UOp5d5+kw==", "c0c32d29-8658-4086-8f21-189d29996d96" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d916f61c-a793-43ca-b4ce-fd03a6d788f2", "ad42543c-ff7e-42d9-8174-14159a2c0b22" });

            migrationBuilder.AddForeignKey(
                name: "FK_People_Centers_Id",
                table: "People",
                column: "Id",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Centers_Id",
                table: "Posts",
                column: "Id",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialEvents_Centers_Id",
                table: "SpecialEvents",
                column: "Id",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Centers_Id",
                table: "Tags",
                column: "Id",
                principalTable: "Centers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
