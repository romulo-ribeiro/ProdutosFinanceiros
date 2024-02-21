
using ProdutosFinanceiros.Domain.Interfaces;

namespace ProdutosFinanceiros.Domain;
public class Entity : IEntity
{
    public Guid Id { get; set; }
    public string? Name { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Entity()
    {
        CreatedAt = DateTime.Now;
    }

    protected void AddName(string name)
    {
        Name = name;
    }
}
