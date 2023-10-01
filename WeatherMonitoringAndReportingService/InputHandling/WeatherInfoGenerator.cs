namespace WeatherMonitoringAndReportingService
{
    public class WeatherInfoGenerator
    {
        public WeatherInfoGenerator(string rawData)
        {
            RawData = rawData;
        }

        public string RawData { get; set; }
        public IWeatherDataHandler weatherDataHandler;

        public WeatherInfo GenerateWetherInfo()
        {
            if (RawData[0] == '<')
            {
                weatherDataHandler = new WeatherXmlHandler();
            }
            else if (RawData[0] == '{' || RawData[0] == '[')
            {
                weatherDataHandler = new WeatherJsonHandler();
            }

            WeatherInfo weatherInfo = weatherDataHandler.GetWeatherInfo(RawData);

            return weatherInfo;
        }

    }
}
