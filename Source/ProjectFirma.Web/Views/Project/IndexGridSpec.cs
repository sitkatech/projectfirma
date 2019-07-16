/*-----------------------------------------------------------------------
<copyright file="IndexGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
    public class IndexGridSpec : GridSpec<ProjectFirmaModels.Models.Project>
    {
        public IndexGridSpec(Person currentPerson, Dictionary<int, FundingType> fundingTypes, List<GeospatialAreaType> geospatialAreaTypes, List<ProjectFirmaModels.Models.ProjectCustomAttributeType> projectCustomAttributeTypes)
        {
            var userHasTagManagePermissions = new FirmaAdminFeature().HasPermissionByPerson(currentPerson);
            var userHasDeletePermissions = new ProjectDeleteFeature().HasPermissionByPerson(currentPerson);
            var userHasEmailViewingPermissions = new LoggedInAndNotUnassignedRoleUnclassifiedFeature().HasPermissionByPerson(currentPerson);

            if (userHasTagManagePermissions)
            {
                BulkTagModalDialogForm = new BulkTagModalDialogForm(SitkaRoute<TagController>.BuildUrlFromExpression(x => x.BulkTagProjects(null)), $"Tag Checked {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", $"Tag {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}");
                AddCheckBoxColumn();
                Add("ProjectID", x => x.ProjectID, 0);
            }

            if (userHasDeletePermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true), 30, DhtmlxGridColumnFilterType.None);
            }

            Add(string.Empty, x => UrlTemplate.MakeHrefString(x.GetFactSheetUrl(), FirmaDhtmlxGridHtmlHelpers.FactSheetIcon.ToString()), 30, DhtmlxGridColumnFilterType.None);

            Add(FieldDefinitionEnum.ProjectName.ToType().ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.GetDetailUrl(), x.ProjectName), 300, DhtmlxGridColumnFilterType.Html);
            if (MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
            {
                Add(FieldDefinitionEnum.ProjectsStewardOrganizationRelationshipToProject.ToType().ToGridHeaderString(), x => x.GetCanStewardProjectsOrganization()?.GetShortNameAsUrl() ?? new HtmlString(""), 150, DhtmlxGridColumnFilterType.Html);
            }
            Add(FieldDefinitionEnum.IsPrimaryContactOrganization.ToType().ToGridHeaderString(), x => x.GetPrimaryContactOrganization().GetShortNameAsUrl(), 150, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.ProjectPrimaryContact.ToType().ToGridHeaderString(),
                x => x.GetPrimaryContact() != null ? UrlTemplate.MakeHrefString(x.GetPrimaryContact().GetDetailUrl(), x.GetPrimaryContact().GetFullNameLastFirst()) : new HtmlString(""),
                150, DhtmlxGridColumnFilterType.Html);
            if (userHasEmailViewingPermissions)
            {
                Add(FieldDefinitionEnum.ProjectPrimaryContactEmail.ToType().ToGridHeaderString(),
                    x => x.GetPrimaryContact() != null ? new HtmlString($"<a href='mailto:{x.GetPrimaryContact().Email}'> {x.GetPrimaryContact().Email}</a>") : new HtmlString(""),
                    200, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
            }
            Add(FieldDefinitionEnum.ProjectStage.ToType().ToGridHeaderString(), x => x.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.PlanningDesignStartYear.ToType().ToGridHeaderString(), x => ProjectModelExtensions.GetPlanningDesignStartYear(x), 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.ImplementationStartYear.ToType().ToGridHeaderString(), x => ProjectModelExtensions.GetImplementationStartYear(x), 115, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.CompletionYear.ToType().ToGridHeaderString(), x => ProjectModelExtensions.GetCompletionYear(x), 90, DhtmlxGridColumnFilterType.SelectFilterStrict);

            Add($"Primary {FieldDefinitionEnum.TaxonomyLeaf.ToType().ToGridHeaderString()}", x => x.TaxonomyLeaf.GetDisplayNameAsUrl(), 200, DhtmlxGridColumnFilterType.Html);
            var enableSecondaryProjectTaxonomyLeaf = MultiTenantHelpers.GetTenantAttribute().EnableSecondaryProjectTaxonomyLeaf;
            if (enableSecondaryProjectTaxonomyLeaf)
            {
                Add(FieldDefinitionEnum.SecondaryProjectTaxonomyLeaf.ToType().ToGridHeaderStringPlural(), x => new HtmlString(string.Join(", ", x.SecondaryProjectTaxonomyLeafs.Select(y => y.TaxonomyLeaf.GetDisplayNameAsUrl().ToString()))), 300, DhtmlxGridColumnFilterType.Html);
            }

            Add($"Number Of Reported {MultiTenantHelpers.GetPerformanceMeasureName()} Records", x => x.PerformanceMeasureActuals.Count, 100);
            Add($"Number Of {FieldDefinitionEnum.ReportedExpenditure.ToType().GetFieldDefinitionLabel()} Records", x => x.ProjectFundingSourceExpenditures.Count, 100);
            Add(FieldDefinitionEnum.FundingType.ToType().ToGridHeaderString(), x => x.FundingTypeID.HasValue ? fundingTypes[x.FundingTypeID.Value].FundingTypeDisplayName : "", 300, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.EstimatedTotalCost.ToType().ToGridHeaderString(), x => x.EstimatedTotalCost, 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(FieldDefinitionEnum.EstimatedAnnualOperatingCost.ToType().ToGridHeaderString(), x => x.EstimatedAnnualOperatingCost, 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(FieldDefinitionEnum.SecuredFunding.ToType().ToGridHeaderString(), x => x.GetSecuredFunding(), 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(FieldDefinitionEnum.TargetedFunding.ToType().ToGridHeaderString(), x => x.GetTargetedFunding(), 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(FieldDefinitionEnum.NoFundingSourceIdentified.ToType().ToGridHeaderString(), x => x.GetNoFundingSourceIdentifiedAmount(), 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            foreach (var projectCustomAttributeType in projectCustomAttributeTypes.OrderBy(x => x.ProjectCustomAttributeTypeName))
            {
                if (projectCustomAttributeType.IncludeInProjectGrid && projectCustomAttributeType.HasViewPermission(currentPerson))
                {
                    Add($"{projectCustomAttributeType.ProjectCustomAttributeTypeName}", a => a.GetProjectCustomAttributesValue(projectCustomAttributeType), 150,DhtmlxGridColumnFilterType.Text);
                }
            }
            foreach (var geospatialAreaType in geospatialAreaTypes.OrderBy(x => x.GeospatialAreaTypeName))
            {
                Add($"{geospatialAreaType.GeospatialAreaTypeNamePluralized}", a => a.GetProjectGeospatialAreaNamesAsHyperlinks(geospatialAreaType), 350, DhtmlxGridColumnFilterType.Html);
            }

            Add(FieldDefinitionEnum.ProjectDescription.ToType().ToGridHeaderString(), x => x.ProjectDescription, 200);
            if (userHasTagManagePermissions)
            {
                Add("Tags", x => new HtmlString(!x.ProjectTags.Any() ? string.Empty : string.Join(", ", x.ProjectTags.Select(pt => pt.Tag.GetDisplayNameAsUrl()))), 100, DhtmlxGridColumnFilterType.Html);
            }

            Add("# of Photos", x => x.ProjectImages.Count, 60);            

        }
    }
}
