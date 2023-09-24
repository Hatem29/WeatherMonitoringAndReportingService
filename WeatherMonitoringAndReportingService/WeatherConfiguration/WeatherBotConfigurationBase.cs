using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService
{
    public abstract class WeatherBotConfigurationBase
    { 
        public bool Enabled { get; set; }
        public int HumidityThreshold { get; set; }
        public int TemperatureThreshold { get; set; }
        public string Message { get; set; }
    }
}
