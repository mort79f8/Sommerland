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

        public void 
    }
}
