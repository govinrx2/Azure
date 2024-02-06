namespace CosmosCRUD.Models;

public class Address
{
    public string AddressID {get;set;} = Guid.NewGuid().ToString();
    public string UserID {get;set;}
    public string Type {get;set;} = "Address";
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string PhoneNumber { get; set; }
    public string UtilityAccountID { get; set; }
}