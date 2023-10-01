using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService
{
    public interface IWeatherDataHandler
    {
        WeatherInfo GetWeatherInfo(string data);
    }
}
