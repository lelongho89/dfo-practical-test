using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace PracticalTestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            new WebHostBuilder()
                .UseUrls("http://*:5000")
                .UseKestrel(k => { k.AddServerHeader = false; })
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIIS()
                .UseStartup<Startup>()
                .ConfigureLogging((hostContext, builder) =>
                {
                    builder.AddConfiguration(hostContext.Configuration.GetSection("logging"));
                })
                .ConfigureAppConfiguration((hostContext, builder) =>
                {
                    builder.Sources.Clear();
                    builder.AddJsonFile("appsettings.json", true, true);
                    builder.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", true);
                    builder.AddEnvironmentVariables();
                    builder.AddCommandLine(args);
                });
    }
}
