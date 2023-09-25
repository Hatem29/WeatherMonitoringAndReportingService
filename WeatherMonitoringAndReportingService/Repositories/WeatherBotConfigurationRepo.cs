using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService.Repositories
{
    public class WeatherBotConfigurationRepo : IWeatherBotConfigurationRepo
    {
        public WeatherBotConfigurationRepo()
        {
            FilePath = "...";
        }
        public string FilePath { get; set; }

        public string ReadWeatherBotConfiguration()
        {
            string content = File.ReadAllText(FilePath);

            return content;
        }
    }
}
