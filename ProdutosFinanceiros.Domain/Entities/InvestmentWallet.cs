﻿namespace ProdutosFinanceiros.Domain;
public class InvestmentWallet : Entity
{
    public string WalletNumber { get; private set; }
    public virtual User User { get; set; }
    public Guid UserId { get; set; }
    public virtual User Manager { get; set; }
    public Guid ManagerId { get; set; }
    public virtual InvestmentWalletFinancialProduct? WalletFinancialProduct { get; set; }
    public Guid? WalletFinancialProductId { get; set; }

    public InvestmentWallet()
    {
        WalletNumber = EntityHelpers.RandomString(5);
    }
}
