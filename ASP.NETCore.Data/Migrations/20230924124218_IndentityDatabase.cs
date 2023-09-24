using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NETCore.Data.Migrations
{
    public partial class IndentityDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("719596ce-9596-438d-b4ef-1edbcfa103b1"), "d42a704f-a14f-42ee-92cd-9589fe264a47", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("719596ce-9596-438d-b4ef-1edbcfa103b1"), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 0, "3536d08d-0001-45ec-a5bf-0de826ff369c", new DateTime(1999, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyenvantanst.2210@gmail.com", true, "Tan", "Nguyen", false, null, "nguyenvantanst.2210@gmail.com", "admin", "AQAAAAEAACcQAAAAEEQ9vHGb7aSDjBvLrQV7rCNBmPKwVHVM7etkupTc7FnY4eGstPRYz4peTVUdryGR/Q==", null, false, "", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 9, 24, 19, 42, 17, 567, DateTimeKind.Local).AddTicks(2381));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("719596ce-9596-438d-b4ef-1edbcfa103b1"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("719596ce-9596-438d-b4ef-1edbcfa103b1"), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 9, 24, 19, 27, 31, 632, DateTimeKind.Local).AddTicks(8167));
        }
    }
}
