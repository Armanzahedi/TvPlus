using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TvPlus.DataAccess.Migrations
{
    public partial class IntegratedPrevDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "VideoConverts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "VideoConverts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ZErrors",
                table: "VideoConverts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZStatus",
                table: "VideoConverts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DislikeCount",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LikeCount",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ZAgent",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZIP",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Centers_Tags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LikeCount",
                table: "Centers_Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ZCategorySlug",
                table: "Centers_Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZCommentLimit",
                table: "Centers_Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ZCommentRead",
                table: "Centers_Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ZCommentUnRead",
                table: "Centers_Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ZLength",
                table: "Centers_Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ZSeoTitle",
                table: "Centers_Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZShowInVarzesh3",
                table: "Centers_Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ZSocialShowInMain",
                table: "Centers_Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ZStatus",
                table: "Centers_Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZuserId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ZComments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Parent = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Agent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LikeNum = table.Column<int>(type: "int", nullable: false),
                    DislikeNum = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAdminId = table.Column<byte>(type: "tinyint", nullable: false),
                    UpdatedAdminId = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZComments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZVideo_Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZVideo_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZVideo_Convert",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoId = table.Column<int>(type: "int", nullable: false),
                    BitRate = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Errors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ErrorStep = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZVideo_Convert", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZVideo_Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZVideo_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZVideos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Converted = table.Column<int>(type: "int", nullable: true),
                    Videolink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Videolinkconverted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Length = table.Column<int>(type: "int", nullable: true),
                    AdminId = table.Column<int>(type: "int", nullable: true),
                    PollId = table.Column<int>(type: "int", nullable: true),
                    UserSenderId = table.Column<long>(type: "bigint", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeoTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentLimit = table.Column<int>(type: "int", nullable: true),
                    ShowInVarzesh3 = table.Column<int>(type: "int", nullable: true),
                    CategorySlug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlagNum = table.Column<int>(type: "int", nullable: true),
                    LikeNum = table.Column<int>(type: "int", nullable: true),
                    ViewNum = table.Column<int>(type: "int", nullable: true),
                    CommentRead = table.Column<int>(type: "int", nullable: true),
                    CommentUnRead = table.Column<int>(type: "int", nullable: true),
                    SocialUserId = table.Column<int>(type: "int", nullable: true),
                    SocialSelected = table.Column<int>(type: "int", nullable: true),
                    SocialShowInMain = table.Column<int>(type: "int", nullable: true),
                    Published = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAdminId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAdminId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZVideos", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "537f9efa-3a1a-4463-96e3-f456dbc8f9d2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "15e6d60f-cd57-4e96-9e2a-938f6b1ad463");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "SADADSAD", "52aac6a6-0956-433a-ab55-d6ccad6d30b8", "Superuser", "SUPERUSER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a75b35f9-13e8-43c7-8e5b-f1d30df2e707", "AQAAAAEAACcQAAAAEBp+ueeWsfmlAnf94kIzvphEFvQYPdpVZrp3/otV0WecS/wFeu8r59Psu9L8ZQr76Q==", "eff332bc-7872-4279-8f8c-085d42c91c7f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2a9a8093-a6d8-4906-bba5-bfdaf3091cc6", "f870a5ab-6220-4b11-bdb6-b89b28cfd6c0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZComments");

            migrationBuilder.DropTable(
                name: "ZTags");

            migrationBuilder.DropTable(
                name: "ZVideo_Category");

            migrationBuilder.DropTable(
                name: "ZVideo_Convert");

            migrationBuilder.DropTable(
                name: "ZVideo_Tag");

            migrationBuilder.DropTable(
                name: "ZVideos");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "SADADSAD");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "VideoConverts");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "VideoConverts");

            migrationBuilder.DropColumn(
                name: "ZErrors",
                table: "VideoConverts");

            migrationBuilder.DropColumn(
                name: "ZStatus",
                table: "VideoConverts");

            migrationBuilder.DropColumn(
                name: "DislikeCount",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "LikeCount",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ZAgent",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ZIP",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Centers_Tags");

            migrationBuilder.DropColumn(
                name: "LikeCount",
                table: "Centers_Posts");

            migrationBuilder.DropColumn(
                name: "ZCategorySlug",
                table: "Centers_Posts");

            migrationBuilder.DropColumn(
                name: "ZCommentLimit",
                table: "Centers_Posts");

            migrationBuilder.DropColumn(
                name: "ZCommentRead",
                table: "Centers_Posts");

            migrationBuilder.DropColumn(
                name: "ZCommentUnRead",
                table: "Centers_Posts");

            migrationBuilder.DropColumn(
                name: "ZLength",
                table: "Centers_Posts");

            migrationBuilder.DropColumn(
                name: "ZSeoTitle",
                table: "Centers_Posts");

            migrationBuilder.DropColumn(
                name: "ZShowInVarzesh3",
                table: "Centers_Posts");

            migrationBuilder.DropColumn(
                name: "ZSocialShowInMain",
                table: "Centers_Posts");

            migrationBuilder.DropColumn(
                name: "ZStatus",
                table: "Centers_Posts");

            migrationBuilder.DropColumn(
                name: "ZuserId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "21b660c6-8a46-4c9b-bc92-7226ac9cae88");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "ade885d6-2cd8-49b8-ab4d-76e087378a2f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "29bd76db-5835-406d-ad1d-7a0901448abd", "fcb9000d-b7c0-4100-aee1-1699923a3269", "Superuser", "SUPERUSER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c459ea4-64e6-4fa8-a9a4-335918314ae4", "AQAAAAEAACcQAAAAEIUu3e+XCShn9MBJlAVgPvORRrFlnAREaLRGUO7AYkEJL7NUXAuCDky2mzt8hpvYag==", "7571a1d2-accb-4102-946c-e5ed6c204bad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "14151106-fd8a-410d-913c-ff10acf6b118", "c3f352b8-cb74-403f-a897-e2e3d578a37a" });
        }
    }
}
