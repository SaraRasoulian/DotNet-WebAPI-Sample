using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace Application.Tests.Integration;

public class BaseHandlerTest : IClassFixture<IntegrationTestWebApplicationFactory>
{
    private readonly IServiceScope _serviceScope;
    protected readonly ISender _sender;
    protected BaseHandlerTest(IntegrationTestWebApplicationFactory factory)
    {
        _serviceScope = factory.Services.CreateScope();
        _sender = _serviceScope.ServiceProvider.GetRequiredService<ISender>();
    }
}
