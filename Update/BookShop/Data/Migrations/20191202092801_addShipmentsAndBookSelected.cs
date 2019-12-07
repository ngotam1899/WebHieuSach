using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookShop.Data.Migrations
{
    public partial class addShipmentsAndBookSelected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLine");

            migrationBuilder.DropTable(
                name: "Sources");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipmentDate = table.Column<DateTime>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    CustomerPhone = table.Column<string>(nullable: true),
                    CustomerEmail = table.Column<string>(nullable: true),
                    isConfirmed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BooksSelectedForShipment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipmentID = table.Column<int>(nullable: false),
                    BookID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksSelectedForShipment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BooksSelectedForShipment_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksSelectedForShipment_Shipments_ShipmentID",
                        column: x => x.ShipmentID,
                        principalTable: "Shipments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BooksSelectedForShipment_BookID",
                table: "BooksSelectedForShipment",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_BooksSelectedForShipment_ShipmentID",
                table: "BooksSelectedForShipment",
                column: "ShipmentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksSelectedForShipment");

            migrationBuilder.DropTable(
                name: "Shipments");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomersID = table.Column<int>(type: "int", nullable: true),
                    OrderFilled = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomersID",
                        column: x => x.CustomersID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderLine",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BooksID = table.Column<int>(type: "int", nullable: true),
                    Cost_Line = table.Column<int>(type: "int", nullable: false),
                    OrdersID = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Shipped = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLine", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderLine_Books_BooksID",
                        column: x => x.BooksID,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLine_Orders_OrdersID",
                        column: x => x.OrdersID,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_BooksID",
                table: "OrderLine",
                column: "BooksID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_OrdersID",
                table: "OrderLine",
                column: "OrdersID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomersID",
                table: "Orders",
                column: "CustomersID");
        }
    }
}
