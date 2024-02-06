using System.Net;
using CosmosCRUD.Models;
using Microsoft.Azure.Cosmos;

namespace CosmosCRUD.Services;

public class CosmosDBProductService(ILogger<CosmosDBProductService> logger, CosmosDBService cosmosDBService) : IProductService
{
    private readonly ILogger<CosmosDBProductService> _logger = logger;
    private const string _partitionKey = "MasterData";
    private const string _containerName = "Prosumers";
    private readonly Container _container = cosmosDBService.GetContainer(_containerName);

    public Product? CreateProduct(Product product)
    {
        var result = _container.CreateItemAsync(product, new PartitionKey(_partitionKey)).Result;
        return result.StatusCode == HttpStatusCode.Created? result.Resource : null;
    }

    public bool DeleteProduct(string sku)
    {
        return _container.DeleteItemAsync<Product>(sku, new PartitionKey(_partitionKey)).Result.StatusCode == HttpStatusCode.OK;
    }

    public Product? ReadProduct(string sku)
    {
        return _container.GetItemLinqQueryable<Product>()
                    .Where(p =>  p.SkuId== sku && p.Type == "Product_Asset")
                    .FirstOrDefault(); // verify FirstOrDefault is supported

        // return  _container.ReadItemAsync<Product>(sku, new PartitionKey(_partitionKey)).Result.Resource;
    }

    public Product? UpdateProduct(Product product)
    {
        var result = _container.UpsertItemAsync(product, new PartitionKey(_partitionKey)).Result;
        return result.StatusCode == HttpStatusCode.OK 
                    || result.StatusCode == HttpStatusCode.Created? 
                        result.Resource : null;
    }
}