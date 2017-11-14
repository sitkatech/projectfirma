/*-----------------------------------------------------------------------
<copyright file="Project.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using GeoJSON.Net.Feature;
using LtInfo.Common;
using LtInfo.Common.GeoJson;
using LtInfo.Common.Models;
using LtInfo.Common.Views;
using MoreLinq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ProjectFirma.Web.Models
{
    public partial class Project : IAuditableEntity, IMappableProject
    {
        public int EntityID => ProjectID;

        public string AuditDescriptionString => ProjectName;

        public string DisplayName => ProjectName;

        public HtmlString DisplayNameAsUrl => UrlTemplate.MakeHrefString(this.GetDetailUrl(), DisplayName);

        public static bool IsProjectNameUnique(IEnumerable<Project> projects, string projectName, int currentProjectID)
        {
            if (string.IsNullOrWhiteSpace(projectName))
            {
                return false;
            }
            var project = projects.SingleOrDefault(x => x.ProjectID != currentProjectID && String.Equals(x.ProjectName.Trim(), projectName.Trim(), StringComparison.InvariantCultureIgnoreCase));
            return project == null;
        }

        public Organization GetPrimaryContactOrganization()
        {
            return ProjectOrganizations.SingleOrDefault(x => x.RelationshipType.IsPrimaryContact)?.Organization;
        }

        public Organization GetCanStewardProjectsOrganization()
        {
            return ProjectOrganizations.SingleOrDefault(x => x.RelationshipType.CanStewardProjects)?.Organization;
        }

        public Person GetPrimaryContact() => PrimaryContactPerson ??
                                             GetPrimaryContactOrganization()?.PrimaryContactPerson;

        public decimal? UnfundedNeed()
        {
            return EstimatedTotalCost - GetSecuredFunding();
        }

        public decimal? GetSecuredFunding()
        {
            return ProjectFundingSourceRequests.Any() ? ProjectFundingSourceRequests.Sum(x => x.SecuredAmount) : 0;
        }

        public decimal GetUnsecuredFunding()
        {
            return ProjectFundingSourceRequests.Any() ? ProjectFundingSourceRequests.Sum(x => x.UnsecuredAmount) : 0;
        }


        public decimal? TotalExpenditures
        {
            get { return ProjectFundingSourceExpenditures.Any() ? ProjectFundingSourceExpenditures.Sum(x => x.ExpenditureAmount) : (decimal?)null; }
        }

        public bool HasProjectLocationPoint => ProjectLocationPoint != null;
        public bool HasProjectLocationDetail => DetailedLocationToGeoJsonFeatureCollection().Features.Any();
        
        private bool _hasCheckedProjectUpdateHistories;
        private List<ProjectUpdateHistory> _projectUpdateHistories;
        public List<ProjectUpdateHistory> ProjectUpdateHistories
        {
            get
            {
                if (_hasCheckedProjectUpdateHistories)
                {
                    return _projectUpdateHistories;
                }
                ProjectUpdateHistories = ProjectUpdateBatches.SelectMany(x => x.ProjectUpdateHistories).ToList();
                return _projectUpdateHistories;
            }
            set
            {
                _projectUpdateHistories = value;
                _hasCheckedProjectUpdateHistories = true;
            }
        }

        public ProjectUpdateBatch GetLatestNotApprovedUpdateBatch()
        {
            return ProjectUpdateBatches.SingleOrDefault(x => x.ProjectUpdateState != ProjectUpdateState.Approved);
        }

        public ProjectUpdateBatch GetLatestApprovedUpdateBatch()
        {
            var projectUpdateBatches = ProjectUpdateBatches.Where(x => x.ProjectUpdateState == ProjectUpdateState.Approved).ToList();

            return projectUpdateBatches.Any() ? projectUpdateBatches.MaxBy(x => x.LastUpdateDate) : null;
        }

        public bool IsUpdateMandatory
        {
            get
            {
                if (!IsUpdatableViaProjectUpdateProcess)
                    return false;

                var latestApprovedUpdateBatch = GetLatestApprovedUpdateBatch();
                if (latestApprovedUpdateBatch == null)
                    return true;

                if (latestApprovedUpdateBatch.LastUpdateDate < FirmaDateUtilities.LastReportingPeriodStartDate())
                {
                    return true;
                }

                return false;
            }
        }

        public bool IsUpdateAllowed
        {
            get
            {
                if (IsActiveProject())
                {
                    return false;
                }

                if (!IsUpdatableViaProjectUpdateProcess)
                    return false;

                var projectUpdateState = GetLatestUpdateState();
                return projectUpdateState != ProjectUpdateState.Submitted;
            }
        }

        public bool IsUpdatableViaProjectUpdateProcess => ProjectStage.RequiresReportedExpenditures() || ProjectStage.RequiresPerformanceMeasureActuals();

        public ProjectUpdateState GetLatestUpdateState()
        {
            if (!ProjectUpdateBatches.Any())
                return null;

            if (ProjectUpdateBatches.Count(x => x.ProjectUpdateState != ProjectUpdateState.Approved) > 1)
                throw new Exception(FirmaValidationMessages.MoreThanOneProjectUpdateInProgress);

            return ProjectUpdateBatches.MaxBy(x => x.LastUpdateDate).ProjectUpdateState;
        }

        public DateTime? GetLatestUpdateSubmittalDate()
        {
            var notNullSubmittalDates = ProjectUpdateBatches.Select(x => x.LatestSubmittalDate).Where(x => x.HasValue).ToList();
            return notNullSubmittalDates.Any() ? notNullSubmittalDates.Max() : null;
        }

        private string _projectLocationStateProvince;
        private bool _hasSetProjectLocationStateProvince;
        public string ProjectLocationStateProvince
        {
            get
            {
                if (_hasSetProjectLocationStateProvince)
                {
                    return _projectLocationStateProvince;
                }
                SetProjectLocationStateProvince(HttpRequestStorage.DatabaseEntities.StateProvinces.ToList());
                return _projectLocationStateProvince;
            }
            set
            {
                _projectLocationStateProvince = value;
                _hasSetProjectLocationStateProvince = true;
            }
        }

        public void SetProjectLocationStateProvince(IEnumerable<StateProvince> stateProvinces)
        {

            if (HasProjectLocationPoint)
            {
                var stateProvince = stateProvinces.FirstOrDefault(x => x.StateProvinceFeatureForAnalysis.Intersects(ProjectLocationPoint));
                ProjectLocationStateProvince = stateProvince != null ? stateProvince.StateProvinceAbbreviation : ViewUtilities.NaString;
            }
            else
            {
                ProjectLocationStateProvince = ViewUtilities.NaString;
            }
        }

        public HtmlString GetProjectWatershedNamesAsHyperlinks()
        {
            return new HtmlString(ProjectWatersheds.Any()
                ? string.Join(", ", ProjectWatersheds.OrderBy(x => x.Watershed.WatershedName).Select(x => x.Watershed.GetDisplayNameAsUrl()))
                : ViewUtilities.NaString);
        }

        public string GetProjectWatershedNamesAsString()
        {
            return ProjectWatersheds.Any()
                ? string.Join(", ", ProjectWatersheds.OrderBy(x => x.Watershed.WatershedName).Select(x => x.Watershed.WatershedName))
                : ViewUtilities.NaString;
        }

        public bool IsMyProject(Person person)
        {
            return IsPersonThePrimaryContact(person) || person.Organization.IsMyProject(this);
        }

        public bool IsPersonThePrimaryContact(Person person)
        {
            if (person == null)
            {
                return false;
            }
            var primaryContactPerson = GetPrimaryContact();
            return person.PersonID == primaryContactPerson?.PersonID;
        }

        public bool IsEditableToThisPerson(Person person)
        {
            return IsMyProject(person) || new ProjectApproveFeature().HasPermission(person, this).HasPermission;
        }

        public List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasures()
        {
            var performanceMeasureReportedValues = PerformanceMeasureActuals.Select(x => x.PerformanceMeasure).Distinct(new HavePrimaryKeyComparer<PerformanceMeasure>()).SelectMany(x => x.GetReportedPerformanceMeasureValues(this)).ToList();
            return performanceMeasureReportedValues.OrderByDescending(pma => pma.CalendarYear).ThenBy(pma => pma.PerformanceMeasureID).ToList();
        }

        public bool HasDependentObjectsThatCount()
        {
            return PerformanceMeasureActuals.Any() || PerformanceMeasureExpecteds.Any() || ProjectFundingSourceExpenditures.Any() || ProjectImages.Any() ||
                   ProjectNotes.Any() || ProjectClassifications.Any() || ProjectExemptReportingYears.Any() || ProjectWatersheds.Any() || ProjectUpdateBatches.Any();
        }

        public FeatureCollection SimpleLocationToGeoJsonFeatureCollection(bool addProjectProperties)
        {
            var featureCollection = new FeatureCollection();

            if (ProjectLocationSimpleType == ProjectLocationSimpleType.PointOnMap && HasProjectLocationPoint)
            {
                featureCollection.Features.Add(MakePointFeatureWithRelevantProperties(ProjectLocationPoint, addProjectProperties));
            }
            return featureCollection;
        }

        public IEnumerable<IQuestionAnswer> GetQuestionAnswers()
        {
            return ProjectAssessmentQuestions;
        }

        public IEnumerable<IProjectLocation> GetProjectLocationDetails()
        {
            return ProjectLocations.ToList();
        }

        public IEnumerable<Watershed> GetProjectWatersheds()
        {
            return ProjectWatersheds.Select(x => x.Watershed);
        }

        public FeatureCollection DetailedLocationToGeoJsonFeatureCollection()
        {
            return ProjectLocations.ToGeoJsonFeatureCollection();
        }

        public static FeatureCollection MappedPointsToGeoJsonFeatureCollection(List<IMappableProject> projects, bool addProjectProperties, Func<IMappableProject, bool> filterFunction)
        {
            var featureCollection = new FeatureCollection();
            var filteredProjectList = projects.Where(x => x.HasProjectLocationPoint).Where(filterFunction).ToList();
            featureCollection.Features.AddRange(filteredProjectList.Select(project => project.MakePointFeatureWithRelevantProperties(project.ProjectLocationPoint, addProjectProperties)).ToList());
            return featureCollection;
        }

        public static FeatureCollection MappedPointsToGeoJsonFeatureCollection(List<IMappableProject> projects, bool addProjectProperties)
        {
            return MappedPointsToGeoJsonFeatureCollection(projects, addProjectProperties, x => x.ProjectStage.ShouldShowOnMap());
        }

        public Feature MakePointFeatureWithRelevantProperties(DbGeometry projectLocationPoint, bool addProjectProperties)
        {
            var feature = DbGeometryToGeoJsonHelper.FromDbGeometry(projectLocationPoint);
            feature.Properties.Add("TaxonomyTierThreeID", TaxonomyTierOne.TaxonomyTierTwo.TaxonomyTierThreeID.ToString(CultureInfo.InvariantCulture));
            feature.Properties.Add("ProjectStageID", ProjectStageID.ToString(CultureInfo.InvariantCulture));
            feature.Properties.Add("Info", DisplayName);
            if (addProjectProperties)
            {
                feature.Properties.Add("ProjectID", ProjectID.ToString(CultureInfo.InvariantCulture));
                feature.Properties.Add("TaxonomyTierTwoID", TaxonomyTierOne.TaxonomyTierTwoID.ToString(CultureInfo.InvariantCulture));
                feature.Properties.Add("TaxonomyTierOneID", TaxonomyTierOneID.ToString(CultureInfo.InvariantCulture));
                feature.Properties.Add("ClassificationID", String.Join(",", ProjectClassifications.Select(x => x.ClassificationID)));
                foreach (var type in ProjectOrganizations.Select(x => x.RelationshipType).Distinct())
                {
                    feature.Properties.Add($"{type.RelationshipTypeName}ID", ProjectOrganizations.Where(y => y.RelationshipType == type).Select(z => z.OrganizationID));
                }                
                feature.Properties.Add("PopupUrl", this.GetProjectMapPopupUrl());
            }
            return feature;
        }        

        public string Duration => $"{ImplementationStartYear?.ToString(CultureInfo.InvariantCulture) ?? "?"} - {CompletionYear?.ToString(CultureInfo.InvariantCulture) ?? "?"}";

        public string ProjectOrganizationNamesAndTypes
        {
            get { return ProjectOrganizations.Any() ? String.Join(", ", ProjectOrganizations.OrderByDescending(x => x.RelationshipType.IsPrimaryContact).ThenByDescending(x => x.RelationshipType.CanStewardProjects).ThenBy(x => x.Organization.DisplayName).Select(x => x.Organization.DisplayName).Distinct()) : String.Empty; }
        }

        public string AssocatedOrganizationNames(Organization organization)
        {
            var projectOrganizationAssocationNames = new List<string>();
            ProjectOrganizations.Where(x => x.Organization == organization).ForEach(x => projectOrganizationAssocationNames.Add(x.RelationshipType.RelationshipTypeName));
            return string.Join(",", projectOrganizationAssocationNames);
        }

        public ProjectImage KeyPhoto
        {
            get { return ProjectImages.SingleOrDefault(x => x.IsKeyPhoto); }
        }

        private DateTime _lastUpdateDate;
        private bool _hasCheckedLastUpdateDate;
        public DateTime LastUpdateDate
        {
            get
            {
                if (!_hasCheckedLastUpdateDate)
                {
                    LastUpdateDate = HttpRequestStorage.DatabaseEntities.AuditLogs.GetAuditLogEntriesForProject(this).Max(x => x.AuditLogDate);
                }
                return _lastUpdateDate;
            }
            set
            {
                _lastUpdateDate = value;
                _hasCheckedLastUpdateDate = true;
            }
        }

        public double? ProjectLocationPointLatitude => HasProjectLocationPoint ? ProjectLocationPoint.YCoordinate : null;

        public double? ProjectLocationPointLongitude => HasProjectLocationPoint ? ProjectLocationPoint.XCoordinate : null;

        public FancyTreeNode ToFancyTreeNode()
        {
            var fancyTreeNode = new FancyTreeNode(
                $"{UrlTemplate.MakeHrefString(this.GetFactSheetUrl(), ProjectName, ProjectName)}", FancyTreeNodeKey.ToString(), false) { ThemeColor = TaxonomyTierOne.TaxonomyTierTwo.TaxonomyTierThree.ThemeColor, MapUrl = null };
            return fancyTreeNode;
        }

        /// <summary>
        /// Note this will do a deep delete of this project image, meaning it will remove it from a ProjectImageUpdate if it is tied to that
        /// </summary>
        /// <param name="projectImages"></param>
        public static void DeleteProjectImages(ICollection<ProjectImage> projectImages)
        {
            var projectImageFileResourceIDsToDelete = projectImages.Select(x => x.FileResourceID).ToList();
            var projectImageIDsToDelete = projectImages.Select(x => x.ProjectImageID).ToList();
            HttpRequestStorage.DatabaseEntities.ProjectImageUpdates.Where(x => x.ProjectImageID.HasValue && projectImageIDsToDelete.Contains(x.ProjectImageID.Value)).ToList().DeleteProjectImageUpdate();
            projectImages.DeleteProjectImage();
            projectImageFileResourceIDsToDelete.DeleteFileResource();
        }

        public Dictionary<string, decimal> GetExpendituresDictionary()
        {
            return ProjectFundingSourceExpenditures.Where(x => x.ExpenditureAmount > 0)
                .GroupBy(x => x.FundingSource.FixedLengthDisplayName)
                .ToDictionary(x => x.Key, x => x.Sum(y => y.ExpenditureAmount));
        }

        public IEnumerable<Person> GetProjectStewards()
        {
            return GetCanStewardProjectsOrganization()?.People
                       .Where(y => y.RoleID == Role.ProjectSteward.RoleID)
                       .ToList() ?? new List<Person>();
        }

        public ICollection<IEntityClassification> ProjectClassificationsForMap =>
            new List<IEntityClassification>(ProjectClassifications);

        public bool HasProjectWatersheds => ProjectWatersheds.Any();
        public int FancyTreeNodeKey => ProjectID;

        public List<GooglePieChartSlice> GetExpenditureGooglePieChartSlices()
        {
            var sortOrder = 0;
            var googlePieChartSlices = new List<GooglePieChartSlice>();
            var expendituresDictionary = ProjectFundingSourceExpenditures.Where(x => x.ExpenditureAmount > 0)
                .GroupBy(x => x.FundingSource, new HavePrimaryKeyComparer<FundingSource>())
                .ToDictionary(x => x.Key, x => x.Sum(y => y.ExpenditureAmount));

            var groupingFundingSources = expendituresDictionary.Keys.GroupBy(x => x.Organization.OrganizationType, new HavePrimaryKeyComparer<OrganizationType>());
            foreach (var groupingFundingSource in groupingFundingSources)
            {
                var sectorColor = ColorTranslator.FromHtml(groupingFundingSource.Key.LegendColor);
                groupingFundingSource.OrderBy(x => x.FundingSourceName)
                    .ForEach((fundingSource, index) =>
                    {
                        var color = ColorTranslator.ToHtml(Color.FromArgb(sectorColor.ChangeColorBrightness(index / 10f).ToArgb()));
                        googlePieChartSlices.Add(new GooglePieChartSlice(fundingSource.FixedLengthDisplayName, Convert.ToDouble(expendituresDictionary[fundingSource]), sortOrder++, color));
                    });
            }
            return googlePieChartSlices;
        }

        public List<GooglePieChartSlice> GetFundingSourceRequestGooglePieChartSlices()
        {
            var sortOrder = 0;
            var googlePieChartSlices = new List<GooglePieChartSlice>();

            var securedAmountsDictionary = ProjectFundingSourceRequests.Where(x => x.SecuredAmount > 0)
                .GroupBy(x => x.FundingSource, new HavePrimaryKeyComparer<FundingSource>())
                .ToDictionary(x => x.Key, x => x.Sum(y => y.SecuredAmount));
            var unsecuredAmountsDictionary = ProjectFundingSourceRequests.Where(x => x.UnsecuredAmount > 0)
                .GroupBy(x => x.FundingSource, new HavePrimaryKeyComparer<FundingSource>())
                .ToDictionary(x => x.Key, x => x.Sum(y => y.UnsecuredAmount));

            var securedColorHsl = new { hue = 96.0, sat = 60.0 };
            var unsecuredColorHsl = new { hue = 33.3, sat = 240.0 };

            securedAmountsDictionary.OrderBy(x => x.Key.FundingSourceName).ForEach((fundingSourceDictionaryItem, index) =>
            {
                var fundingSource = fundingSourceDictionaryItem.Key;
                var fundingAmount = fundingSourceDictionaryItem.Value;

                var luminosity = 100.0 * (securedAmountsDictionary.Count - index - 1) / securedAmountsDictionary.Count + 120;
                var color = ColorTranslator.ToHtml(new HslColor(securedColorHsl.hue, securedColorHsl.sat, luminosity));

                googlePieChartSlices.Add(new GooglePieChartSlice("Secured Funding: " + fundingSource.FixedLengthDisplayName, Convert.ToDouble(fundingAmount), sortOrder++, color));

            });

            unsecuredAmountsDictionary.OrderBy(x => x.Key.FundingSourceName).ForEach((fundingSourceDictionaryItem, index) =>
            {
                var fundingSource = fundingSourceDictionaryItem.Key;
                var fundingAmount = fundingSourceDictionaryItem.Value;

                var luminosity = 100.0 * (unsecuredAmountsDictionary.Count - index - 1) / unsecuredAmountsDictionary.Count + 120;
                var color = ColorTranslator.ToHtml(new HslColor(unsecuredColorHsl.hue, unsecuredColorHsl.sat, luminosity));

                googlePieChartSlices.Add(new GooglePieChartSlice("Targeted Funding: " + fundingSource.FixedLengthDisplayName, Convert.ToDouble(fundingAmount), sortOrder++, color));
            });

            return googlePieChartSlices;
        }

        public List<GooglePieChartSlice> GetRequestAmountGooglePieChartSlices()
        {
            var requestAmountsDictionary = GetFundingSourceRequestGooglePieChartSlices();
            var unfundedNeed = Convert.ToDouble(EstimatedTotalCost ?? 0) - requestAmountsDictionary.Sum(x => x.Value);
            if (unfundedNeed > 0)
            {
                var sortOrder = requestAmountsDictionary.Any() ? requestAmountsDictionary.Max(x => x.SortOrder) + 1 : 0;
                requestAmountsDictionary.Add(new GooglePieChartSlice("No Funding Source Identified", unfundedNeed, sortOrder, "#dbdbdb"));
            }
            return requestAmountsDictionary;
        }

        public bool IsActiveProject()
        {
            return !IsProposal() && ProjectApprovalStatus == ProjectApprovalStatus.Approved;
        }

        public bool IsProposal()
        {
            return ProjectStage == ProjectStage.Proposal;
        }

        public bool IsPendingProposal()
        {
            return IsProposal() && ProjectApprovalStatus != ProjectApprovalStatus.Approved && ProjectApprovalStatus != ProjectApprovalStatus.Rejected;
        }

        public bool IsActiveProposal()
        {
            return IsProposal() && ProjectApprovalStatus == ProjectApprovalStatus.PendingApproval;
        }

        public bool IsForwardLookingFactSheetRelevant()
        {
            return ProjectStage.ForwardLookingFactSheetProjectStages.Contains(ProjectStage);
        }

        public bool IsBackwardLookingFactSheetRelevant()
        {
            return !IsForwardLookingFactSheetRelevant();
        }

        public void DeleteProjectFull()
        {
            var notifications = NotificationProjects.Select(x => x.Notification).ToList();
            NotificationProjects.DeleteNotificationProject();
            notifications.DeleteNotification();

            PerformanceMeasureActuals.SelectMany(x => x.PerformanceMeasureActualSubcategoryOptions).ToList()
                .DeletePerformanceMeasureActualSubcategoryOption();
            PerformanceMeasureActuals.DeletePerformanceMeasureActual();
            PerformanceMeasureExpecteds.SelectMany(x => x.PerformanceMeasureExpectedSubcategoryOptions).ToList()
                .DeletePerformanceMeasureExpectedSubcategoryOption();
            PerformanceMeasureExpecteds.DeletePerformanceMeasureExpected();
            ProjectAssessmentQuestions.DeleteProjectAssessmentQuestion();
            ProjectBudgets.DeleteProjectBudget();
            ProjectClassifications.DeleteProjectClassification();
            ProjectExemptReportingYears.DeleteProjectExemptReportingYear();
            ProjectExternalLinks.DeleteProjectExternalLink();
            ProjectFundingSourceExpenditures.DeleteProjectFundingSourceExpenditure();
            ProjectFundingSourceRequests.DeleteProjectFundingSourceRequest();
            var fileResources = ProjectImages.Select(x => x.FileResource).ToList();
            ProjectImages.DeleteProjectImage();
            fileResources.DeleteFileResource();
            ProjectLocations.DeleteProjectLocation();
            ProjectLocationStagings.DeleteProjectLocationStaging();
            ProjectNotes.DeleteProjectNote();
            ProjectOrganizations.DeleteProjectOrganization();
            ProjectTags.DeleteProjectTag();

            foreach (var projectUpdateBatch in ProjectUpdateBatches.ToList())
            {
                projectUpdateBatch.DeleteAll();
            }

            ProjectWatersheds.DeleteProjectWatershed();

            SnapshotProjects.DeleteSnapshotProject();
            this.DeleteProject();
        }
    }
}
