using Entities;

namespace Interfaces;

public interface IJwtService
{
    string GenerateJwtToken(User user);
    int GetUserIdFromToken(string token);
}
