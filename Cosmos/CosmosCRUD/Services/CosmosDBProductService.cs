using System.Net;
using CosmosCRUD.Models;
using Microsoft.Azure.Cosmos;

namespace CosmosCRUD.Services;

public class CosmosDBProductService(ILogger<CosmosDBProductService> logger, CosmosDBService cosmosDBService) : IProductService
{
    private readonly ILogger<CosmosDBProductService> _logger = logger;
    private const string _partitionKey = "MasterData";
    private const string _containerName = "MasterData";
    private readonly Container _container = cosmosDBService.GetContainerAsync(_containerName, _partitionKey).Result;

    public Product CreateProduct(Product product)
    {
        return _container.CreateItemAsync(product, new PartitionKey(_partitionKey)).Result.Resource;
    }

    public bool DeleteProduct(string sku)
    {
        return _container.DeleteItemAsync<Product>(sku, new PartitionKey(_partitionKey)).Result.StatusCode == HttpStatusCode.OK;
    }

    public Product ReadProduct(string sku)
    {
        return  _container.ReadItemAsync<Product>(sku, new PartitionKey(_partitionKey)).Result.Resource;
    }

    public Product UpdateProduct(Product product)
    {
        return _container.UpsertItemAsync(product, new PartitionKey(_partitionKey)).Result.Resource;
    }
}