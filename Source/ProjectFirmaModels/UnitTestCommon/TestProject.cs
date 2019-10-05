/*-----------------------------------------------------------------------
<copyright file="TestProject.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirmaModels.Models;
using System;

namespace ProjectFirmaModels.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestProject
        {
            public static Project Create()
            {
                var taxonomyLeaf = TestFramework.TestTaxonomyLeaf.Create();
                var projectStage = ProjectStage.PlanningDesign;

                string testProjectName = $"Test Project Name {Guid.NewGuid()}";
                string testProjectDescription = $"Test Project Description {Guid.NewGuid()}";
                const bool isFeatured = false;
                // Using object rather than ID based constructors. Failure to do this will result in a half-baked object later, where IDs work, but not Object accessors interior to the
                // Project.
                var project = new Project(taxonomyLeaf, projectStage, testProjectName, testProjectDescription, isFeatured, ProjectLocationSimpleType.None, ProjectApprovalStatus.Approved, DateTime.Now);

                return project;
            }
        }
    }
}
