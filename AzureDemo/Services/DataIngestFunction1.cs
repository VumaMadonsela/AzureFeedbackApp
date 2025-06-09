using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

public static class DataIngestFunction
{
    [FunctionName("DataIngest")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
        [Queue("datainput-queue"), StorageAccount("AzureWebJobsStorage")] IAsyncCollector<string> outputQueue,
        ILogger log)
    {
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        await outputQueue.AddAsync(requestBody);
        return new OkResult();
    }
}