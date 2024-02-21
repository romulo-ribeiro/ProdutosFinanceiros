using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutosFinanceiros.Domain;

namespace ProdutosFinanceiros.Infra.Mapping;

public class FinancialProductMapping : IEntityTypeConfiguration<FinancialProduct>
{
    public void Configure(EntityTypeBuilder<FinancialProduct> builder)
    {
        builder.HasKey(q => q.Id);
        builder.HasOne(q => q.WalletFinancialProduct).WithMany().HasForeignKey(q => q.WalletFinancialProductId).OnDelete(DeleteBehavior.NoAction);
        builder.Property(q => q.Name).IsRequired();
        builder.Property(q => q.Value).IsRequired().HasPrecision(5);
        builder.Property(q => q.Quantity).IsRequired();
        builder.Property(q => q.Type).IsRequired();
        builder.Property(q => q.CreatedAt).IsRequired();
    }
}
