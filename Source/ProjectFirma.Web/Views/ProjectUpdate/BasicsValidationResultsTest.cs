/*-----------------------------------------------------------------------
<copyright file="BasicsValidationResultsTest.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
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
