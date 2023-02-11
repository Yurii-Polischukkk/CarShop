using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMarket.Core.Migrations
{
    public partial class testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4b8b408e-cfa4-4f27-845e-cb8ce095f2a0", "58a4c033-4831-4d5f-906f-a30e411530fd", "Admin", "ADMIN" },
                    { "9dcd1722-78e9-4748-8b98-b1d5c8402f28", "f634ae6b-f875-460e-9cf0-742d967f80b5", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0f355c90-879f-47ef-ac62-d3d924e07fe9", 0, "27d7159f-c2bc-4cd4-8f92-abfc3bee4f5e", "user@carmarket.com", true, null, null, false, null, "USER@CARMARKET.COM", "USER@CARMARKET.COM", "AQAAAAEAACcQAAAAEDomITbqiSzuFDmskZbYDGK1Vgo3TYrNWIg6tfkNDvBPGBiul5ZhKA1mJe3vDYSnEQ==", null, false, "7bc99a3c-2306-483e-a6c8-b30e3d8b09b8", false, "user@carmarket.com" },
                    { "a31c6a68-e68b-4114-a326-00574da1043d", 0, "08035f64-365f-451f-b96d-8bf198e6fadf", "admin@carmarket.com", true, null, null, false, null, "ADMIN@CARMARKET.COM", "ADMIN@CARMARKET.COM", "AQAAAAEAACcQAAAAENuiBilV3iWsYlznqvnj2dYOktpotdezHE6FTg7rKS2UiwPqHHNIaVv/NPuNd4mvIQ==", null, false, "67bbffd1-7883-4830-a131-aca4c7c4537f", false, "admin@carmarket.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4b8b408e-cfa4-4f27-845e-cb8ce095f2a0", "0f355c90-879f-47ef-ac62-d3d924e07fe9" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9dcd1722-78e9-4748-8b98-b1d5c8402f28", "0f355c90-879f-47ef-ac62-d3d924e07fe9" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4b8b408e-cfa4-4f27-845e-cb8ce095f2a0", "a31c6a68-e68b-4114-a326-00574da1043d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4b8b408e-cfa4-4f27-845e-cb8ce095f2a0", "0f355c90-879f-47ef-ac62-d3d924e07fe9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9dcd1722-78e9-4748-8b98-b1d5c8402f28", "0f355c90-879f-47ef-ac62-d3d924e07fe9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4b8b408e-cfa4-4f27-845e-cb8ce095f2a0", "a31c6a68-e68b-4114-a326-00574da1043d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b8b408e-cfa4-4f27-845e-cb8ce095f2a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9dcd1722-78e9-4748-8b98-b1d5c8402f28");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f355c90-879f-47ef-ac62-d3d924e07fe9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a31c6a68-e68b-4114-a326-00574da1043d");
        }
    }
}
