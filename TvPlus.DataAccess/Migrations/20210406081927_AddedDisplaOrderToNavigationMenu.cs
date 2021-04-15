using Microsoft.EntityFrameworkCore.Migrations;

namespace TvPlus.DataAccess.Migrations
{
    public partial class AddedDisplaOrderToNavigationMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "AspNetNavigationMenu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "625ac5c6-619e-4a58-9510-e957df8f7b3d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "b85c4a89-9c41-4a7e-9f66-3429e77b59ba");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "97265219-660b-4976-bb48-77ed34ad09f1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cdec3c21-7709-4b0f-b1d4-7906e452df67", "AQAAAAEAACcQAAAAEIU8htZy1nCpcsE5/bhspXBVt6yAGHa/+wdZEqZ6dFsjVVUb/hjkPZEOqDlYx86oxA==", "e86a814d-87f8-4abf-9451-836410346ab6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "403a584f-d8f6-4fe5-8c90-93d8df5d6e3b", "e66dc653-0344-4abf-b53b-aa49e7e75e6d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "AspNetNavigationMenu");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "610acb1f-338e-453b-9f8b-dfd0fa126f3b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "cb84aa5a-ebb5-4d72-b0fc-105314384784");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "7d93b223-b30e-4923-b982-482feff65b12");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b209b89-fa7c-4f6d-a057-7ec4d863b0c1", "AQAAAAEAACcQAAAAED/Vc5g5ZpnVEIootkF/duNB2y4f+WJ6+AP96WYf9m2Fjs/415dT2vgzA7Bs0c/Q9g==", "87b0f870-69b9-4240-8107-9efadb9d10dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c08df66b-e2c5-4345-9562-e2ecc6d8e83b", "8a632add-f12c-467f-b932-9fcdc1b52318" });
        }
    }
}
