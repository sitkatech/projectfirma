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
using System.Data.Entity;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;
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
        
        public static HtmlString MakeProjectStatusAddLinkAndText(ProjectFirmaModels.Models.Project project
            , FirmaSession currentFirmaSession
            , vProjectDetail projectDetail
            , string projectLabel
            , bool hasProjectApprovalPermissionBySession
            , string statusUpdateLabel)
        {
            
            var editIconAsModalDialogLinkBootstrap = new HtmlString(string.Empty);
            var isEditableToThisFirmaSession = project.IsEditableToThisFirmaSession(currentFirmaSession, projectDetail, projectLabel, hasProjectApprovalPermissionBySession);

            var returnString = new HtmlString("");
            if (!isEditableToThisFirmaSession) return returnString;

            editIconAsModalDialogLinkBootstrap = DhtmlxGridHtmlHelpers.MakePlusIconAsModalDialogLinkBootstrap(
                project.GetAddProjectProjectStatusFromGridUrl()
                , $"Add {statusUpdateLabel}");

            var currentProjectStatus = project.GetCurrentProjectStatus();
            var colorString = currentProjectStatus != null ? currentProjectStatus.ProjectStatusColor : "transparent";
            var projectStatusDisplayName = currentProjectStatus != null ? currentProjectStatus.ProjectStatusDisplayName : "no status";
            returnString = new HtmlString($"<div style=\"border-left:10px solid {colorString}; padding-left:5px;\">{editIconAsModalDialogLinkBootstrap} {projectStatusDisplayName}</div>");

            return returnString;
        }

        
        private void AddProjectCustomGridField(FirmaSession currentFirmaSession
            , ProjectCustomGridConfiguration projectCustomGridConfiguration
            ,bool userHasEditProjectAsAdminPermissions
            , Dictionary<int, vProjectDetail> projectDetailsDictionary
            , Dictionary<int,ProjectFirmaModels.Models.TaxonomyLeaf> taxonomyLeafDictionary
            , string projectLabel
            , bool hasProjectApprovalPermissionBySession
            , string statusUpdateLabel)
        {

            switch (projectCustomGridConfiguration.ProjectCustomGridColumn.ToEnum)
            {
                // Non-optional fields
                // Project Name
                case ProjectCustomGridColumnEnum.ProjectName:
                    Add(FieldDefinitionEnum.ProjectName.ToType().ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.GetDetailUrl(), x.ProjectName), 300, DhtmlxGridColumnFilterType.Html);
                    break;
                case ProjectCustomGridColumnEnum.PrimaryContactOrganization:
                    Add(FieldDefinitionEnum.IsPrimaryContactOrganization.ToType().ToGridHeaderString(), 
                        x => OrganizationModelExtensions.GetShortNameAsUrl(projectDetailsDictionary[x.ProjectID].PrimaryContactOrganizationID, projectDetailsDictionary[x.ProjectID].PrimaryContactOrganizationDisplayName), 150, DhtmlxGridColumnFilterType.Html);
                    break;
                case ProjectCustomGridColumnEnum.ProjectStage:
                    Add(FieldDefinitionEnum.ProjectStage.ToType().ToGridHeaderString(), x => x.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
                    break;
                case ProjectCustomGridColumnEnum.NumberOfReportedPerformanceMeasures:
                    Add($"Number Of Reported {MultiTenantHelpers.GetPerformanceMeasureName()} Records", x => projectDetailsDictionary[x.ProjectID].PerformanceMeasureActualCount, 100);
                    break;
                case ProjectCustomGridColumnEnum.ProjectsStewardOrganizationRelationshipToProject:
                    if (MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
                    {
                        Add(FieldDefinitionEnum.ProjectsStewardOrganizationRelationshipToProject.ToType().ToGridHeaderString(), x => OrganizationModelExtensions.GetShortNameAsUrl(projectDetailsDictionary[x.ProjectID].CanStewardProjectsOrganizationID, projectDetailsDictionary[x.ProjectID].CanStewardProjectsOrganizationDisplayName), 150, DhtmlxGridColumnFilterType.Html);
                    }
                    break;
                case ProjectCustomGridColumnEnum.ProjectPrimaryContact:
                    Add(FieldDefinitionEnum.ProjectPrimaryContact.ToType().ToGridHeaderString(),
                        x => projectDetailsDictionary[x.ProjectID].PrimaryContactPersonID.HasValue ?
                            UrlTemplate.MakeHrefString(PersonModelExtensions.DetailUrlTemplate.ParameterReplace(projectDetailsDictionary[x.ProjectID].PrimaryContactPersonID.Value), projectDetailsDictionary[x.ProjectID].PrimaryContactPersonFullNameFirstLast) : new HtmlString(""),
                        150, DhtmlxGridColumnFilterType.Html);
                    break;
                case ProjectCustomGridColumnEnum.ProjectPrimaryContactEmail:
                    var userHasEmailViewingPermissions = new LoggedInAndNotUnassignedRoleUnclassifiedFeature().HasPermissionByFirmaSession(currentFirmaSession);
                    if (userHasEmailViewingPermissions)
                    {
                        Add(FieldDefinitionEnum.ProjectPrimaryContactEmail.ToType().ToGridHeaderString(),
                            x => projectDetailsDictionary[x.ProjectID].PrimaryContactPersonID.HasValue ? new HtmlString($"<a href='mailto:{projectDetailsDictionary[x.ProjectID].PrimaryContactPersonEmail}'> {projectDetailsDictionary[x.ProjectID].PrimaryContactPersonEmail}</a>") : new HtmlString(""),
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
                    var gridHeaderString = MultiTenantHelpers.GetTenantAttributeFromCache().EnableSecondaryProjectTaxonomyLeaf
                        ? FieldDefinitionEnum.TaxonomyLeafDisplayNameForProject.ToType().ToGridHeaderString()
                        : FieldDefinitionEnum.TaxonomyLeaf.ToType().ToGridHeaderString();
                    Add(gridHeaderString, x => UrlTemplate.MakeHrefString(TaxonomyLeafModelExtensions.DetailUrlTemplate.ParameterReplace(projectDetailsDictionary[x.ProjectID].TaxonomyLeafID), projectDetailsDictionary[x.ProjectID].TaxonomyLeafDisplayName), 240, DhtmlxGridColumnFilterType.Html);
                    break;
                case ProjectCustomGridColumnEnum.SecondaryTaxonomyLeaf:
                    if (MultiTenantHelpers.GetTenantAttributeFromCache().EnableSecondaryProjectTaxonomyLeaf)
                    {
                        Add(FieldDefinitionEnum.SecondaryProjectTaxonomyLeaf.ToType().ToGridHeaderStringPlural()
                            , x => new HtmlString(string.Join(", ", x.SecondaryProjectTaxonomyLeafs.Select(y => taxonomyLeafDictionary[y.TaxonomyLeafID].GetDisplayNameAsUrl().ToString()))), 300, DhtmlxGridColumnFilterType.Html);
                    }
                    break;
                case ProjectCustomGridColumnEnum.NumberOfReportedExpenditures:
                    Add($"Number Of {FieldDefinitionEnum.ReportedExpenditure.ToType().GetFieldDefinitionLabel()} Records", x => projectDetailsDictionary[x.ProjectID].ProjectFundingSourceExpenditureCount, 100);
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
                    Add("# of Photos", x => projectDetailsDictionary[x.ProjectID].ProjectImageCount, 60);
                    break;
                case ProjectCustomGridColumnEnum.ProjectID:
                    Add(FieldDefinitionEnum.ProjectID.ToType().ToGridHeaderString(), x => x.ProjectID.ToString(), 140);
                    break;
                case ProjectCustomGridColumnEnum.ProjectLastUpdated:
                    Add(FieldDefinitionEnum.ProjectLastUpdated.ToType().ToGridHeaderString(), x => x.LastUpdatedDate, 140);
                    break;
                case ProjectCustomGridColumnEnum.ProjectStatus:
                    if (MultiTenantHelpers.GetTenantAttributeFromCache().UseProjectTimeline && userHasEditProjectAsAdminPermissions)
                    {
                        Add(FieldDefinitionEnum.Status.ToType().ToGridHeaderString()
                            , x => MakeProjectStatusAddLinkAndText(x, currentFirmaSession, projectDetailsDictionary[x.ProjectID], projectLabel, hasProjectApprovalPermissionBySession, statusUpdateLabel)
                            , 100
                            , DhtmlxGridColumnFilterType.SelectFilterHtmlStrict
                        );
                    }
                    break;
                case ProjectCustomGridColumnEnum.FinalStatusUpdateStatus:
                    if (MultiTenantHelpers.GetTenantAttributeFromCache().UseProjectTimeline && userHasEditProjectAsAdminPermissions)
                    {
                        Add(FieldDefinitionEnum.FinalStatusUpdateStatus.ToType().ToGridHeaderString()
                            , x => projectDetailsDictionary[x.ProjectID].FinalStatusReportStatusDescription
                            , 100
                            , DhtmlxGridColumnFilterType.SelectFilterStrict
                        );
                    }
                    break;
                case ProjectCustomGridColumnEnum.GeospatialAreaName:
                    break;
                case ProjectCustomGridColumnEnum.CustomAttribute:
                    break;
                case ProjectCustomGridColumnEnum.ProjectCategory:
                    if (MultiTenantHelpers.GetTenantAttributeFromCache().EnableProjectCategories)
                    {
                        Add(FieldDefinitionEnum.ProjectCategory.ToType().ToGridHeaderString(), x => x.ProjectCategory.ProjectCategoryDisplayName, 140, DhtmlxGridColumnFilterType.SelectFilterStrict);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void AddProjectCustomGridCustomAttributeField(ProjectCustomGridConfiguration projectCustomGridConfiguration, Dictionary<int, List<vProjectCustomAttributeValue>> projectCustomAttributeDictionary)
        {
            var projectCustomAttributeType = projectCustomGridConfiguration.ProjectCustomAttributeType;
            var isCurrency = projectCustomGridConfiguration.ProjectCustomAttributeType.MeasurementUnitTypeID == MeasurementUnitType.Dollars.MeasurementUnitTypeID;
            var gridHeaderHtmlString = ("<div>" 
                                    + LabelWithSugarForExtensions.GenerateHelpIconImgTag(projectCustomAttributeType.ProjectCustomAttributeTypeName, projectCustomAttributeType.ProjectCustomAttributeTypeDescription.ToHTMLFormattedString(), projectCustomAttributeType.GetDescriptionUrl(), 300, LabelWithSugarForExtensions.DisplayStyle.HelpIconOnly) 
                                    + projectCustomAttributeType.ProjectCustomAttributeTypeName 
                                    + "</div>").ToHTMLFormattedString();
            if (isCurrency)
            {
                Add($"{gridHeaderHtmlString}", a => TryParseDecimalCustomAttributeValue(a, projectCustomAttributeType, projectCustomAttributeDictionary), 150, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            }
            else
            {
                Add($"{gridHeaderHtmlString}", a => a.GetProjectCustomAttributesValue(projectCustomAttributeType, projectCustomAttributeDictionary), 150, DhtmlxGridColumnFilterType.Text);
            }
        }

        private static decimal? TryParseDecimalCustomAttributeValue(ProjectFirmaModels.Models.Project project, ProjectFirmaModels.Models.ProjectCustomAttributeType projectCustomAttributeType, Dictionary<int, List<vProjectCustomAttributeValue>> projectCustomAttributeDictionary)
        {
            if (Decimal.TryParse(project.GetProjectCustomAttributesValue(projectCustomAttributeType, projectCustomAttributeDictionary).ToString(), out var value))
            {
                return value;
            }

            if (projectCustomAttributeType.ProjectCustomAttributeGroup.ProjectCustomAttributeGroupProjectCategories.All(x => x.ProjectCategoryID != project.ProjectCategoryID))
            {
                return null;
            }
            return 0;
        }

        private void AddProjectCustomGridGeospatialAreaField(ProjectCustomGridConfiguration projectCustomGridConfiguration, Dictionary<int, vGeospatialArea> geospatialAreas, Dictionary<int, List<ProjectGeospatialArea>> projectGeospatialAreaDictionary)
        {
            var geospatialAreaType = projectCustomGridConfiguration.GeospatialAreaType;
            Add($"{geospatialAreaType.GeospatialAreaTypeNamePluralized}", a => a.GetProjectGeospatialAreaNamesAsHyperlinks(geospatialAreaType, geospatialAreas, projectGeospatialAreaDictionary), 350, DhtmlxGridColumnFilterType.Html);
        }

        public ProjectCustomGridSpec(FirmaSession currentFirmaSession,
            List<ProjectCustomGridConfiguration> projectCustomGridConfigurations,
            ProjectCustomGridTypeEnum projectCustomGridTypeEnum,
            Dictionary<int, vProjectDetail> projectDetailsDictionary,
            ProjectFirmaModels.Models.Tenant tenant)
        {
            var userHasTagManagePermissions = new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);
            var userHasDeletePermissions = new ProjectDeleteFeature().HasPermissionByFirmaSession(currentFirmaSession);
            var userHasEditProjectAsAdminPermissions = new ProjectEditAsAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);
            var userHasReportDownloadPermissions = new ReportTemplateViewListFeature().HasPermissionByFirmaSession(currentFirmaSession);
            var geospatialAreas = HttpRequestStorage.DatabaseEntities.vGeospatialAreas.Where(x => x.TenantID == tenant.TenantID).ToDictionary(x => x.GeospatialAreaID);
            var projectCustomAttributes = HttpRequestStorage.DatabaseEntities.vProjectCustomAttributeValues.Where(x => x.TenantID == tenant.TenantID)
                .GroupBy(x => x.ProjectID)
                .ToDictionary(grp => grp.Key, y => y.ToList());

            var projectGeospatialAreas = HttpRequestStorage.DatabaseEntities.ProjectGeospatialAreas
                .GroupBy(x => x.ProjectID).ToDictionary(grp => grp.Key, y => y.ToList());
            var taxonomyLeafs = HttpRequestStorage.DatabaseEntities.TaxonomyLeafs.ToDictionary(x => x.TaxonomyLeafID);
            var projectLabel = FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel();
            var hasProjectApprovalPermissionBySession =
                new ProjectApproveFeature().HasPermissionByFirmaSession(currentFirmaSession);
            var statusUpdateLabel = FieldDefinitionEnum.StatusUpdate.ToType().GetFieldDefinitionLabel();

            // Mandatory fields before
            AddMandatoryFieldsBefore(userHasTagManagePermissions, userHasReportDownloadPermissions, userHasDeletePermissions, projectCustomGridTypeEnum);
            
            // Implement configured fields here
            AddConfiguredFields(currentFirmaSession
                , projectCustomGridConfigurations
                , userHasEditProjectAsAdminPermissions
                , projectDetailsDictionary
                , geospatialAreas
                , taxonomyLeafs
                , projectGeospatialAreas
                , projectCustomAttributes
                , projectLabel
                , hasProjectApprovalPermissionBySession
                , statusUpdateLabel);

            // Mandatory fields appearing AFTER configurable fields
            AddMandatoryFieldsAfter(userHasTagManagePermissions);
            
        }

        private void AddConfiguredFields(FirmaSession currentFirmaSession
            , List<ProjectCustomGridConfiguration> projectCustomGridConfigurations
            , bool userHasEditProjectAsAdminPermissions
            , Dictionary<int, vProjectDetail> projectDetailsDictionary
            , Dictionary<int, ProjectFirmaModels.Models.vGeospatialArea> geospatialAreaDictionary
            , Dictionary<int, ProjectFirmaModels.Models.TaxonomyLeaf> taxonomyLeafDictionary
            , Dictionary<int, List<ProjectFirmaModels.Models.ProjectGeospatialArea>> projectGeospatialAreaDictionary
            , Dictionary<int, List<ProjectFirmaModels.Models.vProjectCustomAttributeValue>> projectCustomAttributeDictionary
            , string projectLabel
            , bool hasProjectApprovalPermissionBySession
            , string statusUpdateLabel)
        {
            
            foreach (var projectCustomGridConfiguration in projectCustomGridConfigurations.OrderBy(x => x.SortOrder))
            {
                if (projectCustomGridConfiguration.ProjectCustomAttributeType != null)
                {
                    if (projectCustomGridConfiguration.ProjectCustomAttributeType.HasViewPermission(currentFirmaSession))
                    {
                        AddProjectCustomGridCustomAttributeField(projectCustomGridConfiguration, projectCustomAttributeDictionary);
                    }
                }
                else if (projectCustomGridConfiguration.GeospatialAreaType != null)
                {
                    AddProjectCustomGridGeospatialAreaField(projectCustomGridConfiguration, geospatialAreaDictionary, projectGeospatialAreaDictionary);
                }
                else
                {
                    AddProjectCustomGridField(currentFirmaSession, projectCustomGridConfiguration,
                        userHasEditProjectAsAdminPermissions
                        , projectDetailsDictionary
                        , taxonomyLeafDictionary
                        , projectLabel
                        , hasProjectApprovalPermissionBySession
                        , statusUpdateLabel);
                }
            }
        }

        private void AddMandatoryFieldsBefore(bool userHasTagManagePermissions, bool userHasReportDownloadPermissions,
            bool userHasDeletePermissions, ProjectCustomGridTypeEnum projectCustomGridTypeEnum)
        {
            switch (projectCustomGridTypeEnum)
            {
                case ProjectCustomGridTypeEnum.Default:
                case ProjectCustomGridTypeEnum.Full:
                    if (userHasTagManagePermissions)
                    {
                        BulkTagModalDialogForm = new BulkTagModalDialogForm(
                            SitkaRoute<TagController>.BuildUrlFromExpression(x => x.BulkTagProjects(null)),
                            $"Tag Checked {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}",
                            $"Tag {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}");
                    }
                    if (userHasTagManagePermissions)
                    {
                        AddCheckBoxColumn();
                        Add("ProjectID", x => x.ProjectID, 0);
                    }
                    if (userHasDeletePermissions)
                    {
                        Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true), 30,
                            DhtmlxGridColumnFilterType.None);
                    }
                    Add(string.Empty,
                        x => UrlTemplate.MakeHrefString(x.GetFactSheetUrl(),
                            FirmaDhtmlxGridHtmlHelpers.FactSheetIcon.ToString() +
                            $"<span class=\"sr-only\">Download the Fact Sheet for {x.ProjectName}</span>"), 30,
                        DhtmlxGridColumnFilterType.None);
                    break;
                case ProjectCustomGridTypeEnum.Reports:
                    if (userHasReportDownloadPermissions)
                    {
                        GenerateReportModalDialogForm = new SelectProjectsModalDialogForm(
                            SitkaRoute<ReportsController>.BuildUrlFromExpression(x =>
                                x.SelectReportToGenerateFromSelectedProjects()), $"Generate Reports", $"Confirm Report Generation");
                    }
                    AddCheckBoxColumn();
                    Add("ProjectID", x => x.ProjectID, 0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(projectCustomGridTypeEnum), projectCustomGridTypeEnum, null);
            }
        }

        private void AddMandatoryFieldsAfter(bool userHasTagManagePermissions)
        {
            if (userHasTagManagePermissions)
            {
                Add("Tags",
                    x => new HtmlString(!x.ProjectTags.Any()
                        ? string.Empty
                        : string.Join(", ", x.ProjectTags.Select(pt => pt.Tag.GetDisplayNameAsUrl()))), 100,
                    DhtmlxGridColumnFilterType.Html);
            }
        }
    }
}
