using WareSync.API.Authentication.Models;

namespace WareSync.API.Repositories.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}