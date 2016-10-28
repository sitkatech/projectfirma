using System.Linq;
using NUnit.Framework;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public class ProjectStageTest
    {
        [Test]
        public void IsDeletableTest()
        {
            Assert.That(ProjectStage.All.Where(x => x.IsDeletable()), Is.EquivalentTo(new ProjectStage[] {ProjectStage.Deferred}));
        }

        [Test]
        public void IsOnFiveYearListTest()
        {
            Assert.That(ProjectStage.All.Where(x => x.IsOnFiveYearList()), Is.EquivalentTo(new ProjectStage[] {ProjectStage.PlanningDesign, ProjectStage.Implementation}));
        }

        [Test]
        public void IsCompletedOrTerminatedTest()
        {
            Assert.That(ProjectStage.All.Where(x => x.IsOnCompletedList()), Is.EquivalentTo(new ProjectStage[] {ProjectStage.Completed, ProjectStage.PostImplementation}));
        }

        [Test]
        public void AreExpendituresReportableTest()
        {
            Assert.That(ProjectStage.All.Where(x => x.AreExpendituresReportable()),
                Is.EquivalentTo(new ProjectStage[] {ProjectStage.Completed, ProjectStage.Implementation, ProjectStage.PlanningDesign, ProjectStage.PostImplementation}));
        }

        [Test]
        public void ArePerformanceMeasuresReportableTest()
        {
            Assert.That(ProjectStage.All.Where(x => x.ArePerformanceMeasuresReportable()),
                Is.EquivalentTo(new ProjectStage[] {ProjectStage.Completed, ProjectStage.Implementation, ProjectStage.PostImplementation}));
        }

        [Test]
        public void IsVisibleToEveryoneTest()
        {
            Assert.That(ProjectStage.All.Where(x => x.IsVisibleToEveryone()),
                Is.EquivalentTo(ProjectStage.All));
        }

        [Test]
        public void RequiresReportedExpendituresTest()
        {
            Assert.That(ProjectStage.All.Where(x => x.RequiresReportedExpenditures()),
                Is.EquivalentTo(new ProjectStage[] {ProjectStage.Implementation, ProjectStage.PlanningDesign, ProjectStage.PostImplementation}));
        }

        [Test]
        public void RequiresPerformanceMeasureActualsTest()
        {
            Assert.That(ProjectStage.All.Where(x => x.RequiresPerformanceMeasureActuals()), Is.EquivalentTo(new ProjectStage[] {ProjectStage.Implementation}));
        }
    }
}