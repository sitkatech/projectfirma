/*-----------------------------------------------------------------------
<copyright file="ProjectCalendarYearExpenditureTest.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
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
using NUnit.Framework;
using ProjectFirmaModels.Models;
using TestFramework = ProjectFirmaModels.UnitTestCommon.TestFramework;

namespace ProjectFirma.Web.Views.Project
{
    [TestFixture]
    public class ProjectCalendarYearExpenditureTest
    {
        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void CreateFromProjectsAndCalendarYearsTest()
        {
            // Arrange
            var project1 = TestFramework.TestProject.Create();
            project1.ProjectName = "Project 1";
            var project2 = TestFramework.TestProject.Create();
            project2.ProjectName = "Project 2";
            var project3 = TestFramework.TestProject.Create();
            project3.ProjectName = "Project 3";
            var project4 = TestFramework.TestProject.Create();
            project4.ProjectName = "Project 4";
            var calendarYears = new List<int> {2010, 2011, 2012, 2013, 2014};
            var projects = new List<ProjectFirmaModels.Models.Project> {project1, project2, project3, project4};

            var fundingSource = TestFramework.TestFundingSource.Create();

            var projectProjectExpenditure1 = TestFramework.TestProjectFundingSourceExpenditure.Create(project1, fundingSource, 2010, 1000);
            var projectProjectExpenditure2 = TestFramework.TestProjectFundingSourceExpenditure.Create(project1, fundingSource, 2011, 2000);
            var projectProjectExpenditure3 = TestFramework.TestProjectFundingSourceExpenditure.Create(project2, fundingSource, 2012, 3000);
            var projectProjectExpenditure4 = TestFramework.TestProjectFundingSourceExpenditure.Create(project3, fundingSource, 2014, 4000);
            var projectProjectExpenditure5 = TestFramework.TestProjectFundingSourceExpenditure.Create(project4, fundingSource, 2012, 5000);

            var projectFundingSourceExpenditures = new List<ProjectFirmaModels.Models.ProjectFundingSourceExpenditure>
            {
                projectProjectExpenditure1,
                projectProjectExpenditure2,
                projectProjectExpenditure3,
                projectProjectExpenditure4,
                projectProjectExpenditure5
            };

            // Act
            var result = ProjectCalendarYearExpenditure.CreateFromProjectsAndCalendarYears(projectFundingSourceExpenditures, calendarYears);

            // Assert
            Assert.That(result.Count, Is.EqualTo(projects.Count));
            ObjectApproval.ObjectApprover.VerifyWithJson(result.Select(x => new {DisplayName = x.Project.GetDisplayName(), x.CalendarYearExpenditure}));
        }
    }
}
