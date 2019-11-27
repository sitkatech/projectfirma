/*-----------------------------------------------------------------------
<copyright file="EditPerformanceMeasureActualsViewModelTest.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

namespace ProjectFirma.Web.Views.PerformanceMeasureActual
{
    [TestFixture]
    public class EditPerformanceMeasureActualsViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var performanceMeasure1 = TestFramework.TestPerformanceMeasure.Create();
            var performanceMeasure2 = TestFramework.TestPerformanceMeasure.Create();
            var performanceMeasure3 = TestFramework.TestPerformanceMeasure.Create();
            var performanceMeasure4 = TestFramework.TestPerformanceMeasure.Create();

            var project = TestFramework.TestProject.Create();
            TestFramework.TestPerformanceMeasureActual.Create(project, performanceMeasure1, TestFramework.TestPerformanceMeasureReportingPeriod.Create(performanceMeasure1));
            TestFramework.TestPerformanceMeasureActual.Create(project, performanceMeasure2, TestFramework.TestPerformanceMeasureReportingPeriod.Create(performanceMeasure2));
            TestFramework.TestPerformanceMeasureActual.Create(project, performanceMeasure3, TestFramework.TestPerformanceMeasureReportingPeriod.Create(performanceMeasure3));
            TestFramework.TestPerformanceMeasureActual.Create(project, performanceMeasure4, TestFramework.TestPerformanceMeasureReportingPeriod.Create(performanceMeasure4));

            var allperformanceMeasures = new List<ProjectFirmaModels.Models.PerformanceMeasure> {performanceMeasure1, performanceMeasure2, performanceMeasure3, performanceMeasure4};

            // Act
            var viewModel = new EditPerformanceMeasureActualsViewModel(project.PerformanceMeasureActuals.Select(x => new PerformanceMeasureActualSimple(x)).ToList(), "Test Explanation", null);

            // Assert
            Assert.That(viewModel.PerformanceMeasureActuals.Select(x => x.PerformanceMeasureID), Is.EquivalentTo(allperformanceMeasures.Select(x => x.PerformanceMeasureID)));
        }
    }
}
