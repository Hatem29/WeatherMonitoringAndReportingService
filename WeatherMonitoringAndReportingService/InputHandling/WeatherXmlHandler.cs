using System;
using System.IO;
using System.Xml.Serialization;

namespace WeatherMonitoringAndReportingService
{
    public class WeatherXmlHandler : IWeatherDataHandler
    {
        public WeatherInfo GetWeatherInfo(string data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(WeatherInfo));

            WeatherInfo weatherInfo;
            using (StringReader stringReader = new StringReader(data))
            {
                weatherInfo = (WeatherInfo)serializer.Deserialize(stringReader);
            }

            return weatherInfo;
        }
    }
}
