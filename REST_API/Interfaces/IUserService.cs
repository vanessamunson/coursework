using Contracts;
using Entities;

namespace Interfaces;

public interface IUserService
{
    List<User> GetAll();
    User GetById(int id);
    void Add(CreateUserRequest request);
    void Update(int id, User user);
    void DeleteById(int id);
    AuthenticateResponse Authenticate(string username, string password);
}
