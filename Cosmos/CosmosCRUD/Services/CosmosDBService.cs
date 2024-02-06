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
        _database = _cosmosClient.CreateDatabaseIfNotExistsAsync("Prosumers").Result;
       // _container = _database.CreateContainerIfNotExistsAsync("MasterData", "/MasterData").Result;
    }

    public async Task<Container> GetContainerAsync(string containerName, string partitionKeyPath)
    {
        return await _database.CreateContainerIfNotExistsAsync(containerName, partitionKeyPath);
    }
}