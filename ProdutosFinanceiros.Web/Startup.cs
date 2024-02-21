using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProdutosFinanceiros.Application.Services;
using ProdutosFinanceiros.Infra.Context;
using ProdutosFinanceiros.Infra.Helpers;
using ProdutosFinanceiros.Web.Handlers;
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
            try
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Projeto Produtos Financeiros",
                        Version = "v1",
                    });
                    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        Scheme = "basic",
                        In = ParameterLocation.Header,
                        Description = "Authorization header using the Bearer scheme."
                    });
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                    }
                    });
                });
                AddDbContextCollection(services);
                services.AddControllers();
                services.AddCors();

                services.AddAuthentication("BasicAuthentication")
                    .AddScheme<AuthenticationSchemeOptions, AuthenticationHandler>("BasicAuthentication", null);

                services.AddHostedService<EmailNotificationService>();
                DependencyInjection.AddInfrastructure(services, Configuration);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            var serverUrls = Configuration["ASPNETCORE_URLS"] ?? "Not Found";
            Console.WriteLine($"Server URLs: {serverUrls}");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
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
