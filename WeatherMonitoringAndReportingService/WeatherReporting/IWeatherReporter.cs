using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService
{
    public interface IWeatherReporter
    {
        void Attach(IWeatherObserver observer);
        void Detach(IWeatherObserver observer);

        void Notify(WeatherInfo weatherInfo);
    }
}
