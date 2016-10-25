using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.UnitTestCommon;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    [TestFixture]
    public class BasicsValidationResultsTest
    {
        [Test]
        public void ProjectUpdateYearRangesTest()
        {
            var projectUpdate = TestFramework.TestProjectUpdate.Create();

            projectUpdate.ProjectStageID = ProjectStage.Completed.ProjectStageID;
            var warningMessages = new BasicsValidationResult(projectUpdate).GetWarningMessages();

            Assert.That(warningMessages.Contains(BasicsValidationResult.PlanningDesignStartYearIsRequired));
            Assert.That(warningMessages.Contains(BasicsValidationResult.ImplementationStartYearIsRequired));
            Assert.That(warningMessages.Contains(BasicsValidationResult.CompletionYearIsRequired));
                                    
            projectUpdate.CompletionYear = 2007;
            warningMessages = new BasicsValidationResult(projectUpdate).GetWarningMessages();

            Assert.That(warningMessages.Contains(BasicsValidationResult.PlanningDesignStartYearIsRequired));
            Assert.That(warningMessages.Contains(BasicsValidationResult.ImplementationStartYearIsRequired));
            Assert.That(!warningMessages.Contains(BasicsValidationResult.CompletionYearIsRequired));

            projectUpdate.ImplementationStartYear = 2010;
            warningMessages = new BasicsValidationResult(projectUpdate).GetWarningMessages();

            Assert.That(warningMessages.Contains(BasicsValidationResult.PlanningDesignStartYearIsRequired));
            Assert.That(!warningMessages.Contains(BasicsValidationResult.ImplementationStartYearIsRequired));
            Assert.That(!warningMessages.Contains(BasicsValidationResult.CompletionYearIsRequired));
            Assert.That(warningMessages.Contains(FirmaValidationMessages.CompletionYearGreaterThanEqualToImplementationStartYear));

            projectUpdate.ImplementationStartYear = 2006;
            warningMessages = new BasicsValidationResult(projectUpdate).GetWarningMessages();            

            Assert.That(!warningMessages.Contains(FirmaValidationMessages.CompletionYearGreaterThanEqualToImplementationStartYear));

            projectUpdate.ProjectStageID = ProjectStage.PlanningDesign.ProjectStageID;
            projectUpdate.PlanningDesignStartYear = 2020;
            warningMessages = new BasicsValidationResult(projectUpdate).GetWarningMessages();

            Assert.That(!warningMessages.Contains(BasicsValidationResult.PlanningDesignStartYearIsRequired));
            Assert.That(warningMessages.Contains(BasicsValidationResult.PlanningDesignStartYearShouldBeLessThanCurrentYear));
            Assert.That(warningMessages.Contains(FirmaValidationMessages.ImplementationStartYearGreaterThanPlanningDesignStartYear));


            projectUpdate.ProjectStageID = ProjectStage.Implementation.ProjectStageID;
            projectUpdate.ImplementationStartYear = 2020;
            warningMessages = new BasicsValidationResult(projectUpdate).GetWarningMessages();

            Assert.That(warningMessages.Contains(BasicsValidationResult.ImplementationStartYearShouldBeLessThanCurrentYear));

            
        }
    }
}