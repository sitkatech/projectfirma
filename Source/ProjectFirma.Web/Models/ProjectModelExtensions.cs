/*-----------------------------------------------------------------------
<copyright file="ProjectModelExtensions.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Data.Entity.Spatial;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using GeoJSON.Net.Feature;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.GeoJson;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using LtInfo.Common.Views;
using Microsoft.Ajax.Utilities;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ProjectUpdate;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirmaModels.Models
{
    public static class ProjectModelExtensions
    {
        public const int MaxLengthForProjectDescription = 700;
        public static readonly UrlTemplate<int> DetailUrlTemplate = new UrlTemplate<int>(SitkaRoute<ProjectController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int)));
        public static string GetDetailUrl(this Project project)
        {
            return DetailUrlTemplate.ParameterReplace(project.ProjectID);
        }

        public static readonly UrlTemplate<int> EditUrlTemplate = new UrlTemplate<int>(SitkaRoute<ProjectController>.BuildUrlFromExpression(t => t.Edit(UrlTemplate.Parameter1Int)));
        public static string GetEditUrl(this Project project)
        {
            return IsProposal(project) ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(t => t.EditBasics(project.ProjectID)) : EditUrlTemplate.ParameterReplace(project.ProjectID);
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
        public static List<ProjectExemptReportingYear> GetExpendituresExemptReportingYears(this Project project)
        {
            return project.ProjectExemptReportingYears
                .Where(x => x.ProjectExemptReportingType == ProjectExemptReportingType.Expenditures)
                .OrderBy(x => x.CalendarYear).ToList();
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
        public static List<ProjectOrganizationRelationship> GetFundingOrganizations(this Project project)
        {
            var fundingOrganizations = project.ProjectFundingSourceExpenditures.Select(x => x.FundingSource.Organization)
                .Union(project.ProjectFundingSourceRequests.Select(x => x.FundingSource.Organization), new HavePrimaryKeyComparer<Organization>())
                .Select(x => new ProjectOrganizationRelationship(project, x, RelationshipTypeModelExtensions.RelationshipTypeNameFunder));
            return fundingOrganizations.ToList();
        }

        public static List<ProjectOrganizationRelationship> GetAssociatedOrganizations(this Project project)
        {
            var explicitOrganizations = project.ProjectOrganizations.Select(x => new ProjectOrganizationRelationship(project, x.Organization, x.RelationshipType)).ToList();
            explicitOrganizations.AddRange(project.GetFundingOrganizations());
            return explicitOrganizations.DistinctBy(x => new {x.Project.ProjectID, x.Organization.OrganizationID})
                .ToList();
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

        public static FeatureCollection MappedPointsToGeoJsonFeatureCollection(this List<Project> projects, bool addProjectProperties, bool useDetailedCustomPopup)
        {
            var featureCollection = new FeatureCollection();
            var filteredProjectList = projects.Where(x1 => x1.HasProjectLocationPoint()).Where(x => x.ProjectStage.ShouldShowOnMap()).ToList();
            featureCollection.Features.AddRange(filteredProjectList.Select<Project, Feature>(project => MakePointFeatureWithRelevantProperties(project, project.ProjectLocationPoint, addProjectProperties, useDetailedCustomPopup)).ToList());
            return featureCollection;
        }

        /// <summary>
        /// Note this will do a deep delete of this project image, meaning it will remove it from a ProjectImageUpdate if it is tied to that
        /// </summary>
        /// <param name="projectImages"></param>
        public static void DeleteProjectImages(this ICollection<ProjectImage> projectImages)
        {
            var projectImageFileResourceIDsToDelete = projectImages.Select(x => x.FileResourceID).ToList();
            var projectImageIDsToDelete = projectImages.Select(x => x.ProjectImageID).ToList();
            HttpRequestStorage.DatabaseEntities.ProjectImageUpdates.Where(x => x.ProjectImageID.HasValue && projectImageIDsToDelete.Contains(x.ProjectImageID.Value)).ToList().DeleteProjectImageUpdate();
            projectImages.DeleteProjectImage();
            projectImageFileResourceIDsToDelete.DeleteFileResource();
        }

        public static List<ProjectSectionSimple> GetApplicableProposalWizardSections(this Project project, bool ignoreStatus)
        {
            return ProjectWorkflowSectionGrouping.All.SelectMany(x => x.GetProjectCreateSections(project, ignoreStatus)).OrderBy(x => x.ProjectWorkflowSectionGrouping.SortOrder).ThenBy(x => x.SortOrder).ToList();
        }

        public static IEnumerable<Organization> GetOrganizationsToReportInAccomplishments(this Project project)
        {
            if (MultiTenantHelpers.GetRelationshipTypeToReportInAccomplishmentsDashboard() == null)
            {
                // Default is Funding Organizations
                var organizations = project.ProjectFundingSourceExpenditures.Select(x => x.FundingSource.Organization)
                    .Union(project.ProjectFundingSourceRequests.Select(x => x.FundingSource.Organization))
                    .Distinct(new HavePrimaryKeyComparer<Organization>());
                return organizations;
            }

            return project.ProjectOrganizations.Where(x => x.RelationshipType.ReportInAccomplishmentsDashboard)
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

        public static string GetProjectLocationStateProvince(this Project project)
        {
            if (project.HasProjectLocationPoint())
            {
                var stateProvince = HttpRequestStorage.DatabaseEntities.StateProvinces.ToList().FirstOrDefault(x => x.StateProvinceFeatureForAnalysis.Intersects(project.ProjectLocationPoint));
                return stateProvince != null ? stateProvince.StateProvinceAbbreviation : ViewUtilities.NaString;
            }

            return ViewUtilities.NaString;
        }

        public static List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasures(this Project project)
        {
            var reportedPerformanceMeasures = GetNonVirtualPerformanceMeasureReportedValues(project);

            // Idaho's special PM.
            // There Might Be A Better Way To Do This™
            var technicalAssistanceValue = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.SingleOrDefault(x =>
                x.PerformanceMeasureDataSourceTypeID == PerformanceMeasureDataSourceType.TechnicalAssistanceValue
                    .PerformanceMeasureDataSourceTypeID);
            if (technicalAssistanceValue != null)
            {
                reportedPerformanceMeasures.AddRange(technicalAssistanceValue.GetReportedPerformanceMeasureValues(project));
            }

            return Enumerable.OrderByDescending<PerformanceMeasureReportedValue, int>(reportedPerformanceMeasures, pma => pma.CalendarYear).ThenBy(pma => pma.PerformanceMeasureID).ToList();
        }

        public static DateTime GetLastUpdateDate(this Project project)
        {
            return HttpRequestStorage.DatabaseEntities.AuditLogs.GetAuditLogEntriesForProject(project).Max(x => x.AuditLogDate);
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

            var securedAmountsDictionary = project.ProjectFundingSourceRequests.Where(x => x.SecuredAmount > 0)
                .GroupBy(x => x.FundingSource, new HavePrimaryKeyComparer<FundingSource>())
                .ToDictionary(x => x.Key, x => x.Sum(y => y.SecuredAmount));
            var unsecuredAmountsDictionary = project.ProjectFundingSourceRequests.Where(x => x.UnsecuredAmount > 0)
                .GroupBy(x => x.FundingSource, new HavePrimaryKeyComparer<FundingSource>())
                .ToDictionary(x => x.Key, x => x.Sum(y => y.UnsecuredAmount));

            var securedColorHsl = new { hue = 96.0, sat = 60.0 };
            var unsecuredColorHsl = new { hue = 33.3, sat = 240.0 };

            var securedPieChartSlices = securedAmountsDictionary.OrderBy(x => x.Key.FundingSourceName).Select((fundingSourceDictionaryItem, index) =>
            {
                var fundingSource = fundingSourceDictionaryItem.Key;
                var fundingAmount = fundingSourceDictionaryItem.Value;

                var luminosity = 100.0 * (securedAmountsDictionary.Count - index - 1) / securedAmountsDictionary.Count + 120;
                var color = ColorTranslator.ToHtml(new HslColor(securedColorHsl.hue, securedColorHsl.sat, luminosity));
                return new GooglePieChartSlice("Secured Funding: " + fundingSource.GetFixedLengthDisplayName(), Convert.ToDouble(fundingAmount), sortOrder++, color);

            }).ToList();
            googlePieChartSlices.AddRange(securedPieChartSlices);

            var unsecuredPieChartSlices = unsecuredAmountsDictionary.OrderBy(x => x.Key.FundingSourceName).Select((fundingSourceDictionaryItem, index) =>
            {
                var fundingSource = fundingSourceDictionaryItem.Key;
                var fundingAmount = fundingSourceDictionaryItem.Value;

                var luminosity = 100.0 * (unsecuredAmountsDictionary.Count - index - 1) / unsecuredAmountsDictionary.Count + 120;
                var color = ColorTranslator.ToHtml(new HslColor(unsecuredColorHsl.hue, unsecuredColorHsl.sat, luminosity));
                return new GooglePieChartSlice("Targeted Funding: " + fundingSource.GetFixedLengthDisplayName(), Convert.ToDouble(fundingAmount), sortOrder++, color);
            }).ToList();
            googlePieChartSlices.AddRange(unsecuredPieChartSlices);

            return googlePieChartSlices;
        }

        public static List<GooglePieChartSlice> GetRequestAmountGooglePieChartSlices(this Project project)
        {
            var requestAmountsDictionary = project.GetFundingSourceRequestGooglePieChartSlices();
            var noFundingSourceIdentifiedAmount = Convert.ToDouble(project.EstimatedTotalCost ?? 0) - requestAmountsDictionary.Sum(x => x.Value);
            if (noFundingSourceIdentifiedAmount > 0)
            {
                var sortOrder = requestAmountsDictionary.Any() ? requestAmountsDictionary.Max(x => x.SortOrder) + 1 : 0;
                requestAmountsDictionary.Add(new GooglePieChartSlice("No Funding Source Identified", noFundingSourceIdentifiedAmount, sortOrder, "#dbdbdb"));
            }
            return requestAmountsDictionary;
        }

        public static bool IsEditableToThisPerson(this Project project, Person person)
        {
            return project.IsMyProject(person) || new ProjectApproveFeature().HasPermission(person, project).HasPermission;
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

        public static List<Project> GetActiveProjectsAndProposals(this IList<Project> projects, bool showProposals)
        {
            var activeProjects = projects.GetActiveProjects();
            var activeProposals = projects.GetActiveProposals(showProposals);
            return activeProjects.Union(activeProposals, new HavePrimaryKeyComparer<Project>()).OrderBy(x => x.GetDisplayName()).ToList();
        }

        public static List<Project> GetActiveProjects(this IList<Project> projects)
        {
            return projects.Where(x => IsActiveProject(x)).OrderBy(x => x.GetDisplayName()).ToList();
        }

        public static List<Project> GetActiveProposals(this IList<Project> projects, bool showProposals)
        {
            return showProposals
                ? projects.Where(x => IsActiveProposal(x)).OrderBy(x => x.GetDisplayName()).ToList()
                : new List<Project>();
        }

        public static List<Project> GetProposalsVisibleToUser(this IList<Project> projects, Person currentPerson)
        {
            return projects.Where(x => IsProposal(x) && new ProjectViewFeature().HasPermission(currentPerson, x).HasPermission).ToList();
        }

        public static List<Project> GetPendingProjects(this IList<Project> projects, bool showPendingProjects)
        {
            return showPendingProjects ? projects.Where(x => IsPendingProject(x)).OrderBy(x => x.GetDisplayName()).ToList() : new List<Project>();
        }

        public static List<Project> GetUpdatableProjectsThatHaveNotBeenSubmitted(this IQueryable<Project> projects)
        {
            return projects.GetUpdatableProjects().Where(x => x.GetLatestUpdateState() != ProjectUpdateState.Submitted).ToList();
        }

        public static List<Project> GetUpdatableProjects(this IQueryable<Project> projects)
        {
            return projects.Where(x => IsUpdateMandatory(x)).ToList();
        }

        public static bool IsActiveProject(Project project)
        {
            return !IsProposal(project) && project.ProjectApprovalStatus == ProjectApprovalStatus.Approved;
        }

        public static bool IsProposal(Project project)
        {
            return project.ProjectStage == ProjectStage.Proposal;
        }

        public static bool IsActiveProposal(Project project)
        {
            return IsProposal(project) && project.ProjectApprovalStatus == ProjectApprovalStatus.PendingApproval;
        }

        public static bool IsPendingProject(Project project)
        {
            return !IsProposal(project) && project.ProjectApprovalStatus != ProjectApprovalStatus.Approved;
        }

        public static bool IsRejected(Project project)
        {
            return project.ProjectApprovalStatus == ProjectApprovalStatus.Rejected;
        }

        public static bool IsForwardLookingFactSheetRelevant(Project project)
        {
            return ProjectStage.ForwardLookingFactSheetProjectStages.Contains(project.ProjectStage);
        }

        public static bool IsBackwardLookingFactSheetRelevant(Project project)
        {
            return !IsForwardLookingFactSheetRelevant(project);
        }

        public static bool IsExpectedFundingRelevant(Project project)
        {
            // todo: Always relevant for pending projects, otherwise relevant for every stage except terminated/completed
            return true;
        }

        public static bool AreReportedPerformanceMeasuresRelevant(Project project)
        {
            return project.ProjectStage != ProjectStage.Proposal && project.ProjectStage != ProjectStage.PlanningDesign;
        }

        public static bool AreReportedExpendituresRelevant(Project project)
        {
            return project.ProjectStage != ProjectStage.Proposal;
        }

        public static DateTime? GetLatestUpdateSubmittalDate(Project project)
        {
            var notNullSubmittalDates = project.ProjectUpdateBatches.Select(x => x.GetLatestSubmittalDate())).Where(x => x.HasValue).ToList();
            return notNullSubmittalDates.Any() ? notNullSubmittalDates.Max() : null;
        }

        public static HtmlString GetProjectGeospatialAreaNamesAsHyperlinks(Project project, GeospatialAreaType geospatialAreaType)
        {
            var projectGeospatialAreas = project.ProjectGeospatialAreas.Where(x => x.GeospatialArea.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID).ToList();
            return new HtmlString(projectGeospatialAreas.Any()
                ? String.Join(", ", projectGeospatialAreas.OrderBy(x => x.GeospatialArea.GeospatialAreaName).Select(x => x.GeospatialArea.GetDisplayNameAsUrl()))
                : ViewUtilities.NaString);
        }

        public static List<PerformanceMeasureReportedValue> GetNonVirtualPerformanceMeasureReportedValues(Project project)
        {
            var performanceMeasureReportedValues = project.PerformanceMeasureActuals.Select(x => x.PerformanceMeasure)
                .Distinct(new HavePrimaryKeyComparer<PerformanceMeasure>())
                .SelectMany(x => x.GetReportedPerformanceMeasureValues(project)).ToList();
            return performanceMeasureReportedValues.OrderByDescending(pma => pma.CalendarYear).ThenBy(pma => pma.PerformanceMeasureID).ToList();
        }

        public static Feature MakePointFeatureWithRelevantProperties(Project project, DbGeometry projectLocationPoint, bool addProjectProperties, bool useDetailedCustomPopup)
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
                var associatedOrganizations = project.GetAssociatedOrganizations();
                var relationshipTypeNames = associatedOrganizations.Select(x => x.RelationshipTypeName).Distinct();
                foreach (var relationshipTypeName in relationshipTypeNames)
                {
                    feature.Properties.Add($"{relationshipTypeName}ID", associatedOrganizations.Where(y => y.RelationshipTypeName.Equals(relationshipTypeName)).Select(z => z.Organization.OrganizationID));
                }

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
        public static string GetProjectOrganizationNamesForFactSheet(Project project)
        {
            // get the list of funders so we can exclude any that have other project associations
            var fundingOrganizations = project.GetFundingOrganizations().Select(x => x.Organization.OrganizationID);
            // Don't use GetAssociatedOrganizations because we don't care about funders for this list.
            var associatedOrganizations = project.ProjectOrganizations
                .Where(x => x.RelationshipType.ShowOnFactSheet && !fundingOrganizations.Contains(x.OrganizationID)).ToList();
            associatedOrganizations.RemoveAll(x => x.OrganizationID == project.GetPrimaryContactOrganization()?.OrganizationID);
            var organizationNames = associatedOrganizations.OrderByDescending(x => x.RelationshipType.IsPrimaryContact)
                .ThenByDescending(x => x.RelationshipType.CanStewardProjects)
                .ThenBy(x => x.Organization.OrganizationName).Select(x => x.Organization.OrganizationName)
                .Distinct().ToList();
            return organizationNames.Any() ? String.Join(", ", organizationNames) : String.Empty;
        }

        public static string GetFundingOrganizationNamesForFactSheet(Project project)
        {
            return String.Join(", ",
                project.GetFundingOrganizations().OrderBy(x => x.Organization.OrganizationName)
                    .Select(x => x.Organization.OrganizationName));
        }

        public static FancyTreeNode ToFancyTreeNode(Project project)
        {
            var fancyTreeNode = new FancyTreeNode(
                $"{UrlTemplate.MakeHrefString(project.GetFactSheetUrl(), project.ProjectName, project.ProjectName)}", project.ProjectID.ToString(), false) { ThemeColor = project.TaxonomyLeaf.TaxonomyBranch.TaxonomyTrunk.ThemeColor, MapUrl = null };
            return fancyTreeNode;
        }

        public static IEnumerable<Person> GetProjectStewards(Project project)
        {
            return Enumerable.Where<Person>(Project.GetCanStewardProjectsOrganization(project)?.People, y => y.RoleID == Role.ProjectSteward.RoleID)
                       .ToList() ?? new List<Person>();
        }

        public static ProjectUpdateBatch GetLatestNotApprovedUpdateBatch(this Project project)
        {
            return project.ProjectUpdateBatches.SingleOrDefault(x => x.ProjectUpdateState != ProjectUpdateState.Approved);
        }

        public static ProjectUpdateBatch GetLatestApprovedUpdateBatch(Project project)
        {
            var projectUpdateBatches = project.ProjectUpdateBatches.Where(x => x.ProjectUpdateState == ProjectUpdateState.Approved).ToList();
            return projectUpdateBatches.Any() ? projectUpdateBatches.OrderByDescending(x => x.LastUpdateDate).First() : null;
        }

        public static ProjectUpdateBatch GetLatestUpdateBatch(Project project)
        {
            var projectUpdateBatches = project.ProjectUpdateBatches.ToList();
            return projectUpdateBatches.Any() ? projectUpdateBatches.OrderByDescending(x => x.LastUpdateDate).First() : null;
        }

        public static bool IsUpdateMandatory(Project project)
        {
            if (IsPendingProject(project))
            {
                return false;
            }

            if (!project.IsUpdatableViaProjectUpdateProcess())
            {
                return false;
            }

            var latestUpdateBatch = GetLatestUpdateBatch(project);

            if (latestUpdateBatch == null)
            {
                return true;
            }

            if (!latestUpdateBatch.IsApproved())
            {
                return true;
            }

            return false;
        }

        public static bool IsUpdatableViaProjectUpdateProcess(this Project project) => !IsPendingProject(project) &&
                                                            (project.ProjectStage.RequiresReportedExpenditures() ||
                                                             project.ProjectStage.RequiresPerformanceMeasureActuals());

        public static FeatureCollection DetailedLocationToGeoJsonFeatureCollection(this Project project)
        {
            return project.ProjectLocations.ToGeoJsonFeatureCollection();
        }

        public static FeatureCollection SimpleLocationToGeoJsonFeatureCollection(this Project project, bool addProjectProperties)
        {
            var featureCollection = new FeatureCollection();

            if (project.ProjectLocationSimpleType == ProjectLocationSimpleType.PointOnMap && project.HasProjectLocationPoint())
            {
                featureCollection.Features.Add(MakePointFeatureWithRelevantProperties(project, project.ProjectLocationPoint, addProjectProperties, true));
            }
            return featureCollection;
        }
    }
}
