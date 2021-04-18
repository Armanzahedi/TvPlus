using Microsoft.EntityFrameworkCore.Migrations;

namespace TvPlus.DataAccess.Migrations
{
    public partial class AddedParentIdToCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "b32b87db-02c8-4141-af0c-a368a81b91c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "2ebcde90-d62f-4f2a-bd73-22c4828e5da9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "46da7333-521f-4df8-be04-f1d4f79e5ee8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "33f9b423-b750-44c6-80f6-adc2c9264e56", "AQAAAAEAACcQAAAAEJ1iEKXzhfOu3fshPQJSbgv38rxUQ4UlDHb+tbf9/ECOEpOEnjM4b57L3Duv6VHKMw==", "e60603a5-15ae-4eb3-a183-6553d5eb70aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "65499213-f512-4ce7-8d2b-6b921c7c2096", "aef3814c-6603-40d4-8743-7391c8675924" });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories",
                column: "ParentId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ParentId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "3a8775b8-2998-4416-adf3-6b0c12abc2bf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "58da2bb5-6df9-49c6-ad20-30616661795e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "097eb437-1144-4bca-9a1a-fc947b1dc998");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eea77697-65b4-44cf-bde7-d2a7fac5342b", "AQAAAAEAACcQAAAAEHxSjwUYihbI+EMmzNJhMLo0WgbEbGrmhEfsJvyxxuq0QHfq0XzYOZ+FAbFMw09MWQ==", "465e3b26-7080-484e-9043-2126f3b941b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6f8739d8-20fe-4fbb-a10b-dff19fde52bd", "3e9bb49c-7de4-4370-b48e-f8f75ebd76e7" });
        }
    }
}
