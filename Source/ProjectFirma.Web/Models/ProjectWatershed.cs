/*-----------------------------------------------------------------------
<copyright file="ProjectWatershed.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
    public partial class ProjectWatershed : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get
            {
                var project = HttpRequestStorage.DatabaseEntities.AllProjects.Find(ProjectID);
                var watershed = HttpRequestStorage.DatabaseEntities.AllWatersheds.Find(WatershedID);
                var projectName = project != null ? project.AuditDescriptionString : ViewUtilities.NotFoundString;
                var watershedName = watershed != null ? watershed.AuditDescriptionString : ViewUtilities.NotFoundString;
                return $"{FieldDefinition.Project.GetFieldDefinitionLabel()}: {projectName}, {FieldDefinition.Watershed.GetFieldDefinitionLabel()}: {watershedName}";
            }
        }
    }
}
