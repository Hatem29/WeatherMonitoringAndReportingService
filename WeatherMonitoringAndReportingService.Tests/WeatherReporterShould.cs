using AutoFixture;
using Moq;
using Xunit;

namespace WeatherMonitoringAndReportingService.Tests
{
    public class WeatherReporterShould
    {
        public WeatherReporterShould()
        {
            sut = new WeatherReporter();
            mockObserver = new Mock<IWeatherObserver>();
        }
        WeatherReporter sut;
        Mock<IWeatherObserver> mockObserver;


        [Fact]
        public void UpdateAllObservers()
        {
            Fixture fixture = new Fixture();
            int numberOfObservers = fixture.Create<int>();

            for (int i = 0; i < numberOfObservers; i++)
            {
                sut.Attach(mockObserver.Object);
            }

            WeatherInfo weatherInfo = fixture.Create<WeatherInfo>();
            sut.Notify(weatherInfo);

            mockObserver.Verify(x => x.Update(weatherInfo), Times.Exactly(numberOfObservers));
        }

        [Fact]
        public void AddObserverToObserversListOnAttachCall()
        {
            sut.WeatherObserversList.Clear();
            sut.Attach(mockObserver.Object);

            Assert.Equal(sut.WeatherObserversList.Count, 1);
        }
    }
}
