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

            services.AddOptions<AppSettings>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("AppSettings").Bind(settings);
                });

            services.AddOptions<AustralianFootballSettings>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("AustralianFootballSettings").Bind(settings);
                });

            services.AddOptions<CanadianFootballSettings>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("CanadianFootballSettings").Bind(settings);
                    var divisions = configuration.GetSection("CanadianFootballSettings:Divisions").Value;
                    settings.Divisions = JsonSerializer.Deserialize<List<FootballDivision>>(divisions);
                });

            services.AddOptions<NorthAmericanFootballSettings>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("NorthAmericanFootballSettings").Bind(settings);
                    var divisions = configuration.GetSection("NorthAmericanFootballSettings:Divisions").Value;
                    settings.Divisions = JsonSerializer.Deserialize<List<FootballDivision>>(divisions);
                });

            services.AddOptions<XflFootballSettings>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("XflFootballSettings").Bind(settings);
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
