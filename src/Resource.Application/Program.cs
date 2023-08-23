using IdentityAuthentication.Model.Handlers;
using IdentityAuthentication.TokenValidation;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NLog.Web;
using Resource.Core;
using Yangtao.Hosting.Mvc;

namespace Resource.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add NLog
            builder.Logging.ClearProviders();
            builder.Host.UseNLog();

            var services = builder.Services;
            var configuration = builder.Configuration;

            // Add services to the container.

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.SetIsOriginAllowed(_ => true).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                });
            });
            services.AddControllers(options =>
            {
                options.Filters.AddGlobalExceptionFilter();
            }).AddModelValidation().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Formatting = Formatting.Indented;
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddAuthentication(options =>
            {
                var authenticationConfig = configuration.GetSection("Authentication");
                options.Authority = authenticationConfig.GetValue<string>("Endpoint");
                options.Events = new IdentityAuthenticationEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Query["access_token"];
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    },
                };
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddResourceCore(options =>
            {
                options.ConnectionString = string.Empty;
            });

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

            app.Map("/", () => "Hello Resource Service"); // ื๎ะก API

            app.Run();
        }
    }
}