﻿/*-----------------------------------------------------------------------
<copyright file="BasicProjectInfoGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Project
{
    public class BasicProjectInfoGridSpec : GridSpec<ProjectFirmaModels.Models.Project>
    {
        public BasicProjectInfoGridSpec(FirmaSession currentFirmaSession, bool allowTaggingFunctionality)
        {
            var userHasTagManagePermissions = new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);
            if (userHasTagManagePermissions && allowTaggingFunctionality)
            {
                BulkTagModalDialogForm = new BulkTagModalDialogForm(SitkaRoute<TagController>.BuildUrlFromExpression(x => x.BulkTagProjects(null)), $"Tag Checked {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", $"Tag {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}");
                AddCheckBoxColumn();
                Add("ProjectID", x => x.ProjectID, 0);
            }

            Add(string.Empty, x => UrlTemplate.MakeHrefString(x.GetFactSheetUrl(), FirmaDhtmlxGridHtmlHelpers.FactSheetIcon.ToString()), 30, DhtmlxGridColumnFilterType.None);
            Add(FieldDefinitionEnum.ProjectName.ToType().ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.GetDetailUrl(), x.ProjectName), 300, DhtmlxGridColumnFilterType.Html);
            if (MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
            {
                Add(FieldDefinitionEnum.ProjectsStewardOrganizationRelationshipToProject.ToType().ToGridHeaderString(), x => x.GetCanStewardProjectsOrganization().GetShortNameAsUrl(), 150,
                    DhtmlxGridColumnFilterType.Html);
            }
            Add(FieldDefinitionEnum.IsPrimaryContactOrganization.ToType().ToGridHeaderString(), x => x.GetPrimaryContactOrganization().GetShortNameAsUrl(), 150, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.ProjectStage.ToType().ToGridHeaderString(), x => x.ProjectStage.GetProjectStageDisplayName(), 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.PlanningDesignStartYear.ToType().ToGridHeaderString(), x => ProjectModelExtensions.GetPlanningDesignStartYear(x), 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.ImplementationStartYear.ToType().ToGridHeaderString(), x => ProjectModelExtensions.GetImplementationStartYear(x), 115, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.CompletionYear.ToType().ToGridHeaderString(), x => ProjectModelExtensions.GetCompletionYear(x), 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.FundingType.ToType().ToGridHeaderString(), x => x.FundingType?.FundingTypeDisplayName ?? string.Empty, 300, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.EstimatedTotalCost.ToType().ToGridHeaderString(), x => x.GetEstimatedTotalRegardlessOfFundingType(), 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(FieldDefinitionEnum.SecuredFunding.ToType().ToGridHeaderString(), x => x.GetSecuredFunding(), 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(FieldDefinitionEnum.TargetedFunding.ToType().ToGridHeaderString(), x => x.GetTargetedFunding(), 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(FieldDefinitionEnum.NoFundingSourceIdentified.ToType().ToGridHeaderString(), x => x.GetNoFundingSourceIdentifiedAmount(), 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            foreach (var geospatialAreaType in new List<GeospatialAreaType>())
            {
                Add($"{geospatialAreaType.GeospatialAreaTypeNamePluralized}", a => a.GetProjectGeospatialAreaNamesAsHyperlinks(geospatialAreaType), 350, DhtmlxGridColumnFilterType.Html);
            }
            Add(FieldDefinitionEnum.ProjectDescription.ToType().ToGridHeaderString(), x => x.ProjectDescription, 300);
            if (userHasTagManagePermissions)
            {
                Add("Tags", x => new HtmlString(!x.ProjectTags.Any() ? string.Empty : string.Join(", ", x.ProjectTags.Select(pt => pt.Tag.GetDisplayNameAsUrl()))), 100, DhtmlxGridColumnFilterType.Html);    
            }            
        }
    }
}
