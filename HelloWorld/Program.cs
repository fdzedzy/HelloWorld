using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using App.Metrics;
using App.Metrics.AspNetCore;
using App.Metrics.Health;
using App.Metrics.AspNetCore.Health;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseMetrics()
                .ConfigureHealthWithDefaults(
                    builder =>
                    {
                        builder.HealthChecks.AddCheck("Franks Check", () => new ValueTask<HealthCheckResult>(HealthCheckResult.Healthy("App is Running correctly")));
                    })
                .UseHealthEndpoints()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}