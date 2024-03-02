using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace GithubMonitor
{
    public class GithubMonitor
    {
        private readonly ILogger _logger;

        public GithubMonitor(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GithubMonitor>();
        }

        [Function("GithubMonitor")]
        public HttpResponseData Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post")] 
            HttpRequestData request)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = request.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
