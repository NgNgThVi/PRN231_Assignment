using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SE160956_KeyboardShop_Assignment.BussinessObject.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    SupplierAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Total = table.Column<int>(type: "int", nullable: false),
                    BookingStatus = table.Column<int>(type: "int", nullable: false),
                    Freight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlowerBouquetName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UnitPrice = table.Column<int>(type: "int", nullable: false),
                    UnitsInStock = table.Column<int>(type: "int", nullable: false),
                    ProductStatus = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingDetail",
                columns: table => new
                {
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitPrice = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetail", x => new { x.BookingId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_BookingDetail_Booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingDetail_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CreateBy", "Created", "Description", "IsDeleted", "LastModified", "LastModifiedBy" },
                values: new object[,]
                {
                    { new Guid("2c81c8f6-cae1-46a6-9bc4-71f29f6da74e"), "Bàn phím cơ", null, new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1548), "Keyboard", false, null, null },
                    { new Guid("b7101212-c852-4be6-8eed-031b096b2dd4"), "Switch", null, new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1576), "Switch", false, null, null },
                    { new Guid("cb85b07b-2fcc-497c-9007-8912a86c2f4f"), "Keycap", null, new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1579), "Keycap", false, null, null },
                    { new Guid("d302148f-1677-4094-8fa7-1c6b54ff8b69"), "Phụ kiện", null, new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1581), "Phụ kiện", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AccountPassword", "CreateBy", "Created", "EmailAddress", "FullName", "IsDeleted", "LastModified", "LastModifiedBy", "Role" },
                values: new object[,]
                {
                    { new Guid("2477cb57-b562-469d-8f78-0a96663cb5e2"), "@5", null, new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1821), "customer@gmail.com", "Customer", false, null, null, 4 },
                    { new Guid("4694a7a2-e609-4bfc-bd6f-6f082367181d"), "@5", null, new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1816), "manager@gmail.com", "Manager", false, null, null, 3 },
                    { new Guid("c71f13e6-3a8f-4bfa-975e-c05dac1707eb"), "@5", null, new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1813), "staff@gmail.com", "Staff", false, null, null, 2 },
                    { new Guid("d38a7009-fa0c-4fd1-815f-49879dfcbfb7"), "@5", null, new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1810), "admin@gmail.com", "Administrator", false, null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "CreateBy", "Created", "IsDeleted", "LastModified", "LastModifiedBy", "SupplierAddress", "SupplierName", "Telephone" },
                values: new object[,]
                {
                    { new Guid("f60db79f-1c7e-4b2b-a3f2-4551942ccdd6"), null, new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1715), false, null, null, "Ho Chi Minh", "Vĩ Nguyễn Shop", "0123456789" },
                    { new Guid("fc1d6720-4461-418c-8680-8ad859eda033"), null, new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1711), false, null, null, "Ha Noi", "Nguyễn Vĩ Shop", "0123456789" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryID", "CreateBy", "Created", "Description", "FlowerBouquetName", "IsDeleted", "LastModified", "LastModifiedBy", "ProductStatus", "SupplierID", "UnitPrice", "UnitsInStock" },
                values: new object[,]
                {
                    { new Guid("4cee7a0f-17f9-4f49-aa3c-8dce72b8abe1"), new Guid("2c81c8f6-cae1-46a6-9bc4-71f29f6da74e"), null, new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1792), "Tokyo", "Tokyo world tour Anko", false, null, null, 1, new Guid("fc1d6720-4461-418c-8680-8ad859eda033"), 2500000, 100 },
                    { new Guid("6cb4dd24-4dec-4ec2-8dab-5d677f11cffb"), new Guid("2c81c8f6-cae1-46a6-9bc4-71f29f6da74e"), null, new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1771), "Moongeek", "Moongeek", false, null, null, 1, new Guid("fc1d6720-4461-418c-8680-8ad859eda033"), 1750000, 69 },
                    { new Guid("ccf6f1d5-beda-4832-8eae-1d82280693c0"), new Guid("2c81c8f6-cae1-46a6-9bc4-71f29f6da74e"), null, new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1778), "BP", "Anko Blackping", false, null, null, 1, new Guid("fc1d6720-4461-418c-8680-8ad859eda033"), 2500000, 96 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_CustomerID",
                table: "Booking",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetail_ProductId",
                table: "BookingDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierID",
                table: "Products",
                column: "SupplierID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDetail");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
