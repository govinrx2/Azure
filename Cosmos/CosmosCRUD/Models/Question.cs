namespace CosmosCRUD.Models;

public class ServiceQuestion
{
    public string QuestionID {get;set;} = Guid.NewGuid().ToString();
    public string AddressID {get;set;}
    public string Type {get;set;} = "Service_Question";
    public IList<Questions> ServiceQuestions { get; set; }
}
public class ProductQuestion
{
    public string QuestionID {get;set;} = Guid.NewGuid().ToString();
    public string AddressID {get;set;}
    public string Type {get;set;} = "Product_Question";
    public IList<Questions> ProductQuestions { get; set; }
}

public class ExistingEquipment
{
    public string EquipmentID {get;set;} = Guid.NewGuid().ToString();
    public string AddressID {get;set;}
    public string Questioner {get;set;} = "Questioner";
    public string Type {get;set;} = "Existing_Equipment";
    public IList<Questions> ExistingEquipmentQuestions { get; set; }
}

public class FuturePlan
{
    public string FuturePlanID {get;set;} = Guid.NewGuid().ToString();
    public string AddressID {get;set;}
    public string Questioner {get;set;} = "Questioner";
    public string Type {get;set;} = "Future_Plan";
    public IList<Questions> FuturePlanQuestions { get; set; }
}
public class Questions
{
   public ProductCategoryKey ProductCategoryKey { get; set; }
}


public class ProductCategoryKey
{
    public string QuestionID { get; set; }
    public string QuestionKey { get; set; }
    public bool IsHeader { get; set; }
    public bool IsEditable { get; set; }
    public bool IsActive { get; set; }
    public string Question { get; set; }
    public string SortOrder { get; set; }
}