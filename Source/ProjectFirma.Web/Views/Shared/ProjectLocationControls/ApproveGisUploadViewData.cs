/*-----------------------------------------------------------------------
<copyright file="ApproveGisUploadViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Map;

namespace ProjectFirma.Web.Views.Shared.ProjectLocationControls
{
    public class ApproveGisUploadViewData
    {
        public readonly List<IProjectLocationStaging> ProjectLocationStagings;
        public readonly string ApproveGisUploadUrl;
        public readonly MapInitJson MapInitJson;
        public readonly string MapFormID;
        public readonly bool ShowFeatureClassColumn;

        public ApproveGisUploadViewData(List<IProjectLocationStaging> projectLocationStagings, MapInitJson mapInitJson, string mapFormID, string approveGisUploadUrl, bool showFeatureClassColumn)
        {
            ProjectLocationStagings = projectLocationStagings;
            MapInitJson = mapInitJson;
            MapFormID = mapFormID;
            ApproveGisUploadUrl = approveGisUploadUrl;
            ShowFeatureClassColumn = showFeatureClassColumn;
        }
    }
}
