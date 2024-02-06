using Microsoft.Azure.Cosmos;

namespace CosmosCRUD.Services;

public class CosmosDBService
{
    private readonly ILogger<CosmosDBService> _logger;
    private readonly CosmosClient _cosmosClient;
    private readonly Database _database;

    public CosmosDBService(ILogger<CosmosDBService> logger, CosmosClient cosmosClient)
    {
        _logger = logger;
        _cosmosClient = cosmosClient;
        _database = _cosmosClient.GetDatabase("Prosumers");
       // _container = _database.CreateContainerIfNotExistsAsync("MasterData", "/MasterData").Result;
    }

    public Container GetContainer(string containerName)
    {
        return _database.GetContainer(containerName);//.CreateContainerIfNotExistsAsync(containerName, partitionKey);
    }

    // public void ExecuteQuery(string container, string query)
    // {
    //     var queryDefinition = new QueryDefinition(query);
    //     var iterator = GetContainer(container).GetItemQueryIterator<User>(queryDefinition);
    //     while (iterator.HasMoreResults)
    //     {
    //         var response = iterator.ReadNextAsync().Result;
    //     }
    // }
}