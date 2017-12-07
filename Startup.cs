using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cademeucarro_api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace cademeucarro_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (Environment.IsDevelopment())
            {
                services.AddDbContext<CadeMeuCarroDataContext>(options =>
                        options.UseSqlite("Data Source=CadeMeuCarro.db"));
            }
            else
            {
                services.AddDbContext<CadeMeuCarroDataContext>(opts =>
                    opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            }

            services.AddCors(opts => {
                opts.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddMvc();

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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, CadeMeuCarroDataContext context)
        {
            context.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();
        }
    }
}
