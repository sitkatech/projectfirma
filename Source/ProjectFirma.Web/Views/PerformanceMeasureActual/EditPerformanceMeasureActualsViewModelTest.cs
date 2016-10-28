using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.UnitTestCommon;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.PerformanceMeasureActual
{
    [TestFixture]
    public class EditPerformanceMeasureActualsViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var performanceMeasure1 = TestFramework.TestPerformanceMeasure.Create();
            var performanceMeasure2 = TestFramework.TestPerformanceMeasure.Create();
            var performanceMeasure3 = TestFramework.TestPerformanceMeasure.Create();
            var performanceMeasure4 = TestFramework.TestPerformanceMeasure.Create();

            var project = TestFramework.TestProject.Create();
            TestFramework.TestPerformanceMeasureActual.Create(project, performanceMeasure1);
            TestFramework.TestPerformanceMeasureActual.Create(project, performanceMeasure2);
            TestFramework.TestPerformanceMeasureActual.Create(project, performanceMeasure3);
            TestFramework.TestPerformanceMeasureActual.Create(project, performanceMeasure4);

            var allperformanceMeasures = new List<Models.PerformanceMeasure> {performanceMeasure1, performanceMeasure2, performanceMeasure3, performanceMeasure4};

            // Act
            var viewModel = new EditPerformanceMeasureActualsViewModel(project.PerformanceMeasureActuals.Select(x => new PerformanceMeasureActualSimple(x)).ToList(), "Test Explanation", null);

            // Assert
            Assert.That(viewModel.PerformanceMeasureActuals.Select(x => x.PerformanceMeasureID), Is.EquivalentTo(allperformanceMeasures.Select(x => x.PerformanceMeasureID)));
        }
    }
}