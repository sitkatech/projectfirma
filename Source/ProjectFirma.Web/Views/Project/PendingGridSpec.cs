/*-----------------------------------------------------------------------
<copyright file="PendingGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using System.Web;

namespace ProjectFirma.Web.Views.Project
{
    public class PendingGridSpec : GridSpec<ProjectFirmaModels.Models.Project>
    {
        public PendingGridSpec(FirmaSession currentFirmaSession)
        {
            // todo: fulfill "Include standard project grid with columns for “Stage” and “Approval Status”
            Add("delete", x => AgGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteProposalUrl(), new ProjectDeleteProposalFeature().HasPermission(currentFirmaSession, x).HasPermission, true), 30, AgGridColumnFilterType.None);
            Add("edit",
                x => AgGridHtmlHelpers.MakeEditIconAsHyperlinkBootstrap(x.GetProjectCreateUrl(),
                    new ProjectCreateFeature().HasPermission(currentFirmaSession, x).HasPermission &&
                    !(x.ProjectApprovalStatus == ProjectApprovalStatus.PendingApproval &&
                      currentFirmaSession.Role == ProjectFirmaModels.Models.Role.Normal)), 30,
                AgGridColumnFilterType.None);
            Add(FieldDefinitionEnum.ProjectName.ToType().ToGridHeaderString(), x => new HtmlLinkObject(x.ProjectName, x.GetDetailUrl()).ToJsonObjectForAgGrid(), 300, AgGridColumnFilterType.HtmlLinkJson);
            Add("Submittal Status", a => a.ProjectApprovalStatus.ProjectApprovalStatusDisplayName, 110, AgGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.ProjectStage.ToType().ToGridHeaderString(), x => x.ProjectStage.GetProjectStageDisplayName(), 90, AgGridColumnFilterType.SelectFilterStrict);
            if (MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
            {
                Add(FieldDefinitionEnum.ProjectsStewardOrganizationRelationshipToProject.ToType().ToGridHeaderString(), x => x.GetCanStewardProjectsOrganization().GetShortNameAsUrlForAgGrid(), 150,
                    AgGridColumnFilterType.HtmlLinkJson);
            }

            if (MultiTenantHelpers.HasSolicitations())
            {
                Add(FieldDefinitionEnum.Solicitation.ToType().ToGridHeaderString(), x => (x.Solicitation != null) ? x.Solicitation.SolicitationName : string.Empty, 100,
                    AgGridColumnFilterType.SelectFilterStrict);
            }

            Add(FieldDefinitionEnum.IsPrimaryContactOrganization.ToType().ToGridHeaderString(), x => x.GetPrimaryContactOrganization().GetShortNameAsUrlForAgGrid(), 150, AgGridColumnFilterType.HtmlLinkJson);
            Add(FieldDefinitionEnum.TaxonomyLeaf.ToType().ToGridHeaderString(), x => x.TaxonomyLeaf == null ? string.Empty : x.TaxonomyLeaf.GetDisplayName(), 300, AgGridColumnFilterType.Text);
            Add(FieldDefinitionEnum.PlanningDesignStartYear.ToType().ToGridHeaderString(), x => ProjectModelExtensions.GetPlanningDesignStartYear(x), 90, AgGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.ImplementationStartYear.ToType().ToGridHeaderString(), x => ProjectModelExtensions.GetImplementationStartYear(x), 115, AgGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.CompletionYear.ToType().ToGridHeaderString(), x => ProjectModelExtensions.GetCompletionYear(x), 90, AgGridColumnFilterType.SelectFilterStrict);
            if (MultiTenantHelpers.ReportFinancialsAtProjectLevel())
            {
                Add(FieldDefinitionEnum.EstimatedTotalCost.ToType().ToGridHeaderString(), x => x.GetEstimatedTotalRegardlessOfFundingType(), 100, AgGridColumnFormatType.Currency, AgGridColumnAggregationType.Total);
                Add(FieldDefinitionEnum.SecuredFunding.ToType().ToGridHeaderString(), x => x.GetSecuredFunding(), 100, AgGridColumnFormatType.Currency, AgGridColumnAggregationType.Total);
                Add(FieldDefinitionEnum.TargetedFunding.ToType().ToGridHeaderString(), x => x.GetTargetedFunding(), 100, AgGridColumnFormatType.Currency, AgGridColumnAggregationType.Total);
                Add(FieldDefinitionEnum.NoFundingSourceIdentified.ToType().ToGridHeaderString(), x => x.GetNoFundingSourceIdentifiedAmount(), 100, AgGridColumnFormatType.Currency, AgGridColumnAggregationType.Total);
                Add(FieldDefinitionEnum.FundingSource.ToType().ToGridHeaderStringPlural(), x => x.GetFundingSourcesAsLinksForAgGrid(false), 300, AgGridColumnFilterType.HtmlLinkListJson);
            }
            Add("Submitted By", a => a.SubmittedByPerson != null ? a.SubmittedByPerson.GetFullNameFirstLastAndOrgShortNameAsUrl(currentFirmaSession) : new HtmlString(null), 200);
            Add("Submitted Date", a => a.SubmissionDate, 120);
            Add("Last Updated", a => a.LastUpdatedDate, 120);
            Add(FieldDefinitionEnum.ProjectDescription.ToType().ToGridHeaderString(), x => x.ProjectDescription, 300);

            if (MultiTenantHelpers.GetTenantAttributeFromCache().ProjectExternalDataSourceEnabled)
            {
                Add("Source of Record", x => x.ExternalID == null ? MultiTenantHelpers.GetTenantShortDisplayName() : MultiTenantHelpers.GetTenantAttributeFromCache().ProjectExternalSourceOfRecordName, 140, AgGridColumnFilterType.SelectFilterStrict);
            }
        }
    }
}
