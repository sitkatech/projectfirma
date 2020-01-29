/*-----------------------------------------------------------------------
<copyright file="FundingSourcesControllerTest.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
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

using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using NUnit.Framework;
using ProjectFirma.Api.Models;
using ProjectFirmaModels.Models;
using ProjectFirmaModels.UnitTestCommon;

namespace ProjectFirma.Api.Controllers
{
    [TestFixture]
    public class FundingSourcesControllerTest
    {
        private readonly DatabaseEntities _databaseEntities = new DatabaseEntities(Tenant.ActionAgendaForPugetSound.TenantID, "ProjectFirmaDB");

        // These tests are intended to ensure expected API behavior for dependent applications
        // Do make changes to this test to resolve any test failures without assessing the impact to these applications
        // Dependent applications: PS Info
        [Test]
        public void GetProjectCalendarYearBudgetsByFundingSource_ReturnsValidResult()
        {
            var testFundingSource = _databaseEntities.FundingSources.FirstOrDefault(x => x.ProjectFundingSourceBudgets.Count() > 1);
            if (testFundingSource != null)
            {
                var maxSecured = testFundingSource.ProjectFundingSourceBudgets.OrderByDescending(x => x.SecuredAmount).First();
                var minSecured = testFundingSource.ProjectFundingSourceBudgets.OrderBy(x => x.SecuredAmount).First();
                var maxTargeted = testFundingSource.ProjectFundingSourceBudgets.OrderByDescending(x => x.TargetedAmount).First();
                var minTargeted = testFundingSource.ProjectFundingSourceBudgets.OrderBy(x => x.TargetedAmount).First();
                var controller = new FundingSourcesController();
                var result = controller.GetProjectCalendarYearBudgetsByFundingSource(FirmaWebApiConfiguration.PsInfoApiKey, testFundingSource.FundingSourceID) as OkNegotiatedContentResult<List<ProjectBudgetDto>>;
                var maxSecuredResult = result.Content.Single(x => x.ProjectDto.ProjectID == maxSecured.ProjectID);
                Assert.That(maxSecuredResult.SecuredFunding, Is.EqualTo(maxSecured.SecuredAmount));
                var minSecuredResult = result.Content.Single(x => x.ProjectDto.ProjectID == minSecured.ProjectID);
                Assert.That(minSecuredResult.SecuredFunding, Is.EqualTo(minSecured.SecuredAmount));
                var maxTargetedResult = result.Content.Single(x => x.ProjectDto.ProjectID == maxTargeted.ProjectID);
                Assert.That(maxTargetedResult.TargetedFunding, Is.EqualTo(maxTargeted.TargetedAmount));
                var minTargetedResult = result.Content.Single(x => x.ProjectDto.ProjectID == minTargeted.ProjectID);
                Assert.That(minTargetedResult.TargetedFunding, Is.EqualTo(minTargeted.TargetedAmount));
            }
        }

        [Test]
        public void GetProjectCalendarYearExpendituresByFundingSource_ReturnsValidResult()
        {
            var testFundingSource = _databaseEntities.FundingSources.FirstOrDefault(x => x.ProjectFundingSourceExpenditures.Count() > 1);
            if (testFundingSource != null)
            {
                var groupedExpenditures = testFundingSource.ProjectFundingSourceExpenditures.GroupBy(x => x.Project);
                var firstProjectGroup = groupedExpenditures.First();
                var lastProjectGroup = groupedExpenditures.Last();
                var firstTotal = firstProjectGroup.Sum(x => x.ExpenditureAmount);
                var lastTotal = lastProjectGroup.Sum(x => x.ExpenditureAmount);
                var controller = new FundingSourcesController();
                var result = controller.GetProjectCalendarYearExpendituresByFundingSource(FirmaWebApiConfiguration.PsInfoApiKey, testFundingSource.FundingSourceID) as OkNegotiatedContentResult<List<ProjectCalendarYearExpendituresDto>>;
                var firstResultTotal = result.Content.Single(x => x.ProjectDto.ProjectID == firstProjectGroup.Key.ProjectID).CalendarYearExpenditures.Sum(x => x.Value);
                Assert.That(firstResultTotal, Is.EqualTo(firstTotal));
                var lastResultTotal = result.Content.Single(x => x.ProjectDto.ProjectID == lastProjectGroup.Key.ProjectID).CalendarYearExpenditures.Sum(x => x.Value);
                Assert.That(lastResultTotal, Is.EqualTo(lastTotal));
            }
        }
    }
}
