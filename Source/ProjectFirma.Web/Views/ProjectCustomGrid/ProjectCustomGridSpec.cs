/*-----------------------------------------------------------------------
<copyright file="ProjectCustomGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectCustomGrid
{
    public class ProjectCustomGridSpec : GridSpec<ProjectFirmaModels.Models.Project>
    {

        private void AddProjectCustomGridField(Person currentPerson, ProjectCustomGridConfiguration projectCustomGridConfiguration)
        {
            switch (projectCustomGridConfiguration.ProjectCustomGridColumn.ToEnum)
            {
                // Non-optional fields
                // Project Name
                case ProjectCustomGridColumnEnum.ProjectName:
                    Add(FieldDefinitionEnum.ProjectName.ToType().ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.GetDetailUrl(), x.ProjectName), 300, DhtmlxGridColumnFilterType.Html);
                    break;
                case ProjectCustomGridColumnEnum.PrimaryContactOrganization:
                    Add(FieldDefinitionEnum.IsPrimaryContactOrganization.ToType().ToGridHeaderString(), x => x.GetPrimaryContactOrganization().GetShortNameAsUrl(), 150, DhtmlxGridColumnFilterType.Html);
                    break;
                case ProjectCustomGridColumnEnum.ProjectStage:
                    Add(FieldDefinitionEnum.ProjectStage.ToType().ToGridHeaderString(), x => x.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
                    break;
                case ProjectCustomGridColumnEnum.NumberOfReportedPerformanceMeasures:
                    Add($"Number Of Reported {MultiTenantHelpers.GetPerformanceMeasureName()} Records", x => x.PerformanceMeasureActuals.Count, 100);
                    break;
                case ProjectCustomGridColumnEnum.ProjectsStewardOrganizationRelationshipToProject:
                    if (MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
                    {
                        Add(FieldDefinitionEnum.ProjectsStewardOrganizationRelationshipToProject.ToType().ToGridHeaderString(), x => x.GetCanStewardProjectsOrganization()?.GetShortNameAsUrl() ?? new HtmlString(""), 150, DhtmlxGridColumnFilterType.Html);
                    }
                    break;
                case ProjectCustomGridColumnEnum.ProjectPrimaryContact:
                    Add(FieldDefinitionEnum.ProjectPrimaryContact.ToType().ToGridHeaderString(),
                        x => x.GetPrimaryContact() != null ? UrlTemplate.MakeHrefString(x.GetPrimaryContact().GetDetailUrl(), x.GetPrimaryContact().GetFullNameLastFirst()) : new HtmlString(""),
                        150, DhtmlxGridColumnFilterType.Html);
                    break;
                case ProjectCustomGridColumnEnum.ProjectPrimaryContactEmail:
                    var userHasEmailViewingPermissions = new LoggedInAndNotUnassignedRoleUnclassifiedFeature().HasPermissionByPerson(currentPerson);
                    if (userHasEmailViewingPermissions)
                    {
                        Add(FieldDefinitionEnum.ProjectPrimaryContactEmail.ToType().ToGridHeaderString(),
                            x => x.GetPrimaryContact() != null ? new HtmlString($"<a href='mailto:{x.GetPrimaryContact().Email}'> {x.GetPrimaryContact().Email}</a>") : new HtmlString(""),
                            200, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
                    }
                    break;
                case ProjectCustomGridColumnEnum.PlanningDesignStartYear:
                    Add(FieldDefinitionEnum.PlanningDesignStartYear.ToType().ToGridHeaderString(), x => ProjectModelExtensions.GetPlanningDesignStartYear(x), 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
                    break;
                case ProjectCustomGridColumnEnum.ImplementationStartYear:
                    Add(FieldDefinitionEnum.ImplementationStartYear.ToType().ToGridHeaderString(), x => ProjectModelExtensions.GetImplementationStartYear(x), 115, DhtmlxGridColumnFilterType.SelectFilterStrict);
                    break;
                case ProjectCustomGridColumnEnum.CompletionYear:
                    Add(FieldDefinitionEnum.CompletionYear.ToType().ToGridHeaderString(), x => ProjectModelExtensions.GetCompletionYear(x), 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
                    break;
                case ProjectCustomGridColumnEnum.PrimaryTaxonomyLeaf:
                    var gridHeaderString = MultiTenantHelpers.GetTenantAttribute().EnableSecondaryProjectTaxonomyLeaf
                        ? FieldDefinitionEnum.TaxonomyLeafDisplayNameForProject.ToType().ToGridHeaderString()
                        : FieldDefinitionEnum.TaxonomyLeaf.ToType().ToGridHeaderString();
                    Add(gridHeaderString, x => x.TaxonomyLeaf.GetDisplayNameAsUrl(), 240, DhtmlxGridColumnFilterType.Html);
                    break;
                case ProjectCustomGridColumnEnum.SecondaryTaxonomyLeaf:
                    if (MultiTenantHelpers.GetTenantAttribute().EnableSecondaryProjectTaxonomyLeaf)
                    {
                        Add(FieldDefinitionEnum.SecondaryProjectTaxonomyLeaf.ToType().ToGridHeaderStringPlural(), x => new HtmlString(string.Join(", ", x.SecondaryProjectTaxonomyLeafs.Select(y => y.TaxonomyLeaf.GetDisplayNameAsUrl().ToString()))), 300, DhtmlxGridColumnFilterType.Html);
                    }
                    break;
                case ProjectCustomGridColumnEnum.NumberOfReportedExpenditures:
                    Add($"Number Of {FieldDefinitionEnum.ReportedExpenditure.ToType().GetFieldDefinitionLabel()} Records", x => x.ProjectFundingSourceExpenditures.Count, 100);
                    break;
                case ProjectCustomGridColumnEnum.FundingType:
                    Add(FieldDefinitionEnum.FundingType.ToType().ToGridHeaderString(), x => x.FundingType != null ? x.FundingType.FundingTypeDisplayName : "", 300, DhtmlxGridColumnFilterType.SelectFilterStrict);
                    break;
                case ProjectCustomGridColumnEnum.EstimatedTotalCost:
                    Add(FieldDefinitionEnum.EstimatedTotalCost.ToType().ToGridHeaderString(), x => x.GetEstimatedTotalRegardlessOfFundingType(), 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
                    break;
                case ProjectCustomGridColumnEnum.SecuredFunding:
                    Add(FieldDefinitionEnum.SecuredFunding.ToType().ToGridHeaderString(), x => x.GetSecuredFunding(), 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
                    break;
                case ProjectCustomGridColumnEnum.TargetedFunding:
                    Add(FieldDefinitionEnum.TargetedFunding.ToType().ToGridHeaderString(), x => x.GetTargetedFunding(), 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
                    break;
                case ProjectCustomGridColumnEnum.NoFundingSourceIdentified:
                    Add(FieldDefinitionEnum.NoFundingSourceIdentified.ToType().ToGridHeaderString(), x => x.GetNoFundingSourceIdentifiedAmount(), 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
                    break;
                case ProjectCustomGridColumnEnum.ProjectDescription:
                    Add(FieldDefinitionEnum.ProjectDescription.ToType().ToGridHeaderString(), x => x.ProjectDescription, 200);
                    break;
                case ProjectCustomGridColumnEnum.NumberOfPhotos:
                    Add("# of Photos", x => x.ProjectImages.Count, 60);
                    break;
                case ProjectCustomGridColumnEnum.ProjectID:
                    Add(FieldDefinitionEnum.ProjectID.ToType().ToGridHeaderString(), x => x.ProjectID.ToString(), 140);
                    break;
                case ProjectCustomGridColumnEnum.GeospatialAreaName:
                    break;
                case ProjectCustomGridColumnEnum.CustomAttribute:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void AddProjectCustomGridCustomAttributeField(ProjectCustomGridConfiguration projectCustomGridConfiguration)
        {
            var projectCustomAttributeType = projectCustomGridConfiguration.ProjectCustomAttributeType;
            var isCurrency = projectCustomGridConfiguration.ProjectCustomAttributeType.MeasurementUnitTypeID == MeasurementUnitType.Dollars.MeasurementUnitTypeID;
            if (isCurrency)
            {
                Add($"{projectCustomAttributeType.ProjectCustomAttributeTypeName}", a => Decimal.Parse(a.GetProjectCustomAttributesValue(projectCustomAttributeType)), 150, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            }
            else
            {
                Add($"{projectCustomAttributeType.ProjectCustomAttributeTypeName}", a => a.GetProjectCustomAttributesValue(projectCustomAttributeType), 150, DhtmlxGridColumnFilterType.Text);
            }
        }

        private void AddProjectCustomGridGeospatialAreaField(ProjectCustomGridConfiguration projectCustomGridConfiguration)
        {
            var geospatialAreaType = projectCustomGridConfiguration.GeospatialAreaType;
            Add($"{geospatialAreaType.GeospatialAreaTypeNamePluralized}", a => a.GetProjectGeospatialAreaNamesAsHyperlinks(geospatialAreaType), 350, DhtmlxGridColumnFilterType.Html);
        }

    public ProjectCustomGridSpec(Person currentPerson, List<ProjectCustomGridConfiguration> projectCustomGridConfigurations)
        {
            var userHasTagManagePermissions = new FirmaAdminFeature().HasPermissionByPerson(currentPerson);
            var userHasDeletePermissions = new ProjectDeleteFeature().HasPermissionByPerson(currentPerson);

            // Mandatory fields appearing BEFORE configurable fields
            if (userHasTagManagePermissions)
            {
                BulkTagModalDialogForm = new BulkTagModalDialogForm(SitkaRoute<TagController>.BuildUrlFromExpression(x => x.BulkTagProjects(null)), $"Tag Checked {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", $"Tag {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}");
                AddCheckBoxColumn();
            }
        
            if (userHasDeletePermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true), 30, DhtmlxGridColumnFilterType.None);
            }

            Add(string.Empty, x => UrlTemplate.MakeHrefString(x.GetFactSheetUrl(), FirmaDhtmlxGridHtmlHelpers.FactSheetIcon.ToString(), $"Download the Fact Sheet for {x.ProjectName}"), 30, DhtmlxGridColumnFilterType.None);
            //

            // Implement configured fields here
            //
            foreach (var projectCustomGridConfiguration in projectCustomGridConfigurations.OrderBy(x => x.SortOrder))
            {
                if (projectCustomGridConfiguration.ProjectCustomAttributeType != null)
                {
                    if (projectCustomGridConfiguration.ProjectCustomAttributeType.HasViewPermission(currentPerson))
                    {
                        AddProjectCustomGridCustomAttributeField(projectCustomGridConfiguration);
                    }
                }
                else if (projectCustomGridConfiguration.GeospatialAreaType != null)
                {
                    AddProjectCustomGridGeospatialAreaField(projectCustomGridConfiguration);
                }
                else
                {
                    AddProjectCustomGridField(currentPerson, projectCustomGridConfiguration);
                }
            }

            // Mandatory fields appearing AFTER configurable fields
            if (userHasTagManagePermissions)
            {
                Add("Tags", x => new HtmlString(!x.ProjectTags.Any() ? string.Empty : string.Join(", ", x.ProjectTags.Select(pt => pt.Tag.GetDisplayNameAsUrl()))), 100, DhtmlxGridColumnFilterType.Html);
            }
            //
        }
    }
}
