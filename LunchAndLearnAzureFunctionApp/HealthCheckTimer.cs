using System;
using System.Threading.Tasks;
using LunchAndLearnAzureFunctionApp.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

namespace LunchAndLearnAzureFunctionApp
{
    public class HealthCheckTimer
    {
        private readonly IHealthCheckService _healthCheckService;

        public HealthCheckTimer(IHealthCheckService healthCheckService)
        {
            _healthCheckService = healthCheckService;
        }

        //https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-timer?tabs=csharp
        [FunctionName("HealthCheck")]
        public async Task Run([TimerTrigger("%HealthCheckTimerCron%")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var healthCheckResult = await _healthCheckService.CheckHealthAsync(new HealthCheckContext());

            log.LogInformation($"HealthCheck Result: {healthCheckResult.Status}");
        }
    }
}
