using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutosFinanceiros.Domain;

namespace ProdutosFinanceiros.Infra;
public class InvestmentWalletFinancialProductMapping : IEntityTypeConfiguration<InvestmentWalletFinancialProduct>
{
    public void Configure(EntityTypeBuilder<InvestmentWalletFinancialProduct> builder)
    {
        builder.HasKey(q => q.Id);
        builder.HasOne(q => q.FinancialProduct).WithMany().HasForeignKey(q => q.FinancialProductId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(q => q.InvestmentWallet).WithMany().HasForeignKey(q => q.InvestmentWalletId).OnDelete(DeleteBehavior.NoAction);
        builder.Property(q => q.Id).IsRequired().HasDefaultValueSql("NEWID()");
        builder.Property(q => q.Quantity).IsRequired();
        builder.Property(q => q.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");;
    }
}
