using System;
using System.ComponentModel;
using Api.ErrorHandling;
using CodeJam2018.Platform.BusinessLogic;
using CodeJam2018.Platform.Dal.Redis;
using CodeJam2018.PlatformTypes;
using Microsoft.AspNetCore.Builder;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable once CheckNamespace
namespace CodeJam2018.PlatformApi
{
    public static class ServiceInitializer
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IPlatformService, PlatformService>();
            services.AddSingleton<IPlatformRepo, PlatformRepo>();
            services.AddSingleton<IErrorCreator, ErrorCreator>();
            BindAppSettings(services, configuration);
        }

        public static void Configure(IApplicationBuilder app, IConfiguration configuration)
        {
        }

        public static void BindAppSettings(IServiceCollection services, IConfiguration configuration)
        {
            //IConfiguration configuration = container.GetInstance<IConfiguration>();
            var appSettings = configuration.GetSection("AppSettings").Get<PlatformDalConfig>();
            services.AddSingleton<PlatformDalConfig>(appSettings);
        }
    }
}