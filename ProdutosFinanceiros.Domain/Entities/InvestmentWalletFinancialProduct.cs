namespace ProdutosFinanceiros.Domain;
public class InvestmentWalletFinancialProduct : Entity
{
    public virtual InvestmentWallet InvestmentWallet { get; set; }
    public Guid InvestmentWalletId { get; set; }
    public virtual FinancialProduct FinancialProduct { get; set; }
    public Guid FinancialProductId { get; set; }
}
