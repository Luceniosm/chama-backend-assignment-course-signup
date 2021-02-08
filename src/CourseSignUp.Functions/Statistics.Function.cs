using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CourseSignUp.Api.Statistics;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CourseSignUp.Functions
{
    public static class Statistics_Function
    {
        [FunctionName("Statistics_Function")]
        public static async Task RunAsync([TimerTrigger("0 0 7 * * *")] TimerInfo myTimer, ILogger log)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var uri = config["courseSignUpApi"];
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var responseBodyAsText = await response.Content.ReadAsStringAsync();
                var statistics =
                    JsonConvert.DeserializeObject<List<CourseStatisticsDto>>(responseBodyAsText);

                SendEmail(statistics);
            }
        }
        private static void SendEmail(List<CourseStatisticsDto> statistics)
        {
            /// send email not implements
        }
    }
}
