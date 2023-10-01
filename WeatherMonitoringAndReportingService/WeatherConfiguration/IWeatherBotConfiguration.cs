using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService
{
    public interface IWeatherBotConfiguration
    { 
        bool Enabled { get; set; }
        int HumidityThreshold { get; set; }
        int TemperatureThreshold { get; set; }
        string Message { get; set; }
    }
}
