using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using LunchAndLearnAzureFunctionApp.Services;
using System;

namespace LunchAndLearnAzureFunctionApp
{
    public class FootballTeamsLocator
    {
        private readonly IFootballTeamsService _footballTeamsService;

        public FootballTeamsLocator(IFootballTeamsService footballTeamsService)
        {
            _footballTeamsService = footballTeamsService;
        }

        //https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-http-webhook-trigger?tabs=csharp
        [FunctionName("GetFootballNames")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string city = req.Query["city"];

            string responseMessage = string.IsNullOrEmpty(city)
                ? $"This HTTP triggered function executed successfully. Pass a city in the query string for a personalized response. Or claim the Jets..." +
                $"{Environment.NewLine}All NFL Teams:{Environment.NewLine}{string.Join(Environment.NewLine, _footballTeamsService.GetTeamNames())}"
                : $"{city} is home of the: {string.Join(", ", _footballTeamsService.GetTeamNames(city))}.";

            return new OkObjectResult(responseMessage);
        }
    }
}
