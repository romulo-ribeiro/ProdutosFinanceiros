using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProdutosFinanceiros.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancialProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(5,2)", precision: 5, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WalletFinancialProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvestmentWallet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WalletNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WalletFinancialProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentWallet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestmentWallet_User_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvestmentWallet_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvestmentWalletFinancialProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvestmentWalletId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FinancialProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentWalletFinancialProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestmentWalletFinancialProduct_FinancialProduct_FinancialProductId",
                        column: x => x.FinancialProductId,
                        principalTable: "FinancialProduct",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvestmentWalletFinancialProduct_InvestmentWallet_InvestmentWalletId",
                        column: x => x.InvestmentWalletId,
                        principalTable: "InvestmentWallet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinancialProduct_WalletFinancialProductId",
                table: "FinancialProduct",
                column: "WalletFinancialProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentWallet_ManagerId",
                table: "InvestmentWallet",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentWallet_UserId",
                table: "InvestmentWallet",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentWallet_WalletFinancialProductId",
                table: "InvestmentWallet",
                column: "WalletFinancialProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentWalletFinancialProduct_FinancialProductId",
                table: "InvestmentWalletFinancialProduct",
                column: "FinancialProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentWalletFinancialProduct_InvestmentWalletId",
                table: "InvestmentWalletFinancialProduct",
                column: "InvestmentWalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialProduct_InvestmentWalletFinancialProduct_WalletFinancialProductId",
                table: "FinancialProduct",
                column: "WalletFinancialProductId",
                principalTable: "InvestmentWalletFinancialProduct",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvestmentWallet_InvestmentWalletFinancialProduct_WalletFinancialProductId",
                table: "InvestmentWallet",
                column: "WalletFinancialProductId",
                principalTable: "InvestmentWalletFinancialProduct",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialProduct_InvestmentWalletFinancialProduct_WalletFinancialProductId",
                table: "FinancialProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_InvestmentWallet_InvestmentWalletFinancialProduct_WalletFinancialProductId",
                table: "InvestmentWallet");

            migrationBuilder.DropTable(
                name: "InvestmentWalletFinancialProduct");

            migrationBuilder.DropTable(
                name: "FinancialProduct");

            migrationBuilder.DropTable(
                name: "InvestmentWallet");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
