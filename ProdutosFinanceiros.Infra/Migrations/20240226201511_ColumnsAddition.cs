using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProdutosFinanceiros.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ColumnsAddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvestmentWallet_InvestmentWalletFinancialProduct_WalletFinancialProductId",
                table: "InvestmentWallet");

            migrationBuilder.DropIndex(
                name: "IX_InvestmentWallet_WalletFinancialProductId",
                table: "InvestmentWallet");

            migrationBuilder.AddColumn<Guid>(
                name: "InvestmentWalletId1",
                table: "InvestmentWalletFinancialProduct",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "WalletFinancialProductId",
                table: "InvestmentWallet",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "InvestmentWallet",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentWalletFinancialProduct_InvestmentWalletId1",
                table: "InvestmentWalletFinancialProduct",
                column: "InvestmentWalletId1");

            migrationBuilder.AddForeignKey(
                name: "FK_InvestmentWalletFinancialProduct_InvestmentWallet_InvestmentWalletId1",
                table: "InvestmentWalletFinancialProduct",
                column: "InvestmentWalletId1",
                principalTable: "InvestmentWallet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvestmentWalletFinancialProduct_InvestmentWallet_InvestmentWalletId1",
                table: "InvestmentWalletFinancialProduct");

            migrationBuilder.DropIndex(
                name: "IX_InvestmentWalletFinancialProduct_InvestmentWalletId1",
                table: "InvestmentWalletFinancialProduct");

            migrationBuilder.DropColumn(
                name: "InvestmentWalletId1",
                table: "InvestmentWalletFinancialProduct");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "InvestmentWallet");

            migrationBuilder.AlterColumn<Guid>(
                name: "WalletFinancialProductId",
                table: "InvestmentWallet",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_InvestmentWallet_WalletFinancialProductId",
                table: "InvestmentWallet",
                column: "WalletFinancialProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvestmentWallet_InvestmentWalletFinancialProduct_WalletFinancialProductId",
                table: "InvestmentWallet",
                column: "WalletFinancialProductId",
                principalTable: "InvestmentWalletFinancialProduct",
                principalColumn: "Id");
        }
    }
}
