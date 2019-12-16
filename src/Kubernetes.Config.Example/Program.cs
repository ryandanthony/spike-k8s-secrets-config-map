using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Kubernetes.Config.Example
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureHostConfiguration(configHost =>
                {
                    configHost.SetBasePath(Directory.GetCurrentDirectory());
                    configHost.AddEnvironmentVariables(prefix: "TEST_");
                    configHost.AddKeyPerFile(directoryPath: "/test/secrets", optional: true);
                    configHost.AddKeyPerFile(directoryPath: "/test/config", optional: true);
                })
                .ConfigureLogging((hostContext, configLogging) =>
                {
                    //if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    //{
                        configLogging.AddConsole();
                    //}
                })
                .ConfigureServices((hostContext, services) =>
                {
                    //Setup an environment variable "MYENVVAR" with some value
                    var env = hostContext.Configuration["MYENVVAR"];
                    Console.WriteLine($"MYENVVAR:{env}");
                    //In Windows, create file: c:/test/secrets/MYSECRETVAR and put a value in it
                    var secret = hostContext.Configuration["MYSECRETVAR"];
                    Console.WriteLine($"MYSECRETVAR:{secret}");
                    //In Windows, create file: c:/test/config/MYCONFIGVAR and put a value in it
                    var config = hostContext.Configuration["MYCONFIGVAR"];
                    Console.WriteLine($"MYCONFIGVAR:{config}");
                })
                .Build();

            await host.RunAsync();
        }
    }
}
