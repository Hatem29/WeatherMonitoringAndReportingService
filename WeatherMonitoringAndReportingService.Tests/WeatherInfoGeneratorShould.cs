using Xunit;
using AutoFixture;
using WeatherMonitoringAndReportingService;
using System;
using Moq;

namespace WeatherMonitoringAndReportingService.Tests
{
    public class WeatherInfoGeneratorShould
    {
        public WeatherInfoGeneratorShould()
        {
            sut = new WeatherInfoGenerator("");
            mochHandler = new Mock<IWeatherDataHandler>();
        }
        WeatherInfoGenerator sut;
        Mock<IWeatherDataHandler> mochHandler;

        [Theory]
        [InlineData(@"{
    ""Location"": ""City Name"",
    ""Temperature"": 23.0,
    ""Humidity"": 85.0
}", typeof(WeatherJsonHandler))]

        [InlineData(@"<WeatherData>
  <Location>City Name</Location>
  <Temperature>23.0</Temperature>
  <Humidity>85.0</Humidity>
</WeatherData>", typeof(WeatherXmlHandler))]
        public void HaveTheRightDataHandlerForTheFormat(string rawData, Type expectedType)
        {
            sut.RawData = rawData;

            var weatherInfo = sut.GenerateWetherInfo();
            var dataHandler = sut.weatherDataHandler;

            Assert.IsAssignableFrom(expectedType, dataHandler);
        }
    }
}
