using CosmosCRUD.Models;

namespace CosmosCRUD.Services;
public interface IUserService
{
    User? ReadUser(string id);
    //User ReadUser();
    User? CreateUser(User user);
    User? UpdateUser(User user);
    bool DeleteUser(string id);
}