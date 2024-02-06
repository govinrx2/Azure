
using Microsoft.Azure.Cosmos;
using CosmosCRUD.Models;
using User = CosmosCRUD.Models.User;
using System.Net;

namespace CosmosCRUD.Services;


public class CosmosDBUserService: IUserService
{
    private readonly ILogger<CosmosDBUserService> _logger;
    private readonly CosmosClient _cosmosClient;
    private readonly Database _database;
    private readonly Container _container;

    public CosmosDBUserService(ILogger<CosmosDBUserService> logger)
    {
        _logger = logger;
        _cosmosClient = new CosmosClient(
             "Cosmos:Endpoint", 
                "Cosmos:Key");
        _database = _cosmosClient.CreateDatabaseIfNotExistsAsync("Prosumers").Result;
        _container = _database.CreateContainerIfNotExistsAsync("Users", "/UserID").Result;
    }

    public User ReadUser(string userId)
    {
        return  _container.ReadItemAsync<User>(userId, new PartitionKey(userId)).Result.Resource;
    }

    public IList<User> ReadUsers(IList<string>  userIds)
    {
        IReadOnlyList<(string, PartitionKey)> items = [];
        return  _container.ReadManyItemsAsync<User>(items).Result.Resource.ToList();
    }

    public User CreateUser(User user)
    {
        return _container.CreateItemAsync(user, new PartitionKey(user.UserID)).Result.Resource;
    }

    public User UpdateUser(string userId, User user)
    {
        return _container.UpsertItemAsync(user, new PartitionKey(userId)).Result.Resource;
    }

    public bool DeleteUser(string userId)
    {
        return _container.DeleteItemAsync<User>(userId, new PartitionKey(userId)).Result.StatusCode == HttpStatusCode.OK;
    }

}

