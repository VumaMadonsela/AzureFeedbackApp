using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using System.Text;
using System.Threading.Tasks;

public class EventHubService
{
    private readonly string _connectionString;
    private readonly string _eventHubName;

    public EventHubService(IConfiguration config)
    {
        _connectionString = config["EventHub:ConnectionString"] ?? throw new ArgumentNullException(nameof(_connectionString), "EventHub:ConnectionString is missing in configuration.");
        _eventHubName = config["EventHub:Name"] ?? throw new ArgumentNullException(nameof(_eventHubName), "EventHub:Name is missing in configuration.");
    }

    public async Task SendMessageAsync(string message)
    {
        await using var producer = new EventHubProducerClient(_connectionString, _eventHubName);
        using EventDataBatch eventBatch = await producer.CreateBatchAsync();
        if (!eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes(message))))
        {
            throw new InvalidOperationException("Message is too large for the batch.");
        }
        await producer.SendAsync(eventBatch);
    }
}