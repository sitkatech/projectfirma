/*-----------------------------------------------------------------------
<copyright file="TestProjectGeospatialArea.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

namespace ProjectFirmaModels.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestProjectGeospatialArea
        {
            public static ProjectGeospatialArea Create()
            {
                var project = TestProject.Create();
                var geospatialArea = TestGeospatialArea.Create();
                return Create(project, geospatialArea);
            }

            public static ProjectGeospatialArea Create(DatabaseEntities dbContext)
            {
                var project = TestProject.Create(dbContext);
                var geospatialArea = TestGeospatialArea.Create(dbContext);
                return Create(project, geospatialArea);
            }

            public static ProjectGeospatialArea Create(Project project, GeospatialArea geospatialArea)
            {
                var projectGeospatialArea = ProjectGeospatialArea.CreateNewBlank(project, geospatialArea);
                return projectGeospatialArea;
            }
        }
    }
}