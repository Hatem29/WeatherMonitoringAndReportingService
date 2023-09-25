using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService
{
    class Program
    {
        static void Main(string[] args)
        {
            IWeatherBotConfigurationRepo configurationRepo = new WeatherBotConfigurationRepo();
            string configurationData = configurationRepo.ReadWeatherBotConfiguration();

            WeatherBotsGenerator weatherBotsGenerator = new WeatherBotsGenerator();
            List<IWeatherBot> weatherBots = weatherBotsGenerator.GenerateWeatherBotsFromConfiguration(configurationData);

            IWeatherReporter weatherReporter = new WeatherReporter();
            foreach(var bot in weatherBots)
            {
                weatherReporter.Attach(bot);
            }

            weatherService(weatherReporter);
        }

        private static void weatherService(IWeatherReporter weatherReporter)
        {
            int choice;
            do
            {
                Console.WriteLine
                    (
                    "Enter :\n" +
                    "1. To monitor your weather data.\n" +
                    "0. To exit."
                    );

                choice = Int32.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("Enter weather data : ");
                    StringBuilder weatherData = new StringBuilder();

                    string line;
                    while( !string.IsNullOrWhiteSpace(line = Console.ReadLine()) )
                    {
                        weatherData.AppendLine(line);
                    }

                    WeatherInfo weatherInfo = GetWeatherInfoFromData(weatherData.ToString());

                    weatherReporter.Notify(weatherInfo);
                }
                else if (choice == 0)
                    Console.WriteLine("Exiting..");
                else
                    Console.WriteLine("Wrong entry number.");
                
            } while (choice != 0);
        }

        private static WeatherInfo GetWeatherInfoFromData(string weatherData)
        {
            WeatherInfoGenerator weatherInfoGenerator = new WeatherInfoGenerator(weatherData);

            WeatherInfo weatherInfo = weatherInfoGenerator.GenerateWetherInfo();
            return weatherInfo;
        }
    }
}
