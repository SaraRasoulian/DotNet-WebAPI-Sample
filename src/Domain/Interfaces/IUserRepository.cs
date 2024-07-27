using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetAsync(long userId);
    Task<User?> GetAsync(string userName, string password);
    Task<User?> GetFromCacheAsync(long userId);
    User Update(User user);
    Task SaveChangesAsync();
}