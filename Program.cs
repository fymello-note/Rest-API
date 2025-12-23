using CompanyEmployees.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.ConfigureCors();
            builder.Services.ConfigureSqlContext(builder.Configuration);
            builder.Services.ConfigureRepositoryManager();
            builder.Services.ConfigureServiceManager();
            builder.Services.AddAutoMapper(typeof(Program));

            // Suppress ApiController behaviour
            builder.Services.Configure<ApiBehaviorOptions>(option => {
                option.SuppressModelStateInvalidFilter = true;
            });

            builder.Services.AddControllers();

            builder.Services.AddAuthentication();
            builder.Services.ConfigureJWT(builder.Configuration);

            var app = builder.Build();

            //Install a global exception handler
            app.ConfigureExceptionHandler();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // ! MIDDLEWARE
            // a custom middleware cross cutting concern
            /*Run is a finalizer method, use is more appropriate
            app.Use(async (context, next) =>
            {
                Console.WriteLine("Logic before executing next level");
                //await context.Response.WriteAsync("before...start from api");
                await next.Invoke();
                Console.WriteLine("Logic after executing next level");
            });

            app.Map("/usingmapbranch", builder =>
            {
                builder.Use(async (context, next) =>
                {
                    Console.WriteLine("Map branch logic in use method before");
                    //await context.Response.WriteAsync("before...start from api");
                    await next.Invoke();
                    Console.WriteLine("Map branch logic in use method after");
                });
                builder.Run(async context =>
                {
                    Console.WriteLine("writing response to client");
                    //context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("Startup from WebAPI");
                });
            });

            app.Run(async context =>
            {
                Console.WriteLine("writing response to client");
                //context.Response.StatusCode = 200;
                await context.Response.WriteAsync("Startup from WebAPI");
            });*/

            app.UseCors("CorsPolicy");

            app.MapControllers();

            app.Run();
        }
    }
}
