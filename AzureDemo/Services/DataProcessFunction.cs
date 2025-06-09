using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

public static class DataProcessFunction
{
    [FunctionName("DataProcess")]
    public static async Task Run(
        [QueueTrigger("datainput-queue", Connection = "AzureWebJobsStorage")] string queueItem,
        ILogger log)
    {
        // Deserialize, process, and store in DB or forward to Event Hub
        await dbContext.MyData.AddAsync(data);
        await dbContext.SaveChangesAsync();
    }
}