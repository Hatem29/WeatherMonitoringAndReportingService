﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService.WeatherBots
{
    public class SunBot : IWeatherBot, IWeatherObserver
    {
        public WeatherBotConfigurationBase BotConfiguration = new WeatherBotConfiguration();
        WeatherInfo currentWeather = new WeatherInfo();
        public bool isActivated()
        {
            if (currentWeather.Tempreture > BotConfiguration.TemperatureThreshold)
                return true;
            return false;
        }

        public void OnBotActivation()
        {
            Console.WriteLine(currentWeather.Message);
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
