/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ProjectCustomGrid;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Classification
{
    public class DetailViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.Classification Classification { get; }
        public string EditClassificationUrl { get; }
        public string IndexUrl { get; }
        public bool UserHasClassificationManagePermissions { get; }

        public ProjectCustomGridSpec ProjectCustomDefaultGridSpec { get; }
        public string ProjectCustomDefaultGridName { get; }
        public string ProjectCustomDefaultGridDataUrl { get; }

        public string ClassificationDisplayName { get; }
        public string ClassificationDisplayNamePluralized { get; }

        public DetailViewData(Person currentPerson, 
                            ProjectFirmaModels.Models.Classification classification,
                            List<ProjectCustomGridConfiguration> projectCustomDefaultGridConfigurations)
                            : base(currentPerson)
        {
            Classification = classification;
            PageTitle = ClassificationSystemModelExtensions.GetClassificationSystemNamePluralized(classification.ClassificationSystem);
            EditClassificationUrl = SitkaRoute<ClassificationController>.BuildUrlFromExpression(c => c.Edit(classification));
            IndexUrl = SitkaRoute<ProgramInfoController>.BuildUrlFromExpression(c => c.ClassificationSystem(classification.ClassificationSystem));

            UserHasClassificationManagePermissions = new FirmaAdminFeature().HasPermissionByPerson(currentPerson);
            ClassificationDisplayNamePluralized = ClassificationSystemModelExtensions.GetClassificationSystemNamePluralized(classification.ClassificationSystem);
            ClassificationDisplayName = classification.ClassificationSystem.ClassificationSystemName;

            ProjectCustomDefaultGridSpec = new ProjectCustomGridSpec(currentPerson, projectCustomDefaultGridConfigurations) { ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}", ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", SaveFiltersInCookie = true };

            ProjectCustomDefaultGridName = "classificationProjectListGrid";
            ProjectCustomDefaultGridDataUrl = SitkaRoute<ProjectCustomGridController>.BuildUrlFromExpression(tc => tc.ClassificationProjectsGridJsonData(classification));
        }
    }
}
