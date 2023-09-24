using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService
{
    public class WeatherBotConfiguration : WeatherBotConfigurationBase
    {
        public WeatherBotConfiguration()
        {
            Enabled = false;
            HumidityThreshold = -1;
            TemperatureThreshold = -300;
            Message = "";
        }
    }
}
