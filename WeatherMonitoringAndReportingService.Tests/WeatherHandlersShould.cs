using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WeatherMonitoringAndReportingService.Tests
{
    public class WeatherHandlersShould
    {
        public WeatherHandlersShould()
        {
            expected = new WeatherInfo();
            expected.Location = "City Name";
            expected.Temperature = 23.0;
            expected.Humidity = 85.0;
        }
        public string data;
        WeatherInfo expected;

        [Fact]
        public void ReturnTheRightWeatherInfoOnJsonFormat()
        {
            data =
            @"{
    ""Location"": ""City Name"",
    ""Temperature"": 23.0,
    ""Humidity"": 85.0
}";

            WeatherJsonHandler sut = new WeatherJsonHandler();
            WeatherInfo actual = sut.GetWeatherInfo(data);

            bool equal = true;
            if (expected.GetType() != actual.GetType())
                equal = false;
            else if (expected.Humidity != actual.Humidity)
                equal = false;
            else if (expected.Temperature != actual.Temperature)
                equal = false;
            else if (expected.Location != actual.Location)
                equal = false;

            Assert.True(equal);
        }
    }
}
