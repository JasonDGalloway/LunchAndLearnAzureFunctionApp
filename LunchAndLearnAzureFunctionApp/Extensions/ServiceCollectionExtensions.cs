using LunchAndLearnAzureFunctionApp.Models;
using LunchAndLearnAzureFunctionApp.Repositories;
using LunchAndLearnAzureFunctionApp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LunchAndLearnAzureFunctionApp.Extensions
{
    //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.1#register-groups-of-services-with-extension-methods
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFootballRepositories(this IServiceCollection services)
        {
            services
                .AddSingleton<IFootballRepository<AustralianFootballSettings>, AustralianFootballRepository>()
                .AddSingleton<IFootballRepository<CanadianFootballSettings>, CanadianFootballRepository>()
                .AddSingleton<IFootballRepository<NorthAmericanFootballSettings>, NorthAmericanFootballRepository>()
                .AddSingleton<IFootballRepository<XflFootballSettings>, XflFootballRepository>();

            return services;
        }

        public static IServiceCollection AddFootballServices(this IServiceCollection services)
        {
            services
                .AddSingleton<IFootballTeamsService<AustralianFootballSettings>, AustralianFootballTeamsService>()
                .AddSingleton<IFootballTeamsService<CanadianFootballSettings>, CanadianFootballTeamsService>()
                .AddSingleton<IFootballTeamsService<NorthAmericanFootballSettings>, NorthAmericanFootballTeamsService>()
                .AddSingleton<IFootballTeamsService<XflFootballSettings>, XflFootballTeamsService>();

            return services;
        }
        public static IServiceCollection AddNflFootballServices(this IServiceCollection services)
        {
            services
                .AddSingleton<IFootballTeamsService<NorthAmericanFootballSettings>, NorthAmericanFootballTeamsService>();

            return services;
        }

        public static IServiceCollection AddFootballServices<T>(this IServiceCollection services) where T : FootballSettings
        {
            services
                .AddSingleton<IFootballTeamsService<T>>(); //some factory method here

            return services;
        }
    }
}
