using System;
using NUnit.Framework;

namespace LtInfo.Common.Tasks
{
    [TestFixture]
    public class SitkaTaskBaseTest
    {
        [Test]
        public void TestNextRunTimeCalcuations()
        {
            var timeOfDayToRun = TimeSpan.Parse("01:00:00");

            Assert.That(SitkaTaskBase.TimeOfNextRunForDailyRun(DateTime.Parse("01/01/2000 10:00"), DateTime.Parse("01/01/2000 10:00:00"), timeOfDayToRun),
                        Is.EqualTo(DateTime.Parse("01/02/2000 01:00")), "Startup situation in which last run is set = now");

            Assert.That(SitkaTaskBase.TimeOfNextRunForDailyRun(DateTime.Parse("01/02/2000 00:30"), DateTime.Parse("01/01/2000 01:00"), timeOfDayToRun),
                        Is.EqualTo(DateTime.Parse("01/02/2000 01:00")), "Regular run - just before next run");

            Assert.That(SitkaTaskBase.TimeOfNextRunForDailyRun(DateTime.Parse("01/01/2000 12:00"), DateTime.Parse("01/01/2000 01:00"), timeOfDayToRun),
                        Is.EqualTo(DateTime.Parse("01/02/2000 01:00")), "Just after a run");

            Assert.That(SitkaTaskBase.TimeOfNextRunForDailyRun(DateTime.Parse("01/01/2000 12:00"), DateTime.Parse("01/10/2000 01:00"), timeOfDayToRun),
                        Is.EqualTo(DateTime.Parse("01/02/2000 01:00")), "Last run is somehow in the future, should give reasonable answer");

            // Boundary conditions on the time of day
            // --------------------------------------

            var arbitraryDateTime = DateTime.Now;
            var upperLimit = TimeSpan.Parse("23:59:59.99");
            Assert.DoesNotThrow(() => SitkaTaskBase.TimeOfNextRunForDailyRun(arbitraryDateTime, arbitraryDateTime, upperLimit), "Upper limit timespan should be OK");

            var lowerLimit = TimeSpan.Zero;
            Assert.DoesNotThrow(() => SitkaTaskBase.TimeOfNextRunForDailyRun(arbitraryDateTime, arbitraryDateTime, lowerLimit), "Lower limit timespan should be OK");

            var invalidLargerThanTimeOfDay1 = TimeSpan.Parse("24:00:00");
            Assert.Catch(() => SitkaTaskBase.TimeOfNextRunForDailyRun(arbitraryDateTime, arbitraryDateTime, invalidLargerThanTimeOfDay1), "Time of day greater than a day is impossible");

            var invalidLargerThanTimeOfDay2 = TimeSpan.Parse("25:00:00");
            Assert.Catch(() => SitkaTaskBase.TimeOfNextRunForDailyRun(arbitraryDateTime, arbitraryDateTime, invalidLargerThanTimeOfDay2), "Time of day greater than a day is impossible");

            var invalidSmallerThanTimeOfDay = TimeSpan.Parse("-00:00:01");
            Assert.Catch(() => SitkaTaskBase.TimeOfNextRunForDailyRun(arbitraryDateTime, arbitraryDateTime, invalidSmallerThanTimeOfDay), "Negative time of day is impossible");
        }

    }
}