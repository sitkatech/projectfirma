/*-----------------------------------------------------------------------
<copyright file="TestProject.cs" company="Tahoe Regional Planning Agency">
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
using System;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestProject
        {
            public static Project Create()
            {
                var taxonomyTierOne = TestTaxonomyTierOne.Create();
                var projectStage = ProjectStage.PlanningDesign;
                var project = Project.CreateNewBlank(taxonomyTierOne, projectStage, ProjectLocationSimpleType.None, FundingType.Capital);
                return project;
            }

            public static Project Create(DatabaseEntities dbContext)
            {
                var taxonomyTierOne = TestTaxonomyTierOne.Create(dbContext);

                var projectStage = ProjectStage.PlanningDesign;
                var project = new Project(taxonomyTierOne,
                    projectStage,
                    string.Format("Test Project Name {0}", Guid.NewGuid()),
                    MakeTestName("Test Project Description"),
                    false,
                    ProjectLocationSimpleType.None,
                    FundingType.Capital);

                dbContext.AllProjects.Add(project);
                return project;
            }

            public static Project Create(short projectID, string projectName)
            {
                var taxonomyTierOne = TestTaxonomyTierOne.Create();
                var projectStage = ProjectStage.Implementation;
                var project = new Project(taxonomyTierOne, projectStage, projectName, "Some description",  false, ProjectLocationSimpleType.None, FundingType.Capital)
                {
                    ProjectID = projectID
                };
                return project;
            }

            public static Project Insert(DatabaseEntities dbContext)
            {
                var project = Create(dbContext);
                HttpRequestStorage.DatabaseEntities.SaveChanges();
                return project;
            }
        }
    }
}
