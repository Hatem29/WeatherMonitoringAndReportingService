using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherMonitoringAndReportingService
{
    public class WeatherBotsGenerator
    {
        public WeatherBotsGenerator()
        {
            configurer = new WeatherBotConfigurer();
        }

        IWeatherBotConfigurer configurer;
        public List<IWeatherBot> GenerateWeatherBotsFromConfiguration(string ConfigurationData)
        {
            List<IWeatherBot> weatherBots = new List<IWeatherBot>();
            var botsConfig = JsonConvert.DeserializeObject<Dictionary<string, WeatherBotConfiguration>>(ConfigurationData);

            foreach(var config in botsConfig)
            {
                string fullClassName = typeof(IWeatherBot).Namespace + '.' + config.Key;
                IWeatherBot weatherBot = (IWeatherBot)Activator.CreateInstance(Type.GetType(fullClassName));

                WeatherBotConfigurationBase weatherBotConfiguration = config.Value;
                weatherBot = configurer.ConfigureBot(weatherBot, weatherBotConfiguration);

                weatherBots.Add(weatherBot);
            }

            return weatherBots;
        }
    }
}
