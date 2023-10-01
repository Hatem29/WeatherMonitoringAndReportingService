using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherMonitoringAndReportingService
{
    public class WeatherBotsGenerator
    {
        public WeatherBotsGenerator(WeatherBotConfigurer configurer)
        {
            weatherBotConfigurer = configurer;
        }

        public IWeatherBotConfigurer weatherBotConfigurer;
        public List<IWeatherBot> GenerateWeatherBotsFromConfiguration(string ConfigurationData)
        {
            List<IWeatherBot> weatherBots = new List<IWeatherBot>();
            var botsConfig = JsonConvert.DeserializeObject<Dictionary<string, WeatherBotConfiguration>>(ConfigurationData);

            foreach(var config in botsConfig)
            {
                string fullClassName = typeof(IWeatherBot).Namespace + '.' + config.Key;
                IWeatherBot weatherBot = (IWeatherBot)Activator.CreateInstance(Type.GetType(fullClassName));

                IWeatherBotConfiguration weatherBotConfiguration = config.Value;
                weatherBot = weatherBotConfigurer.ConfigureBot(weatherBot, weatherBotConfiguration);

                weatherBots.Add(weatherBot);
            }

            return weatherBots;
        }
    }
}
