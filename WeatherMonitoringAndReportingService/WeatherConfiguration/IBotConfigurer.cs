using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService
{
    public interface IBotConfigurer
    {
        void ConfiguerBot(bool enabled, double threshold, string message);
    }
}
