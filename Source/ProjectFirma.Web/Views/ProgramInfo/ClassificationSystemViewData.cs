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
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.SortOrder;

namespace ProjectFirma.Web.Views.ProgramInfo
{
    public class ClassificationSystemViewData : FirmaViewData
    {
        public readonly List<ProjectFirmaModels.Models.Classification> Classifications;
        public readonly ProjectFirmaModels.Models.ClassificationSystem ClassificationSystem;
        public readonly bool ShowEditButton;
        public readonly string EditPageContentUrl;

        public ClassificationSystemViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.ClassificationSystem classificationSystem) : base(currentFirmaSession)
        {
            PageTitle = ClassificationSystemModelExtensions.GetClassificationSystemNamePluralized(classificationSystem);
            Classifications = classificationSystem.Classifications.SortByOrderThenName().ToList();
            ClassificationSystem = classificationSystem;
            ShowEditButton = new FirmaPageManageFeature().HasPermission(currentFirmaSession, null).HasPermission;
            EditPageContentUrl = SitkaRoute<ClassificationSystemController>.BuildUrlFromExpression(t => t.EditInDialog(classificationSystem));
        }
    }
}
