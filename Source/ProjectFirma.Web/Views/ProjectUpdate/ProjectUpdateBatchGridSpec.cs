/*-----------------------------------------------------------------------
<copyright file="ProjectUpdateBatchGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System;
using System.Collections.Generic;
using System.Web;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ProjectUpdateBatchGridSpec : GridSpec<ProjectUpdateBatch>
    {
        private DateTime _detailTrackingStartDate = new DateTime(2016, 3, 8);

        public ProjectUpdateBatchGridSpec()
        {
            Add("Date", x => x.LastUpdateDate, 120);
            Add($"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Update Status", x => x.ProjectUpdateState.ProjectUpdateStateDisplayName, 170, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Updated By", x => x.LastUpdatePerson.GetFullNameFirstLastAndOrgShortName(), 350, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add($"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Update Details",
                pub =>
                {
                    if (pub.ProjectUpdateState == ProjectUpdateState.Approved && pub.LastUpdateDate.IsDateOnOrAfter(_detailTrackingStartDate))
                    {
                        var url = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(c => c.ProjectUpdateBatchDiff(pub));
                        return ModalDialogFormHelper.ModalDialogFormLink("diff-link-id",
                            "Show Details",
                            url,
                            $"{Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Update Change Log",
                            1000,
                            "hidden-save-button",
                            string.Empty,
                            "Close",
                            new List<string> { "btn", "btn-xs", "btn-firma" },
                            null,
                            null,
                            null);
                    }
                    else if (pub.ProjectUpdateState == ProjectUpdateState.Approved)
                    {
                        return new HtmlString("Only available for Updates submitted after " + _detailTrackingStartDate.ToShortDateString());
                    }
                    else
                    {
                        return new HtmlString("Not yet submitted");
                    }
                },
                270);
        }
    }
}
