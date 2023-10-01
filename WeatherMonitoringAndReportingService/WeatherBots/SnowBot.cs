using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService
{
    public class SnowBot : IWeatherBot
    {
        public WeatherBotConfigurationBase BotConfiguration = new WeatherBotConfiguration();
        WeatherInfo currentWeather = new WeatherInfo();
        public bool isActivated()
        {
            if (currentWeather.Temperature < BotConfiguration.TemperatureThreshold)
                return true;
            return false;
        }

        public void OnBotActivation()
        {
            Console.WriteLine(BotConfiguration.Message + '\n');
        }

        public void SetWeatherInfoFromConfiguration(WeatherBotConfigurationBase weatherBotConfiguration)
        {
            BotConfiguration = weatherBotConfiguration;
        }

        public void Update(WeatherInfo weatherInfo)
        {
            currentWeather = weatherInfo;
            if (isActivated())
                OnBotActivation();
        }
    }
}
