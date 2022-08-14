using BuildingBlocks;

namespace Tests;

public class WeatherForecastExampleTest
{

    [Test]
    public void Test1()
    {
        var sut = new WeatherForecast { TemperatureC = 0 };
        Assert.That(sut.TemperatureF, Is.EqualTo(32));
    }
}