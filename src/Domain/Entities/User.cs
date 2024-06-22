using Domain.ValueObjects;
using Domain.Common;

namespace Domain.Entities;

public record User : EntityBase
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public Email Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public decimal PointBalance { get; set; }    
}