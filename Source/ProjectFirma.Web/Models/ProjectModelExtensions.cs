﻿/*-----------------------------------------------------------------------
<copyright file="ProjectModelExtensions.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using GeoJSON.Net.Feature;
using LtInfo.Common;
using LtInfo.Common.GeoJson;
using LtInfo.Common.Models;
using LtInfo.Common.Views;
using MoreLinq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ProjectUpdate;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Drawing;
using System.EnterpriseServices.Internal;
using System.Globalization;
using System.Linq;
using System.Web;
using ProjectCustomAttributesValidationResult = ProjectFirma.Web.Views.ProjectCreate.ProjectCustomAttributesValidationResult;

namespace ProjectFirma.Web.Models
{
    public static class ProjectModelExtensions
    {
        public const int MaxLengthForProjectDescription = 700;
        public static readonly UrlTemplate<int> DetailUrlTemplate = new UrlTemplate<int>(SitkaRoute<ProjectController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int)));
        public static readonly UrlTemplate<int> DetailAbsoluteUrlTemplate = new UrlTemplate<int>(SitkaRoute<ProjectController>.BuildAbsoluteUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int)));
        public static string GetDetailUrl(this Project project)
        {
            return DetailUrlTemplate.ParameterReplace(project.ProjectID);
        }

        public static string GetProjectDetailUrl(this vProjectAttachment projectAttachment)
        {
            return DetailUrlTemplate.ParameterReplace(projectAttachment.ProjectID);
        }

        public static string GetDetailAbsoluteUrl(this Project project)
        {
            return DetailAbsoluteUrlTemplate.ParameterReplace(project.ProjectID);
        }

        public static readonly UrlTemplate<int> EditUrlTemplate = new UrlTemplate<int>(SitkaRoute<ProjectController>.BuildUrlFromExpression(t => t.Edit(UrlTemplate.Parameter1Int)));
        public static string GetEditUrl(this Project project)
        {
            return project.IsProposal() ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(t => t.EditBasics(project.ProjectID)) : EditUrlTemplate.ParameterReplace(project.ProjectID);
        }

        public static readonly UrlTemplate<int> ProjectCreateUrlTemplate = new UrlTemplate<int>(SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(t => t.EditBasics(UrlTemplate.Parameter1Int)));
        public static string GetProjectCreateUrl(this Project project)
        {
            return ProjectCreateUrlTemplate.ParameterReplace(project.ProjectID);
        }

        public static readonly UrlTemplate<int> FactSheetUrlTemplate = new UrlTemplate<int>(SitkaRoute<ProjectController>.BuildUrlFromExpression(t => t.FactSheet(UrlTemplate.Parameter1Int)));
        public static string GetFactSheetUrl(this Project project)
        {
            return FactSheetUrlTemplate.ParameterReplace(project.ProjectID);
        }

        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(SitkaRoute<ProjectController>.BuildUrlFromExpression(t => t.DeleteProject(UrlTemplate.Parameter1Int)));
        public static string GetDeleteUrl(this Project project)
        {
            return DeleteUrlTemplate.ParameterReplace(project.ProjectID);
        }

        public static readonly UrlTemplate<int> AddProjectProjectStatusUrlTemplate = new UrlTemplate<int>(SitkaRoute<ProjectProjectStatusController>.BuildUrlFromExpression(t => t.New(UrlTemplate.Parameter1Int)));
        public static string GetAddProjectProjectStatusUrl(this Project project)
        {
            return AddProjectProjectStatusUrlTemplate.ParameterReplace(project.ProjectID);
        }

        public static readonly UrlTemplate<int> AddProjectProjectStatusFromGridUrlTemplate = new UrlTemplate<int>(SitkaRoute<ProjectProjectStatusController>.BuildUrlFromExpression(t => t.NewFromGrid(UrlTemplate.Parameter1Int)));
        public static string GetAddProjectProjectStatusFromGridUrl(this Project project)
        {
            return AddProjectProjectStatusFromGridUrlTemplate.ParameterReplace(project.ProjectID);
        }

        public static readonly UrlTemplate<int> DeleteProposalUrlTemplate = new UrlTemplate<int>(SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(t => t.DeleteProjectProposal(UrlTemplate.Parameter1Int)));
        public static string GetDeleteProposalUrl(this Project project)
        {
            return DeleteProposalUrlTemplate.ParameterReplace(project.ProjectID);
        }

        public static readonly UrlTemplate<int> ProjectUpdateUrlTemplate = new UrlTemplate<int>(SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(t => t.Instructions(UrlTemplate.Parameter1Int)));
        public static string GetProjectUpdateUrl(this Project project)
        {
            return ProjectUpdateUrlTemplate.ParameterReplace(project.ProjectID);
        }

        public static readonly UrlTemplate<int> ProjectMapPopuUrlTemplate = new UrlTemplate<int>(SitkaRoute<ProjectController>.BuildUrlFromExpression(t => t.ProjectMapPopup(UrlTemplate.Parameter1Int)));
        public static string GetProjectMapPopupUrl(this Project project)
        {
            return ProjectMapPopuUrlTemplate.ParameterReplace(project.ProjectID);
        }

        public static readonly UrlTemplate<int> ProjectMapSimplePopuUrlTemplate = new UrlTemplate<int>(SitkaRoute<ProjectController>.BuildUrlFromExpression(t => t.ProjectSimpleMapPopup(UrlTemplate.Parameter1Int)));
        public static string GetProjectSimpleMapPopupUrl(this Project project)
        {
            return ProjectMapSimplePopuUrlTemplate.ParameterReplace(project.ProjectID);
        }

        /// <summary>
        /// Does the given user have full edit rights / possession of the given Project?
        /// </summary>
        /// <param name="project"></param>
        /// <param name="currentFirmaSession"></param>
        /// <returns></returns>
        public static bool IsMyProject(this Project project, FirmaSession currentFirmaSession)
        {
            if (currentFirmaSession.IsAnonymousUser())
            {
                return false;
            }

            bool isPersonThePrimaryContact = project.IsPersonThePrimaryContact(currentFirmaSession.Person);
            bool isPersonContactThatCanManageProject = project.IsPersonContactThatCanManageProject(currentFirmaSession.Person);
            bool isProjectInPersonsOrganization = currentFirmaSession.Person.Organization.IsMyProject(project);
            bool userHasProjectStewardPermissionsForProject = currentFirmaSession.Person.PersonStewardOrganizations.Any(x => x.Organization.IsMyProject(project));

            bool isUsersProject = isPersonThePrimaryContact || isPersonContactThatCanManageProject || isProjectInPersonsOrganization || userHasProjectStewardPermissionsForProject;

            return isUsersProject;
        }

        // Keep this function 100% aligned with IsMyProject(Project project) for consistency!!!
        public static bool IsMyProject(this vProjectDetail projectDetail, FirmaSession currentFirmaSession)
        {
            var personID = currentFirmaSession.PersonID;
            var isPrimaryContact = projectDetail.PrimaryContactPersonID == personID;

            var contactsWhoCanManageProject = projectDetail.ProjectContactsWhoCanManageProjectConcatenated?.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x.Trim())).ToList();
            var isPersonContactThatCanManageProject = personID.HasValue && contactsWhoCanManageProject != null && contactsWhoCanManageProject.Contains(personID.Value);

            return !currentFirmaSession.IsAnonymousUser() && (isPrimaryContact || isPersonContactThatCanManageProject || currentFirmaSession.Person.Organization.IsMyProject(projectDetail) || currentFirmaSession.Person.PersonStewardOrganizations.Any(x => x.Organization.IsMyProject(projectDetail)));
        }

        public static List<int> GetProjectUpdateImplementationStartToCompletionYearRange(this IProject projectUpdate)
        {
            var startYear = projectUpdate?.ImplementationStartYear;
            return GetYearRangesImpl(projectUpdate, startYear);
        }




        public static List<int> GetProjectUpdatePlanningDesignStartToCompletionYearRange(this IProject projectUpdate)
        {
            var startYear = projectUpdate?.PlanningDesignStartYear;
            return GetYearRangesImpl(projectUpdate, startYear);
        }

        public static List<ProjectExemptReportingYear> GetPerformanceMeasuresExemptReportingYears(this Project project)
        {
            return project.ProjectExemptReportingYears
                .Where(x => x.ProjectExemptReportingType == ProjectExemptReportingType.PerformanceMeasures)
                .OrderBy(x => x.CalendarYear).ToList();
        }

        public static List<ProjectRelevantCostType> GetBudgetsRelevantCostTypes(this Project project)
        {
            return project.ProjectRelevantCostTypes
                .Where(x => x.ProjectRelevantCostTypeGroup == ProjectRelevantCostTypeGroup.Budgets)
                .OrderBy(x => x.CostTypeID).ToList();
        }
        public static List<ProjectRelevantCostType> GetExpendituresRelevantCostTypes(this Project project)
        {
            return project.ProjectRelevantCostTypes
                .Where(x => x.ProjectRelevantCostTypeGroup == ProjectRelevantCostTypeGroup.Expenditures)
                .OrderBy(x => x.CostTypeID).ToList();
        }

        private static List<int> GetYearRangesImpl(IProject projectUpdate, int? startYear)
        {
            var currentYearToUse = FirmaDateUtilities.CalculateCurrentYearToUseForUpToAllowableInputInReporting();
            if (projectUpdate != null)
            {
                if (startYear.HasValue && startYear.Value < MultiTenantHelpers.GetMinimumYear() &&
                    (projectUpdate.CompletionYear.HasValue && projectUpdate.CompletionYear.Value < MultiTenantHelpers.GetMinimumYear()))
                {
                    // both start and completion year are before the minimum year, so no year range required
                    return new List<int>();
                }

                if (startYear.HasValue && startYear.Value > currentYearToUse && (projectUpdate.CompletionYear.HasValue && projectUpdate.CompletionYear.Value > currentYearToUse))
                {
                    return new List<int>();
                }

                if (startYear.HasValue && projectUpdate.CompletionYear.HasValue && startYear.Value > projectUpdate.CompletionYear.Value)
                {
                    return new List<int>();
                }
            }
            return FirmaDateUtilities.CalculateCalendarYearRangeAccountingForExistingYears(new List<int>(),
                startYear,
                projectUpdate?.CompletionYear,
                currentYearToUse,
                MultiTenantHelpers.GetMinimumYear(),
                currentYearToUse);
        }

        /// <summary>
        /// Returns the organizations that appear in this project's Expected Funding or Reported Funding
        /// Returns as ProjectOrganization with a dummy "Funder" RelationshipType, which lives as a static property of the RelationshipType class
        /// </summary>
        /// <returns></returns>
        public static List<ProjectOrganizationRelationship> GetFundingOrganizations(this Project project, bool excludeTargetedFunders)
        {
            var fundingOrganizations = project.ProjectFundingSourceExpenditures.Select(x => x.FundingSource.Organization)
                .Union(project.ProjectFundingSourceBudgets.Where(x => (excludeTargetedFunders && x.SecuredAmount > 0) || !excludeTargetedFunders).Select(x => x.FundingSource.Organization), new HavePrimaryKeyComparer<Organization>())
                .Select(x => new ProjectOrganizationRelationship(project, x, OrganizationRelationshipTypeModelExtensions.OrganizationRelationshipTypeNameFunder));
            return fundingOrganizations.ToList();
        }

        public static List<FundingSource> GetFundingSources(this Project project, bool excludeTargetedFunders)
        {
            var fundingOrganizations = project.ProjectFundingSourceExpenditures.Select(x => x.FundingSource)
                .Union(project.ProjectFundingSourceBudgets.Where(x => (excludeTargetedFunders && x.SecuredAmount > 0) || !excludeTargetedFunders).Select(x => x.FundingSource), new HavePrimaryKeyComparer<FundingSource>());
            return fundingOrganizations.OrderBy(x => x.FundingSourceName).ToList();
        }


        public static List<Organization> GetAssociatedOrganizations(this Project project)
        {
            var explicitOrganizations = project.ProjectOrganizations.Select(x => new ProjectOrganizationRelationship(project, x.Organization, x.OrganizationRelationshipType)).ToList();
            explicitOrganizations.AddRange(project.GetFundingOrganizations(false));
            return explicitOrganizations.Select(x => x.Organization).Distinct(new HavePrimaryKeyComparer<Organization>()).ToList();
        }

        public static List<ProjectOrganizationRelationship> GetAssociatedOrganizationRelationships(this Project project)
        {
            return project.GetAssociatedOrganizationRelationships(false);
        }

        public static List<ProjectOrganizationRelationship> GetAssociatedOrganizationRelationships(this Project project, bool excludeTargetedFunders)
        {
            var explicitOrganizations = project.ProjectOrganizations.Select(x => new ProjectOrganizationRelationship(project, x.Organization, x.OrganizationRelationshipType)).ToList();
            explicitOrganizations.AddRange(project.GetFundingOrganizations(excludeTargetedFunders));
            return explicitOrganizations;
        }

        public static List<ProjectContactRelationship> GetAssociatedContactRelationships(this Project project)
        {
            var contacts = project.ProjectContacts.Select(x => new ProjectContactRelationship(project, x.Contact, x.ContactRelationshipType)).ToList();
            return contacts;
        }

        public static bool IsProjectNameUnique(IEnumerable<Project> projects, string projectName, int? currentProjectID)
        {
            if (String.IsNullOrWhiteSpace(projectName))
            {
                return false;
            }
            var project = projects.SingleOrDefault(x => x.ProjectID != (currentProjectID ?? 0) && String.Equals(x.ProjectName.Trim(), projectName.Trim(), StringComparison.InvariantCultureIgnoreCase));
            return project == null;
        }

        public static GeospatialAreaValidationResult ValidateProjectGeospatialArea(this GeospatialAreaType geospatialAreaType, Project project)
        {
            var projectGeospatialAreaTypeNoteUpdate = project.ProjectGeospatialAreaTypeNotes.SingleOrDefault(x => x.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID);
            var incomplete = project.ProjectGeospatialAreas.All(x => x.GeospatialArea.GeospatialAreaTypeID != geospatialAreaType.GeospatialAreaTypeID) && projectGeospatialAreaTypeNoteUpdate == null;
            return new GeospatialAreaValidationResult(incomplete, geospatialAreaType);
        }

        public static bool IsProjectGeospatialAreaValid(this GeospatialAreaType geospatialAreaType, Project project)
        {
            return geospatialAreaType.ValidateProjectGeospatialArea(project).IsValid;
        }

        public static FeatureCollection MappedPointsToGeoJsonFeatureCollection(this List<Project> projects, bool includePrivateLocations,
            bool addProjectProperties, bool useDetailedCustomPopup)
        {
            var featureCollection = new FeatureCollection();
            var filteredProjectList = projects.Where(x1 => x1.HasProjectLocationPoint(includePrivateLocations)).Where(x => x.ProjectStage.ShouldShowOnMap()).ToList();
            featureCollection.Features.AddRange(filteredProjectList.Select(project => project.MakePointFeatureWithRelevantProperties(project.GetProjectLocationPoint(true),
                addProjectProperties, useDetailedCustomPopup)).ToList());
            return featureCollection;
        }

        /// <summary>
        /// Note this will do a deep delete of this project image, meaning it will remove it from a ProjectImageUpdate if it is tied to that
        /// </summary>
        public static void DeleteProjectImages(this Project project)
        {
            foreach (var fileResourceInfo in project.ProjectImages.Select(x => x.FileResourceInfo))
            {
                fileResourceInfo.DeleteFull(HttpRequestStorage.DatabaseEntities);
            }
        }

        public static List<ProjectSectionSimple> GetApplicableProposalWizardSections(this Project project, bool ignoreStatus, bool hasEditableCustomAttributes)
        {
            var projectWorkflowSectionGroupings = ProjectWorkflowSectionGrouping.All;
            if (!MultiTenantHelpers.TrackAccomplishments())
            {
                projectWorkflowSectionGroupings = projectWorkflowSectionGroupings.Where(x => x != ProjectWorkflowSectionGrouping.Accomplishments).ToList();
            }
            if (!MultiTenantHelpers.ReportFinancialsAtProjectLevel())
            {
                projectWorkflowSectionGroupings = projectWorkflowSectionGroupings.Where(x => x != ProjectWorkflowSectionGrouping.Financials).ToList();
            }
            return projectWorkflowSectionGroupings.SelectMany(x => x.GetProjectCreateSections(project, ignoreStatus, hasEditableCustomAttributes)).OrderBy(x => x.ProjectWorkflowSectionGrouping.SortOrder).ThenBy(x => x.SortOrder).ToList();
        }

        public static IEnumerable<Organization> GetOrganizationsToReportInAccomplishments(this Project project)
        {
            if (MultiTenantHelpers.GetOrganizationRelationshipTypeToReportInAccomplishmentsDashboard() == null)
            {
                // Default is Funding Organizations
                var organizations = project.ProjectFundingSourceExpenditures.Select(x => x.FundingSource.Organization)
                    .Union(project.ProjectFundingSourceBudgets.Select(x => x.FundingSource.Organization))
                    .Distinct(new HavePrimaryKeyComparer<Organization>());
                return organizations;
            }

            return project.ProjectOrganizations.Where(x => x.OrganizationRelationshipType.ReportInAccomplishmentsDashboard)
                .Select(x => x.Organization).ToList();
        }

        public static ProjectUpdateState GetLatestUpdateState(this Project project)
        {
            if (!project.ProjectUpdateBatches.Any())
                return null;

            if (project.ProjectUpdateBatches.Count(x => x.ProjectUpdateState != ProjectUpdateState.Approved) > 1)
                throw new Exception(FirmaValidationMessages.MoreThanOneProjectUpdateInProgress);

            return project.ProjectUpdateBatches.OrderByDescending(x => x.LastUpdateDate).First().ProjectUpdateState;
        }

        public static ProjectUpdateState GetLatestUpdateStateResilientToDuplicateUpdateBatches(this Project project)
        {
            if (!project.ProjectUpdateBatches.Any())
                return null;

            return project.ProjectUpdateBatches.OrderByDescending(x => x.LastUpdateDate).First().ProjectUpdateState;
        }

        public static string GetProjectLocationStateProvince(this Project project)
        {
            if (project.HasProjectLocationPoint(true))  // User doesn't need permission to view location point here since it's only being used to get the state
            {
                var stateProvince = HttpRequestStorage.DatabaseEntities.StateProvinces.ToList().
                    FirstOrDefault(x => x.StateProvinceFeatureForAnalysis.Intersects(project.GetProjectLocationPoint(true)));
                return stateProvince != null ? stateProvince.StateProvinceAbbreviation : ViewUtilities.NaString;
            }

            return ViewUtilities.NaString;
        }

        public static List<PerformanceMeasureReportedValue> GetPerformanceMeasureReportedValues(this Project project)
        {
            var reportedPerformanceMeasures = project.GetNonVirtualPerformanceMeasureReportedValues();
            return reportedPerformanceMeasures.OrderByDescending<PerformanceMeasureReportedValue, int>(pma => pma.CalendarYear).ThenBy(pma => pma.PerformanceMeasureID).ToList();
        }

        public static string GetPlanningDesignStartYear(Project project)
        {
            return project.PlanningDesignStartYear.HasValue ? MultiTenantHelpers.FormatReportingYear(project.PlanningDesignStartYear.Value) : null;
        }

        public static string GetCompletionYear(Project project)
        {
            return project.CompletionYear.HasValue ? MultiTenantHelpers.FormatReportingYear(project.CompletionYear.Value) : null;
        }

        public static string GetImplementationStartYear(Project project)
        {
            return project.ImplementationStartYear.HasValue ? MultiTenantHelpers.FormatReportingYear(project.ImplementationStartYear.Value) : null;
        }

        public static int? StartYearForTotalCostCalculations(this IProject project)
        {
            return project.ImplementationStartYear.HasValue && project.ImplementationStartYear < DateTime.Now.Year
                ? DateTime.Now.Year
                : project.ImplementationStartYear;
        }

        public static List<GooglePieChartSlice> GetExpenditureGooglePieChartSlices(Project project)
        {
            var sortOrder = 0;
            var googlePieChartSlices = new List<GooglePieChartSlice>();
            var expendituresDictionary = project.ProjectFundingSourceExpenditures.Where(x => x.ExpenditureAmount > 0)
                .GroupBy(x => x.FundingSource, new HavePrimaryKeyComparer<FundingSource>())
                .ToDictionary(x => x.Key, x => x.Sum(y => y.ExpenditureAmount));

            var groupingFundingSources = expendituresDictionary.Keys.GroupBy(x => x.Organization.OrganizationType, new HavePrimaryKeyComparer<OrganizationType>());
            foreach (var groupingFundingSource in groupingFundingSources)
            {
                var sectorColor = ColorTranslator.FromHtml(groupingFundingSource.Key.LegendColor);
                var sectorColorHsl = new HslColor(sectorColor.R, sectorColor.G, sectorColor.B);

                var pieChartSlices = groupingFundingSource.OrderBy(x => x.FundingSourceName).Select((fundingSource, index) =>
                {
                    var luminosity = 100.0 * (groupingFundingSource.Count() - index - 1) /
                                     groupingFundingSource.Count() + 120;
                    var color = ColorTranslator.ToHtml(new HslColor(sectorColorHsl.Hue, sectorColorHsl.Saturation,
                        luminosity));

                    return new GooglePieChartSlice(fundingSource.GetFixedLengthDisplayName(),
                        Convert.ToDouble(expendituresDictionary[fundingSource]), sortOrder++, color);
                }).ToList();
                googlePieChartSlices.AddRange(pieChartSlices);
            }
            return googlePieChartSlices;
        }

        public static List<GooglePieChartSlice> GetFundingSourceRequestGooglePieChartSlices(this Project project)
        {
            var sortOrder = 0;
            var googlePieChartSlices = new List<GooglePieChartSlice>();

            var securedAmountsDictionary = project.ProjectFundingSourceBudgets.Where(x => x.SecuredAmount > 0)
                .GroupBy(x => x.FundingSource, new HavePrimaryKeyComparer<FundingSource>())
                .ToDictionary(x => x.Key, x => x.Sum(y => y.SecuredAmount));
            var targetedAmountsDictionary = project.ProjectFundingSourceBudgets.Where(x => x.TargetedAmount > 0)
                .GroupBy(x => x.FundingSource, new HavePrimaryKeyComparer<FundingSource>())
                .ToDictionary(x => x.Key, x => x.Sum(y => y.TargetedAmount));

            var securedColorHsl = new { hue = 96.0, sat = 60.0 };
            var targetedColorHsl = new { hue = 33.3, sat = 240.0 };

            var showFullName = (securedAmountsDictionary.Count + targetedAmountsDictionary.Count) <= 2;

            var securedPieChartSlices = securedAmountsDictionary.OrderBy(x => x.Key.FundingSourceName).Select((fundingSourceDictionaryItem, index) =>
            {
                var fundingSource = fundingSourceDictionaryItem.Key;
                var fundingAmount = fundingSourceDictionaryItem.Value;
                var displayName = showFullName
                    ? fundingSource.GetDisplayName()
                    : fundingSource.GetFixedLengthDisplayName();

                var luminosity = 100.0 * (securedAmountsDictionary.Count - index - 1) / securedAmountsDictionary.Count + 120;
                var color = ColorTranslator.ToHtml(new HslColor(securedColorHsl.hue, securedColorHsl.sat, luminosity));
                return new GooglePieChartSlice(@FieldDefinitionEnum.SecuredFunding.ToType().GetFieldDefinitionLabel() + ": " + displayName, Convert.ToDouble(fundingAmount), sortOrder++, color);

            }).ToList();
            googlePieChartSlices.AddRange(securedPieChartSlices);

            var targetedPieChartSlices = targetedAmountsDictionary.OrderBy(x => x.Key.FundingSourceName).Select((fundingSourceDictionaryItem, index) =>
            {
                var fundingSource = fundingSourceDictionaryItem.Key;
                var fundingAmount = fundingSourceDictionaryItem.Value;
                var displayName = showFullName
                    ? fundingSource.GetDisplayName()
                    : fundingSource.GetFixedLengthDisplayName();

                var luminosity = 100.0 * (targetedAmountsDictionary.Count - index - 1) / targetedAmountsDictionary.Count + 120;
                var color = ColorTranslator.ToHtml(new HslColor(targetedColorHsl.hue, targetedColorHsl.sat, luminosity));
                return new GooglePieChartSlice(@FieldDefinitionEnum.TargetedFunding.ToType().GetFieldDefinitionLabel() + ": " + displayName, Convert.ToDouble(fundingAmount), sortOrder++, color);
            }).ToList();
            googlePieChartSlices.AddRange(targetedPieChartSlices);

            return googlePieChartSlices;
        }

        public static List<GooglePieChartSlice> GetRequestAmountGooglePieChartSlices(this Project project)
        {
            var requestAmountsDictionary = project.GetFundingSourceRequestGooglePieChartSlices();
            var noFundingSourceIdentifiedAmount = Convert.ToDouble(project.GetNoFundingSourceIdentifiedAmount() ?? 0);
            if (noFundingSourceIdentifiedAmount > 0)
            {
                var sortOrder = requestAmountsDictionary.Any() ? requestAmountsDictionary.Max(x => x.SortOrder) + 1 : 0;
                requestAmountsDictionary.Add(new GooglePieChartSlice(FieldDefinitionEnum.NoFundingSourceIdentified.ToType().GetFieldDefinitionLabel(), noFundingSourceIdentifiedAmount, sortOrder, "#dbdbdb"));
            }
            return requestAmountsDictionary;
        }

        public static decimal GetEstimatedTotalCost(this Project project)
        {
            return project.GetEstimatedTotalRegardlessOfFundingType() ?? 0;
        }

        public static decimal? CalculateTotalRemainingOperatingCost(this IProject project)
        {
            if (!project.CanCalculateTotalRemainingOperatingCostInYearOfExpenditure())
            {
                return null;
            }

            var startYearForRemaining = project.ImplementationStartYear.Value >= DateTime.Now.Year ? project.ImplementationStartYear.Value : DateTime.Now.Year;
            return (project.CompletionYear.Value - startYearForRemaining + 1) * project.GetEstimatedTotalRegardlessOfFundingType().Value;
        }

        public static bool CanCalculateTotalRemainingOperatingCostInYearOfExpenditure(this IProject project)
        {
            return project.FundingType == FundingType.BudgetSameEachYear
                   && project.GetEstimatedTotalRegardlessOfFundingType().HasValue
                   && project.CompletionYear.HasValue
                   && project.ImplementationStartYear.HasValue
                   && project.ProjectStage.IsStageIncludedInCostCalculations();
        }

        public static bool IsEditableToThisFirmaSession(this Project project, FirmaSession firmaSession)
        {
            return project.IsMyProject(firmaSession) || new ProjectApproveFeature().HasPermission(firmaSession, project).HasPermission;
        }

        public static bool IsEditableToThisFirmaSession(this Project project, FirmaSession firmaSession, vProjectDetail projectDetail, string projectLabel, bool hasPermissionBySession)
        {
            bool userCanDoProjectApproval = new ProjectApproveFeature().HasPermission(firmaSession, project, projectLabel, hasPermissionBySession).HasPermission;
            bool userHasEditRightsToProject = projectDetail.IsMyProject(firmaSession);

            return userHasEditRightsToProject || userCanDoProjectApproval;
        }

        public static HtmlString GetDisplayNameAsUrl(this Project project) => UrlTemplate.MakeHrefString(project.GetDetailUrl(), project.GetDisplayName());

        public static List<Person> GetPrimaryContactPeople(this IList<Project> projects)
        {
            return projects.Where(x => x.GetPrimaryContact() != null).Select(x => x.GetPrimaryContact()).Distinct(new HavePrimaryKeyComparer<Person>()).ToList();
        }

        public static List<Project> GetProjectFindResultsForProjectNameAndDescriptionAndNumber(this IQueryable<Project> projects, string projectKeyword)
        {
            return
                projects.Where(x => x.ProjectName.Contains(projectKeyword) || x.ProjectDescription.Contains(projectKeyword))
                    .OrderBy(x => x.ProjectName)
                    .ToList();
        }

        public static List<Project> GetActiveProjectsAndProposals(this IList<Project> projects, bool showProposals,
            FirmaSession firmaSession)
        {
            var activeProjects = projects.GetActiveProjects();
            var activeProposalsAndPendingProjects = projects.GetActiveProposalsAndPendingProjects(showProposals, firmaSession);
            return activeProjects.Union(activeProposalsAndPendingProjects, new HavePrimaryKeyComparer<Project>()).OrderBy(x => x.GetDisplayName()).ToList();
        }

        public static List<Project> GetActiveProjects(this IList<Project> projects)
        {
            return projects.Where(x => x.IsActiveProject()).OrderBy(x => x.GetDisplayName()).ToList();
        }

        public static List<Project> GetActiveProposalsAndPendingProjects(this IList<Project> projects, bool showProposals,
            FirmaSession firmaSession)
        {
            if (!showProposals)
            {
                return new List<Project>();
            }

            var proposalsAndPendingProjects = projects.GetProposalsVisibleToUser(firmaSession).Where(x => x.IsActiveProposal()).ToList();
            proposalsAndPendingProjects.AddRange(projects.GetPendingProjectsVisibleToUser(firmaSession).Where(x => x.IsActivePendingProject()));

            return proposalsAndPendingProjects.OrderBy(x => x.GetDisplayName()).ToList();
        }


        public static List<Project> GetProposalsVisibleToUser(this IList<Project> projects, FirmaSession firmaSession)
        {
            return projects.Where(x => x.IsProposal() && new ProjectViewFeature().HasPermission(firmaSession, x).HasPermission).ToList();
        }

        public static List<Project> GetPendingProjectsVisibleToUser(this IList<Project> projects, FirmaSession firmaSession)
        {
            return projects.Where(x => x.IsPendingProject() && new ProjectViewFeature().HasPermission(firmaSession, x).HasPermission).ToList();
        }

        public static List<Project> GetUpdatableProjectsThatHaveNotBeenSubmittedForBackgroundJob(this IQueryable<Project> projects, int tenantID)
        {
            return projects.GetUpdatableProjectsForBackgroundJob(tenantID).Where(x => x.GetLatestUpdateState() != ProjectUpdateState.Submitted).ToList();
        }

        public static List<Project> GetUpdatableProjectsForBackgroundJob(this IQueryable<Project> projects, int tenantID)
        {
            return projects.Where(x => x.IsUpdateMandatoryForBackgroundJob(tenantID)).ToList();
        }

        public static bool IsForwardLookingFactSheetRelevant(this Project project)
        {
            return ProjectStage.ForwardLookingFactSheetProjectStages.Contains(project.ProjectStage);
        }

        public static bool IsBackwardLookingFactSheetRelevant(this Project project)
        {
            return !project.IsForwardLookingFactSheetRelevant();
        }

        public static bool IsExpectedFundingRelevant(this Project project)
        {
            // todo: Always relevant for pending projects, otherwise relevant for every stage except terminated/completed
            return true;
        }

        public static bool AreReportedPerformanceMeasuresRelevant(this Project project)
        {
            return project.ProjectStage != ProjectStage.Proposal && project.ProjectStage != ProjectStage.PlanningDesign;
        }

        public static bool AreReportedExpendituresRelevant(this Project project)
        {
            return project.ProjectStage != ProjectStage.Proposal;
        }

        public static DateTime? GetLatestUpdateSubmittalDate(this Project project)
        {
            var notNullSubmittalDates = project.ProjectUpdateBatches.Select(x => x.GetLatestSubmittalDate()).Where(x => x.HasValue).ToList();
            return notNullSubmittalDates.Any() ? notNullSubmittalDates.Max() : null;
        }

        public static Person GetLatestUpdateSubmittalPerson(this Project project)
        {
            var latestSubmittals = project.ProjectUpdateBatches.Select(x => x.GetLatestProjectUpdateHistorySubmitted()).Where(x => x != null).ToList();
            return latestSubmittals.Any() ? latestSubmittals.OrderByDescending(x => x.TransitionDate).First().UpdatePerson : null;
        }

        public static string GetProjectCustomAttributesValue(this Project project, ProjectCustomAttributeType projectCustomAttributeType)
        {
            var projectCustomAttribute = project.ProjectCustomAttributes.SingleOrDefault(x => x.ProjectCustomAttributeTypeID == projectCustomAttributeType.ProjectCustomAttributeTypeID);
            if (projectCustomAttribute != null)
            {
                if (projectCustomAttributeType.ProjectCustomAttributeDataType == ProjectCustomAttributeDataType.DateTime)
                {
                    return DateTime.TryParse(projectCustomAttribute.GetCustomAttributeValues().Single().AttributeValue, out var date) ? date.ToShortDateString() : null;
                }
                else
                {
                    return string.Join(", ", projectCustomAttribute.ProjectCustomAttributeValues.Select(x => x.AttributeValue));
                }
            }
            else if (projectCustomAttributeType.ProjectCustomAttributeGroup.ProjectCustomAttributeGroupProjectCategories.All(x => x.ProjectCategoryID != project.ProjectCategoryID))
            {
                //This ProjectCustomAttributeType is not applicable to this Project Type, therefore it is Not Applicable(N/A)
                return "N/A";
            }
            else
            {
                //This just has no value
                return "None";
            }
        }

        public static string GetProjectCustomAttributesValue(this Project project, ProjectCustomAttributeType projectCustomAttributeType, Dictionary<int, List<vProjectCustomAttributeValue>> projectCustomAttributeDictionary)
        {
            var listExists = projectCustomAttributeDictionary.ContainsKey(project.ProjectID);
            var projectCustomAttribute = listExists ? projectCustomAttributeDictionary[project.ProjectID].SingleOrDefault(x => x.ProjectCustomAttributeTypeID == projectCustomAttributeType.ProjectCustomAttributeTypeID) : null;

            if (projectCustomAttribute != null)
            {
                if (projectCustomAttributeType.ProjectCustomAttributeDataType == ProjectCustomAttributeDataType.DateTime)
                {
                    return DateTime.TryParse(projectCustomAttribute.ProjectCustomAttributeValuesConcatenated, out var date) ? date.ToShortDateString() : null;
                }
                else
                {
                    return projectCustomAttribute.ProjectCustomAttributeValuesConcatenated;
                }
            }
            else if (projectCustomAttributeType.ProjectCustomAttributeGroup.ProjectCustomAttributeGroupProjectCategories.All(x => x.ProjectCategoryID != project.ProjectCategoryID))
            {
                //This ProjectCustomAttributeType is not applicable to this Project Type, therefore it is Not Applicable(N/A)
                return "N/A";
            }
            else
            {
                //This just has no value
                return "None";
            }
        }




        public static HtmlString GetProjectGeospatialAreaNamesAsHyperlinks(this Project project, GeospatialAreaType geospatialAreaType)
        {
            var projectGeospatialAreas = project.ProjectGeospatialAreas.Where(x => x.GeospatialArea.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID).ToList();
            return new HtmlString(projectGeospatialAreas.Any()
                ? String.Join(", ", projectGeospatialAreas.OrderBy(x => x.GeospatialArea.GeospatialAreaShortName).Select(x => x.GeospatialArea.GetDisplayNameAsUrl()))
                : ViewUtilities.NaString);
        }

        public static HtmlString GetProjectGeospatialAreaNamesAsHyperlinks(this Project project, GeospatialAreaType geospatialAreaType, Dictionary<int, vGeospatialArea> geospatialDictionary, Dictionary<int, List<ProjectGeospatialArea>> projectGeospatialAreaDictionary)
        {
            var areThereAny = projectGeospatialAreaDictionary.ContainsKey(project.ProjectID);
            var projectGeospatialAreas = areThereAny ? projectGeospatialAreaDictionary[project.ProjectID].Where(x => geospatialDictionary[x.GeospatialAreaID].GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID).ToList() : new List<ProjectGeospatialArea>();
            return new HtmlString(projectGeospatialAreas.Any()
                ? String.Join(", ", projectGeospatialAreas.OrderBy(x => geospatialDictionary[x.GeospatialAreaID].GeospatialAreaShortName).Select(x => geospatialDictionary[x.GeospatialAreaID].GetDisplayNameAsUrl()))
                : ViewUtilities.NaString);
        }

        public static HtmlString GetProjectClassificationsAsHyperlinks(this Project project, ClassificationSystem classificationSystem, Dictionary<int, Classification> classificationDictionary, Dictionary<int, List<ProjectClassification>> projectClassificationDictionary)
        {
            var areThereAny = projectClassificationDictionary.ContainsKey(project.ProjectID);
            var projectClassifications = areThereAny ? projectClassificationDictionary[project.ProjectID].Where(x => classificationDictionary[x.ClassificationID].ClassificationSystemID == classificationSystem.ClassificationSystemID).ToList() : new List<ProjectClassification>();
            return new HtmlString(projectClassifications.Any()
                ? String.Join(", ", projectClassifications.OrderBy(x => classificationDictionary[x.ClassificationID].DisplayName).Select(x => classificationDictionary[x.ClassificationID].GetDisplayNameAsUrl()))
                : ViewUtilities.NaString);
        }

        public static List<PerformanceMeasureReportedValue> GetNonVirtualPerformanceMeasureReportedValues(this Project project)
        {
            var performanceMeasures = project.PerformanceMeasureActuals.Select(x => x.PerformanceMeasure).ToList();
            var performanceMeasureReportedValues = performanceMeasures.Distinct(new HavePrimaryKeyComparer<PerformanceMeasure>())
                .SelectMany(x => x.GetReportedPerformanceMeasureValues(project)).ToList();
            var orderedPerformanceMeasureValues = performanceMeasureReportedValues.OrderByDescending(pma => pma.CalendarYear).ThenBy(pma => pma.PerformanceMeasureID).ToList();
            return orderedPerformanceMeasureValues;
        }

        public static Feature MakePointFeatureWithRelevantProperties(this Project project, DbGeometry projectLocationPoint, bool addProjectProperties, bool useDetailedCustomPopup)
        {
            var feature = DbGeometryToGeoJsonHelper.FromDbGeometry(projectLocationPoint);
            feature.Properties.Add("TaxonomyTrunkID", project.TaxonomyLeaf.TaxonomyBranch.TaxonomyTrunkID.ToString(CultureInfo.InvariantCulture));
            feature.Properties.Add("ProjectStageID", project.ProjectStageID.ToString(CultureInfo.InvariantCulture));
            feature.Properties.Add("Info", project.GetDisplayName());
            if (addProjectProperties)
            {
                feature.Properties.Add("ProjectID", project.ProjectID.ToString(CultureInfo.InvariantCulture));
                feature.Properties.Add("TaxonomyBranchID", project.TaxonomyLeaf.TaxonomyBranchID.ToString(CultureInfo.InvariantCulture));
                feature.Properties.Add("TaxonomyLeafID", project.TaxonomyLeafID.ToString(CultureInfo.InvariantCulture));
                feature.Properties.Add("ClassificationID", String.Join(",", project.ProjectClassifications.Select(x => x.ClassificationID)));

                if (useDetailedCustomPopup)
                {
                    feature.Properties.Add("PopupUrl", project.GetProjectMapPopupUrl());
                }
                else
                {
                    feature.Properties.Add("PopupUrl", project.GetProjectSimpleMapPopupUrl());
                }

            }
            return feature;
        }

        /// <summary>
        /// Returns a commma-separated list of organizations that doesn't include the lead implementer or the funders and only includes the relationships that are configured to show on the fact sheet
        /// </summary>
        /// <param name="project"></param>
        public static string GetProjectOrganizationNamesForFactSheet(this Project project)
        {
            // get the list of funders so we can exclude any that have other project associations
            var tenantAttribute = MultiTenantHelpers.GetTenantAttributeFromCache();
            var fundingOrganizations = project.GetFundingOrganizations(tenantAttribute.ExcludeTargetedFundingOrganizations).Select(x => x.Organization.OrganizationID);
            // Don't use GetAssociatedOrganizations because we don't care about funders for this list.
            var associatedOrganizations = project.ProjectOrganizations
                .Where(x => x.OrganizationRelationshipType.ShowOnFactSheet && !fundingOrganizations.Contains(x.OrganizationID)).ToList();
            associatedOrganizations.RemoveAll(x => x.OrganizationID == project.GetPrimaryContactOrganization()?.OrganizationID);
            var organizationNames = associatedOrganizations.OrderByDescending(x => x.OrganizationRelationshipType.IsPrimaryContact)
                .ThenByDescending(x => x.OrganizationRelationshipType.CanStewardProjects)
                .ThenBy(x => x.Organization.OrganizationName).Select(x => x.Organization.OrganizationName)
                .Distinct().ToList();
            return organizationNames.Any() ? String.Join(", ", organizationNames) : String.Empty;
        }

        public static string GetFundingOrganizationNamesForFactSheet(this Project project)
        {
            var tenantAttribute = MultiTenantHelpers.GetTenantAttributeFromCache();
            return String.Join(", ",
                project.GetFundingOrganizations(tenantAttribute.ExcludeTargetedFundingOrganizations).OrderBy(x => x.Organization.OrganizationName)
                    .Select(x => x.Organization.OrganizationName));
        }

        public static FancyTreeNode ToFancyTreeNode(this Project project, FirmaSession currentFirmaSession)
        {
            bool shouldOfferFactSheetLink = OfferProjectFactSheetLinkFeature.OfferProjectFactSheetLink(currentFirmaSession, project);
            HtmlString titleHtml = new HtmlString(project.ProjectName);
            if (shouldOfferFactSheetLink)
            {
                string factSheetUrl = project.GetFactSheetUrl();
                titleHtml = UrlTemplate.MakeHrefString(factSheetUrl, project.ProjectName, project.ProjectName);
            }

            var fancyTreeNode = new FancyTreeNode(titleHtml, project.ProjectID.ToString(), false) { ThemeColor = project.TaxonomyLeaf.TaxonomyBranch.TaxonomyTrunk.ThemeColor, MapUrl = null };
            return fancyTreeNode;
        }

        public static IEnumerable<Person> GetProjectStewards(this Project project)
        {
            return project.GetCanStewardProjectsOrganization()?.People.Where(y => y.RoleID == Role.ProjectSteward.RoleID)
                .ToList();
        }

        public static ProjectUpdateBatch GetLatestNotApprovedUpdateBatch(this Project project)
        {
            // Making resilient to duplicate Update Batches (even though this should not occur), return latest if more than one are found
            return project.ProjectUpdateBatches.Where(x => x.ProjectUpdateState != ProjectUpdateState.Approved).OrderByDescending(x => x.LastUpdateDate).FirstOrDefault();
        }

        public static bool HasSubmittedOrApprovedUpdateBatchChangingProjectToCompleted(this Project project)
        {
            return project
                .ProjectUpdateBatches
                .Where(x => x.ProjectUpdateState == ProjectUpdateState.Approved ||
                            x.ProjectUpdateState == ProjectUpdateState.Submitted)
                .Any(x => x.ProjectUpdate?.ProjectStage == ProjectStage.Completed);
        }

        public static ProjectUpdateBatch GetLatestApprovedUpdateBatch(this Project project)
        {
            var projectUpdateBatches = project.ProjectUpdateBatches.Where(x => x.ProjectUpdateState == ProjectUpdateState.Approved).ToList();
            return projectUpdateBatches.Any() ? projectUpdateBatches.OrderByDescending(x => x.LastUpdateDate).First() : null;
        }

        public static ProjectUpdateBatch GetLatestUpdateBatch(this Project project)
        {
            var projectUpdateBatches = project.ProjectUpdateBatches.ToList();
            return projectUpdateBatches.Any() ? projectUpdateBatches.OrderByDescending(x => x.LastUpdateDate).First() : null;
        }

        public static bool IsUpdateMandatory(this Project project)
        {
            return IsUpdateMandatory(project, FirmaDateUtilities.LastReportingPeriodStartDate());
        }

        public static bool IsUpdateMandatoryForBackgroundJob(this Project project, int tenantID)
        {
            var lastReportingPeriodStartDate =
                FirmaDateUtilities.LastReportingPeriodStartDateForBackgroundJob(
                    MultiTenantHelpers.GetStartDayOfReportingPeriodForBackgroundJob(tenantID));
            return IsUpdateMandatory(project, lastReportingPeriodStartDate);
        }

        private static bool IsUpdateMandatory(this Project project, DateTime lastReportingPeriodStartDate)
        {
            if (project.IsPendingProject())
            {
                return false;
            }

            if (!project.IsUpdatableViaProjectUpdateProcess())
            {
                return false;
            }

            var latestUpdateBatch = project.GetLatestUpdateBatch();

            if (latestUpdateBatch == null)
            {
                return true;
            }

            // last update was not approved, or was approved before the reporting period start
            if (!latestUpdateBatch.IsApproved() || latestUpdateBatch.LastUpdateDate.IsDateBefore(lastReportingPeriodStartDate))
            {
                return true;
            }

            return false;
        }

        public static bool IsUpdatableViaProjectUpdateProcess(this Project project) => !project.IsPendingProject() &&
                                                            (project.ProjectStage.RequiresReportedExpenditures() ||
                                                             project.ProjectStage.RequiresPerformanceMeasureActuals());
        
        public static FeatureCollection SimpleLocationToGeoJsonFeatureCollection(this Project project, bool userCanViewPrivateLocations, bool addProjectProperties)
        {
            var featureCollection = new FeatureCollection();
            if ((project.ProjectLocationSimpleType == ProjectLocationSimpleType.PointOnMap || project.ProjectLocationSimpleType == ProjectLocationSimpleType.LatLngInput) &&
                project.HasProjectLocationPoint(userCanViewPrivateLocations))
            {
                featureCollection.Features.Add(project.MakePointFeatureWithRelevantProperties(project.GetProjectLocationPoint(userCanViewPrivateLocations),
                    addProjectProperties, true));
            }
            return featureCollection;
        }


        public static FeatureCollection DetailedLocationToGeoJsonFeatureCollection(this Project project, bool userCanViewPrivateLocations)
        {
            if (project.LocationIsPrivate && !userCanViewPrivateLocations)
            {
                return new FeatureCollection();
            }
            return project.GetProjectLocationDetailedAsProjectLocations(true).ToGeoJsonFeatureCollection();
        }



        public static List<Person> GetProjectStewardPeople(this Project project)
        {
            var projectStewards = project.GetProjectStewards() ?? new List<Person>();
            return HttpRequestStorage.DatabaseEntities.People.GetPeopleWhoReceiveNotifications().Union(projectStewards, new HavePrimaryKeyComparer<Person>()).OrderBy(ht => ht.GetFullNameLastFirst()).ToList();
        }

        public static TaxonomyTrunk GetTaxonomyTrunk(this Project project)
        {
            return project.TaxonomyLeaf.TaxonomyBranch.TaxonomyTrunk;
        }

        public static IEnumerable<AttachmentType> GetValidAttachmentTypesForForms(this Project project)
        {
            return project.GetAllAttachmentTypes().Where(x => !x.NumberOfAllowedAttachments.HasValue || (x.ProjectAttachments.Where(pa => pa.ProjectID == project.ProjectID).ToList().Count < x.NumberOfAllowedAttachments));
        }

        public static IEnumerable<AttachmentType> GetAllAttachmentTypes(this Project project)
        {
            return project.TaxonomyLeaf.TaxonomyBranch.TaxonomyTrunk.AttachmentTypeTaxonomyTrunks.Select(x => x.AttachmentType);
        }

        public static decimal GetSecuredFundingForAllProjects()
        {
            decimal securedAmount = 0;
            foreach (Project project in HttpRequestStorage.DatabaseEntities.Projects)
            {
                securedAmount += (project.ProjectFundingSourceBudgets.Sum(x => x.SecuredAmount) ?? 0);
            }
            return securedAmount;
        }

        public static decimal GetTargetedFundingForAllProjects()
        {
            decimal targetedAmount = 0;
            foreach (Project project in HttpRequestStorage.DatabaseEntities.Projects)
            {
                targetedAmount += (project.ProjectFundingSourceBudgets.Sum(x => x.TargetedAmount) ?? 0);
            }
            return targetedAmount;
        }

        public static decimal GetNoFundingSourceIdentifiedYetForAllProjects()
        {
            decimal noFundingSourceAmount = 0;
            foreach (Project project in HttpRequestStorage.DatabaseEntities.Projects)
            {
                noFundingSourceAmount += project.GetNoFundingSourceIdentifiedAmountOrZero();
            }
            return noFundingSourceAmount;
        }

        public static Dictionary<OrganizationType, List<decimal>> GetFundingForAllProjectsByOwnerOrgType(FirmaSession currentFirmaSession)
        {
            var ownerOrgRelationshipType =
                HttpRequestStorage.DatabaseEntities.OrganizationRelationshipTypes.SingleOrDefault(x => x.IsPrimaryContact && x.TenantID == currentFirmaSession.TenantID);
            var projectOwnerOrganizationsOld =
                HttpRequestStorage.DatabaseEntities.ProjectOrganizations
                    .Where(x => x.OrganizationRelationshipTypeID ==
                                ownerOrgRelationshipType.OrganizationRelationshipTypeID).GroupBy(x => x.Organization.OrganizationType).OrderBy(x => x.Key.OrganizationTypeName).ToList();
            var orgTypeToAmounts = new Dictionary<OrganizationType, List<decimal>>();
            OrganizationType otherOrgType = null;
            List<decimal> otherOrgTypeAmounts = null;
            foreach (var typeToProjectOrg in projectOwnerOrganizationsOld)
            {
                decimal securedAmount = 0;
                decimal targetedAmount = 0;
                decimal noFundingSourceAmount = 0;
                int projectCount = 0;
                typeToProjectOrg.ForEach(x =>
                {
                    securedAmount += x.Project.GetSecuredFunding();
                    targetedAmount += x.Project.GetTargetedFunding();
                    noFundingSourceAmount += x.Project.GetNoFundingSourceIdentifiedAmountOrZero();
                    projectCount++;
                });

                var amounts = new List<decimal> { securedAmount, targetedAmount, noFundingSourceAmount, projectCount };
                if ("Other".Equals(typeToProjectOrg.Key.OrganizationTypeName))
                {
                    // save to add to the end of the dictionary because Other should be displayed last
                    otherOrgType = typeToProjectOrg.Key;
                    otherOrgTypeAmounts = amounts;
                }
                else
                {
                    orgTypeToAmounts.Add(typeToProjectOrg.Key, amounts);
                }
            }

            if (otherOrgType != null)
            {
                orgTypeToAmounts.Add(otherOrgType, otherOrgTypeAmounts);
            }

            return orgTypeToAmounts;
        }

        public static GoogleChartDataTable GetFundingStatusByOwnerOrgTypeGoogleChartDataTable(Dictionary<OrganizationType, List<decimal>> orgTypeToAmounts)
        {
            var securedSeries = new GoogleChartSeries(GoogleChartType.ColumnChart, GoogleChartAxisType.Primary, "#C6B42F", null, null);
            var targetedSeries = new GoogleChartSeries(GoogleChartType.ColumnChart, GoogleChartAxisType.Primary, "#007C8A", null, null);
            var noFundingSourceSeries = new GoogleChartSeries(GoogleChartType.ColumnChart, GoogleChartAxisType.Primary, "#D34727", null, null);
            var securedLabel = $"{FieldDefinitionEnum.SecuredFunding.ToType().GetFieldDefinitionLabel()}";
            var targetedLabel = $"{FieldDefinitionEnum.TargetedFunding.ToType().GetFieldDefinitionLabel()}";
            var noFundingSourceLabel = $"{FieldDefinitionEnum.NoFundingSourceIdentified.ToType().GetFieldDefinitionLabel()}";
            var googleChartColumns = new List<GoogleChartColumn>
            {
                new GoogleChartColumn("Owner Org Type", GoogleChartColumnDataType.String),
                new GoogleChartColumn(GoogleChartColumnDataType.String.ColumnDataType, "tooltip", new GoogleChartProperty()),
                new GoogleChartColumn(securedLabel, securedLabel, GoogleChartColumnDataType.Number.ToString(), securedSeries),
                new GoogleChartColumn(targetedLabel, targetedLabel, GoogleChartColumnDataType.Number.ToString(), targetedSeries),
                new GoogleChartColumn(noFundingSourceLabel, noFundingSourceLabel, GoogleChartColumnDataType.Number.ToString(), noFundingSourceSeries)
            };

            var googleChartRowCs = new List<GoogleChartRowC>();

            var labels = new List<string> { securedLabel, targetedLabel, noFundingSourceLabel };

            foreach (var orgToAmount in orgTypeToAmounts)
            {
                var googleChartRowVs = new List<GoogleChartRowV> { new GoogleChartRowV(orgToAmount.Key.OrganizationTypeAbbreviation) };
                var amounts = orgTypeToAmounts[orgToAmount.Key];
                // add custom tool tip hover
                googleChartRowVs.Add(new GoogleChartRowV(null, FormattedDataTooltip(amounts, orgToAmount.Key, labels)));
                // add data
                googleChartRowVs.Add(new GoogleChartRowV(amounts[0], GoogleChartJson.GetFormattedValue(Convert.ToDouble(amounts[0]), MeasurementUnitType.Dollars)));
                googleChartRowVs.Add(new GoogleChartRowV(amounts[1], GoogleChartJson.GetFormattedValue(Convert.ToDouble(amounts[1]), MeasurementUnitType.Dollars)));
                googleChartRowVs.Add(new GoogleChartRowV(amounts[2], GoogleChartJson.GetFormattedValue(Convert.ToDouble(amounts[2]), MeasurementUnitType.Dollars)));
                googleChartRowCs.Add(new GoogleChartRowC(googleChartRowVs));
            }

            var googleChartDataTable = new GoogleChartDataTable(googleChartColumns, googleChartRowCs);
            return googleChartDataTable;
        }

        public static List<GooglePieChartSlice> GetFundingStatusPieChartSlices()
        {
            var sortOrder = 0;
            var googlePieChartSlices = new List<GooglePieChartSlice>();
            googlePieChartSlices.Add(new GooglePieChartSlice(FieldDefinitionEnum.SecuredFunding.ToType().GetFieldDefinitionLabel(), Convert.ToDouble(GetSecuredFundingForAllProjects()), sortOrder++, "#C6B42F"));
            googlePieChartSlices.Add(new GooglePieChartSlice(FieldDefinitionEnum.TargetedFunding.ToType().GetFieldDefinitionLabel(), Convert.ToDouble(GetTargetedFundingForAllProjects()), sortOrder++, "#007C8A"));
            googlePieChartSlices.Add(new GooglePieChartSlice(FieldDefinitionEnum.NoFundingSourceIdentified.ToType().GetFieldDefinitionLabel(), Convert.ToDouble(GetNoFundingSourceIdentifiedYetForAllProjects()), sortOrder, "#D34727"));
            return googlePieChartSlices;
        }

        public static GoogleChartDataTable GetFundingStatusSummaryGoogleChartDataTable(List<GooglePieChartSlice> fundingStatusTotals)
        {
            var googleChartColumns = new List<GoogleChartColumn>
            {
                new GoogleChartColumn($"Funding Type", GoogleChartColumnDataType.String, GoogleChartType.PieChart),
                new GoogleChartColumn($"Amount", GoogleChartColumnDataType.Number, GoogleChartType.PieChart)

            };

            var chartRowCs = fundingStatusTotals.Select(x =>
            {
                var fundingTypeRowV = new GoogleChartRowV(x.Label);
                var formattedValue = GoogleChartJson.GetFormattedValue(x.Value, MeasurementUnitType.Dollars);
                var amountRowV = new GoogleChartRowV(x.Value, formattedValue);
                return new GoogleChartRowC(new List<GoogleChartRowV> { fundingTypeRowV, amountRowV });
            });
            var googleChartRowCs = new List<GoogleChartRowC>(chartRowCs);

            var googleChartDataTable = new GoogleChartDataTable(googleChartColumns, googleChartRowCs);
            return googleChartDataTable;
        }

        public static string FormattedDataTooltip(List<decimal> amounts, OrganizationType organizationType, List<string> labels)
        {
            // build html for tooltip
            var html = "<div class='googleTooltipDiv'>";
            html += $"<p><b>{organizationType.OrganizationTypeAbbreviation}</b></p>";
            html += "<table class='table table-striped googleTooltipTable'>";

            var stringPrecision = new String('0', MeasurementUnitType.Count.NumberOfSignificantDigits);
            var formattedTotal = amounts[3].ToString($"#,###,###,##0.{stringPrecision}");
            html += $"<tr class='googleTooltipTableTotalRow'><td>Total # of NTAs</td><td style='text-align: right'><b>{formattedTotal}</b></td></tr>";

            stringPrecision = new String('0', MeasurementUnitType.Dollars.NumberOfSignificantDigits);
            var prefix = "$";

            for (int i = labels.Count - 1; i >= 0; i--)
            {
                var formattedValue = amounts[i].ToString($"#,###,###,##0.{stringPrecision}");
                html += $"<tr><td>{labels[i]}</td><td style='text-align: right'><b>{prefix}{formattedValue}</b></td></tr>";
            }
            html += "</table></div>";
            return html;
        }

        public static ProjectCustomAttributesValidationResult ValidateCustomAttributes(this Project project, FirmaSession currentFirmaSession)
        {
            return new ProjectCustomAttributesValidationResult(project, currentFirmaSession);
        }

        public static bool AreProjectCustomAttributesValid(this Project project, FirmaSession currentFirmaSession)
        {
            return project.ValidateCustomAttributes(currentFirmaSession).IsValid;
        }

        public static List<ProjectCustomAttributeType> GetCustomAttributeTypes(this Project project)
        {
            return HttpRequestStorage.DatabaseEntities.ProjectCustomAttributeTypes.Where(x => x.ProjectCustomAttributeGroup.ProjectCustomAttributeGroupProjectCategories.Any(pcagpt => pcagpt.ProjectCategoryID == project.ProjectCategoryID)).ToList();
        }

        public static bool HasEditableCustomAttributes(this Project project, FirmaSession currentFirmaSession)
        {
            return project.GetCustomAttributeTypes().Any(x => x.HasEditPermission(currentFirmaSession));
        }

        public static bool HasProjectLocationPointViewableByUser(this Project project, FirmaSession currentFirmaSession)
        {
            var userCanViewPrivateLocations = currentFirmaSession.UserCanViewPrivateLocations(project);
            return project.HasProjectLocationPoint(userCanViewPrivateLocations);
        }

        public static DbGeometry GetProjectLocationPointIfViewableByUser(this Project project, FirmaSession currentFirmaSession)
        {
            var userCanViewPrivateLocations = currentFirmaSession.UserCanViewPrivateLocations(project);
            return project.GetProjectLocationPoint(userCanViewPrivateLocations);
        }
    }
}
