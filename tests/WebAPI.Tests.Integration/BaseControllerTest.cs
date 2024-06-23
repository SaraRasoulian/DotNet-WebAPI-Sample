using Application.RequestModels;
using Application.Tests.Integration;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace WebAPI.Tests.Integration;

public class BaseControllerTest : IClassFixture<IntegrationTestWebApplicationFactory>
{
    protected readonly HttpClient _httpClient;

    protected BaseControllerTest(IntegrationTestWebApplicationFactory factory)
    {
        _httpClient = factory.CreateDefaultClient();
    }

    /// <summary>
    /// Authenticate using the one user created by database seed
    /// </summary>
    /// <returns></returns>
    protected async Task AuthenticateAsync()
    {
        LoginRequest loginRequest = new LoginRequest
        (
            UserName: "sara",
            Password: "123456"
        );

        var loginResponse = await _httpClient.PostAsJsonAsync("api/identity/login", loginRequest);
        string token = await loginResponse.Content.ReadAsStringAsync();

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }
}