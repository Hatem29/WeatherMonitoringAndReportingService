using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService.WeatherBots
{
    public class RainBot : IWeatherBot, IWeatherObserver
    {
        WeatherInfo currentWeather = new WeatherInfo();
        public bool isActivated()
        {
            throw new NotImplementedException();
        }

        public void OnBotActivation()
        {
            throw new NotImplementedException();
        }

        public void Update(WeatherInfo weatherInfo)
        {
            currentWeather = weatherInfo;
            if (isActivated())
                OnBotActivation();
        }
    }
}
