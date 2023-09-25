using System.Xml.Serialization;

namespace WeatherMonitoringAndReportingService
{
    [XmlRoot("WeatherData")]
    public class WeatherInfo
    {
        public string Location { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
    }
}