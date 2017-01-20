using System.Collections.Generic;
using ProjectFirma.Web.UnitTestCommon;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.Shared.ProjectControls
{
    //[TestFixture]
    //public class EditProjectViewModelValidatorTest
    //{
    //    private EditProjectViewModel _viewModel;
    //    private Models.Project _project;

    //    [SetUp]
    //    public void Setup()
    //    {
    //        _project = TestFramework.TestProject.Create();
    //        _project.ProjectName = "TestProjectName777";
    //        _project.ProjectID = -999999;
    //        var projects = new List<Models.Project> {_project};
    //        _viewModel = new EditProjectViewModel(_project, false);
    //    }

    //    [Test]
    //    public void ShouldHaveErrorWhenProjectNameIsNullOrWhiteSpaceOrInvalidLength()
    //    {
    //        _viewModel.ShouldHaveValidationErrorFor(person => person.ProjectName, null as string);
    //        _viewModel.ShouldHaveValidationErrorFor(person => person.ProjectName, string.Empty);
    //        _viewModel.ShouldHaveValidationErrorFor(person => person.ProjectName, TestFramework.MakeTestNameLongerThan("Random Text", Models.Project.FieldLengths.ProjectName));
    //    }

    //    [Test]
    //    public void ShouldNotHaveErrorWhenProjectNameIsSpecified()
    //    {
    //        _viewModel.ShouldNotHaveValidationErrorFor(person => person.ProjectName, TestFramework.MakeTestName("Random Text", Models.Project.FieldLengths.ProjectName));
    //    }

    //    [Test]
    //    public void ShouldHaveErrorWhenProjectDescriptionIsNullOrWhiteSpaceOrInvalidLength()
    //    {
    //        _viewModel.ShouldHaveValidationErrorFor(person => person.ProjectDescription, string.Empty);
    //        //            _viewModel.ShouldHaveValidationErrorFor(person => person.ProjectDescription, TestFramework.MakeTestNameLongerThan("Random Text", Models.Project.FieldLengths.ProjectDescription));
    //    }

    //    [Test]
    //    public void ShouldNotHaveErrorWhenProjectDescriptionIsSpecified()
    //    {
    //        _viewModel.ShouldNotHaveValidationErrorFor(person => person.ProjectDescription, TestFramework.MakeTestName("Random Text", Models.Project.FieldLengths.ProjectDescription));
    //    }

    //    [Test]
    //    public void ProjectYearRangesTest()
    //    {
    //        _viewModel.ShouldNotHaveValidationErrorFor(person => person.ImplementationStartYear, null as int?);
    //        _viewModel.ShouldNotHaveValidationErrorFor(person => person.CompletionYear, null as int?);

    //        var project = TestFramework.TestProject.Create();
    //        project.CompletionYear = 2007;
    //        var viewModel = new EditProjectViewModel(project, false);
    //        _viewModel.ShouldNotHaveValidationErrorFor(person => person.CompletionYear, viewModel);

    //        viewModel.ImplementationStartYear = 2010;
    //        _viewModel.ShouldHaveValidationErrorFor(person => person.CompletionYear, viewModel);

    //        viewModel.ImplementationStartYear = 2007;
    //        _viewModel.ShouldNotHaveValidationErrorFor(person => person.CompletionYear, viewModel);
    //    }

    //    [Test]
    //    public void ShouldHaveErrorWhenNameExistsAndProjectIDNotTheSame()
    //    {
    //        var project = TestFramework.TestProject.Create();
    //        project.ProjectName = _project.ProjectName;
    //        project.ProjectID = _project.ProjectID + 1;
    //        var viewModel = new EditProjectViewModel(project, false);
    //        _viewModel.ShouldHaveValidationErrorFor(person => person.ProjectName, viewModel);
    //    }

    //    [Test]
    //    public void ShouldNotHaveErrorWhenNameDifferent()
    //    {
    //        var project = TestFramework.TestProject.Create();
    //        project.ProjectName = "TestProjectName677";
    //        var viewModel = new EditProjectViewModel(project, false);
    //        _viewModel.ShouldNotHaveValidationErrorFor(person => person.ProjectName, viewModel);
    //    }

    //    [Test]
    //    public void ShouldNotHaveErrorWhenNameExistsAndProjectIDTheSame()
    //    {
    //        var project = TestFramework.TestProject.Create();
    //        project.ProjectName = _project.ProjectName;
    //        project.ProjectID = _project.ProjectID;
    //        var viewModel = new EditProjectViewModel(project, false);
    //        _viewModel.ShouldNotHaveValidationErrorFor(person => person.ProjectName, viewModel);
    //    }
    //}
}