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

using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Classification
{
    public class DetailViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.Classification Classification { get; }
        public string EditClassificationUrl { get; }
        public string IndexUrl { get; }
        public bool UserHasClassificationManagePermissions { get; }

        public BasicProjectInfoGridSpec BasicProjectInfoGridSpec { get; }
        public string BasicProjectInfoGridName { get; }
        public string BasicProjectInfoGridDataUrl { get; }

        public string ClassificationDisplayName { get; }
        public string ClassificationDisplayNamePluralized { get; }

        public DetailViewData(Person currentPerson, ProjectFirmaModels.Models.Classification classification)
            : base(currentPerson)
        {
            Classification = classification;
            PageTitle = ClassificationSystemModelExtensions.GetClassificationSystemNamePluralized(classification.ClassificationSystem);
            EditClassificationUrl = SitkaRoute<ClassificationController>.BuildUrlFromExpression(c => c.Edit(classification));
            IndexUrl = SitkaRoute<ProgramInfoController>.BuildUrlFromExpression(c => c.ClassificationSystem(classification.ClassificationSystem));

            UserHasClassificationManagePermissions = new PerformanceMeasureManageFeature().HasPermissionByPerson(currentPerson);
            ClassificationDisplayNamePluralized = ClassificationSystemModelExtensions.GetClassificationSystemNamePluralized(classification.ClassificationSystem);
            ClassificationDisplayName = classification.ClassificationSystem.ClassificationSystemName;

            BasicProjectInfoGridName = "geospatialAreaProjectListGrid";
            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(CurrentPerson, false)
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} associated with the {ClassificationDisplayName} {classification.GetDisplayName()}",
                ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} associated with the {ClassificationDisplayName} {classification.GetDisplayName()}",
                SaveFiltersInCookie = true
            };

            BasicProjectInfoGridDataUrl = SitkaRoute<ClassificationController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(classification));
        }
    }
}
