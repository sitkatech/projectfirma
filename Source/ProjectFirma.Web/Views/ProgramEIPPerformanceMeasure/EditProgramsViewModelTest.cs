using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.UnitTestCommon;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.ProgramEIPPerformanceMeasure
{
    [TestFixture]
    public class EditProgramsViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var program1 = TestFramework.TestProgram.Create();
            var program2 = TestFramework.TestProgram.Create();
            var program3 = TestFramework.TestProgram.Create();
            var program4 = TestFramework.TestProgram.Create();

            var eipPerformanceMeasure = TestFramework.TestEIPPerformanceMeasure.Create();
            TestFramework.TestProgramEIPPerformanceMeasure.Create(program1, eipPerformanceMeasure);
            TestFramework.TestProgramEIPPerformanceMeasure.Create(program2, eipPerformanceMeasure);
            TestFramework.TestProgramEIPPerformanceMeasure.Create(program3, eipPerformanceMeasure);
            TestFramework.TestProgramEIPPerformanceMeasure.Create(program4, eipPerformanceMeasure);

            var allPrograms = new List<Models.Program> {program1, program2, program3, program4};

            // Act
            const int primaryProgramID = 1;
            var viewModel = new EditProgramsViewModel(eipPerformanceMeasure.ProgramEIPPerformanceMeasures.Select(x => new ProgramEIPPerformanceMeasureSimple(x)).ToList(), primaryProgramID);

            // Assert
            Assert.That(viewModel.ProgramEIPPerformanceMeasures.Select(x => x.ProgramID), Is.EquivalentTo(allPrograms.Select(x => x.ProgramID)));
        }
    }
}