/*-----------------------------------------------------------------------
<copyright file="ProjectOrganizationsGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Organization
{
    public class ProjectsIncludingLeadImplementingGridSpec : GridSpec<ProjectFirmaModels.Models.Project>
    {
        public ProjectsIncludingLeadImplementingGridSpec(ProjectFirmaModels.Models.Organization organization, FirmaSession currentFirmaSession, bool showSubmittalStatus)
        {
            Add(FieldDefinitionEnum.Project.ToType().ToGridHeaderString(), a => new HtmlLinkObject(a.GetDisplayName(),a.GetDetailUrl()).ToJsonObjectForAgGrid(), 350, AgGridColumnFilterType.HtmlLinkJson);

            if (showSubmittalStatus)
            {
                Add("Submittal Status", a => a.ProjectApprovalStatus.ProjectApprovalStatusDisplayName, 110, AgGridColumnFilterType.SelectFilterStrict);
            }
            

            if (MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
            {
                Add(FieldDefinitionEnum.ProjectsStewardOrganizationRelationshipToProject.ToType().ToGridHeaderString(), x => x.GetCanStewardProjectsOrganization().GetDisplayNameAsUrl(), 150,
                    AgGridColumnFilterType.SelectFilterHtmlStrict);
            }
            Add(FieldDefinitionEnum.IsPrimaryContactOrganization.ToType().ToGridHeaderString(), x => x.GetPrimaryContactOrganization().GetDisplayNameAsUrl(), 150, AgGridColumnFilterType.SelectFilterHtmlStrict);

            Add(FieldDefinitionEnum.ProjectStage.ToType().ToGridHeaderString(), a => a.ProjectStage.GetProjectStageDisplayName(), 90, AgGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.ProjectOrganizationRelationshipType.ToType().ToGridHeaderStringPlural(FieldDefinitionEnum.ProjectOrganizationRelationshipType.ToType().GetFieldDefinitionLabelPluralized()),
                a => string.Join(", ", a.GetAssociatedOrganizationRelationships().Where(x => x.Organization.OrganizationID == organization.OrganizationID).Select(x => x.OrganizationRelationshipTypeName)), 180, AgGridColumnFilterType.Text);

            Add(FieldDefinitionEnum.PlanningDesignStartYear.ToType().ToGridHeaderString(), x => ProjectModelExtensions.GetPlanningDesignStartYear(x), 90, AgGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.ImplementationStartYear.ToType().ToGridHeaderString(), x => ProjectModelExtensions.GetImplementationStartYear(x), 115, AgGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.CompletionYear.ToType().ToGridHeaderString(), x => ProjectModelExtensions.GetCompletionYear(x), 90, AgGridColumnFilterType.SelectFilterStrict);
            Add($"# Of Reported {MultiTenantHelpers.GetPerformanceMeasureName()} Records", x => x.PerformanceMeasureActuals.Count, 100);
            if (MultiTenantHelpers.ReportFinancialsAtProjectLevel())
            {
                Add($"# Of {FieldDefinitionEnum.ReportedExpenditure.ToType().GetFieldDefinitionLabel()} Records", x => x.ProjectFundingSourceExpenditures.Count, 100);
                Add(FieldDefinitionEnum.FundingType.ToType().ToGridHeaderString(), x => x.FundingType?.FundingTypeDisplayName, 300, AgGridColumnFilterType.SelectFilterStrict);
                Add(FieldDefinitionEnum.EstimatedTotalCost.ToType().ToGridHeaderString(), x => x.GetEstimatedTotalRegardlessOfFundingType(), 85, AgGridColumnFormatType.Currency, AgGridColumnAggregationType.Total);
                Add(FieldDefinitionEnum.SecuredFunding.ToType().ToGridHeaderString(), x => x.GetSecuredFunding(), 85, AgGridColumnFormatType.Currency, AgGridColumnAggregationType.Total);
                Add(FieldDefinitionEnum.TargetedFunding.ToType().ToGridHeaderString(), x => x.GetTargetedFunding(), 100, AgGridColumnFormatType.Currency, AgGridColumnAggregationType.Total);
                Add(FieldDefinitionEnum.NoFundingSourceIdentified.ToType().ToGridHeaderString(), x => x.GetNoFundingSourceIdentifiedAmount(), 85, AgGridColumnFormatType.Currency, AgGridColumnAggregationType.Total);
            }
            foreach (var geospatialAreaType in new List<GeospatialAreaType>())
            {
                Add($"{geospatialAreaType.GeospatialAreaTypeNamePluralized}", a => a.GetProjectGeospatialAreaNamesAsHyperlinksForAgGrid(geospatialAreaType), 350, AgGridColumnFilterType.HtmlLinkListJson);
            }
            Add(FieldDefinitionEnum.ProjectDescription.ToType().ToGridHeaderString(), x => x.ProjectDescription, 200);
            if (new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession))
            {
                Add("Tags", x => x.ProjectTags.Select(y => y.Tag).ToList().GetDisplayNamesAsUrlListForAgGrid(), 100, AgGridColumnFilterType.HtmlLinkListJson);
            }
            Add("# of Photos", x => x.ProjectImages.Count, 60);
        }
    }
}
