using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class migrate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crust",
                columns: table => new
                {
                    CrustId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crust", x => x.CrustId);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    SizeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.SizeId);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    StoreId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.StoreId);
                });

            migrationBuilder.CreateTable(
                name: "Topping",
                columns: table => new
                {
                    ToppingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topping", x => x.ToppingId);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    PizzaTypeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.PizzaTypeId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    LastLocationOrderedFromStoreId = table.Column<long>(nullable: true),
                    LastOrderTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Store_LastLocationOrderedFromStoreId",
                        column: x => x.LastLocationOrderedFromStoreId,
                        principalTable: "Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TypeTopping",
                columns: table => new
                {
                    PizzaTypeId = table.Column<long>(nullable: false),
                    ToppingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeTopping", x => new { x.PizzaTypeId, x.ToppingId });
                    table.ForeignKey(
                        name: "FK_TypeTopping_Type_PizzaTypeId",
                        column: x => x.PizzaTypeId,
                        principalTable: "Type",
                        principalColumn: "PizzaTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypeTopping_Topping_ToppingId",
                        column: x => x.ToppingId,
                        principalTable: "Topping",
                        principalColumn: "ToppingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    StoreId = table.Column<long>(nullable: false),
                    TimeOrdered = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    PizzaId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(nullable: false),
                    OrderId = table.Column<long>(nullable: false),
                    CrustId = table.Column<long>(nullable: false),
                    SizeId = table.Column<long>(nullable: false),
                    PizzaTypeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.PizzaId);
                    table.ForeignKey(
                        name: "FK_Pizza_Crust_CrustId",
                        column: x => x.CrustId,
                        principalTable: "Crust",
                        principalColumn: "CrustId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pizza_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pizza_Type_PizzaTypeId",
                        column: x => x.PizzaTypeId,
                        principalTable: "Type",
                        principalColumn: "PizzaTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pizza_Size_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Size",
                        principalColumn: "SizeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Crust",
                columns: new[] { "CrustId", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "Hand Tossed", 2.00m },
                    { 2L, "New York Style", 2.50m },
                    { 3L, "Thin Crust", 2.50m },
                    { 4L, "Deep Dish", 3.50m },
                    { 5L, "Gluten Free", 2.50m }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "SizeId", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "Small", 6.00m },
                    { 2L, "Medium", 8.00m },
                    { 3L, "Large", 10.00m }
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "StoreId", "Name", "Password", "Username" },
                values: new object[,]
                {
                    { 637193615219218113L, "'za by Tony", "12345", "tony" },
                    { 637193615219218062L, "Peace of Pie", "password", "pizza" },
                    { 637193615219216968L, "Big Rico's Grease Extravaganza", "grease", "bigrico" }
                });

            migrationBuilder.InsertData(
                table: "Topping",
                columns: new[] { "ToppingId", "Name" },
                values: new object[,]
                {
                    { 6, "Mushroom" },
                    { 8, "Tomato" },
                    { 9, "Green Pepper" },
                    { 10, "Jalapeno" },
                    { 5, "Onion" },
                    { 15, "Feta Cheese" },
                    { 13, "Bannana Pepper" },
                    { 12, "Pineapple" },
                    { 4, "Sausage" },
                    { 11, "Ham" },
                    { 1, "Pepperoni" },
                    { 14, "Cheese" },
                    { 3, "Alfredo Sauce" },
                    { 2, "Tomato Sauce" },
                    { 7, "Bacon" }
                });

            migrationBuilder.InsertData(
                table: "Type",
                columns: new[] { "PizzaTypeId", "Name", "Price" },
                values: new object[,]
                {
                    { 637193615219216034L, "Hawaiian", 7.00m },
                    { 637193615219216031L, "Super Supreme", 10.00m },
                    { 637193615219216025L, "All Meat", 8.00m },
                    { 637193615219215980L, "Pepperoni", 5.00m },
                    { 637193615219187294L, "Cheese", 3.00m }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "LastLocationOrderedFromStoreId", "LastOrderTime", "Name", "Password", "Username" },
                values: new object[,]
                {
                    { 637193615219219878L, null, 0, "Jessa Jenkins", "12345", "jjenkins" },
                    { 637193615219218851L, null, 0, "Ryan Smith", "12345", "rsmith" },
                    { 637193615219219831L, null, 0, "Alexander Wilkins", "12345", "awilkins" },
                    { 637193615219219882L, null, 0, "Wilma Stephens", "12345", "wstephens" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_StoreId",
                table: "Order",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_CrustId",
                table: "Pizza",
                column: "CrustId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_OrderId",
                table: "Pizza",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_PizzaTypeId",
                table: "Pizza",
                column: "PizzaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_SizeId",
                table: "Pizza",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeTopping_ToppingId",
                table: "TypeTopping",
                column: "ToppingId");

            migrationBuilder.CreateIndex(
                name: "IX_User_LastLocationOrderedFromStoreId",
                table: "User",
                column: "LastLocationOrderedFromStoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "TypeTopping");

            migrationBuilder.DropTable(
                name: "Crust");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropTable(
                name: "Topping");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Store");
        }
    }
}
