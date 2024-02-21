namespace ProdutosFinanceiros.Domain.Interfaces;

public interface IEntity
{
    public Guid Id { get; set; }
    public string? Name { get; }
    public DateTime CreatedAt { get; }
}
