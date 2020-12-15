using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

namespace LunchAndLearnAzureFunctionApp
{
    public class HealthCheckTimer : IHealthCheck
    {
        [FunctionName("HealthCheck")]
        public async Task Run([TimerTrigger("%HealthCheckTimerCron%")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var healthCheckResult = await CheckHealthAsync(new HealthCheckContext());

            log.LogInformation($"HealthCheck Result: {healthCheckResult.Status}");
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(HealthCheckResult.Healthy());
        }
    }
}
