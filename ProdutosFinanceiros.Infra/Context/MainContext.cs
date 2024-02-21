using Microsoft.EntityFrameworkCore;
using ProdutosFinanceiros.Infra.Helpers;

namespace ProdutosFinanceiros.Infra.Context
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options)
            : base(options)
        {
        }

        public MainContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainContext).Assembly);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(InfraHelper.GetConnectionString("DB_CONNECTION_STRING"));
            }
        }
    }
}