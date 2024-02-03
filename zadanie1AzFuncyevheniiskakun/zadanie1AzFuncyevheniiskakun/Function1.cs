using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace zadanie1AzFuncyevheniiskakun
{
    public class DateToday
    {
        private readonly ILogger _logger;

        public DateToday(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<DateToday>();
        }

        [Function("DateToday")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            DateTime today = DateTime.Today;

            response.WriteString(today.ToString("dd/MM/yyyy"));

            return response;
        }
    }
}
