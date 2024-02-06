
using Microsoft.Azure.Cosmos;
using CosmosCRUD.Models;
using User = CosmosCRUD.Models.User;
using System.Net;
using System.Collections.Generic;

namespace CosmosCRUD.Services;


public class CosmosDBUserService(ILogger<CosmosDBUserService> logger, CosmosDBService cosmosDBService) : IUserService
{
    private readonly ILogger<CosmosDBUserService> _logger = logger;
    private const string _partitionKey = "UserID";
    private const string _containerName = "Users";
    private readonly Container _container = cosmosDBService.GetContainerAsync(_containerName, _partitionKey).Result;
    

    public User ReadUser(string userId)
    {
        return  _container.ReadItemAsync<User>(userId, new PartitionKey(_partitionKey)).Result.Resource;
    }

    // public IList<User> ReadUsers(List<string>  userIds)
    // {
    //     List<(string, PartitionKey)> items = [];
    //     userIds.ForEach(userId => items.Add((userId, new PartitionKey(_partitionKey))));
    //     return  _container.ReadManyItemsAsync<User>(items).Result.Resource.ToList();
    // }

    public User CreateUser(User user)
    {
        return _container.CreateItemAsync(user, new PartitionKey(_partitionKey)).Result.Resource;
    }

    public User UpdateUser(User user)
    {
        return _container.UpsertItemAsync(user, new PartitionKey(_partitionKey)).Result.Resource;
    }

    public bool DeleteUser(string userId)
    {
        return _container.DeleteItemAsync<User>(userId, new PartitionKey(_partitionKey)).Result.StatusCode == HttpStatusCode.OK;
    }

}

