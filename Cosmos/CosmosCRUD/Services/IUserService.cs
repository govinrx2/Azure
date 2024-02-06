using CosmosCRUD.Models;

namespace CosmosCRUD.Services;
public interface IUserService
{
    User ReadUser(string id);
    User CreateUser(User user);
    User UpdateUser(string userId,User user);
    bool DeleteUser(string id);
}