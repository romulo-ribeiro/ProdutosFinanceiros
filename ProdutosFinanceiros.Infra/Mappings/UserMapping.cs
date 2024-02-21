using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutosFinanceiros.Domain;

namespace ProdutosFinanceiros.Infra;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(q => q.Id);
        builder.Property(q => q.Id).IsRequired().HasDefaultValueSql("NEWID()");
        builder.Property(q => q.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
        builder.Property(q => q.Name).IsRequired().HasMaxLength(200);
        builder.Property(q => q.Type).IsRequired();
        builder.Property(q => q.Email).IsRequired().HasMaxLength(200);
        builder.Property(q => q.Password).IsRequired().HasMaxLength(200);
    }
}
