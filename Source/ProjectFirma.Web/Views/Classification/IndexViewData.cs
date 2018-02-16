/*-----------------------------------------------------------------------
<copyright file="IndexViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Classification
{
    public class IndexViewData : FirmaViewData
    {
        public readonly List<Models.Classification> Classifications;
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson, ClassificationSystem classificationSystem) : base(currentPerson)
        {
            PageTitle = Models.FieldDefinition.Classification.GetFieldDefinitionLabelPluralized();
            Classifications = classificationSystem.Classifications.ToList();

            GridSpec = new IndexGridSpec(new PerformanceMeasureManageFeature().HasPermissionByPerson(CurrentPerson))
            {
                ObjectNameSingular = classificationSystem.ClassificationSystemName,
                ObjectNamePlural = classificationSystem.ClassificationSystemName,
                SaveFiltersInCookie = true,
                CreateEntityModalDialogForm = new ModalDialogForm(SitkaRoute<ClassificationController>.BuildUrlFromExpression(tc => tc.New(classificationSystem)), $"New {classificationSystem.ClassificationSystemName}"),
            };

            GridName = "classificationsGrid";
            GridDataUrl = SitkaRoute<ClassificationController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData(classificationSystem));
        }
    }
}
