namespace SociableTests;

using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using Fixtures;

public class WebApiTests
{
    private HttpClient _client;
    #region Boilerplate
    private WebApplicationFactory<Program> _factory;
    [SetUp]
    public void Setup()
    {
        _factory = new SociableTestWebApplicationFactory();
        var opt = new WebApplicationFactoryClientOptions { AllowAutoRedirect = false };
        _client = _factory.CreateClient(opt);
        _client.DefaultRequestHeaders.Accept.Add(new("application/json"));
    }

    [TearDown]
    public void TearDown()
    {
        _factory.Dispose();
        _client.Dispose();
    }
    #endregion
    
    [Test]
    public async Task GetWeatherForecast()
    {
        WeatherForecast[]? result = await _client.GetFromJsonAsync<WeatherForecast[]>("weather-forecast");
        
        var first = result!.First();
        first.TemperatureC.ShouldBeGreaterThanOrEqualTo(-20);
        first.Date.ShouldBeGreaterThan(DateOnly.FromDateTime(DateTime.Now));
    }
}