using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionApp4
{
    public class MyApiEndpoint
    {
        private readonly ILogger<MyApiEndpoint> _logger;

        public MyApiEndpoint(ILogger<MyApiEndpoint> logger)
        {
            _logger = logger;
        }

        [Function("throw-error")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            throw new Exception("my error");
        }

        [Function("log-error")]
        public IActionResult LogError([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var ex = new Exception();

            _logger.LogError(ex, "My error {message}", "message");

            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
