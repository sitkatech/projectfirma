/*-----------------------------------------------------------------------
<copyright file="SnapshotProjectGridSpec.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.Snapshot
{
    public class SnapshotProjectGridSpec : GridSpec<Models.SnapshotProject>
    {
        public SnapshotProjectGridSpec()
        {
            Add(string.Empty, x => UrlTemplate.MakeHrefString(x.Project.GetFactSheetUrl(), FirmaDhtmlxGridHtmlHelpers.FactSheetIcon.ToString()), 30);
            Add(Models.FieldDefinition.ProjectName.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.Project.GetDetailUrl(), x.Project.ProjectName), 300, DhtmlxGridColumnFilterType.Html);
            Add("Added/ Updated", x => x.SnapshotProjectType.SnapshotProjectTypeDisplayName, 60, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.LeadImplementer.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.Project.LeadImplementer != null ? x.Project.LeadImplementer.GetDetailUrl() : null, x.Project.LeadImplementerName), 140);
            Add(Models.FieldDefinition.ProjectStage.ToGridHeaderStringWider(), x => x.Project.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.PlanningDesignStartYear.ToGridHeaderString(), x => x.Project.PlanningDesignStartYear, 90, DhtmlxGridColumnFormatType.None);
            Add(Models.FieldDefinition.ImplementationStartYear.ToGridHeaderString(), x => x.Project.ImplementationStartYear, 115, DhtmlxGridColumnFormatType.None);
            Add(Models.FieldDefinition.CompletionYear.ToGridHeaderString(), x => x.Project.CompletionYear, 90, DhtmlxGridColumnFormatType.None);
            Add(Models.FieldDefinition.FundingType.ToGridHeaderString(), x => x.Project.FundingType.FundingTypeShortName, 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.EstimatedTotalCost.ToGridHeaderString(), x => x.Project.EstimatedTotalCost, 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(Models.FieldDefinition.SecuredFunding.ToGridHeaderString(), x => x.Project.SecuredFunding, 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(Models.FieldDefinition.UnfundedNeed.ToGridHeaderString(), x => x.Project.UnfundedNeed, 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(Models.FieldDefinition.Region.ToGridHeaderString(), x => x.Project.ProjectLocationTypeDisplay, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            //Add("State", x => x.Project.ProjectLocationStateProvince, 95, DhtmlxGridColumnFilterType.Text);
            //Add("Jurisdiction", x => x.Project.ProjectLocationJurisdiction, 95, DhtmlxGridColumnFilterType.Text);
            //Add("Watershed", x => x.Project.ProjectLocationWatershed, 95, DhtmlxGridColumnFilterType.Text);
            Add(Models.FieldDefinition.ProjectDescription.ToGridHeaderString(), x => x.Project.ProjectDescription, 300);
        }
    }
}
