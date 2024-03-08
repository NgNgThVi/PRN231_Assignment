﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SE160956_KeyboardShop_Assignment.BussinessObject.DbContexts;

#nullable disable

namespace SE160956_KeyboardShop_Assignment.BussinessObject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240308070430_1")]
    partial class _1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Freight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("BookingStatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ShippedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerID");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess.BookingDetail", b =>
                {
                    b.Property<Guid>("BookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("UnitPrice")
                        .HasColumnType("int");

                    b.HasKey("BookingId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("BookingDetail");
                });

            modelBuilder.Entity("SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2c81c8f6-cae1-46a6-9bc4-71f29f6da74e"),
                            CategoryName = "Bàn phím cơ",
                            Created = new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1548),
                            Description = "Keyboard",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = new Guid("b7101212-c852-4be6-8eed-031b096b2dd4"),
                            CategoryName = "Switch",
                            Created = new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1576),
                            Description = "Switch",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = new Guid("cb85b07b-2fcc-497c-9007-8912a86c2f4f"),
                            CategoryName = "Keycap",
                            Created = new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1579),
                            Description = "Keycap",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = new Guid("d302148f-1677-4094-8fa7-1c6b54ff8b69"),
                            CategoryName = "Phụ kiện",
                            Created = new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1581),
                            Description = "Phụ kiện",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d38a7009-fa0c-4fd1-815f-49879dfcbfb7"),
                            AccountPassword = "@5",
                            Created = new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1810),
                            EmailAddress = "admin@gmail.com",
                            FullName = "Administrator",
                            IsDeleted = false,
                            Role = 1
                        },
                        new
                        {
                            Id = new Guid("c71f13e6-3a8f-4bfa-975e-c05dac1707eb"),
                            AccountPassword = "@5",
                            Created = new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1813),
                            EmailAddress = "staff@gmail.com",
                            FullName = "Staff",
                            IsDeleted = false,
                            Role = 2
                        },
                        new
                        {
                            Id = new Guid("4694a7a2-e609-4bfc-bd6f-6f082367181d"),
                            AccountPassword = "@5",
                            Created = new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1816),
                            EmailAddress = "manager@gmail.com",
                            FullName = "Manager",
                            IsDeleted = false,
                            Role = 3
                        },
                        new
                        {
                            Id = new Guid("2477cb57-b562-469d-8f78-0a96663cb5e2"),
                            AccountPassword = "@5",
                            Created = new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1821),
                            EmailAddress = "customer@gmail.com",
                            FullName = "Customer",
                            IsDeleted = false,
                            Role = 4
                        });
                });

            modelBuilder.Entity("SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("FlowerBouquetName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("SupplierID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UnitPrice")
                        .HasColumnType("int");

                    b.Property<int>("UnitsInStock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.HasIndex("SupplierID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6cb4dd24-4dec-4ec2-8dab-5d677f11cffb"),
                            CategoryID = new Guid("2c81c8f6-cae1-46a6-9bc4-71f29f6da74e"),
                            Created = new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1771),
                            Description = "Moongeek",
                            FlowerBouquetName = "Moongeek",
                            IsDeleted = false,
                            ProductStatus = 1,
                            SupplierID = new Guid("fc1d6720-4461-418c-8680-8ad859eda033"),
                            UnitPrice = 1750000,
                            UnitsInStock = 69
                        },
                        new
                        {
                            Id = new Guid("ccf6f1d5-beda-4832-8eae-1d82280693c0"),
                            CategoryID = new Guid("2c81c8f6-cae1-46a6-9bc4-71f29f6da74e"),
                            Created = new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1778),
                            Description = "BP",
                            FlowerBouquetName = "Anko Blackping",
                            IsDeleted = false,
                            ProductStatus = 1,
                            SupplierID = new Guid("fc1d6720-4461-418c-8680-8ad859eda033"),
                            UnitPrice = 2500000,
                            UnitsInStock = 96
                        },
                        new
                        {
                            Id = new Guid("4cee7a0f-17f9-4f49-aa3c-8dce72b8abe1"),
                            CategoryID = new Guid("2c81c8f6-cae1-46a6-9bc4-71f29f6da74e"),
                            Created = new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1792),
                            Description = "Tokyo",
                            FlowerBouquetName = "Tokyo world tour Anko",
                            IsDeleted = false,
                            ProductStatus = 1,
                            SupplierID = new Guid("fc1d6720-4461-418c-8680-8ad859eda033"),
                            UnitPrice = 2500000,
                            UnitsInStock = 100
                        });
                });

            modelBuilder.Entity("SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierAddress")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fc1d6720-4461-418c-8680-8ad859eda033"),
                            Created = new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1711),
                            IsDeleted = false,
                            SupplierAddress = "Ha Noi",
                            SupplierName = "Nguyễn Vĩ Shop",
                            Telephone = "0123456789"
                        },
                        new
                        {
                            Id = new Guid("f60db79f-1c7e-4b2b-a3f2-4551942ccdd6"),
                            Created = new DateTime(2024, 3, 8, 14, 4, 30, 716, DateTimeKind.Local).AddTicks(1715),
                            IsDeleted = false,
                            SupplierAddress = "Ho Chi Minh",
                            SupplierName = "Vĩ Nguyễn Shop",
                            Telephone = "0123456789"
                        });
                });

            modelBuilder.Entity("SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess.Booking", b =>
                {
                    b.HasOne("SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess.Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess.BookingDetail", b =>
                {
                    b.HasOne("SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess.Booking", "Booking")
                        .WithMany("BookingDetail")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess.Product", "Product")
                        .WithMany("BookingDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess.Product", b =>
                {
                    b.HasOne("SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess.Booking", b =>
                {
                    b.Navigation("BookingDetail");
                });

            modelBuilder.Entity("SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess.Customer", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess.Product", b =>
                {
                    b.Navigation("BookingDetails");
                });

            modelBuilder.Entity("SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess.Supplier", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
