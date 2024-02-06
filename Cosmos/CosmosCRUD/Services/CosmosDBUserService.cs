
using Microsoft.Azure.Cosmos;
using CosmosCRUD.Models;
using User = CosmosCRUD.Models.User;
using System.Net;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Linq;

namespace CosmosCRUD.Services;


public class CosmosDBUserService(ILogger<CosmosDBUserService> logger, CosmosDBService cosmosDBService) : IUserService
{
    private readonly ILogger<CosmosDBUserService> _logger = logger;
    private const string _partitionKey = "UserID";
    private const string _containerName = "Prosumers";
    private readonly Container _container = cosmosDBService.GetContainer(_containerName);
    

    public User? ReadUser(string userId)
    {
        // "Select * from u where u.UserID = @userId AND u.Type='User'";
        var userFeed = _container.GetItemLinqQueryable<User>()
                    .Where(u => u.UserID == userId && u.Type == "User")
                    .ToFeedIterator();
        return userFeed.HasMoreResults ? userFeed.ReadNextAsync().Result.FirstOrDefault() : null;

        // return  _container.ReadItemAsync<User>(userId, new PartitionKey(_partitionKey)).Result.Resource;
    }

    // public IList<User> ReadUsers(List<string>  userIds)
    // {
    //     List<(string, PartitionKey)> items = [];
    //     userIds.ForEach(userId => items.Add((userId, new PartitionKey(_partitionKey))));
    //     return  _container.ReadManyItemsAsync<User>(items).Result.Resource.ToList();
    // }

    public User? CreateUser(User user)
    {
        var result = _container.CreateItemAsync(user, new PartitionKey(_partitionKey)).Result;
        return result.StatusCode == HttpStatusCode.Created? result.Resource : null;
    }

    public User? UpdateUser(User user)
    {
        var result = _container.UpsertItemAsync(user, new PartitionKey(_partitionKey)).Result;
        return result.StatusCode == HttpStatusCode.OK 
                    || result.StatusCode == HttpStatusCode.Created? 
                        result.Resource : null;
    }

    public bool DeleteUser(string userId)
    {
        return _container.DeleteItemAsync<User>(userId, new PartitionKey(_partitionKey)).Result.StatusCode == HttpStatusCode.OK;
    }

}

