using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> Get(long userId);
    Task<User?> Get(string userName, string password);
    User Update(User model);
    Task SaveChanges();
}