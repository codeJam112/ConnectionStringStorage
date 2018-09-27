using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

// ReSharper disable once CheckNamespace
namespace CodeJam2018.PlatformApi
{
    public class EnvironmentInitializer
    {
        public static IConfiguration Init(IHostingEnvironment hostingEnvironment)
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }
    }
}
