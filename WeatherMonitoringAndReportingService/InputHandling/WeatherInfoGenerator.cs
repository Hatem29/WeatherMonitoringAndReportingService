using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService
{
    public class WeatherInfoGenerator
    {
        public WeatherInfoGenerator(string rawData)
        {
           RawData = rawData;
        }

        public string RawData { get; set; }
        IWeatherDataHandler weatherDataHandler;

        public WeatherInfo GenerateWetherInfo()
        {
            if(RawData[0] == '<')
            {
                weatherDataHandler = new WeatherXmlHandler();
            }
            else if(RawData[0] == '{' || RawData[0] == '[')
            {
                weatherDataHandler = new WeatherJsonHandler();
            }

            WeatherInfo weatherInfo = weatherDataHandler.GetWeatherInfo(RawData);

            return weatherInfo;
        }
        
    }
}
