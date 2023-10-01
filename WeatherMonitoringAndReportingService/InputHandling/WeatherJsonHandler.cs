using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService
{
    public class WeatherJsonHandler : IWeatherDataHandler
    {
        public WeatherInfo GetWeatherInfo(string data)
        {
            WeatherInfo weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(data);
            return weatherInfo;
        }
    }
}
