namespace CosmosCRUD.Models;

public class Product
{
    public required string SkuId { get; set; } = Guid.NewGuid().ToString();
    public required string AssetKey { get; set; }
    public required string Type { get; set; } = "Product_Asset";
    public required string ProductKey { get; set; }
    public required string ProductName { get; set; }
    public required string ProductDescription { get; set; }
    public required string ProductPrice { get; set; }
    public required string FullfilledBy { get; set; }
}