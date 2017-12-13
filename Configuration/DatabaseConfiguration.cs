using System;
using CademeucarroApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CademeucarroApi.Configuration
{
    public static class DatabaseConfiguration
    {
        private const string SqlliteConnString = "Data Source=CadeMeuCarro.db";

        public static void ConfigureDatabase(this IServiceCollection services, IHostingEnvironment env, IConfiguration config)
        {
            if (env.IsDevelopment())
            {
                services.AddDbContext<CadeMeuCarroDataContext>(options =>
                    options.UseSqlite(SqlliteConnString));
            }
            else
            {
                services.AddDbContext<CadeMeuCarroDataContext>(opts =>
                    opts.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            }
        }
    }
}
