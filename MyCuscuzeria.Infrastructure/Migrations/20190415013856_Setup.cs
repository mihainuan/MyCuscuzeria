using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCuscuzeria.Infrastructure.Migrations
{
    public partial class Setup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    GuId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Phone = table.Column<string>(maxLength: 150, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastOrder = table.Column<DateTime>(nullable: true),
                    UrlImg = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Cuscuzeiros",
                columns: table => new
                {
                    GuId = table.Column<Guid>(nullable: false),
                    CuscuzeiroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CuscuzeiroName = table.Column<string>(maxLength: 150, nullable: false),
                    YearsOfExperience = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    UrlImg = table.Column<string>(maxLength: 500, nullable: true),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuscuzeiros", x => x.CuscuzeiroId);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    GuId = table.Column<Guid>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeName = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    GuId = table.Column<Guid>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CuscuzeiroId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    BeverageId = table.Column<int>(nullable: false),
                    CuscuzId = table.Column<int>(nullable: false),
                    DrinkId = table.Column<int>(nullable: false),
                    PromoId = table.Column<int>(nullable: false),
                    OrderStatus = table.Column<int>(nullable: false),
                    OrderCreation = table.Column<DateTime>(nullable: false),
                    Delivered = table.Column<bool>(nullable: false),
                    OrderTotal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Cuscuzeiros_CuscuzeiroId",
                        column: x => x.CuscuzeiroId,
                        principalTable: "Cuscuzeiros",
                        principalColumn: "CuscuzeiroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_UserId",
                        column: x => x.UserId,
                        principalTable: "Clients",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beverages",
                columns: table => new
                {
                    GuId = table.Column<Guid>(nullable: false),
                    BeverageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BeverageName = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beverages", x => x.BeverageId);
                    table.ForeignKey(
                        name: "FK_Beverages_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cuscuz",
                columns: table => new
                {
                    GuId = table.Column<Guid>(nullable: false),
                    CuscuzId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CuscuzName = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    AccompanimentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuscuz", x => x.CuscuzId);
                    table.ForeignKey(
                        name: "FK_Cuscuz_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cuscuz_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    GuId = table.Column<Guid>(nullable: false),
                    DrinkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DrinkName = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.DrinkId);
                    table.ForeignKey(
                        name: "FK_Drinks_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promos",
                columns: table => new
                {
                    GuId = table.Column<Guid>(nullable: false),
                    PromoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    StartsAt = table.Column<DateTime>(nullable: true),
                    EndsAt = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promos", x => x.PromoId);
                    table.ForeignKey(
                        name: "FK_Promos_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accompaniments",
                columns: table => new
                {
                    GuId = table.Column<Guid>(nullable: false),
                    AccompanimentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccompanimentName = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    CuscuzId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accompaniments", x => x.AccompanimentId);
                    table.ForeignKey(
                        name: "FK_Accompaniments_Cuscuz_CuscuzId",
                        column: x => x.CuscuzId,
                        principalTable: "Cuscuz",
                        principalColumn: "CuscuzId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accompaniments_CuscuzId",
                table: "Accompaniments",
                column: "CuscuzId");

            migrationBuilder.CreateIndex(
                name: "IX_Beverages_OrderId",
                table: "Beverages",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuscuz_OrderId",
                table: "Cuscuz",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuscuz_TypeId",
                table: "Cuscuz",
                column: "TypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_OrderId",
                table: "Drinks",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CuscuzeiroId",
                table: "Orders",
                column: "CuscuzeiroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Promos_OrderId",
                table: "Promos",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accompaniments");

            migrationBuilder.DropTable(
                name: "Beverages");

            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "Promos");

            migrationBuilder.DropTable(
                name: "Cuscuz");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "Cuscuzeiros");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
