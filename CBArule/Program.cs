using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CBArule
{
    //https://andrewlock.net/using-dependency-injection-in-a-net-core-console-application/
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");

            IConfigurationRoot configuration = builder.Build();

            var services = new ServiceCollection()
                           .AddLogging()
                           .AddSingleton<IRulesApplicationService, RulesApplicationService>()
                           .AddSingleton<IFileCleanUpService, FileCleanUpService>()
                           .AddSingleton<IRule, Rule1>()
                           .AddSingleton<IRule, Rule2>()
                           .AddSingleton<IRule, Rule3>()
                           .AddSingleton<IRule, Rule4>();

            services.Configure<Rule1Config>(configuration.GetSection("RulesConfig:Rule1Config"));
            services.Configure<Rule2Config>(configuration.GetSection("RulesConfig:Rule2Config"));
            services.Configure<Rule3Config>(configuration.GetSection("RulesConfig:Rule3Config"));
            services.Configure<Rule4Config>(configuration.GetSection("RulesConfig:Rule4Config"));
            services.Configure<FilePathConfig>(configuration.GetSection("FilePathConfig"));
            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug)
                .AddConsole(LogLevel.Error);

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting application");

            var cleanUpService = serviceProvider.GetService<IFileCleanUpService>();
            var ruleService = serviceProvider.GetService<IRulesApplicationService>();
          

            //CreateWebHostBuilder(args).Build().Run();
            bool endApp = false;
            while (!endApp)
            {
                Console.WriteLine("Enter a String...");
                var str = Console.ReadLine();
                try
                {
                    cleanUpService.FileCleanUp();
                    ruleService.ExecuteRules(str);
                }
                catch(Exception ex)
                {
                    logger.LogError("Exception " + ex.Message + 
                                    "Source " + ex.Source +
                                    "StackTrace " + ex.StackTrace);
                }
                Console.WriteLine("------------------------\n");

                // Wait for the user to respond before closing
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); // Friendly linespacing
            }

            return;

        }

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>();
    }
}
