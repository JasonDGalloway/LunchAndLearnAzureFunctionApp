using System.Collections.Generic;
using System.Text.Json;
using LunchAndLearnAzureFunctionApp.Models;
using LunchAndLearnAzureFunctionApp.Repositories;
using LunchAndLearnAzureFunctionApp.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

//https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection
[assembly: FunctionsStartup(typeof(LunchAndLearnAzureFunctionApp.Startup))]
namespace LunchAndLearnAzureFunctionApp
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var services = builder.Services;
            //var config = services.BuildServiceProvider().GetService<IConfiguration>();
            //services.AddOptions<FootballSettings>().Bind(config);
            
            services.AddOptions<FootballSettings>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("FootballSettings").Bind(settings);
                    var leagues = configuration.GetSection("FootballSettings:Leagues").Value;
                    settings.Leagues = JsonSerializer.Deserialize<List<FootballLeagues>>(leagues);
                });
            
            services
                .AddSingleton<IFootballTeamsService, FootballTeamsService>()
                .AddSingleton<IFootballRepository, FootballRepository>()
                .AddSingleton<IHealthCheckService, HealthCheckService>();
        }
    }
}
