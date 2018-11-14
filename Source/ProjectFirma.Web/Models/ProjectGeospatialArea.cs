/*-----------------------------------------------------------------------
<copyright file="ProjectGeospatialArea.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectGeospatialArea : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get
            {
                var project = HttpRequestStorage.DatabaseEntities.AllProjects.Find(ProjectID);
                var geospatialArea = HttpRequestStorage.DatabaseEntities.AllGeospatialAreas.Find(GeospatialAreaID);
                var projectName = project != null ? project.AuditDescriptionString : ViewUtilities.NotFoundString;
                var geospatialAreaName = geospatialArea != null ? geospatialArea.AuditDescriptionString : ViewUtilities.NotFoundString;
                return $"{FieldDefinition.Project.GetFieldDefinitionLabel()}: {projectName}, {FieldDefinition.GeospatialArea.GetFieldDefinitionLabel()}: {geospatialAreaName}";
            }
        }
    }
}
