/*-----------------------------------------------------------------------
<copyright file="ProjectStageTest.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using NUnit.Framework;

namespace ProjectFirmaModels.Models
{
    [TestFixture]
    public class ProjectStageTest
    {
        [Test]
        public void IsDeletableTest()
        {
            Assert.That(ProjectStage.All.Where(x => x.IsDeletable()), Is.EquivalentTo(new ProjectStage[] {ProjectStage.Deferred}));
        }

        [Test]
        public void IsCompletedOrTerminatedTest()
        {
            Assert.That(ProjectStage.All.Where(x => x.IsOnCompletedList()), Is.EquivalentTo(new ProjectStage[] {ProjectStage.Completed, ProjectStage.PostImplementation}));
        }
        
        [Test]
        public void RequiresReportedExpendituresTest()
        {
            Assert.That(ProjectStage.All.Where(x => x.RequiresReportedExpenditures()),
                Is.EquivalentTo(new ProjectStage[] {ProjectStage.Implementation, ProjectStage.PlanningDesign, ProjectStage.PostImplementation}));
        }

        [Test]
        public void RequiresPerformanceMeasureActualsTest()
        {
            Assert.That(ProjectStage.All.Where(x => x.RequiresPerformanceMeasureActuals()), Is.EquivalentTo(new ProjectStage[] {ProjectStage.Implementation}));
        }
    }
}
