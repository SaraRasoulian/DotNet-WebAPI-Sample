using Application.Users.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Users.Handlers.QueryHandlers;

public class LoginQueryHandler : IRequestHandler<LoginQuery, string?>
{
    private readonly IConfiguration _config;
    private readonly IUserRepository _userRepository;
    private readonly ILogger<LoginQueryHandler> _logger;
    public LoginQueryHandler(IUserRepository userRepository, IConfiguration config, ILogger<LoginQueryHandler> logger)
    {
        _userRepository = userRepository;
        _config = config;
        _logger = logger;
    }
    public async Task<string?> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.Get(request.UserName, request.Password);

        if (user is null) return null;

        _logger.LogInformation("User with id {userId} logged in at {now}", user.Id, DateTime.Now);

        return GenerateToken(user);
    }

    private string GenerateToken(User user)
    {
        var issuer = _config["JwtSettings:Issuer"];
        var audience = _config["JwtSettings:Audience"];
        var key = Encoding.ASCII.GetBytes(_config["JwtSettings:Key"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
            new Claim("Id", Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email.Value),
            new Claim(JwtRegisteredClaimNames.Jti,
            Guid.NewGuid().ToString())
         }),
            Expires = DateTime.UtcNow.AddMinutes(10),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha512Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var stringToken = tokenHandler.WriteToken(token);
        return stringToken;
    }
}
