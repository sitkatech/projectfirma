using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.UnitTestCommon;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.ProgramPerformanceMeasure
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

            var performanceMeasure = TestFramework.TestPerformanceMeasure.Create();
            TestFramework.TestProgramPerformanceMeasure.Create(program1, performanceMeasure);
            TestFramework.TestProgramPerformanceMeasure.Create(program2, performanceMeasure);
            TestFramework.TestProgramPerformanceMeasure.Create(program3, performanceMeasure);
            TestFramework.TestProgramPerformanceMeasure.Create(program4, performanceMeasure);

            var allPrograms = new List<Models.Program> {program1, program2, program3, program4};

            // Act
            const int primaryProgramID = 1;
            var viewModel = new EditProgramsViewModel(performanceMeasure.ProgramPerformanceMeasures.Select(x => new ProgramPerformanceMeasureSimple(x)).ToList(), primaryProgramID);

            // Assert
            Assert.That(viewModel.ProgramPerformanceMeasures.Select(x => x.ProgramID), Is.EquivalentTo(allPrograms.Select(x => x.ProgramID)));
        }
    }
}