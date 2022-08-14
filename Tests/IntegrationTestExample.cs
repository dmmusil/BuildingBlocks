using System.Net.Http.Json;
using BuildingBlocks;
using BuildingBlocks.Users;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests;

public class IntegrationTestExample
{
    private HttpClient _client = null!;

    [SetUp]
    public void Setup()
    {
        var factory = new WebApplicationFactory<Program>();
        _client = factory.CreateClient();
    }

    [Test]
    public async Task Can_call_API()
    {
        var response = await _client.GetAsync("/WeatherForecast");
        Assert.That(response.IsSuccessStatusCode);
    }

    [Test]
    public async Task User_can_register()
    {
        const string name = "dmusil";
        var response = await _client.PostAsync("/users/register", JsonContent.Create(new User(name)));
        Assert.That(response.IsSuccessStatusCode);
        
        response = await _client.GetAsync($"/users/{name}");
        var user = await response.Content.ReadFromJsonAsync<User>();
        Assert.That(name == user.Name);

    }
}