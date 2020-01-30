/*-----------------------------------------------------------------------
<copyright file="ProjectBudgetDtoTest.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using NUnit.Framework;
using ProjectFirmaModels.UnitTestCommon;

namespace ProjectFirma.Api.Models
{
    [TestFixture]
    public class ProjectBudgetDtoTest
    {
        // These tests are intended to ensure expected API behavior for dependent applications
        // Do make changes to this test to resolve any test failures without assessing the impact to these applications
        // Dependent applications: PS Info
        [Test]
        public void CreateFromProjectTest()
        {
            var project = TestFramework.TestProject.Create();
            // Test that values can be nullable
            var dto = new ProjectBudgetDto(project, null, null);
            Assert.That(dto.ProjectDto.ProjectID, Is.EqualTo(project.ProjectID));
            // Test with decimal values 
            var secured = 1001002.27m;
            var targeted = 5004003.88m;
            dto = new ProjectBudgetDto(project, secured, targeted);
            Assert.That(dto.ProjectDto.ProjectID, Is.EqualTo(project.ProjectID));
            Assert.That(dto.SecuredFunding, Is.EqualTo(secured));
            Assert.That(dto.TargetedFunding, Is.EqualTo(targeted));
        }
    }
}
