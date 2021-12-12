
using CoreTemplate.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Compression;

namespace CoreTemplateREST
{
    public static class ServiceExtensions
    {
        public static void ConfigureContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<DbContext, AppDBContext>();
        }

        public static void MapInterfaceImplementation(this IServiceCollection services)
        {
            // add BL classes here

            // add DAL classes here

            // add other services here
            services.AddHttpClient();
        }

        public static void ConfigureResponseCompresion(this IServiceCollection services)
        {
            // Manage response compression
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.EnableForHttps = true;
            });
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });
        }
    }
}