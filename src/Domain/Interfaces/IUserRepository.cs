using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetById(long id);
    User Update(User model);
    Task SaveChanges();
}