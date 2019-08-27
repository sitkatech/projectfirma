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
            // Non-optional fields
            // Project Name
            if (projectCustomGridConfiguration.ProjectCustomGridColumnID == ProjectCustomGridColumn.ProjectName.ProjectCustomGridColumnID)
            {
                Add(FieldDefinitionEnum.ProjectName.ToType().ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.GetDetailUrl(), x.ProjectName), 300, DhtmlxGridColumnFilterType.Html);
                return;
            }
            // Primary Contact Organization
            if (projectCustomGridConfiguration.ProjectCustomGridColumnID == ProjectCustomGridColumn.PrimaryContactOrganization.ProjectCustomGridColumnID)
            {
                Add(FieldDefinitionEnum.IsPrimaryContactOrganization.ToType().ToGridHeaderString(), x => x.GetPrimaryContactOrganization().GetShortNameAsUrl(), 150, DhtmlxGridColumnFilterType.Html);
                return;
            }
            // Project Stage
            if (projectCustomGridConfiguration.ProjectCustomGridColumnID == ProjectCustomGridColumn.ProjectStage.ProjectCustomGridColumnID)
            {
                Add(FieldDefinitionEnum.ProjectStage.ToType().ToGridHeaderString(), x => x.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
                return;
            }
            // Optional fields
            // Performance Measure Count
            if (projectCustomGridConfiguration.ProjectCustomGridColumnID == ProjectCustomGridColumn.NumberOfReportedPerformanceMeasures.ProjectCustomGridColumnID)
            {
                Add($"Number Of Reported {MultiTenantHelpers.GetPerformanceMeasureName()} Records", x => x.PerformanceMeasureActuals.Count, 100);
                return;
            }
            // Projects Steward Organization Relationship To Project
            if (projectCustomGridConfiguration.ProjectCustomGridColumnID == ProjectCustomGridColumn.ProjectsStewardOrganizationRelationshipToProject.ProjectCustomGridColumnID)
            {
                if (MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
                {
                    Add(FieldDefinitionEnum.ProjectsStewardOrganizationRelationshipToProject.ToType().ToGridHeaderString(), x => x.GetCanStewardProjectsOrganization()?.GetShortNameAsUrl() ?? new HtmlString(""), 150, DhtmlxGridColumnFilterType.Html);
                }
            }
            // Project Primary Contact
            if (projectCustomGridConfiguration.ProjectCustomGridColumnID == ProjectCustomGridColumn.ProjectPrimaryContact.ProjectCustomGridColumnID)
            {
                Add(FieldDefinitionEnum.ProjectPrimaryContact.ToType().ToGridHeaderString(),
                    x => x.GetPrimaryContact() != null ? UrlTemplate.MakeHrefString(x.GetPrimaryContact().GetDetailUrl(), x.GetPrimaryContact().GetFullNameLastFirst()) : new HtmlString(""),
                    150, DhtmlxGridColumnFilterType.Html);
            }
            // Project Primary Contact Email
            if (projectCustomGridConfiguration.ProjectCustomGridColumnID == ProjectCustomGridColumn.ProjectPrimaryContactEmail.ProjectCustomGridColumnID)
            {
                var userHasEmailViewingPermissions = new LoggedInAndNotUnassignedRoleUnclassifiedFeature().HasPermissionByPerson(currentPerson);
                if (userHasEmailViewingPermissions)
                {
                    Add(FieldDefinitionEnum.ProjectPrimaryContactEmail.ToType().ToGridHeaderString(),
                        x => x.GetPrimaryContact() != null ? new HtmlString($"<a href='mailto:{x.GetPrimaryContact().Email}'> {x.GetPrimaryContact().Email}</a>") : new HtmlString(""),
                        200, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);
                }
            }
            // Planning Design Start Year
            if (projectCustomGridConfiguration.ProjectCustomGridColumnID == ProjectCustomGridColumn.PlanningDesignStartYear.ProjectCustomGridColumnID)
            {
                Add(FieldDefinitionEnum.PlanningDesignStartYear.ToType().ToGridHeaderString(), x => ProjectModelExtensions.GetPlanningDesignStartYear(x), 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            }
            // Implementation Start Year
            if (projectCustomGridConfiguration.ProjectCustomGridColumnID == ProjectCustomGridColumn.ImplementationStartYear.ProjectCustomGridColumnID)
            {
                Add(FieldDefinitionEnum.ImplementationStartYear.ToType().ToGridHeaderString(), x => ProjectModelExtensions.GetImplementationStartYear(x), 115, DhtmlxGridColumnFilterType.SelectFilterStrict);
            }
            // Completion Year
            if (projectCustomGridConfiguration.ProjectCustomGridColumnID == ProjectCustomGridColumn.CompletionYear.ProjectCustomGridColumnID)
            {
                Add(FieldDefinitionEnum.CompletionYear.ToType().ToGridHeaderString(), x => ProjectModelExtensions.GetCompletionYear(x), 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            }
            // Primary Taxonomy Leaf
            if (projectCustomGridConfiguration.ProjectCustomGridColumnID == ProjectCustomGridColumn.PrimaryTaxonomyLeaf.ProjectCustomGridColumnID)
            {
                Add($"Primary {FieldDefinitionEnum.TaxonomyLeaf.ToType().ToGridHeaderString()}", x => x.TaxonomyLeaf.GetDisplayNameAsUrl(), 200, DhtmlxGridColumnFilterType.Html);
            }
            // Secondary Taxonomy Leaf
            if (projectCustomGridConfiguration.ProjectCustomGridColumnID == ProjectCustomGridColumn.SecondaryTaxonomyLeaf.ProjectCustomGridColumnID)
            {
                var enableSecondaryProjectTaxonomyLeaf = MultiTenantHelpers.GetTenantAttribute().EnableSecondaryProjectTaxonomyLeaf;
                if (enableSecondaryProjectTaxonomyLeaf)
                {
                    Add(FieldDefinitionEnum.SecondaryProjectTaxonomyLeaf.ToType().ToGridHeaderStringPlural(), x => new HtmlString(string.Join(", ", x.SecondaryProjectTaxonomyLeafs.Select(y => y.TaxonomyLeaf.GetDisplayNameAsUrl().ToString()))), 300, DhtmlxGridColumnFilterType.Html);
                }
            }
            // Number of Reported Expenditures
            if (projectCustomGridConfiguration.ProjectCustomGridColumnID == ProjectCustomGridColumn.NumberOfReportedExpenditures.ProjectCustomGridColumnID)
            {
                Add($"Number Of {FieldDefinitionEnum.ReportedExpenditure.ToType().GetFieldDefinitionLabel()} Records", x => x.ProjectFundingSourceExpenditures.Count, 100);
            }
            // Funding Type
            if (projectCustomGridConfiguration.ProjectCustomGridColumnID == ProjectCustomGridColumn.FundingType.ProjectCustomGridColumnID)
            {
                Add(FieldDefinitionEnum.FundingType.ToType().ToGridHeaderString(), x => x.FundingType != null ? x.FundingType.FundingTypeDisplayName : "", 300, DhtmlxGridColumnFilterType.SelectFilterStrict);
            }
            // Estimated Total Cost
            if (projectCustomGridConfiguration.ProjectCustomGridColumnID == ProjectCustomGridColumn.EstimatedTotalCost.ProjectCustomGridColumnID)
            {
                Add(FieldDefinitionEnum.EstimatedTotalCost.ToType().ToGridHeaderString(), x => x.GetEstimatedTotalRegardlessOfFundingType(), 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            }
            // Secured Funding
            if (projectCustomGridConfiguration.ProjectCustomGridColumnID == ProjectCustomGridColumn.SecuredFunding.ProjectCustomGridColumnID)
            {
                Add(FieldDefinitionEnum.SecuredFunding.ToType().ToGridHeaderString(), x => x.GetSecuredFunding(), 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            }
            // Targeted Funding
            if (projectCustomGridConfiguration.ProjectCustomGridColumnID == ProjectCustomGridColumn.TargetedFunding.ProjectCustomGridColumnID)
            {
                Add(FieldDefinitionEnum.TargetedFunding.ToType().ToGridHeaderString(), x => x.GetTargetedFunding(), 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            }
            // No Funding Source Identified
            if (projectCustomGridConfiguration.ProjectCustomGridColumnID == ProjectCustomGridColumn.NoFundingSourceIdentified.ProjectCustomGridColumnID)
            {
                Add(FieldDefinitionEnum.NoFundingSourceIdentified.ToType().ToGridHeaderString(), x => x.GetNoFundingSourceIdentifiedAmount(), 110, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            }
            // Project Description
            if (projectCustomGridConfiguration.ProjectCustomGridColumnID == ProjectCustomGridColumn.ProjectDescription.ProjectCustomGridColumnID)
            {
                Add(FieldDefinitionEnum.ProjectDescription.ToType().ToGridHeaderString(), x => x.ProjectDescription, 200);
            }
            // Number of Photos
            if (projectCustomGridConfiguration.ProjectCustomGridColumnID == ProjectCustomGridColumn.NumberOfPhotos.ProjectCustomGridColumnID)
            {
                Add("# of Photos", x => x.ProjectImages.Count, 60);
            }
        }

        private void AddProjectCustomGridCustomAttributeField(ProjectCustomGridConfiguration projectCustomGridConfiguration)
        {
            var projectCustomAttributeType = projectCustomGridConfiguration.ProjectCustomAttributeType;
            Add($"{projectCustomAttributeType.ProjectCustomAttributeTypeName}", a => a.GetProjectCustomAttributesValue(projectCustomAttributeType), 150, DhtmlxGridColumnFilterType.Text);
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
            var userHasEmailViewingPermissions = new LoggedInAndNotUnassignedRoleUnclassifiedFeature().HasPermissionByPerson(currentPerson);

            // Mandatory fields appearing BEFORE configurable fields
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
