﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutosFinanceiros.Domain;

namespace ProdutosFinanceiros.Infra;
public class InvestmentWalletMapping : IEntityTypeConfiguration<InvestmentWallet>
{
    public void Configure(EntityTypeBuilder<InvestmentWallet> builder)
    {
        builder.HasKey(q => q.Id);
        builder.HasMany(q => q.WalletFinancialProduct).WithOne().HasForeignKey(q => q.InvestmentWalletId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(q => q.User).WithMany().HasForeignKey(q => q.UserId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(q => q.Manager).WithMany().HasForeignKey(q => q.ManagerId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Property(q => q.Id).IsRequired().HasDefaultValueSql("NEWID()");
        builder.Property(q => q.Balance);
        builder.Property(q => q.WalletNumber).IsRequired();
        builder.Property(q => q.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
    }
}
