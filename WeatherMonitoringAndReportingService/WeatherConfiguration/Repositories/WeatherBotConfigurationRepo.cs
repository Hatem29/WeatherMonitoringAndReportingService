using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService
{
    public class WeatherBotConfigurationRepo : IWeatherBotConfigurationRepo
    {
        public WeatherBotConfigurationRepo()
        {
            FilePath = @"C:\Users\Msi\source\repos\WeatherMonitoringAndReportingService\WeatherMonitoringAndReportingService\Files\BotConfiguration.json";
        }
        public string FilePath { get; set; }

        public string ReadWeatherBotConfiguration()
        {
            string content = File.ReadAllText(FilePath);

            return content;
        }
    }
}
