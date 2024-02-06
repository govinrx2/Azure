namespace CosmosCRUD.Models;

public class Recommendation
{
    public string RecommendationID {get;set;} = Guid.NewGuid().ToString();
    public string Type {get;set;} = "Recommendation";
}