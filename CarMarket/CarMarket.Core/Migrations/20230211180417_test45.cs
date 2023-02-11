using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarMarket.Core.Migrations
{
    public partial class test45 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Brands_BrandId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Models_ModelId",
                table: "Cars");

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

            migrationBuilder.AlterColumn<int>(
                name: "ModelId",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Engine",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "055da7b9-d9e5-4083-a823-02c0bc4fc7bc", "03193019-62a9-426b-879b-d4043ad6135b", "Admin", "ADMIN" },
                    { "97a99d0f-7032-488e-a945-82d99d802a27", "bbc6824e-b11d-4f30-9cdb-a5e2e85abdd1", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "94e0158f-b5e2-4a7c-9c19-cbf1d60220bf", 0, "f4da04ff-6a93-4fdf-a771-e29b03f15ad5", "user@carmarket.com", true, null, null, false, null, "USER@CARMARKET.COM", "USER@CARMARKET.COM", "AQAAAAEAACcQAAAAEF56prvKoI6mY36R8GkABSd3ZDE/RJi+nTrDSxUvP7UYMapbUHDFEiXFe6Qj/mRoEA==", null, false, "e6d284d0-ae32-4c22-ae4a-74a90254c919", false, "user@carmarket.com" },
                    { "fe4f5679-030f-48a1-8e92-63e65756af40", 0, "9459d5da-2ed5-41ff-b0b2-59008dbd1bcf", "admin@carmarket.com", true, null, null, false, null, "ADMIN@CARMARKET.COM", "ADMIN@CARMARKET.COM", "AQAAAAEAACcQAAAAEOZjlOV8soosSHNJ4fn1+cpJZtZyGNVMLogeo9nAk5MU0ZgCouo5qFcE9VDkFrIRIg==", null, false, "ca137813-9113-483a-8e10-d0018c574115", false, "admin@carmarket.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "055da7b9-d9e5-4083-a823-02c0bc4fc7bc", "94e0158f-b5e2-4a7c-9c19-cbf1d60220bf" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "97a99d0f-7032-488e-a945-82d99d802a27", "94e0158f-b5e2-4a7c-9c19-cbf1d60220bf" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "055da7b9-d9e5-4083-a823-02c0bc4fc7bc", "fe4f5679-030f-48a1-8e92-63e65756af40" });

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Brands_BrandId",
                table: "Cars",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Models_ModelId",
                table: "Cars",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Brands_BrandId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Models_ModelId",
                table: "Cars");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "055da7b9-d9e5-4083-a823-02c0bc4fc7bc", "94e0158f-b5e2-4a7c-9c19-cbf1d60220bf" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "97a99d0f-7032-488e-a945-82d99d802a27", "94e0158f-b5e2-4a7c-9c19-cbf1d60220bf" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "055da7b9-d9e5-4083-a823-02c0bc4fc7bc", "fe4f5679-030f-48a1-8e92-63e65756af40" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "055da7b9-d9e5-4083-a823-02c0bc4fc7bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97a99d0f-7032-488e-a945-82d99d802a27");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "94e0158f-b5e2-4a7c-9c19-cbf1d60220bf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe4f5679-030f-48a1-8e92-63e65756af40");

            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "ModelId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Engine",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Brands_BrandId",
                table: "Cars",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Models_ModelId",
                table: "Cars",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
