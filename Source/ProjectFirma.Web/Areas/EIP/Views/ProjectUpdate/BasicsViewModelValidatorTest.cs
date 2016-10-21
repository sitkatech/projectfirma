using ProjectFirma.Web.UnitTestCommon;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace ProjectFirma.Web.Areas.EIP.Views.ProjectUpdate
{
    [TestFixture]
    public class BasicsViewModelValidatorTest
    {
        private BasicsViewModelValidator _validator;
        private Models.ProjectUpdate _projectUpdate;

        [SetUp]
        public void Setup()
        {
            _projectUpdate = TestFramework.TestProjectUpdate.Create();
            _projectUpdate.ProjectDescription = "TestProjectUpdateDescription777";
            _projectUpdate.ProjectUpdateID = -999999;
            _validator = new BasicsViewModelValidator();
        }

        [Test]
        public void ShouldHaveErrorWhenProjectDescriptionIsNullOrWhiteSpaceOrInvalidLength()
        {
            _validator.ShouldHaveValidationErrorFor(x => x.ProjectDescription, string.Empty);
            //            _validator.ShouldHaveValidationErrorFor(x => x.ProjectDescription, TestFramework.MakeTestNameLongerThan("Random Text", Models.ProjectUpdate.FieldLengths.ProjectDescription));
        }

        [Test]
        public void ShouldNotHaveErrorWhenProjectDescriptionIsSpecified()
        {
            _validator.ShouldNotHaveValidationErrorFor(x => x.ProjectDescription, TestFramework.MakeTestName("Random Text", Models.ProjectUpdate.FieldLengths.ProjectDescription));
        }
    }
}