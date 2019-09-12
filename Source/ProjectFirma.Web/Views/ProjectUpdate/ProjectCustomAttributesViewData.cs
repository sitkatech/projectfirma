/*-----------------------------------------------------------------------
<copyright file="CustomAttributesViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Shared.ProjectControls;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ProjectCustomAttributesViewData : ProjectUpdateViewData
    {
        public readonly EditProjectCustomAttributesViewData EditCustomAttributesViewData;
        public readonly SectionCommentsViewData SectionCommentsViewData;
        public readonly string RefreshUrl;
        public readonly string DiffUrl;

        public ProjectCustomAttributesViewData(Person currentPerson,
            ProjectUpdateBatch projectUpdateBatch,
            ProjectUpdateStatus projectUpdateStatus,
            List<string> validationWarnings,
            string sectionDisplayName,
            EditProjectCustomAttributesViewData editCustomAttributesViewData) : base(currentPerson, projectUpdateBatch, projectUpdateStatus, validationWarnings, sectionDisplayName)
        {
            EditCustomAttributesViewData = editCustomAttributesViewData;
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdateBatch.CustomAttributesComment, projectUpdateBatch.IsReturned());
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshProjectCustomAttributes(projectUpdateBatch.Project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffProjectCustomAttributes(projectUpdateBatch.Project));
        }

        
    }
}
