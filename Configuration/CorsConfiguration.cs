using Microsoft.Extensions.DependencyInjection;

namespace CademeucarroApi.Configuration
{
    public static class CorsConfiguration
    {
        public const string CorsPolicyName = "CademeucarroCorsPolicy";

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy(CorsPolicyName, builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }
    }
}