using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.UnitTestCommon;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.EIPPerformanceMeasureActual
{
    [TestFixture]
    public class EditEIPPerformanceMeasureActualsViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var eipPerformanceMeasure1 = TestFramework.TestEIPPerformanceMeasure.Create();
            var eipPerformanceMeasure2 = TestFramework.TestEIPPerformanceMeasure.Create();
            var eipPerformanceMeasure3 = TestFramework.TestEIPPerformanceMeasure.Create();
            var eipPerformanceMeasure4 = TestFramework.TestEIPPerformanceMeasure.Create();

            var project = TestFramework.TestProject.Create();
            TestFramework.TestEIPPerformanceMeasureActual.Create(project, eipPerformanceMeasure1);
            TestFramework.TestEIPPerformanceMeasureActual.Create(project, eipPerformanceMeasure2);
            TestFramework.TestEIPPerformanceMeasureActual.Create(project, eipPerformanceMeasure3);
            TestFramework.TestEIPPerformanceMeasureActual.Create(project, eipPerformanceMeasure4);

            var allEIPPerformanceMeasures = new List<Models.EIPPerformanceMeasure> {eipPerformanceMeasure1, eipPerformanceMeasure2, eipPerformanceMeasure3, eipPerformanceMeasure4};

            // Act
            var viewModel = new EditEIPPerformanceMeasureActualsViewModel(project.EIPPerformanceMeasureActuals.Select(x => new EIPPerformanceMeasureActualSimple(x)).ToList(), "Test Explanation", null);

            // Assert
            Assert.That(viewModel.EIPPerformanceMeasureActuals.Select(x => x.EIPPerformanceMeasureID), Is.EquivalentTo(allEIPPerformanceMeasures.Select(x => x.EIPPerformanceMeasureID)));
        }
    }
}