using LunchAndLearnAzureFunctionApp.Extensions;
using LunchAndLearnAzureFunctionApp.Models;
using LunchAndLearnAzureFunctionApp.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

//https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection
[assembly: FunctionsStartup(typeof(LunchAndLearnAzureFunctionApp.Startup))]
namespace LunchAndLearnAzureFunctionApp
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var services = builder.Services;
            //var sp = services.BuildServiceProvider();  --why not here?
            var config = services.BuildServiceProvider().GetService<IConfiguration>();

            services.AddOptions<AppSettings>().Bind(config.GetSection("AppSettings"));
            services.AddOptions<AustralianFootballSettings>().Bind(config.GetSection("AustralianFootballSettings"));
            services.AddOptions<CanadianFootballSettings>().Bind(config.GetSection("CanadianFootballSettings"));
            services.AddOptions<NorthAmericanFootballSettings>().Bind(config.GetSection("NorthAmericanFootballSettings"));
            services.AddOptions<XflFootballSettings>().Bind(config.GetSection("XflFootballSettings"));

            var sp = services.BuildServiceProvider();
            sp.GetService<IOptions<AppSettings>>().Value.Validate();

            services
                .AddFootballRepositories()
                .AddFootballServices()

                .AddSingleton<IHealthCheckService, HealthCheckService>();
        }
    }
}
