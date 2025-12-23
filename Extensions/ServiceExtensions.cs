using CompanyEmployees.Repository;
using CompanyEmployees.Repository.Contracts;
using CompanyEmployees.Service;
using CompanyEmployees.Service.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployees.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            Console.WriteLine("in ConfigureCors");
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader() );
            });
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services){
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }

        public static void ConfigureServiceManager(this IServiceCollection services){
            services.AddScoped<IServiceManager, ServiceManager>();
        }

        //Just for db
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(opts =>
            {
                opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"));
            });
        }
    }
}
