// Example: HttpTrigger Function to ingest data
public static class DataIngestFunction
{
    [FunctionName("DataIngest")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
        [Queue("datainput-queue"), StorageAccount("AzureWebJobsStorage")] IAsyncCollector<string> outputQueue,
        ILogger log)
    {
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        // Validate a process as needed
        await outputQueue.AddAsync(requestBody);
        return new OkResult();
    }
}