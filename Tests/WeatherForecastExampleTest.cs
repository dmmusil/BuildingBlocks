using BuildingBlocks;

namespace Tests;

public class WeatherForecastExampleTest
{

    [Test]
    public void Zero_C_is_32_F()
    {
        var sut = new WeatherForecast { TemperatureC = 0 };
        Assert.That(sut.TemperatureF, Is.EqualTo(32));
    }

    [Test]
    public void Boiling_Is_212_F()
    {
        var sut = new WeatherForecast { TemperatureC = 100 };
        Assert.That(sut.TemperatureF, Is.EqualTo(212));
    }
}