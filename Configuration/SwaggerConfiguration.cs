using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CademeucarroApi.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "CadeMeuCarro",
                    Version = "v1",
                    Description = "MVP criado no Hackaton organizado pelo grupo de desenvolvedores do Dev-ES",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Dev-ES", Email = "", Url = "http://dev-es.org/" },
                    // License = new License { Name = "Use under LICX", Url = "https://example.com/license" }
                });
            });
        }
    }
}