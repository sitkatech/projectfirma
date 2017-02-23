/*-----------------------------------------------------------------------
<copyright file="FundingSourceCalendarYearExpenditureTest.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.Collections.Generic;
using System.Linq;
using ApprovalTests.Reporters;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.UnitTestCommon;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.Project
{
    [TestFixture]
    public class FundingSourceCalendarYearExpenditureTest
    {
        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void CreateFromFundingSourcesAndCalendarYearsTest()
        {
            // Arrange
            var fundingSource1 = TestFramework.TestFundingSource.Create();
            fundingSource1.FundingSourceName = "Funding Source 1";
            var fundingSource2 = TestFramework.TestFundingSource.Create();
            fundingSource2.FundingSourceName = "Funding Source 2";
            var fundingSource3 = TestFramework.TestFundingSource.Create();
            fundingSource3.FundingSourceName = "Funding Source 3";
            var fundingSource4 = TestFramework.TestFundingSource.Create();
            fundingSource4.FundingSourceName = "Funding Source 4";
            var calendarYears = new List<int> {2010, 2011, 2012, 2013, 2014};
            var fundingSources = new List<Models.FundingSource> {fundingSource1, fundingSource2, fundingSource3, fundingSource4};

            var project = TestFramework.TestProject.Create();

            var projectFundingSourceExpenditure1 = TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource1, 2010, 1000);
            var projectFundingSourceExpenditure2 = TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource1, 2011, 2000);
            var projectFundingSourceExpenditure3 = TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource2, 2012, 3000);
            var projectFundingSourceExpenditure4 = TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource3, 2014, 4000);
            var projectFundingSourceExpenditure5 = TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource4, 2012, 5000);

            var projectFundingSourceExpenditures = new List<Models.ProjectFundingSourceExpenditure>
            {
                projectFundingSourceExpenditure1,
                projectFundingSourceExpenditure2,
                projectFundingSourceExpenditure3,
                projectFundingSourceExpenditure4,
                projectFundingSourceExpenditure5
            };

            // Act
            var result = FundingSourceCalendarYearExpenditure.CreateFromFundingSourcesAndCalendarYears(new List<IFundingSourceExpenditure>(projectFundingSourceExpenditures), calendarYears);

            // Assert
            Assert.That(result.Count, Is.EqualTo(fundingSources.Count));
            ObjectApproval.ObjectApprover.VerifyWithJson(result.Select(x => new {x.FundingSourceName, x.CalendarYearExpenditure}));
        }
    }
}
