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

            //TODO: Code Tip #1 - less lines of code for Bind:
            //var config = services.BuildServiceProvider().GetService<IConfiguration>();
            //services.AddOptions<FootballSettings>().Bind(config);
            
            services.AddOptions<FootballSettings>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("FootballSettings").Bind(settings);
                });

            services.AddOptions<AustralianFootballSettings>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("AustralianFootballSettings").Bind(settings);
                    var leagues = configuration.GetSection("AustralianFootballSettings:Leagues").Value;
                    settings.Leagues = JsonSerializer.Deserialize<List<FootballLeagues>>(leagues);
                });

            services.AddOptions<CanadianFootballSettings>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("CanadianFootballSettings").Bind(settings);
                    var leagues = configuration.GetSection("CanadianFootballSettings:Leagues").Value;
                    settings.Leagues = JsonSerializer.Deserialize<List<FootballLeagues>>(leagues);
                });

            services.AddOptions<NorthAmericanFootballSettings>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("NorthAmericanFootballSettings").Bind(settings);
                    var leagues = configuration.GetSection("NorthAmericanFootballSettings:Leagues").Value;
                    settings.Leagues = JsonSerializer.Deserialize<List<FootballLeagues>>(leagues);
                });

            services.AddOptions<XflFootballSettings>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("XflFootballSettings").Bind(settings);
                    var leagues = configuration.GetSection("XflFootballSettings:Leagues").Value;
                    settings.Leagues = JsonSerializer.Deserialize<List<FootballLeagues>>(leagues);
                });

            //TODO: Code Tip #2 - Service collection extension
            services
                .AddSingleton<IAustralianFootballTeamsService, AustralianFootballTeamsService>()
                .AddSingleton<ICanadianFootballTeamsService, CanadianFootballTeamsService>()
                .AddSingleton<INorthAmericanFootballTeamsService, NorthAmericanFootballTeamsService>()
                .AddSingleton<IXflFootballTeamsService, XflFootballTeamsService>()

                .AddSingleton<IAustralianFootballRepository, AustralianFootballRepository>()
                .AddSingleton<ICanadianFootballRepository, CanadianFootballRepository>()
                .AddSingleton<INorthAmericanFootballRepository, NorthAmericanFootballRepository>()
                .AddSingleton<IXflFootballRepository, XflFootballRepository>()
                
                .AddSingleton<IHealthCheckService, HealthCheckService>();
        }
    }
}
