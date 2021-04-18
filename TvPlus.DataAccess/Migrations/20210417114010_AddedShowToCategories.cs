using Microsoft.EntityFrameworkCore.Migrations;

namespace TvPlus.DataAccess.Migrations
{
    public partial class AddedShowToCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Show",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Show",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "a5827808-c60d-457c-b5d7-9e33ab1986c6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "fff1afd4-cd2a-4721-a2ea-83af71297597");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "82cccc07-9989-4adf-8e00-b5ad94872f90");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c11481da-a196-48f1-8fc8-1106065d17c5", "AQAAAAEAACcQAAAAEGnLZIRgI8pJI75FYsgSnH6dvoc39wifVgyh5HBElCfEabohXE23St+Jk8WueoZWmA==", "ee6a5730-2718-4266-80b7-b96f08b336bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2b22ec8c-0019-49c8-821e-7d0663c836f2", "ea5f2a4d-efce-4dd7-be7c-01b15686a218" });
        }
    }
}
