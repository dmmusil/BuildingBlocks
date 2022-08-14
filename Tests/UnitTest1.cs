using BuildingBlocks;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var sut = new WeatherForecast { TemperatureC = 0 };
            Assert.That(sut.TemperatureF, Is.EqualTo(32));
        }
    }
}