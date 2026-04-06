using Contracts;
using Entities;

namespace Interfaces;

public interface IUserService
{
    List<User> GetAll();
    User GetById(int id);
    void Add(User user);
    void Update(int id, User user);
    void Delete(int id);
    AuthenticateResponse Authenticate(string username, string password);
}
