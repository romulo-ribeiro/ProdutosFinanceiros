namespace ProdutosFinanceiros.Domain;
public class FinancialProduct : Entity
{
    public FinancialProductType Type { get; private set; }
    public decimal Value { get; private set; }
    public DateTime PaymentDate { get; set; }

    public FinancialProduct(string name, FinancialProductType type, decimal value)
    {
        AddName(name);
        Type = type;
        Value = value;
        PaymentDate = DateTime.Today;
    }
}
