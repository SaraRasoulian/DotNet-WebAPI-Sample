using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.DbContexts;

public class LoyaltyDBContext : DbContext
{
    public LoyaltyDBContext(DbContextOptions<LoyaltyDBContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Database Seeding
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                FirstName = "Sara",
                LastName = "Rasoulian",
                UserName = "sara",
                Email = new Email("sara@gmail.com"),
                Password = "123456",
                PointBalance = 0
            });
    }
}