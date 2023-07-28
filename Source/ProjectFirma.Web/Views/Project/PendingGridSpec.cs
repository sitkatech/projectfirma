﻿/*-----------------------------------------------------------------------
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

using System;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Project
{
    public class PendingGridSpec : GridSpec<ProjectFirmaModels.Models.Project>
    {
        public PendingGridSpec(FirmaSession currentFirmaSession)
        {
            // todo: fulfill "Include standard project grid with columns for “Stage” and “Approval Status”
            Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteProposalUrl(), new ProjectDeleteProposalFeature().HasPermission(currentFirmaSession, x).HasPermission, true), 30, DhtmlxGridColumnFilterType.None);
            Add(string.Empty,
                x => DhtmlxGridHtmlHelpers.MakeEditIconAsHyperlinkBootstrap(x.GetProjectCreateUrl(),
                    new ProjectCreateFeature().HasPermission(currentFirmaSession, x).HasPermission &&
                    !(x.ProjectApprovalStatus == ProjectApprovalStatus.PendingApproval &&
                      currentFirmaSession.Role == ProjectFirmaModels.Models.Role.Normal)), 30,
                DhtmlxGridColumnFilterType.None);
            Add(FieldDefinitionEnum.ProjectName.ToType().ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.GetDetailUrl(), x.ProjectName), 300, DhtmlxGridColumnFilterType.Html);
            Add("Submittal Status", a => a.ProjectApprovalStatus.ProjectApprovalStatusDisplayName, 110, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.ProjectStage.ToType().ToGridHeaderString(), x => x.ProjectStage.GetProjectStageDisplayName(), 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            if (MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
            {
                Add(FieldDefinitionEnum.ProjectsStewardOrganizationRelationshipToProject.ToType().ToGridHeaderString(), x => x.GetCanStewardProjectsOrganization().GetShortNameAsUrl(), 150,
                    DhtmlxGridColumnFilterType.Html);
            }

            if (MultiTenantHelpers.HasSolicitations())
            {
                Add(FieldDefinitionEnum.Solicitation.ToType().ToGridHeaderString(), x => (x.Solicitation != null) ? x.Solicitation.SolicitationName : string.Empty, 100,
                    DhtmlxGridColumnFilterType.SelectFilterStrict);
            }

            Add(FieldDefinitionEnum.IsPrimaryContactOrganization.ToType().ToGridHeaderString(), x => x.GetPrimaryContactOrganization().GetShortNameAsUrl(), 150, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.TaxonomyLeaf.ToType().ToGridHeaderString(), x => x.TaxonomyLeaf == null ? string.Empty : x.TaxonomyLeaf.GetDisplayName(), 300, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.PlanningDesignStartYear.ToType().ToGridHeaderString(), x => ProjectModelExtensions.GetPlanningDesignStartYear(x), 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.ImplementationStartYear.ToType().ToGridHeaderString(), x => ProjectModelExtensions.GetImplementationStartYear(x), 115, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.CompletionYear.ToType().ToGridHeaderString(), x => ProjectModelExtensions.GetCompletionYear(x), 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            if (MultiTenantHelpers.ReportFinancialsAtProjectLevel())
            {
                Add(FieldDefinitionEnum.EstimatedTotalCost.ToType().ToGridHeaderString(), x => x.GetEstimatedTotalRegardlessOfFundingType(), 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
                Add(FieldDefinitionEnum.SecuredFunding.ToType().ToGridHeaderString(), x => x.GetSecuredFunding(), 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
                Add(FieldDefinitionEnum.TargetedFunding.ToType().ToGridHeaderString(), x => x.GetTargetedFunding(), 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
                Add(FieldDefinitionEnum.NoFundingSourceIdentified.ToType().ToGridHeaderString(), x => x.GetNoFundingSourceIdentifiedAmount(), 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            }
            Add("Submitted By", a => a.SubmittedByPerson != null ? a.SubmittedByPerson.GetFullNameFirstLastAndOrgShortNameAsUrl(currentFirmaSession) : new HtmlString(null), 200);
            Add("Submitted Date", a => a.SubmissionDate, 120);
            Add("Last Updated", a => a.LastUpdatedDate, 120);
            Add(FieldDefinitionEnum.ProjectDescription.ToType().ToGridHeaderString(), x => x.ProjectDescription, 300);
        }
    }
}
