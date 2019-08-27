/*-----------------------------------------------------------------------
<copyright file="ProjectCustomGridConfigurationSimple.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomGridConfigurationSimple
    {

        public int ProjectCustomGridTypeID { get; set; }
        public int ProjectCustomGridColumnID { get; set; }
        public string ProjectCustomGridColumnName { get; set; }
        public int? ProjectCustomAttributeTypeID { get; set; }
        public string ProjectCustomAttributeTypeName { get; set; }

        public int? GeospatialAreaTypeID { get; set; }
        public string GeospatialAreaTypeName { get; set; }

        public bool IsEnabled { get; set; }
        public bool IsOptional { get; }
        public int? SortOrder { get; set; }

        public ProjectCustomGridConfigurationSimple()
        {
        }

        public ProjectCustomGridConfigurationSimple(int projectCustomGridTypeID, ProjectCustomGridColumn projectCustomGridColumn, ProjectCustomAttributeType projectCustomAttributeType, GeospatialAreaType geospatialAreaType, bool isEnabled, int? sortOrder)
        {
            ProjectCustomGridTypeID = projectCustomGridTypeID;
            ProjectCustomGridColumnID = projectCustomGridColumn.ProjectCustomGridColumnID;
            ProjectCustomGridColumnName = projectCustomGridColumn.ProjectCustomGridColumnDisplayName;
            ProjectCustomAttributeTypeID = projectCustomAttributeType?.ProjectCustomAttributeTypeID;
            ProjectCustomAttributeTypeName = projectCustomAttributeType?.ProjectCustomAttributeTypeName;
            GeospatialAreaTypeID = geospatialAreaType?.GeospatialAreaTypeID;
            GeospatialAreaTypeName = geospatialAreaType?.GeospatialAreaTypeName;
            IsEnabled = !projectCustomGridColumn.IsOptional || isEnabled;
            IsOptional = projectCustomGridColumn.IsOptional;
            SortOrder = sortOrder;
        }
    }
}
