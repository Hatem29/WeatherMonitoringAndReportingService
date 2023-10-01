using System.Collections.Generic;
using Xunit;
using Newtonsoft.Json;
using Moq;
using System;
using System.Reflection;

namespace WeatherMonitoringAndReportingService.Tests
{
    public class WeatherBotsGeneratorShould
    {
        public WeatherBotsGeneratorShould()
        {
            configurer = new Mock<WeatherBotConfigurer>();
            sut = new WeatherBotsGenerator(configurer.Object);
        }
        Mock<WeatherBotConfigurer> configurer;
        WeatherBotsGenerator sut;

        [Theory]
        [InlineData(@"{
    ""RainBot"": {
    ""enabled"": true,
    ""humidityThreshold"": 70,
    ""message"": ""It looks like it's about to pour down!""
  }
}")]
        public void ConfigureAllBots(string configurationData)
        {
            var botsConfig = JsonConvert.DeserializeObject<Dictionary<string, WeatherBotConfiguration>>(configurationData);
            List<IWeatherBot> weatherBotsList = sut.GenerateWeatherBotsFromConfiguration(configurationData);

            bool same = true;
            foreach (var weatherBot in weatherBotsList)
            {
                string name = weatherBot.GetType().Name;
                if(!botsConfig.ContainsKey(name))
                {
                    same = false;
                    break;
                }
            }

            Assert.True(same);
        }
    }
}
