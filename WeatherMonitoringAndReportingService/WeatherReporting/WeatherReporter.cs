using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService
{
    public class WeatherReporter : IWeatherReporter
    {
        List<IWeatherObserver> WeatherObserversList = new List<IWeatherObserver>();
        public void Attach(IWeatherObserver observer)
        {
            if(observer != null)
                WeatherObserversList.Add(observer);
        }

        public void Detach(IWeatherObserver observer)
        {
            WeatherObserversList.RemoveAll(item => item == observer);
        }

        public void Notify(WeatherInfo weatherInfo)
        {
            foreach(var observer in WeatherObserversList)
            {
                observer.Update(weatherInfo);
            }
        }
    }
}
