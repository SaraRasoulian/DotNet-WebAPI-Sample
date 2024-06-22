using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly LoyaltyDBContext _dbContext;
    public UserRepository(LoyaltyDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> GetById(long id)
    {
        return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task SaveChanges()
    {
        await _dbContext.SaveChangesAsync();
    }
}
