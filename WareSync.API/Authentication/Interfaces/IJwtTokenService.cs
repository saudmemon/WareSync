using WareSync.API.Authentication.Models;

namespace WareSync.API.Authentication.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(User user);
}