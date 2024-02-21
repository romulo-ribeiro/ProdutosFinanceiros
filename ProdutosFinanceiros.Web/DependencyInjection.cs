using FluentValidation;
using ProdutosFinanceiros.Application.Interfaces;
using ProdutosFinanceiros.Application.Services;
using ProdutosFinanceiros.Application.Validators;
using ProdutosFinanceiros.Domain;
using ProdutosFinanceiros.Domain.Interfaces;
using ProdutosFinanceiros.Infra.Repository;

namespace ProdutosFinanceiros.Web
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IValidator<User>, UserValidator>();

            services.AddScoped<IFinancialProductRepository, FinancialProductRepository>();
            services.AddScoped<IFinancialProductService, FinancialProductService>();
            services.AddScoped<IValidator<FinancialProduct>, FinancialProductValidator>();

            services.AddScoped<IInvestmentWalletRepository, InvestmentWalletRepository>();
            services.AddScoped<IInvestmentWalletService, InvestmentWalletService>();
            services.AddScoped<IValidator<InvestmentWallet>, InvestmentWalletValidator>();

            services.AddScoped<IInvestmentWalletFinancialProductRepository, InvestmentWalletFinancialProductRepository>();
        }
    }
}