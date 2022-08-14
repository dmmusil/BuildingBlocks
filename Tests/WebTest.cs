using BuildingBlocks;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests;

public class WebTest
{
    private HttpClient _client;

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
}