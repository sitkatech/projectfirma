using System.Collections.Generic;
using ProjectFirma.Web.UnitTestCommon;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace ProjectFirma.Web.Areas.EIP.Views.ProposedProject
{
    [TestFixture]
    public class BasicsViewModelValidatorTest
    {
        private BasicsViewModelValidator _validator;
        private Models.ProposedProject _proposedProject;

        [SetUp]
        public void Setup()
        {
            _proposedProject = TestFramework.TestProposedProject.Create();
            _proposedProject.ProjectName = "TestProposedProjectName777";
            _proposedProject.ProposedProjectID = -999999;
            var proposedProjects = new List<Models.ProposedProject> {_proposedProject};
            _validator = new BasicsViewModelValidator(proposedProjects);            
        }

        [Test]
        public void ShouldHaveErrorWhenProposedProjectNameIsNullOrWhiteSpaceOrInvalidLength()
        {
            _validator.ShouldHaveValidationErrorFor(model => model.ProjectName, null as string);
            _validator.ShouldHaveValidationErrorFor(model => model.ProjectName, string.Empty);
            _validator.ShouldHaveValidationErrorFor(model => model.ProjectName, TestFramework.MakeTestNameLongerThan("Random Text", Models.ProposedProject.FieldLengths.ProjectName));
        }

        [Test]
        public void ShouldNotHaveErrorWhenProposedProjectNameIsSpecified()
        {
            _validator.ShouldNotHaveValidationErrorFor(model => model.ProjectName, TestFramework.MakeTestName("Random Text", Models.ProposedProject.FieldLengths.ProjectName));
        }

        [Test]
        public void ShouldHaveErrorWhenProposedProjectDescriptionIsNullOrWhiteSpaceOrInvalidLength()
        {
            _validator.ShouldHaveValidationErrorFor(model => model.ProjectDescription, string.Empty);
            //            _validator.ShouldHaveValidationErrorFor(person => person.ProposedProjectDescription, TestFramework.MakeTestNameLongerThan("Random Text", Models.ProposedProject.FieldLengths.ProjectDescription));
        }

        [Test]
        public void ShouldNotHaveErrorWhenProposedProjectDescriptionIsSpecified()
        {
            _validator.ShouldNotHaveValidationErrorFor(model => model.ProjectDescription, TestFramework.MakeTestName("Random Text", Models.ProposedProject.FieldLengths.ProjectDescription));
        }

        [Test]
        public void ProposedProjectYearRangesTest()
        {
            _validator.ShouldHaveValidationErrorFor(model => model.PlanningDesignStartYear, null as int?);
            _validator.ShouldHaveValidationErrorFor(model => model.ImplementationStartYear, null as int?);
            _validator.ShouldNotHaveValidationErrorFor(model => model.CompletionYear, null as int?);

            var proposedProject = TestFramework.TestProposedProject.Create();
            proposedProject.CompletionYear = 2007;
            var viewModel = new BasicsViewModel(proposedProject);
            _validator.ShouldNotHaveValidationErrorFor(model => model.CompletionYear, viewModel);

            viewModel.ImplementationStartYear = 2010;
            _validator.ShouldHaveValidationErrorFor(model => model.CompletionYear, viewModel);

            viewModel.ImplementationStartYear = 2007;
            _validator.ShouldNotHaveValidationErrorFor(model => model.CompletionYear, viewModel);
        }

        [Test]
        public void ShouldHaveErrorWhenNameExistsAndProposedProjectIDNotTheSame()
        {
            var proposedProject = TestFramework.TestProposedProject.Create();
            proposedProject.ProjectName = _proposedProject.ProjectName;
            proposedProject.ProposedProjectID = _proposedProject.ProposedProjectID + 1;
            var viewModel = new BasicsViewModel(proposedProject);
            _validator.ShouldHaveValidationErrorFor(model => model.ProjectName, viewModel);
        }

        [Test]
        public void ShouldNotHaveErrorWhenNameDifferent()
        {
            var proposedProject = TestFramework.TestProposedProject.Create();
            proposedProject.ProjectName = "TestProposedProjectName677";
            var viewModel = new BasicsViewModel(proposedProject);
            _validator.ShouldNotHaveValidationErrorFor(model => model.ProjectName, viewModel);
        }

        [Test]
        public void ShouldNotHaveErrorWhenNameExistsAndProposedProjectIDTheSame()
        {
            var proposedProject = TestFramework.TestProposedProject.Create();
            proposedProject.ProjectName = _proposedProject.ProjectName;
            proposedProject.ProposedProjectID = _proposedProject.ProposedProjectID;
            var viewModel = new BasicsViewModel(proposedProject);
            _validator.ShouldNotHaveValidationErrorFor(model => model.ProjectName, viewModel);
        }
    }
}