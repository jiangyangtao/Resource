using IdentityAuthentication.TokenValidation;
using Yangtao.Hosting.Endpoint;
using Yangtao.Hosting.Mvc;
using Yangtao.Hosting.NLog;
using Resource.Core;

namespace Resource.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add NLog
            builder.Logging.ConfigNLog();

            var services = builder.Services;
            var configuration = builder.Configuration;

            // Add services to the container.

            services.AddAllowAnyCors();
            services.AddControllers(options =>
            {
                options.Filters.AddGlobalExceptionFilter();
            }).AddModelValidation().AddDefaultNewtonsoftJson();

            services.AddIdentityAuthentication();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddApiVersion();
            services.AddSwaggerGen();
            services.AddResourceCore();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseIdentityAuthentication();

            app.MapControllers();

            app.UseEnumConfigurationEndpoint();
            app.Map("/", () => "Hello Resource Service"); // ื๎ะก API
            app.Run();
        }
    }
}