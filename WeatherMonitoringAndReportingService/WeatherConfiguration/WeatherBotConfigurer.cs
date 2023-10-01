using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService
{
    public class WeatherBotConfigurer : IWeatherBotConfigurer
    {
        public IWeatherBot ConfigureBot(IWeatherBot weatherBot, WeatherBotConfigurationBase weatherBotConfiguration)
        {
            if (!weatherBotConfiguration.Enabled)
                return null;

            weatherBot.SetWeatherInfoFromConfiguration(weatherBotConfiguration);
            return weatherBot;
        }

    }
}
