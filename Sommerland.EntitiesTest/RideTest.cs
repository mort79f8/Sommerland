using Sommerland.Entities;
using System;
using Xunit;

namespace Sommerland.EntitiesTest
{
    public class RideTest
    {
        [Fact]
        public void DaysSinceLastShutdown_ReturnCorrectDaysWithOneBrokenReport()
        {
            //Arrange
            Ride ride = new Ride();
            DateTime reportTime = DateTime.Parse("2019-06-16 10:01:00");
            Report report = new Report() { Status = Status.Broken, ReportTime = reportTime };
            ride.Add(report);
            int expectedDays = (DateTime.Now - reportTime).Days;

            //Act
            int actualDays = ride.DaysSinceLastShutdown();

            //Assert
            Assert.Equal(actualDays, expectedDays);

        }

        [Fact]
        public void DaysSinceLastShutdown_ReturnsCorrectDaysWithMultiBrokenReports()
        {
            //Arrange
            Ride ride = new Ride();
            DateTime reportTime = DateTime.Parse("2019-05-12 10:12:00");
            Report report = new Report() { Status = Status.Broken, ReportTime = reportTime};
            ride.Add(report);
            DateTime reportTime2 = DateTime.Parse("2019-05-13 11:12:00");
            Report report2 = new Report() { Status = Status.Broken, ReportTime = reportTime2 };
            ride.Add(report2);
            DateTime reportTime3 = DateTime.Parse("2019-05-22 01:01:00");
            Report report3 = new Report() { Status = Status.Broken, ReportTime = reportTime3 };
            ride.Add(report3);
            int expectedDays = (DateTime.Now - reportTime3).Days;

            //Act
            int actualDays = ride.DaysSinceLastShutdown();

            //Assert
            Assert.Equal(actualDays, expectedDays);
        }
    }
}
