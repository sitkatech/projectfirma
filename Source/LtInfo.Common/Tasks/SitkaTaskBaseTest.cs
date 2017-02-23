/*-----------------------------------------------------------------------
<copyright file="SitkaTaskBaseTest.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
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
