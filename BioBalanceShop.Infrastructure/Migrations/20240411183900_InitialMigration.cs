using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BioBalanceShop.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Indicator if user exists"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true, comment: "User first name"),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true, comment: "User last name"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date when user was created"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Product category identificator")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Indicator if category exists"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Product category name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Country identificator")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Indicator if country exists"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Country name"),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false, comment: "Country code")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Currency identificator")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Indicator if currency exists"),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false, comment: "Currency code"),
                    Symbol = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false, comment: "Currency symbol"),
                    IsSymbolPrefix = table.Column<bool>(type: "bit", nullable: false, comment: "Indicator if the currency symbol is displayed before or after price")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderRecipients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Order recipient identificator")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Indicator if order recipient exists"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true, comment: "Order recipient first name"),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true, comment: "Order recipient last name"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true, comment: "Order recipient phone number"),
                    EmailAddress = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "Order recipient phone number")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRecipients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Payment identificator")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Payment date"),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Payment amount"),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false, comment: "Payment status")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Customer address identificator")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Indicator if customer address exists"),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Customer address street name"),
                    PostCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "Customer address post code"),
                    City = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Customer address city"),
                    CountryId = table.Column<int>(type: "int", nullable: true, comment: "Customer address country identificator")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Order address identificator")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Indicator if order address exists"),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Order address street name"),
                    PostCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Order address post code"),
                    City = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Order address city"),
                    CountryId = table.Column<int>(type: "int", nullable: false, comment: "Order address country identificator")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderAddresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Shop identificator")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Indicator if shop exists"),
                    CurrencyId = table.Column<int>(type: "int", nullable: false, comment: "Shop currency identificator"),
                    ShippingFeeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true, comment: "Shipping fee rate applied to order amount")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shops_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Customer identificator")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Indicator if customer exists"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identificator"),
                    AddressId = table.Column<int>(type: "int", nullable: true, comment: "Customer address identificator")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_CustomerAddresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "CustomerAddresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Product identificator")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Indicator if product exists"),
                    ProductCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Product code"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "Product name"),
                    Subtitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Product subtitle"),
                    Description = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false, comment: "Product description"),
                    Ingredients = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false, comment: "Product ingredients"),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Product image URL"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Product quantity"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Product price"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Product category identificator"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date product was created"),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Product creator identificator"),
                    ShopId = table.Column<int>(type: "int", nullable: false, comment: "Shop identificator")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Order identificator")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Indicator if order exists"),
                    OrderNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Order number"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Order date"),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "Order status"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Order amount excluding shipping fee"),
                    ShippingFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Order shipping fee"),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Order total amount including shipping fee"),
                    CurrencyId = table.Column<int>(type: "int", nullable: false, comment: "Order currency identificator"),
                    CustomerId = table.Column<int>(type: "int", nullable: true, comment: "Customer identificator"),
                    OrderAddressId = table.Column<int>(type: "int", nullable: false, comment: "Order address identificator"),
                    PaymentId = table.Column<int>(type: "int", nullable: false, comment: "Payment identificator"),
                    OrderRecipientId = table.Column<int>(type: "int", nullable: false, comment: "Order recipient identificator")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_OrderAddresses_OrderAddressId",
                        column: x => x.OrderAddressId,
                        principalTable: "OrderAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_OrderRecipients_OrderRecipientId",
                        column: x => x.OrderRecipientId,
                        principalTable: "OrderRecipients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Order item identificator")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Indicator if order item exists"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "Order item name"),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Order item image URL"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Order item quantity"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Order item price"),
                    CurrencyId = table.Column<int>(type: "int", nullable: false, comment: "Order item currency identificator"),
                    OrderId = table.Column<int>(type: "int", nullable: false, comment: "Order item order identificator")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "02c32793-47c7-4f3b-9487-d91c2a0e4345", 0, "05d8e453-cd16-421b-9808-3878601c4fef", new DateTime(2024, 4, 11, 20, 38, 59, 566, DateTimeKind.Local).AddTicks(8586), "admin@mail.com", true, "Admin", true, "User", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEM35VlVavnrxhFb669c/WQWQpOlN0UEVeSfENsrgEibRsYBdG685P5SgfFC1a9cVoQ==", null, false, "4c3b676e-7cf2-43d8-9fba-b1a095653028", false, "admin@mail.com" },
                    { "c4f1530f-2727-4bc8-9de3-075fc7420586", 0, "e09b0b53-d6ca-400a-8eab-5f5ab525d7da", new DateTime(2024, 4, 11, 20, 38, 59, 574, DateTimeKind.Local).AddTicks(7595), "customer@mail.com", true, "Ivan", true, "Ivanov", false, null, "CUSTOMER@MAIL.COM", "CUSTOMER@MAIL.COM", "AQAAAAEAACcQAAAAEMNLbGy2zwkbsLBS28ecOJFar7al0Dc9YJsPgTAhRZZCce7n70b/DNUBBY7cFOX2bw==", null, false, "baa2216b-2c2f-41e6-b0ff-497dcd223db6", false, "customer@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "Organic products" },
                    { 2, true, "Super foods" },
                    { 3, true, "MuscleMass" },
                    { 4, true, "Immunity Support" },
                    { 5, true, "DietFoods" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "BG", true, "Bulgaria" },
                    { 2, "GB", true, "United Kingdom" },
                    { 3, "US", true, "United States" },
                    { 4, "DE", true, "Germany" },
                    { 5, "ES", true, "Spain" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Code", "IsActive", "IsSymbolPrefix", "Symbol" },
                values: new object[,]
                {
                    { 1, "BGN", true, false, "лв." },
                    { 2, "EUR", true, false, "€" },
                    { 3, "USD", true, true, "$" },
                    { 4, "GBP", true, true, "£" }
                });

            migrationBuilder.InsertData(
                table: "OrderRecipients",
                columns: new[] { "Id", "EmailAddress", "FirstName", "IsActive", "LastName", "PhoneNumber" },
                values: new object[] { 1, "customer@mail.com", "Ivan", true, "Ivanov", "+359883123456" });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "PaymentAmount", "PaymentDate", "PaymentStatus" },
                values: new object[] { 1, 18.00m, new DateTime(2024, 4, 11, 20, 38, 59, 517, DateTimeKind.Local).AddTicks(7236), 1 });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "user:fullname", "Admin User", "02c32793-47c7-4f3b-9487-d91c2a0e4345" },
                    { 2, "user:fullname", "Ivan Ivanov", "c4f1530f-2727-4bc8-9de3-075fc7420586" }
                });

            migrationBuilder.InsertData(
                table: "CustomerAddresses",
                columns: new[] { "Id", "City", "CountryId", "IsActive", "PostCode", "Street" },
                values: new object[] { 1, "Sofia", 1, true, "1000", "Tsarigradsko shose 45" });

            migrationBuilder.InsertData(
                table: "OrderAddresses",
                columns: new[] { "Id", "City", "CountryId", "IsActive", "PostCode", "Street" },
                values: new object[] { 1, "Sofia", 1, true, "1000", "Tsarigradsko shose 45" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "CurrencyId", "IsActive", "ShippingFeeRate" },
                values: new object[] { 1, 2, true, null });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressId", "IsActive", "UserId" },
                values: new object[] { 1, 1, true, "c4f1530f-2727-4bc8-9de3-075fc7420586" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedById", "CreatedDate", "Description", "ImageUrl", "Ingredients", "IsActive", "Price", "ProductCode", "Quantity", "ShopId", "Subtitle", "Title" },
                values: new object[,]
                {
                    { 1, 1, "02c32793-47c7-4f3b-9487-d91c2a0e4345", new DateTime(2024, 4, 11, 20, 38, 59, 534, DateTimeKind.Local).AddTicks(5730), "This high-fibre organic foods blend contains over 35 food ingredients (including green foods, vegetables, fruits, berries, herbs, mushrooms and seeds) PLUS bio-active enzymes in a single serving (see below). Organic vegan nutrition made easy, with naturally high food form vitamin C content (for immune system support), as well as plant protein.\r\n\r\nAll of the organic foods in this blend are Soil Association certified and the ingredients come in concentrated powder form. A great all-round supplement to support immunity, digestion (bulk) and optimal nutrition.\r\n\r\nAs well as providing phyto-nutrients (such as chlorophyll), per 100g it provides 9.1g of plant protein, 59g of carbohydrate (with just 12.5g sugars) and 17.1g of fibre (making it a high-fibre food).\r\n\r\nSuitable for vegetarians and vegans.", "https://www.dropshipwebhosting.co.uk/image/data/product/main/SN105_front.png", "Product ingredients (dried, powdered): Pre-Sprouted Activated BARLEY, Lucuma Fruit, Linseed (Flaxseed), WHEAT GRASS, Quinoa, BARLEY Grass, Apple, Acai Berry, Baobab Fruit Pulp, Seagreens® Kelp (Ascophyllum Nodosum), Spirulina, Turmeric, Alfalfa, Carrot, Bilberry Fruit, Spinach Leaf, BARLEY Grass Juice, WHEAT GRASS Juice, Beet, Acerola Cherry Extract, Chlorella (Broken Cell Wall), Nettle, Tomato, Bilberry Extract, Blueberry, Cranberry, Green Cabbage, Kale, Parsley, Kale Sprout, Broccoli Sprout, Reishi Mushroom, Cordyceps Mushroom, Shiitake Mushroom, Cauliflower Sprout, Maitake Mushroom, Enzyme Blend* (protease*, amylase*, bromelain*, cellulase*, lactase*, papain*, lipase*). * = Non organic ingredient", true, 12.00m, "SN105", 100, 1, "Certified organic GreeNourish Complete is no ordinary green shake.", "Green Nourish Complete" },
                    { 2, 1, "02c32793-47c7-4f3b-9487-d91c2a0e4345", new DateTime(2024, 4, 11, 20, 38, 59, 534, DateTimeKind.Local).AddTicks(5738), "MaxNourish is a 100% organic (Soil Association and EU organic certified) food supplement, with over 35 nutritious fruits, vegetables, sprouts, seeds and herbals PLUS bio-active enzymes (see below).\r\n\r\nWith some of the most nutrient-dense foods that Nature has to offer, it is an all-round multi-nutrient blend in easy-to-take capsules - no poorly-absorbed synthetic vitamins and minerals.\r\n\r\nQuickly and easily access organic and vegan nutrition on a daily basis with just this one product.", "https://www.dropshipwebhosting.co.uk/image/data/product/main/MSFO_front.png", "Product ingredients (dried, powdered): Capsule Shell: Hydroxypropyl Methylcellulose (HPMC)*, Pre-Sprouted Activated BARLEY Powder (Hordeum vulgare), Lucuma Fruit Powder (Pouteria lucuma), Linseed (Flaxseed) Powder (Linum usitatissimum), WHEAT GRASS Powder (Triticum aestivum), Quinoa Powder (Chenopodium quinoa), BARLEY Grass Powder (Hordeum vulgare), Acai Berry Powder (Euterpe oleracea), Baobab Pulp Powder (Adansonia digitata), Seagreens® Kelp Powder (Ascophyllum Nodosum), Spirulina Powder (Arthrospira platensis), Turmeric Powder (Curcuma longa), Apple Powder (Malus Sylvestris), Alfalfa Powder (Medicago sativa), Carrot Powder (Daucus carota), Bilberry Fruit Powder (Vaccinium myrtillus), Spinach Leaf Powder (Spinacia oleracea), BARLEY Grass Juice Powder (Hordeum vulgare), WHEAT GRASS Juice Powder (Triticum aestivum), Beetroot Powder (Beta vulgaris), Acerola Cherry Extract (Malphigia glabra), Chlorella vulgaris (Broken Cell Wall) Powder, Nettle Leaf Powder (Urtica dioica), Tomato Powder (Lycopersicum esculentum), Bilberry Extract (Vaccinium myrtillus), Blueberry Powder (Vaccinium sp.), Cranberry Powder (Vaccinium macrocarpon), Green Cabbage Powder (Brassica oleracea), Kale Powder (Brassica oleracea acephala), Parsley Powder (Carum petroselinum), Kale Sprout Powder (Brassica oleracea acephala), Broccoli Sprout Powder (Brassica oleracea italica), Reishi Mushroom Powder (Ganoderma Lucidum), Cordyceps Mushroom Powder (Cordyceps militaris), Shiitake Mushroom Powder (Lentinula edodes), Cauliflower Sprout Powder (Brassica oleracea botrytis), Maitake Mushroom Powder (Grifola frondosa), Enzyme Blend* (protease*, amylase*, bromelain*, cellulase*, lactase*, papain*, lipase*) * = Non organic ingredient.", true, 18.00m, "MSFO", 150, 1, "Organic fruit, vegetable and herbal blend (in capsules)", "MaxNourish" },
                    { 3, 2, "02c32793-47c7-4f3b-9487-d91c2a0e4345", new DateTime(2024, 4, 11, 20, 38, 59, 534, DateTimeKind.Local).AddTicks(5741), "Acai Immuno Defence is a high-potency formulation, which combines Brazilian acai berry with a range of other beneficial ingredients, including vitamins, minerals and herbs (such as zinc, vitamin B6, biotin, organic Moringa oleifera, beetroot, resveratrol and more - see below). \r\n\r\nThis superfood combination provides support for immunity, energy, bones, hair, skin, nails and more. It also contains polyphenolic anthocyanin compounds, as well as vitamins, minerals and ellagic acid.\r\n\r\nPopular with slimmers, athletes, diabetics and those looking to support their immunity, general health and well-being.", "https://www.dropshipwebhosting.co.uk/image/data/product/main/SN099B_front.png", "Product ingredients: Stoneground Brown Rice Flour (Oryza Sativa), Organic Moringa Oleifera Powder, Capsule Shell: Hydroxypropyl Methylcellulose (HPMC), Beetroot (Beta vulgaris) Extract, Acai Berry (Euterpe Oleracea Martius) Extract, Rice Extract (Oryza Sativa), Pomegranate Seed (Punica Granatum) Extract, Resveratrol from Japanese Knotweed (Polygonum Cuspidatum) Extract, Zinc (Zinc Citrate), Vitamin B6 (Pyridoxine Hydrochloride), Grape Seed (Vitis Vinifera) Extract, Vitamin B7 (as Biotin Pure).", true, 9.60m, "SN099B", 220, 1, "Acai berry immunity complex", "Acai Immuno Defence" },
                    { 4, 2, "02c32793-47c7-4f3b-9487-d91c2a0e4345", new DateTime(2024, 4, 11, 20, 38, 59, 534, DateTimeKind.Local).AddTicks(5745), "Apple Cider Vinegar Complex is a herbal weight management and digestive health combination.\r\n\r\nThis food supplement has been formulated with a specialist blend of synergistic herbs and nutrients.\r\n\r\nEach capsule combines 400mg of apple cider vinegar powder with cayenne, ginger root, turmeric, green tea leaf, organic black pepper and chromium.\r\n\r\nChromium is scientifically proven to contribute to normal macronutrient metabolism and to the maintenance of normal blood glucose levels.", "https://www.dropshipwebhosting.co.uk/image/data/product/main/ACV-120_front.png", "Product ingredients: Apple Cider Vinegar Powder (Malus Sylvestris), Stoneground Brown Rice Flour (Oryza Sativa), Capsule Shell: Hydroxypropyl Methylcellulose (HPMC), Rice Concentrate (Oryza Sativa), Rice Extract (Oryza Sativa), Cayenne Pepper Extract (Capsicum Annuum), Ginger Root Extract (Zingiber Officinale), Black Pepper Powder (Piper Nigrum), Turmeric Root Extract (Curcuma Longa), Green Tea Leaf Extract (Camellia Sinensis), Chromium Picolinate.", true, 6.00m, "ACV-120", 180, 1, "Apple cider vinegar powder plus herbs", "Apple Cider Vinegar Complex" },
                    { 5, 3, "02c32793-47c7-4f3b-9487-d91c2a0e4345", new DateTime(2024, 4, 11, 20, 38, 59, 534, DateTimeKind.Local).AddTicks(5749), "A premium quality chocolate-flavoured whey protein powder, derived from a blend of concentrate and isolate.\r\n\r\nProviding 22g of protein and just 1.6g of fat per 30g serving, this formula contains only the highest grade hormone-free milk, sourced from EU and British cows - no GMOs, artificial colours, flavours, sweeteners or added sugar (stevia is used).\r\n\r\nAs well as providing an excellent nutritional (and amino acid) profile, we have ensured that using WheyNourish is a tasty, hassle-free experience. It can be used before or after exercise, or at any time of day as a protein-rich, muscle building and appetite curbing snack.", "https://www.dropshipwebhosting.co.uk/image/data/product/main/WPP600C_front.png", "Product ingredients: Whey Protein Concentrate (MILK); Whey Protein Isolate (MILK, SOY lecithin); Cocoa (Theobroma cacao) Powder; Flavouring; Stabiliser (Xanthan Gum); Sweetener: Stevia Leaf Extract (Steviol glycosides).", true, 21.60m, "WPP600C", 300, 1, "From whey concentrate and isolate", "WheyNourish (Chocolate Flavour)" },
                    { 6, 3, "02c32793-47c7-4f3b-9487-d91c2a0e4345", new DateTime(2024, 4, 11, 20, 38, 59, 534, DateTimeKind.Local).AddTicks(5753), "PeaNourish is a high quality pea protein powder (from snap peas), blended with a range of other foods and herbs for added nutritional value - chicory root, green tea leaf, dandelion root, spirulina and acai berry (see below).\r\n\r\nThis green protein shake mix contains a concentrated level of pea protein, from the 6% found in fresh peas up to around 80%, and is therefore high in protein (over 18g per serving). It is also low in carbohydrates, high in fibre, easily digestible (no bloating), hypo-allergenic and suitable for vegetarians and vegans.\r\n\r\nPea protein is a natural vegetable-source protein, which offers an excellent amino acid profile. It is also valued for its high digestibility (90-95%), low potential for allergic responses and reasonable price. It is particularly popular because it has a sweet taste and a texture which mixes well in liquid solutions.\r\n\r\nUnlike many other pea protein powders on the market, PeaNourish contains no hexane, toxic chemicals or added 'nasties', which are often used during the pea protein extraction process. Our pea protein is extracted using only water, pressure and then flocculation.", "https://www.dropshipwebhosting.co.uk/image/data/product/main/PP500_front.png", "Product ingredients: Pea Protein (Pisum sativum) Isolate, Fibre (Chicory Root (Cichorium intybus) Extract), Green Tea Leaf (Camellia Sinensis) Extract, Dandelion Root (Taraxacum officinale) Powder, Spirulina Powder (Arthrospira platensis), Acai Berry (Euterpe Oleracae Martius) Extract, Stabiliser (Xanthan Gum), Sweetener: Stevia Leaf Extract (Steviol glycosides).", true, 21.00m, "PP500", 98, 1, "High quality protein PLUS phytonutrients", "PeaNourish" },
                    { 7, 4, "02c32793-47c7-4f3b-9487-d91c2a0e4345", new DateTime(2024, 4, 11, 20, 38, 59, 534, DateTimeKind.Local).AddTicks(5758), "ProBio MAX is a vegan, multi-strain combination of 8 live cultures, providing 20 billion viable organisms per capsule (see below).\r\n\r\nWith no added dairy, sugars, artificial flavourings or colourings, this food supplement provides an alternative to sugary yoghurts and yoghurt drinks containing live cultures. In fact, it provides the equivalent of 40 tubs of probiotic yoghurt, but without the dairy, sugar, fat and calories.\r\n\r\nMicro-encapsulated for acid resistance, this live bacteria biotic has been specifically formulated for natural health practitioners who treat digestive and intestinal disorders. It is ideal for use following antibiotics, travelling abroad and colonic hydrotherapy treatment.", "https://www.dropshipwebhosting.co.uk/image/data/product/main/PBMAX30_front.png", "Product ingredients: Capsule Shell: Hydroxypropyl Methylcellulose (HMPC); Brown Rice Flour (Oryza Sativa); Bio-Live Bacteria Blend: Lactobacillus rhamnosus, Lactobacillus casei, Lactobacillus acidophillus, Bifidobacterium infantis, Streptococcus thermophilus, Bifdobacterium breve, Bifidobacterium longum, Lactobacillus bulgaricus; Rice Extract (Oryza Sativa).", true, 15.00m, "PBMAX30", 54, 1, "A practitioner-strength, multi-strain live culture combination", "ProBio MAX" },
                    { 8, 4, "02c32793-47c7-4f3b-9487-d91c2a0e4345", new DateTime(2024, 4, 11, 20, 38, 59, 534, DateTimeKind.Local).AddTicks(5762), "NaturaC is a combination food state vitamin C supplement, derived from some of nature’s richest sources of this important vitamin: Acerola cherry, rosehip, blackcurrant, parsley leaf and elderberry.\r\n\r\nThe natural food ingredients included in this supplement are more easily recognised by the body, facilitating absorption and utilisation - no artificial vitamin C (ascorbic acid). As such, the vitamin C is retained for longer; not rapidly eliminated.\r\n\r\nThis food supplement offers ideal support for: the immune system, collagen formation, blood vessels, bones, cartilage, gums, skin, teeth, energy-yielding metabolism, the nervous system, the protection of cells from oxidative stress, the reduction of tiredness and fatigue, the regeneration of the reduced form of vitamin E and iron absorption.", "https://www.dropshipwebhosting.co.uk/image/data/product/main/SS360_front.png", "Product ingredients: Acerola Cherry Extract ((Malphigia glabra) (25% Vitamin C)), Capsule Shell: Hydroxypropyl Methylcellulose (HPMC), Anti-caking Agent: Microcrystalline Cellulose, Parsley Leaf Powder (Petroselinum sativum), Blackcurrant Extract (Ribes Nigrum L.), Rice Extract (Oryza Sativa), Elderberry Extract (Sambucus Nigra L.), Rosehip Extract (Rosa Canina).", true, 8.40m, "SS360", 112, 1, "Food form vitamin C", "NaturaC" },
                    { 9, 5, "02c32793-47c7-4f3b-9487-d91c2a0e4345", new DateTime(2024, 4, 11, 20, 38, 59, 534, DateTimeKind.Local).AddTicks(5766), "MEALtime (Vanilla Flavour) is a dairy-free, gluten-free and vegan meal shake and protein powder (non-GM soya protein isolate) that has been fortified with vitamins and minerals.\r\n\r\nHigh in protein (over 72g per 100g), low in fat (0.0g saturated fat per 100g) and with no artificial sweeteners, this vanilla flavoured daily shake is also high in dietary fibre from chicory root extract.\r\n\r\nTasty and filling, MEALtime (Vanilla Flavour) makes for the ideal in-between meals shake. It can even be used as a tasty, guilt-free dessert - only 87 calories per serving!", "https://www.dropshipwebhosting.co.uk/image/data/product/main/SN049_front.png", "Product ingredients: SOY (Glycina Maxima) Protein Isolate (SOY); Fibre (Chicory Root (Cichorium intybus) Extract); Natural Flavour; Maltodextrin; Vitamin and Mineral Blend: ((Potassium Chloride, Magnesium Citrate, Vitamin C (Ascorbic Acid), Ferrous Citrate, Zinc Citrate, Copper Citrate, Vitamin E (DL-Alpha-Tocopheryl Acetate), Vitamin B3 (Niacin), Vitamin A (Acetate), Vitamin B12 (Cyanocobalamin), Vitamin B2 (Riboflavin), Vitamin B6 (Pyridoxine Hydrochloride), Vitamin B1 (Thiamine), Folic Acid (Folacin), Potassium Iodide)); Sweetener: Stevia Leaf Extract (Steviol glycosides).", true, 10.20m, "SN049", 88, 1, "Dairy and gluten-free meal shake", "MEALtime (Vanilla Flavour)" },
                    { 10, 5, "02c32793-47c7-4f3b-9487-d91c2a0e4345", new DateTime(2024, 4, 11, 20, 38, 59, 534, DateTimeKind.Local).AddTicks(5828), "Fibre & Full is an all-in-one dietary fibre based bowel support and weight loss supplement in a tasty, easy-to-take powder form.\r\n\r\nWith a special combination of psyllium husks, sugar beet fibre, glucommanan, L-Glutamine, prebiotics, bacterial cultures, herbs and stevia leaf extract (see more below), the variety of nutrients and high fibre content of this shake make it ideal for long-term use, as well as part of a cleanse and detox programme or weight management programme.\r\n\r\nSpecifically formulated to contribute to healthy weight loss in the context of an energy-restricted diet, normal blood cholesterol levels, as well as a healthy, varied and balanced diet. Sugar beet fibre, in particular, contributes to an increase in faecal bulk and may have a beneficial physiological effect for people who want to improve or maintain a normal bowel function.", "https://www.dropshipwebhosting.co.uk/image/data/product/main/SN040_front.png", "Product ingredients: Psyllium Whole Husks Powder (Plantago ovata); Glucomannan Powder (Amorphophallus Konjac); Sugar Beet Fibre Powder (Beta Vulgaris); L-Glutamine Powder; Inulin Powder (Fructo-oligosaccharides); Fennel Seed Powder (Foeniculum Vulgare); Peppermint Leaf Powder (Mentha Piperita); Ginger Root Powder (Zingiber officinale); Bacteria Blend: Lactobacillus Acidophilus, Bifidobacterium Bifidum; Sweetener: Stevia Leaf Extract (Steviol glycosides).", true, 9.00m, "SN040", 133, 1, "High dietary fibre, bulk and weight loss blend", "Fibre & Full" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Amount", "CurrencyId", "CustomerId", "IsActive", "OrderAddressId", "OrderDate", "OrderNumber", "OrderRecipientId", "PaymentId", "ShippingFee", "Status", "TotalAmount" },
                values: new object[] { 1, 18.00m, 2, 1, true, 1, new DateTime(2024, 4, 11, 20, 38, 59, 435, DateTimeKind.Local).AddTicks(4547), "PO000000", 1, 1, 1.80m, 1, 19.80m });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "CurrencyId", "ImageUrl", "IsActive", "OrderId", "Price", "Quantity", "Title" },
                values: new object[] { 1, 2, "https://www.dropshipwebhosting.co.uk/image/data/product/main/SN105_front.png", true, 1, 12.00m, 1, "Green Nourish Complete" });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "CurrencyId", "ImageUrl", "IsActive", "OrderId", "Price", "Quantity", "Title" },
                values: new object[] { 2, 2, "https://www.dropshipwebhosting.co.uk/image/data/product/main/ACV-120_front.png", true, 1, 6.00m, 1, "Apple Cider Vinegar Complex" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_CountryId",
                table: "CustomerAddresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAddresses_CountryId",
                table: "OrderAddresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_CurrencyId",
                table: "OrderItems",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CurrencyId",
                table: "Orders",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderAddressId",
                table: "Orders",
                column: "OrderAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderRecipientId",
                table: "Orders",
                column: "OrderRecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedById",
                table: "Products",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShopId",
                table: "Products",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_CurrencyId",
                table: "Shops",
                column: "CurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "OrderAddresses");

            migrationBuilder.DropTable(
                name: "OrderRecipients");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CustomerAddresses");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
