/*-----------------------------------------------------------------------
<copyright file="ProjectOrganizationsGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Organization
{
    public class ProjectsIncludingLeadImplementingGridSpec : GridSpec<Models.Project>
    {
        public ProjectsIncludingLeadImplementingGridSpec(Models.Organization organization, Person currentPerson, bool showSubmittalStatus)
        {
            Add(Models.FieldDefinition.Project.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.GetDetailUrl(), a.GetDisplayName()), 350, DhtmlxGridColumnFilterType.Html);

            if (showSubmittalStatus)
            {
                Add("Submittal Status", a => a.ProjectApprovalStatus.ProjectApprovalStatusDisplayName, 110, DhtmlxGridColumnFilterType.SelectFilterStrict);
            }
            

            if (MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
            {
                Add(Models.FieldDefinition.ProjectsStewardOrganizationRelationshipToProject.ToGridHeaderString(), x => x.GetCanStewardProjectsOrganization().GetDisplayNameAsUrl(), 150,
                    DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            }
            Add(Models.FieldDefinition.IsPrimaryContactOrganization.ToGridHeaderString(), x => x.GetPrimaryContactOrganization().GetDisplayNameAsUrl(), 150, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);

            Add(Models.FieldDefinition.ProjectStage.ToGridHeaderString(), a => a.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.ProjectRelationshipType.ToGridHeaderStringPlural(Models.FieldDefinition.ProjectRelationshipType.GetFieldDefinitionLabelPluralized()),
                a => a.AssocatedOrganizationNames(organization), 180, DhtmlxGridColumnFilterType.Text);

            Add(Models.FieldDefinition.PlanningDesignStartYear.ToGridHeaderString(), x => Models.ProjectModelExtensions.GetPlanningDesignStartYear(x), 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.ImplementationStartYear.ToGridHeaderString(), x => Models.ProjectModelExtensions.GetImplementationStartYear(x), 115, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.CompletionYear.ToGridHeaderString(), x => Models.ProjectModelExtensions.GetCompletionYear(x), 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add($"Number Of Reported {MultiTenantHelpers.GetPerformanceMeasureName()} Records", x => x.PerformanceMeasureActuals.Count, 100);
            Add($"Number Of {Models.FieldDefinition.ReportedExpenditure.GetFieldDefinitionLabel()} Records", x => x.ProjectFundingSourceExpenditures.Count, 100);
            Add(Models.FieldDefinition.FundingType.ToGridHeaderString(), x => x.FundingType.GetFundingTypeShortName(), 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.EstimatedTotalCost.ToGridHeaderString(), x => x.EstimatedTotalCost, 85, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(Models.FieldDefinition.SecuredFunding.ToGridHeaderString(), x => x.GetSecuredFunding(), 85, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(Models.FieldDefinition.UnfundedNeed.ToGridHeaderString(), x => x.UnfundedNeed(), 85, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            foreach (var geospatialAreaType in new List<GeospatialAreaType>())
            {
                Add($"{geospatialAreaType.GeospatialAreaTypeNamePluralized}", a => a.GetProjectGeospatialAreaNamesAsHyperlinks(geospatialAreaType), 350, DhtmlxGridColumnFilterType.Html);
            }
            Add(Models.FieldDefinition.ProjectDescription.ToGridHeaderString(), x => x.ProjectDescription, 200);
            if (new FirmaAdminFeature().HasPermissionByPerson(currentPerson))
            {
                Add("Tags", x => new HtmlString(!x.ProjectTags.Any() ? string.Empty : string.Join(", ", x.ProjectTags.Select(pt => pt.Tag.GetDisplayNameAsUrl()))), 100, DhtmlxGridColumnFilterType.Html);
            }
            Add("# of Photos", x => x.ProjectImages.Count, 60);
        }
    }
}
