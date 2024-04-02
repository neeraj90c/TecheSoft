using DTO;
using EncryptDecrypt.Interface;
using EncryptDecrypt.Service;
using Filter;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace TecheSoft.Extensions
{
    public static class ServiceExtentions
    {
        private static string XmlCommentsFilePath(string xmlDocFileName)
                           => Path.Combine(AppContext.BaseDirectory, xmlDocFileName);
        private static string GetAssemblyName()
                                   => typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

        public static void AddServices(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddScoped<ValidationFilterAttribute>();
            services.AddNLogService(_config);
            services.AddSharedInfrastructure(_config);
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllers();
            services.AddSwagger();
            services.AddApplication();
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            var executingAssemblySimpleName = Assembly.GetExecutingAssembly().GetName().Name;


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Roles API", Version = "v1" });
                //c.IncludeXmlComments(XmlCommentsFilePath("AuthenticationService.xml"));
            });

        }

        public static void AddNLogService(this IServiceCollection services, IConfiguration config)
        {
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.SetMinimumLevel(LogLevel.Trace);
                //loggingBuilder.AddNLog(config);
            })
            .BuildServiceProvider();
        }
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<ConnectionSettings>(_config.GetSection("ConnectionStrings"));
            services.Configure<APISettings>(_config.GetSection("Settings"));
            services.Configure<JWTSettings>(_config.GetSection("JWT"));
            services.AddSingleton<IEncryptDecrypt, EncryptDecryptService>();
        }
    }
}
