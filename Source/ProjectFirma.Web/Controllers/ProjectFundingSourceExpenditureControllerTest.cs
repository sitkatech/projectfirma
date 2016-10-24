using System.Collections.Generic;
using System.Linq;
using ApprovalUtilities.Utilities;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.UnitTestCommon;
using NUnit.Framework;

namespace ProjectFirma.Web.Controllers
{
    [TestFixture]
    public class ProjectFundingSourceExpenditureControllerTest
    {
        [Test]
        public void ProjectWithNoExpendituresShouldReturnEmptyDictionary()
        {
            var project = TestFramework.TestProject.Create();
            var projectFundingSourceExpenditures = project.ProjectFundingSourceExpenditures.ToList();
            var rangeOfYears = GetRangeOfYears(projectFundingSourceExpenditures);

            var fullSectorAndYearDictionary = projectFundingSourceExpenditures.GetFullCategoryYearDictionary(x => x.FundingSource.Organization.DisplayName,
                new List<string>(), x => x.FundingSource.Organization.DisplayName, rangeOfYears);

            Assert.That(fullSectorAndYearDictionary, Is.Empty);
        }

        private static List<int> GetRangeOfYears(List<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures)
        {
            if (!projectFundingSourceExpenditures.Any())
                return new List<int>();

            var beginCalendarYear = projectFundingSourceExpenditures.Min(x => x.CalendarYear);
            var endCalendarYear = projectFundingSourceExpenditures.Max(x => x.CalendarYear);
            var rangeOfYears = ProjectFirmaDateUtilities.GetRangeOfYears(beginCalendarYear, endCalendarYear);
            return rangeOfYears;
        }

        [Test]
        public void SimpleProjectSumsCorrectly()
        {
            var project = TestFramework.TestProject.Create();            

            var organization = TestFramework.TestOrganization.Create("test organization 1");
            var fundingSource = TestFramework.TestFundingSource.Create(organization, "test funding source 1");

            TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource, 2010, 100.00m);
            TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource, 2011, 100.00m);
            TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource, 2012, 100.00m);
            TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource, 2013, 100.00m);

            var projectFundingSourceExpenditures = project.ProjectFundingSourceExpenditures.ToList();
            var rangeOfYears = GetRangeOfYears(projectFundingSourceExpenditures);
            var fullSectorAndYearDictionary = projectFundingSourceExpenditures.GetFullCategoryYearDictionary(x => x.FundingSource.Organization.DisplayName,
                new List<string> {"test organization 1"}, x => x.FundingSource.Organization.DisplayName, rangeOfYears);

            Assert.That(fullSectorAndYearDictionary.Sum(x => x.Value.Sum(y => y.Value)), Is.EqualTo(400.00m));
        }

        [Test]
        public void MultipleProjectsSumCorrectly()
        {
            var projectFundingSourceExpenditures = BuildExpenditures("org 1", "funding source 1", new Dictionary<int, decimal> {{2010, 100.0m}, {2011, 200.0m}, {2012, 300.0m}, {2013, 400.0m}});
            projectFundingSourceExpenditures.AddAll(BuildExpenditures("org 2", "funding source 2", new Dictionary<int, decimal> {{2010, 100.0m}, {2011, 200.0m}, {2012, 300.0m}, {2013, 400.0m}}));

            var fullSectorAndYearDictionary = projectFundingSourceExpenditures.GetFullCategoryYearDictionary(x => x.FundingSource.Organization.DisplayName,
                new List<string> {"org 1", "org 2"},
                x => x.FundingSource.Organization.DisplayName,
                GetRangeOfYears(projectFundingSourceExpenditures));

            Assert.That(fullSectorAndYearDictionary.Sum(x => x.Value.Sum(y => y.Value)), Is.EqualTo(2000.0m));
        }

        [Test]
        public void DictionaryBuildsCorrectly()
        {
            var projectFundingSourceExpenditures = BuildExpenditures("org 1", "funding source 1", new Dictionary<int, decimal> 
            {{2010, 100.0m}, {2011, 200.0m}, {2012, 300.0m}, {2013, 400.0m}});

            projectFundingSourceExpenditures.AddAll(BuildExpenditures("org 2", "funding source 2", new Dictionary<int, decimal> 
            {{2010, 100.0m}, {2011, 200.0m}, {2012, 300.0m}, {2013, 400.0m}}));

            var beginCalendarYear = projectFundingSourceExpenditures.Min(x => x.CalendarYear);
            var endCalendarYear = projectFundingSourceExpenditures.Max(x => x.CalendarYear);
            var rangeOfYears = ProjectFirmaDateUtilities.GetRangeOfYears(beginCalendarYear, endCalendarYear);

            var fullSectorAndYearDictionary = projectFundingSourceExpenditures.GetFullCategoryYearDictionary(x => x.FundingSource.Organization.DisplayName,
                new List<string> {"org 1", "org 2"}, x=> x.FundingSource.Organization.DisplayName, rangeOfYears);

            Assert.That(fullSectorAndYearDictionary["org 1"][2012], Is.EqualTo(300.00m));
        }

        [Test]
        public void YearSumsCorrectly()
        {
            var projectFundingSourceExpenditures = BuildExpenditures("org 1", "funding source 1", new Dictionary<int, decimal> 
            {{2010, 100.0m}, {2011, 200.0m}, {2012, 300.0m}, {2013, 400.0m}});

            projectFundingSourceExpenditures.AddAll(BuildExpenditures("org 2", "funding source 2", new Dictionary<int, decimal> 
            {{2010, 100.0m}, {2011, 200.0m}, {2012, 300.0m}, {2013, 400.0m}}));

            var beginCalendarYear = projectFundingSourceExpenditures.Min(x => x.CalendarYear);
            var endCalendarYear = projectFundingSourceExpenditures.Max(x => x.CalendarYear);
            var rangeOfYears = ProjectFirmaDateUtilities.GetRangeOfYears(beginCalendarYear, endCalendarYear);

            var fullSectorAndYearDictionary = projectFundingSourceExpenditures.GetFullCategoryYearDictionary(x => x.FundingSource.Organization.DisplayName,
                new List<string> { "org 1", "org 2" }, x => x.FundingSource.Organization.DisplayName, rangeOfYears);

            Assert.That(fullSectorAndYearDictionary.Sum(x => x.Value[2012]), Is.EqualTo(600.0m));
        }

        [Test]
        public void GroupByOrgSumsCorrectly()
        {
            var projectFundingSourceExpenditures = BuildExpenditures("org 1", "funding source 1", new Dictionary<int, decimal> { { 2010, 100.0m }, { 2011, 200.0m }, { 2012, 300.0m }, { 2013, 400.0m } });

            projectFundingSourceExpenditures.AddAll(BuildExpenditures("org 2", "funding source 2", new Dictionary<int, decimal> { { 2010, 100.0m }, { 2011, 200.0m }, { 2012, 300.0m }, { 2013, 400.0m } }));

            var beginCalendarYear = projectFundingSourceExpenditures.Min(x => x.CalendarYear);
            var endCalendarYear = projectFundingSourceExpenditures.Max(x => x.CalendarYear);
            var rangeOfYears = ProjectFirmaDateUtilities.GetRangeOfYears(beginCalendarYear, endCalendarYear);

            var fullSectorAndYearDictionary = projectFundingSourceExpenditures.GetFullCategoryYearDictionary(x => x.FundingSource.Organization.DisplayName,
                new List<string> { "org 1", "org 2" }, x => x.FundingSource.Organization.DisplayName, rangeOfYears);

            Assert.That(fullSectorAndYearDictionary["org 1"].Sum(x => x.Value), Is.EqualTo(1000.0m));
        }

        [Test]
        public void GroupByFundingSourceSumsCorrectly()
        {
            var projectFundingSourceExpenditures = BuildExpenditures("org 1", "funding source 1", new Dictionary<int, decimal> { { 2010, 100.0m }, { 2011, 100.0m } });
            projectFundingSourceExpenditures.AddAll(BuildExpenditures("org 2", "funding source 2", new Dictionary<int, decimal> { { 2010, 200.0m }, { 2011, 200.0m } }));
            projectFundingSourceExpenditures.AddAll(BuildExpenditures("org 3", "funding source 2", new Dictionary<int, decimal> { { 2010, 200.0m }, { 2011, 200.0m } }));

            var fullSectorAndYearDictionary = projectFundingSourceExpenditures.GetFullCategoryYearDictionary(x => x.FundingSource.FundingSourceName,
                new List<string> { "funding source 1", "funding source 2" }, x => x.FundingSource.Organization.DisplayName, GetRangeOfYears(projectFundingSourceExpenditures));

            Assert.That(fullSectorAndYearDictionary["funding source 2"].Sum(x => x.Value), Is.EqualTo(800.0m));
        }


        [Test]
        public void ExcludedOrgSumsCorrectly()
        {
            var projectFundingSourceExpenditures = BuildExpenditures("org 1", "funding source 1", new Dictionary<int, decimal> 
            { { 2010, 100.0m }, { 2011, 200.0m }, { 2012, 300.0m }, { 2013, 400.0m } });
            projectFundingSourceExpenditures.AddAll(BuildExpenditures("org 2", "funding source 2", new Dictionary<int, decimal> 
            { { 2010, 100.0m }, { 2011, 200.0m }, { 2012, 300.0m }, { 2013, 400.0m } }));

            var fullSectorAndYearDictionary = projectFundingSourceExpenditures.GetFullCategoryYearDictionary(x => x.FundingSource.Organization.DisplayName,
                new List<string> { "org 1" }, x => x.FundingSource.Organization.DisplayName, GetRangeOfYears(projectFundingSourceExpenditures));

            Assert.That(fullSectorAndYearDictionary.ContainsKey("org 2"), Is.False);
            Assert.That(fullSectorAndYearDictionary.Sum(x => x.Value.Sum(y => y.Value)), Is.EqualTo(1000.0m));
        }


        private static List<ProjectFundingSourceExpenditure> BuildExpenditures(string organizationName, string fundingSourceName, Dictionary<int, decimal> yearAndExpenditureDictionary)
        {
            var project = TestFramework.TestProject.Create();
            var organization = TestFramework.TestOrganization.Create(organizationName);
            var fundingSource = TestFramework.TestFundingSource.CreateWithoutChangingName(organization, fundingSourceName);

            return yearAndExpenditureDictionary.Select(x => TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource, x.Key, x.Value)).ToList();

        }
    }
}