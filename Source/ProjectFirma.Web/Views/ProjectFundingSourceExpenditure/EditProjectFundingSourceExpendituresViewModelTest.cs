/*-----------------------------------------------------------------------
<copyright file="EditProjectFundingSourceExpendituresViewModelTest.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirmaModels.Models;
using NUnit.Framework;
using ProjectFirma.Web.Models;
using TestFramework = ProjectFirmaModels.UnitTestCommon.TestFramework;

namespace ProjectFirma.Web.Views.ProjectFundingSourceExpenditure
{
    [TestFixture]
    public class EditProjectFundingSourceExpendituresViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var fundingSource1 = TestFramework.TestFundingSource.Create();
            var fundingSource2 = TestFramework.TestFundingSource.Create();
            var fundingSource3 = TestFramework.TestFundingSource.Create();
            var fundingSource4 = TestFramework.TestFundingSource.Create();

            var project = TestFramework.TestProject.Create();
            TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource1);
            TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource2);
            TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource3);
            TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource4);

            var allFundingSources = new List<ProjectFirmaModels.Models.FundingSource> {fundingSource1, fundingSource2, fundingSource3, fundingSource4};

            // Act
            var projectFundingSourceExpenditures = project.ProjectFundingSourceExpenditures.ToList();
            var calendarYearRangeForExpenditures = projectFundingSourceExpenditures.CalculateCalendarYearRangeForExpenditures(project);
            var viewModel = new EditProjectFundingSourceExpendituresViewModel(project, ProjectFundingSourceExpenditureBulk.MakeFromList(projectFundingSourceExpenditures, calendarYearRangeForExpenditures));

            // Assert
            Assert.That(viewModel.ProjectFundingSourceExpenditures.Select(x => x.FundingSourceID), Is.EquivalentTo(allFundingSources.Select(x => x.FundingSourceID)));
        }
    }
}
