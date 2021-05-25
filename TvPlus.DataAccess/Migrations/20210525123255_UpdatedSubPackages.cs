using Microsoft.EntityFrameworkCore.Migrations;

namespace TvPlus.DataAccess.Migrations
{
    public partial class UpdatedSubPackages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29bd76db-5835-406d-ad1d-7a0901447c18", "708b68c6-a515-4c06-ac2f-54ab4b241867", "Admin", "ADMIN" },
                    { "d7be43da-622c-4cfe-98a9-5a5161120d24", "823696ea-c151-4515-99f2-0a0840c45572", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Information", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZuserId" },
                values: new object[,]
                {
                    { "75625814-138e-4831-a1ea-bf58e211adff", 0, "user-avatar.png", "2eb92b92-75ca-41ac-9467-3a7a2fdd55de", "Admin@Admin.com", false, "Admin", null, "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN", null, null, false, "6938bd17-0dc8-4cfd-9312-c8427e00a84e", false, "Admin", 0 },
                    { "75625814-138e-4831-a1ea-bf58e211acmf", 0, "user-avatar.png", "9b3e46e7-13dc-4ed4-a397-1bb31de7309c", "Superuser@Superuser.com", false, "Superuser", null, "Superuser", false, null, "SUPERUSER@SUPERUSER.COM", "SUPERUSER", "AQAAAAEAACcQAAAAEBUgUIiuM6EbDZZYiYIb0Dhq6Y4lRCc2GlKqipRi0WSJ85SvFRZ+G6Kxw0BMl7jPaQ==", null, false, "3bc12274-5a19-4fbb-a55e-683669658851", false, "Superuser", 0 }
                });
        }
    }
}
