using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProdutosFinanceiros.Application.Services;
using ProdutosFinanceiros.Infra.Context;
using ProdutosFinanceiros.Infra.Helpers;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace ProdutosFinanceiros.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Projeto Produtos Financeiros",
                    Version = "v1",
                });
            });
            AddDbContextCollection(services);
            services.AddControllers();
            services.AddCors();
            services.AddHostedService<EmailNotificationService>();

            DependencyInjection.AddInfrastructure(services, Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RoleManager<IdentityRole> roleManager)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1 Projeto Produtos Financeiros");
                c.DocExpansion(DocExpansion.None);
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private void AddDbContextCollection(IServiceCollection services)
        {
            services.AddDbContext<MainContext>(opt => opt
                .UseSqlServer(InfraHelper.GetConnectionString(Configuration["ConnectionStrings:DefaultConnection"])));
        }
    }
}
