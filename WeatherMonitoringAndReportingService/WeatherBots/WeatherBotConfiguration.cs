using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService
{
    public class WeatherBotConfiguration
    {
        public WeatherBotConfiguration()
        {
            Enabled = false;
            HumidityThreshold = 0;
            TemperatureThreshold = 0;
            Message = "";
        }

        public bool Enabled { get; set; }
        public int HumidityThreshold { get; set; }
        public int TemperatureThreshold { get; set; }
        public string Message { get; set; }
    }
}
