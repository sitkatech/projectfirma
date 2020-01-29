/*-----------------------------------------------------------------------
<copyright file="ProjectCalendarYearExpendituresDtoTest.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;

namespace ProjectFirma.Api.Models
{
    // These tests are intended to ensure expected API behavior for dependent applications
    // Do make changes to this test to resolve any test failures without assessing the impact to these applications
    // Dependent applications: PS Info
    [TestFixture]
    public class ProjectCalendarYearExpendituresDtoTest
    {
        [Test]
        public void CreateFromProjectTest()
        {
            var project = TestFramework.TestProject.Create();
            var calendarYearExpenditures = new Dictionary<int, decimal?>()
            {
                [2017] = null,
                [2018] = null,
                [2019] = 8758.92m,
                [2020] = 2874.46m
            } ;
            var dto = new ProjectCalendarYearExpendituresDto(project, calendarYearExpenditures);
            Assert.That(dto.ProjectDto.ProjectID, Is.EqualTo(project.ProjectID));
            Assert.That(dto.CalendarYearExpenditures, Is.EqualTo(calendarYearExpenditures));
        }
    }
}
