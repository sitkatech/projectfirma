using System.Collections.Generic;
using System.Linq;
using ApprovalTests.Reporters;
using ProjectFirma.Web.UnitTestCommon;
using NUnit.Framework;

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
            var projects = new List<Models.Project> {project1, project2, project3, project4};

            var fundingSource = TestFramework.TestFundingSource.Create();

            var projectProjectExpenditure1 = TestFramework.TestProjectFundingSourceExpenditure.Create(project1, fundingSource, 2010, 1000);
            var projectProjectExpenditure2 = TestFramework.TestProjectFundingSourceExpenditure.Create(project1, fundingSource, 2011, 2000);
            var projectProjectExpenditure3 = TestFramework.TestProjectFundingSourceExpenditure.Create(project2, fundingSource, 2012, 3000);
            var projectProjectExpenditure4 = TestFramework.TestProjectFundingSourceExpenditure.Create(project3, fundingSource, 2014, 4000);
            var projectProjectExpenditure5 = TestFramework.TestProjectFundingSourceExpenditure.Create(project4, fundingSource, 2012, 5000);

            var projectFundingSourceExpenditures = new List<Models.ProjectFundingSourceExpenditure>
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
            ObjectApproval.ObjectApprover.VerifyWithJson(result.Select(x => new {x.Project.DisplayName, x.CalendarYearExpenditure}));
        }
    }
}