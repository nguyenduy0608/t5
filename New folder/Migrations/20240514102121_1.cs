using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIS.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    City = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Region = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PostalCode = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Country = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    address = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    phone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "StaffManagers",
                columns: table => new
                {
                    id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffManagers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    city = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    country = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Shopid = table.Column<long>(type: "NUMBER(19)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.id);
                    table.ForeignKey(
                        name: "FK_Warehouse_Shops_Shopid",
                        column: x => x.Shopid,
                        principalTable: "Shops",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    category = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Warehouseid = table.Column<long>(type: "NUMBER(19)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Warehouse_Warehouseid",
                        column: x => x.Warehouseid,
                        principalTable: "Warehouse",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Type = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Warehouseid = table.Column<long>(type: "NUMBER(19)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statistics_Warehouse_Warehouseid",
                        column: x => x.Warehouseid,
                        principalTable: "Warehouse",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "StaffProducts",
                columns: table => new
                {
                    id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ProductId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    StaffId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffProducts", x => x.id);
                    table.ForeignKey(
                        name: "FK_StaffProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StaffProducts_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StaffStatistics",
                columns: table => new
                {
                    id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StaffId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    StatisticId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffStatistics", x => x.id);
                    table.ForeignKey(
                        name: "FK_StaffStatistics_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StaffStatistics_Statistics_StatisticId",
                        column: x => x.StatisticId,
                        principalTable: "Statistics",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StatisticManagers",
                columns: table => new
                {
                    id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Managerid = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    StatisticId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatisticManagers", x => x.id);
                    table.ForeignKey(
                        name: "FK_StatisticManagers_Managers_Managerid",
                        column: x => x.Managerid,
                        principalTable: "Managers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_StatisticManagers_Statistics_StatisticId",
                        column: x => x.StatisticId,
                        principalTable: "Statistics",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StatisticsCustomer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CustomerId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    StatisticId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatisticsCustomer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatisticsCustomer_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StatisticsCustomer_Statistics_StatisticId",
                        column: x => x.StatisticId,
                        principalTable: "Statistics",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Warehouseid",
                table: "Products",
                column: "Warehouseid");

            migrationBuilder.CreateIndex(
                name: "IX_StaffProducts_ProductId",
                table: "StaffProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffProducts_StaffId",
                table: "StaffProducts",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffStatistics_StaffId",
                table: "StaffStatistics",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffStatistics_StatisticId",
                table: "StaffStatistics",
                column: "StatisticId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticManagers_Managerid",
                table: "StatisticManagers",
                column: "Managerid");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticManagers_StatisticId",
                table: "StatisticManagers",
                column: "StatisticId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_Warehouseid",
                table: "Statistics",
                column: "Warehouseid");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticsCustomer_CustomerId",
                table: "StatisticsCustomer",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticsCustomer_StatisticId",
                table: "StatisticsCustomer",
                column: "StatisticId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_Shopid",
                table: "Warehouse",
                column: "Shopid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffManagers");

            migrationBuilder.DropTable(
                name: "StaffProducts");

            migrationBuilder.DropTable(
                name: "StaffStatistics");

            migrationBuilder.DropTable(
                name: "StatisticManagers");

            migrationBuilder.DropTable(
                name: "StatisticsCustomer");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "Shops");
        }
    }
}
