/*-----------------------------------------------------------------------
<copyright file="Project.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.Globalization;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using GeoJSON.Net.Feature;
using LtInfo.Common;
using LtInfo.Common.GeoJson;
using LtInfo.Common.Models;
using LtInfo.Common.Views;
using MoreLinq;

namespace ProjectFirma.Web.Models
{
    public partial class Project : IAuditableEntity, IProject
    {
        public int EntityID => ProjectID;

        public string AuditDescriptionString => ProjectName;

        public string DisplayName => ProjectName;

        public HtmlString DisplayNameAsUrl => UrlTemplate.MakeHrefString(this.GetDetailUrl(), DisplayName);

        public List<ProjectOrganization> GetAllProjectOrganizations()
        {
            return ProjectOrganizations.OrderBy(x => x.Organization.OrganizationName).ToList();
        }

        public static bool IsProjectNameUnique(IEnumerable<Project> projects, string projectName, int currentProjectID)
        {
            if (string.IsNullOrWhiteSpace(projectName))
            {
                return false;
            }
            var project = projects.SingleOrDefault(x => x.ProjectID != currentProjectID && String.Equals(x.ProjectName.Trim(), projectName.Trim(), StringComparison.InvariantCultureIgnoreCase));
            return project == null;
        }

        public Person GetPrimaryContact() => PrimaryContactPerson ??
                                             ProjectOrganizations.Where(x => x.RelationshipType.IsPrimaryContact)
                                                 .Select(x => x.Organization.PrimaryContactPerson).FirstOrDefault(); // TODO: Probably want to handle the case where there are multiple primary contact organizations

        public decimal? UnfundedNeed => EstimatedTotalCost - SecuredFunding;

        public decimal? TotalExpenditures
        {
            get { return ProjectFundingSourceExpenditures.Any() ? ProjectFundingSourceExpenditures.Sum(x => x.ExpenditureAmount) : (decimal?)null; }
        }

        public bool HasProjectLocationPoint => ProjectLocationPoint != null;

        //TODO: This could be moved to ProjectLocationSimpleType and made smarter
        public string ProjectLocationTypeDisplay => ViewUtilities.NaString;

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

        private string _projectLocationWatershed;
        private bool _hasSetProjectLocationWatershed;
        public string ProjectLocationWatershed
        {
            get
            {
                if (_hasSetProjectLocationWatershed)
                {
                    return _projectLocationWatershed;
                }
                SetProjectLocationWatershed(HttpRequestStorage.DatabaseEntities.Watersheds.GetWatershedsWithGeospatialFeatures());
                return _projectLocationWatershed;
            }
            set
            {
                _projectLocationWatershed = value;
                _hasSetProjectLocationWatershed = true;
            }
        }

        public void SetProjectLocationWatershed(IEnumerable<Watershed> watersheds)
        {
            if (HasProjectLocationPoint)
            {
                var watershed = watersheds.FirstOrDefault(x => x.WatershedFeature.Intersects(ProjectLocationPoint));
                ProjectLocationWatershed = watershed != null ? watershed.WatershedName : ViewUtilities.NaString;
            }
            else
            {
                ProjectLocationWatershed = ViewUtilities.NaString;
            }
        }

        public bool IsVisibleToEveryone()
        {
            return ProjectStage.IsVisibleToEveryone();
        }

        public bool IsMyProject(Person person)
        {
            return IsPersonThePrimaryContact(person) || DoesPersonBelongToProjectLeadImplementingOrganization(person);
        }

        public bool IsVisibleToThisPerson(Person person)
        {
            return IsVisibleToEveryone() || IsMyProject(person) || new FirmaAdminFeature().HasPermissionByPerson(person);
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

        public bool DoesPersonBelongToProjectLeadImplementingOrganization(Person person)
        {
            if (person == null)
            {
                return false;
            }
            var primaryContactProjectOrganizations = ProjectOrganizations.Where(x => x.RelationshipType.IsPrimaryContact);
            return primaryContactProjectOrganizations.Any(x => x.OrganizationID == person.OrganizationID);
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

        public ProjectType ProjectType => ProjectType.Project;

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

        public static FeatureCollection MappedPointsToGeoJsonFeatureCollection(List<Project> projects, bool addProjectProperties, Func<Project, bool> filterFunction)
        {
            var featureCollection = new FeatureCollection();
            var filteredProjectList = projects.Where(x => x.HasProjectLocationPoint).Where(filterFunction).ToList();
            featureCollection.Features.AddRange(filteredProjectList.Select(project => project.MakePointFeatureWithRelevantProperties(project.ProjectLocationPoint, addProjectProperties)).ToList());
            return featureCollection;
        }

        public static FeatureCollection MappedPointsToGeoJsonFeatureCollection(List<Project> projects, bool addProjectProperties)
        {
            return MappedPointsToGeoJsonFeatureCollection(projects, addProjectProperties, x => x.ProjectStage.ShouldShowOnMap());
        }

        public Feature MakePointFeatureWithRelevantProperties(DbGeometry projectLocationPoint, bool addProjectProperties)
        {
            var feature = DbGeometryToGeoJsonHelper.FromDbGeometry(projectLocationPoint);
            feature.Properties.Add("TaxonomyTierThreeID", TaxonomyTierOne.TaxonomyTierTwo.TaxonomyTierThreeID.ToString(CultureInfo.InvariantCulture));
            feature.Properties.Add("ProjectStageID", ProjectStageID.ToString(CultureInfo.InvariantCulture));
            if (addProjectProperties)
            {
                feature.Properties.Add("ProjectID", ProjectID.ToString(CultureInfo.InvariantCulture));
                feature.Properties.Add("ProjectName", DisplayName);
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
            get { return ProjectOrganizations.Any() ? String.Join(", ", ProjectOrganizations.OrderBy(x => x.RelationshipType.RelationshipTypeName).ThenBy(x => x.Organization.OrganizationName).Select(x => x.Organization.OrganizationName)) : String.Empty; }
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
                $"{UrlTemplate.MakeHrefString(this.GetFactSheetUrl(), ProjectName, ProjectName)}", ProjectID.ToString(), false) { ThemeColor = TaxonomyTierOne.TaxonomyTierTwo.TaxonomyTierThree.ThemeColor, MapUrl = null };
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

        public IEnumerable<Person> GetProjectOwnersForProject()
        {
            return ProjectOrganizations.Where(x => x.RelationshipType.CanApproveProjects)
                .SelectMany(x => x.Organization.People.Where(y => y.RoleID == Role.ProjectOwner.RoleID)).ToList();
        }
    }
}
