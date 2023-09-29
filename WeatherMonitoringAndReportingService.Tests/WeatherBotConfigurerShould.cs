using Moq;
using System;
using System.Linq;
using Xunit;

namespace WeatherMonitoringAndReportingService.Tests
{
    public class WeatherBotConfigurerShould
    {
        Mock<IWeatherBot> mockBot;
        Mock<IWeatherBotConfiguration> configuration;
        IWeatherBotConfigurer sut;
        public WeatherBotConfigurerShould()
        {
            mockBot = new Mock<IWeatherBot>();
            configuration = new Mock<IWeatherBotConfiguration>();
            sut = new WeatherBotConfigurer();
        }

        [Fact]
        public void ReturnNullWhenEnabledIsFalse()
        {
            configuration.Setup(x => x.Enabled).Returns(false);

            IWeatherBot weatherBot = sut.ConfigureBot(mockBot.Object, configuration.Object);

            Assert.Null(weatherBot);
        }

        [Fact]
        public void ReturnWeatherBotWhenEnabledIsTrue()
        {
            configuration.Setup(x => x.Enabled).Returns(true);
            Type type = mockBot.Object.GetType();

            IWeatherBot weatherBot = sut.ConfigureBot(mockBot.Object, configuration.Object);

            Assert.IsType(type, weatherBot);
        }

        [Fact]
        public void ShouldSetWeatherBotsWeatherInfoWhenEnabledIsTrue()
        {
            configuration.Setup(x => x.Enabled).Returns(true);

            IWeatherBot weatherBot = sut.ConfigureBot(mockBot.Object, configuration.Object);

            mockBot.Verify(x => x.SetWeatherInfoFromConfiguration(configuration.Object), Times.Once);
        }
    }
}
