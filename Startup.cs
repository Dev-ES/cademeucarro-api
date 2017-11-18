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
            if (Environment.IsDevelopment()) {
                services.AddDbContext<CadeMeuCarroDataContext>(options =>
                        options.UseSqlite("Data Source=CadeMeuCarro.db"));
            }
            else {
                services.AddDbContext<CadeMeuCarroDataContext>(opts =>
                    opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            }
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, CadeMeuCarroDataContext context)
        {
            context.Database.Migrate();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
