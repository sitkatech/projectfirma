﻿/*-----------------------------------------------------------------------
<copyright file="ManageTrainingVideosGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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

using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.TrainingVideo
{
    public class ManageTrainingVideosGridSpec : GridSpec<ProjectFirmaModels.Models.TrainingVideo>
    {
        public ManageTrainingVideosGridSpec()
        {
            Add("delete", x => AgGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true, true), 30, AgGridColumnFilterType.None);
            Add("edit", a => AgGridHtmlHelpers.MakeLtInfoEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(SitkaRoute<TrainingVideoController>.BuildUrlFromExpression(t => t.Edit(a)),
                    850, "Edit")),
                30, AgGridColumnFilterType.None);

            Add("Video Title", a => a.VideoName, 250);
            Add("Video Description", a => a.VideoDescription, 300);
            Add(FieldDefinitionEnum.TrainingVideoUploadDate.ToType().ToGridHeaderString(), a => a.VideoUploadDate, 130, AgGridColumnFormatType.DateTime);
            Add(FieldDefinitionEnum.TrainingVideoUrl.ToType().ToGridHeaderString(), a => a.VideoURL, 250);
            Add("Sort Order", a => a.SortOrder, 90, AgGridColumnFormatType.None);  // Most humans ordinarily expect lists to be 1-indexed instead of zero-indexed)
            Add(FieldDefinitionEnum.TrainingVideoViewableBy.ToType().ToGridHeaderString(), a => a.GetViewableRoles(), 200, AgGridColumnFilterType.Html);

        }


    }
}
