using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SE160956_KeyboardShop_Assignment.BussinessObject.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FlowerBouquetName",
                table: "Products",
                newName: "ProductName");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2c81c8f6-cae1-46a6-9bc4-71f29f6da74e"),
                column: "Created",
                value: new DateTime(2024, 3, 8, 21, 7, 59, 375, DateTimeKind.Local).AddTicks(6352));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b7101212-c852-4be6-8eed-031b096b2dd4"),
                column: "Created",
                value: new DateTime(2024, 3, 8, 21, 7, 59, 375, DateTimeKind.Local).AddTicks(6380));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cb85b07b-2fcc-497c-9007-8912a86c2f4f"),
                column: "Created",
                value: new DateTime(2024, 3, 8, 21, 7, 59, 375, DateTimeKind.Local).AddTicks(6382));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d302148f-1677-4094-8fa7-1c6b54ff8b69"),
                column: "Created",
                value: new DateTime(2024, 3, 8, 21, 7, 59, 375, DateTimeKind.Local).AddTicks(6384));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("2477cb57-b562-469d-8f78-0a96663cb5e2"),
                column: "Created",
                value: new DateTime(2024, 3, 8, 21, 7, 59, 375, DateTimeKind.Local).AddTicks(6619));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("4694a7a2-e609-4bfc-bd6f-6f082367181d"),
                column: "Created",
                value: new DateTime(2024, 3, 8, 21, 7, 59, 375, DateTimeKind.Local).AddTicks(6617));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("c71f13e6-3a8f-4bfa-975e-c05dac1707eb"),
                column: "Created",
                value: new DateTime(2024, 3, 8, 21, 7, 59, 375, DateTimeKind.Local).AddTicks(6615));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("d38a7009-fa0c-4fd1-815f-49879dfcbfb7"),
                column: "Created",
                value: new DateTime(2024, 3, 8, 21, 7, 59, 375, DateTimeKind.Local).AddTicks(6611));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4cee7a0f-17f9-4f49-aa3c-8dce72b8abe1"),
                column: "Created",
                value: new DateTime(2024, 3, 8, 21, 7, 59, 375, DateTimeKind.Local).AddTicks(6594));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6cb4dd24-4dec-4ec2-8dab-5d677f11cffb"),
                column: "Created",
                value: new DateTime(2024, 3, 8, 21, 7, 59, 375, DateTimeKind.Local).AddTicks(6567));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ccf6f1d5-beda-4832-8eae-1d82280693c0"),
                column: "Created",
                value: new DateTime(2024, 3, 8, 21, 7, 59, 375, DateTimeKind.Local).AddTicks(6590));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("f60db79f-1c7e-4b2b-a3f2-4551942ccdd6"),
                column: "Created",
                value: new DateTime(2024, 3, 8, 21, 7, 59, 375, DateTimeKind.Local).AddTicks(6511));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("fc1d6720-4461-418c-8680-8ad859eda033"),
                column: "Created",
                value: new DateTime(2024, 3, 8, 21, 7, 59, 375, DateTimeKind.Local).AddTicks(6508));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Products",
                newName: "FlowerBouquetName");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2c81c8f6-cae1-46a6-9bc4-71f29f6da74e"),
                column: "Created",
                value: new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1548));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b7101212-c852-4be6-8eed-031b096b2dd4"),
                column: "Created",
                value: new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1576));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cb85b07b-2fcc-497c-9007-8912a86c2f4f"),
                column: "Created",
                value: new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1579));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d302148f-1677-4094-8fa7-1c6b54ff8b69"),
                column: "Created",
                value: new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1581));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("2477cb57-b562-469d-8f78-0a96663cb5e2"),
                column: "Created",
                value: new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1821));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("4694a7a2-e609-4bfc-bd6f-6f082367181d"),
                column: "Created",
                value: new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1816));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("c71f13e6-3a8f-4bfa-975e-c05dac1707eb"),
                column: "Created",
                value: new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1813));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("d38a7009-fa0c-4fd1-815f-49879dfcbfb7"),
                column: "Created",
                value: new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1810));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4cee7a0f-17f9-4f49-aa3c-8dce72b8abe1"),
                column: "Created",
                value: new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1792));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6cb4dd24-4dec-4ec2-8dab-5d677f11cffb"),
                column: "Created",
                value: new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1771));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ccf6f1d5-beda-4832-8eae-1d82280693c0"),
                column: "Created",
                value: new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1778));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("f60db79f-1c7e-4b2b-a3f2-4551942ccdd6"),
                column: "Created",
                value: new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1715));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("fc1d6720-4461-418c-8680-8ad859eda033"),
                column: "Created",
                value: new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1711));
        }
    }
}
