using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace CademeucarroApi.Configuration
{
    public static class MvcConfiguration
    {
        public static void ConfigureMvc(this IServiceCollection services)
        {
            services.AddMvc();

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory(CorsConfiguration.CorsPolicyName));
            });
        }
    }
}