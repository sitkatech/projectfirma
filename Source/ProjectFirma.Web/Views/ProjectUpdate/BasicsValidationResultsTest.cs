/*-----------------------------------------------------------------------
<copyright file="BasicsValidationResultsTest.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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

using System;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using NUnit.Framework;
using TestFramework = ProjectFirmaModels.UnitTestCommon.TestFramework;

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

            // This should always be the next calendar year, I believe -- SLG 1/2/2020 (writing after this test started crashing)
            int nextCalendarYear = FirmaDateUtilities.CalculateCurrentYearToUseForUpToAllowableInputInReporting() + 1;

            projectUpdate.ProjectStageID = ProjectStage.PlanningDesign.ProjectStageID;
            projectUpdate.PlanningDesignStartYear = nextCalendarYear;
            warningMessages = new BasicsValidationResult(projectUpdate).GetWarningMessages();

            Assert.That(!warningMessages.Contains(BasicsValidationResult.PlanningDesignStartYearIsRequired));
            Assert.That(warningMessages.Contains(BasicsValidationResult.PlanningDesignStartYearShouldBeLessThanCurrentYear));
            Assert.That(warningMessages.Contains(FirmaValidationMessages.ImplementationStartYearGreaterThanPlanningDesignStartYear));


            projectUpdate.ProjectStageID = ProjectStage.Implementation.ProjectStageID;
            projectUpdate.ImplementationStartYear = nextCalendarYear;
            warningMessages = new BasicsValidationResult(projectUpdate).GetWarningMessages();

            Assert.That(warningMessages.Contains(BasicsValidationResult.ImplementationStartYearShouldBeLessThanCurrentYear));

            
        }
    }
}
