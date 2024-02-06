namespace CosmosCRUD.Models;

public class User
{
    public required string UserID { get; set; } = Guid.NewGuid().ToString();
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Type { get; set; } = "User";
    public string? LastPageAccessed { get; set; }
    public string? AddressIdCounter { get; set; }
    public string? RecommendationIdCounter { get; set; }
    public string? ShoppingIdCounter { get; set; }
    public string? OrderIdCounter { get; set; }
    public string? CalculatedOutputIdCounter { get; set; }
    public string? ServiceQuestionResponseIdCounter { get; set; }
    public string? ProductQuestionResponseIdCounter { get; set; }
}