namespace ProdutosFinanceiros.Domain;
public class FinancialProduct : Entity
{
    public FinancialProductType Type { get; private set; }
    public decimal Value { get; private set; }
    public int Quantity { get; private set; }
    public DateTime PaymentDate { get; set; }
    public virtual InvestmentWalletFinancialProduct WalletFinancialProduct { get; set; }
    public Guid WalletFinancialProductId { get; set; }

    public FinancialProduct(string name, FinancialProductType type, decimal value, int quantity)
    {
        AddName(name);
        Type = type;
        Value = value;
        Quantity = quantity;
        PaymentDate = DateTime.Today;
    }
}
