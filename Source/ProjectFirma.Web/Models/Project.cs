using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Globalization;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.Shared;
using EntityFramework.Extensions;
using GeoJSON.Net.Feature;
using LtInfo.Common;
using LtInfo.Common.DbSpatial;
using LtInfo.Common.GeoJson;
using LtInfo.Common.Models;
using LtInfo.Common.Views;
using MoreLinq;

namespace ProjectFirma.Web.Models
{
    public partial class Project : IAuditableEntity, IProject
    {
        public Project(Project project)
            : this(
                project.TaxonomyTierOne,
                project.ProjectStage,
                project.ProjectName,
                project.ProjectDescription,
                project.IsFeatured,
                project.ProjectLocationSimpleType,
                project.FundingType)
        {
            project.ProjectImplementingOrganizations.ForEach(x => ProjectImplementingOrganizations.Add(x));
        }

        public int EntityID
        {
            get { return ProjectID; }
        }

        public string AuditDescriptionString
        {
            get { return ProjectName; }
        }

        public string DisplayName
        {
            get { return ProjectName; }
        }

        public HtmlString DisplayNameAsUrl
        {
            get { return UrlTemplate.MakeHrefString(this.GetDetailUrl(), DisplayName); }
        }

        public Organization LeadImplementer
        {
            get
            {
                var leadImplementingOrganization = ProjectImplementingOrganizations.SingleOrDefault(o => o.IsLeadOrganization);
                return leadImplementingOrganization != null ? leadImplementingOrganization.Organization : null;
            }
        }

        public int? LeadImplementerOrganizationID
        {
            get { return LeadImplementer != null ? LeadImplementer.OrganizationID : (int?)null; }
        }

        public string LeadImplementerName
        {
            get { return LeadImplementer != null ? LeadImplementer.OrganizationName : String.Empty; }
        }

        public List<ProjectImplementingOrganizationOrProjectFundingOrganization> GetAllProjectOrganizations()
        {
            var implementingOrgs = ProjectImplementingOrganizations.ToList().ToLookup(x => x.OrganizationID);
            var fundingOrgs = ProjectFundingOrganizations.ToList().ToLookup(x => x.OrganizationID);
            var allOrgs = implementingOrgs.Select(x => x.Key).Union(fundingOrgs.Select(x => x.Key)).ToList();
            var projectImplementingOrganizationOrProjectFundingOrganizations =
                allOrgs.Select(
                    organizationID => new ProjectImplementingOrganizationOrProjectFundingOrganization(implementingOrgs[organizationID].SingleOrDefault(), fundingOrgs[organizationID].SingleOrDefault()))
                    .ToList();
            return projectImplementingOrganizationOrProjectFundingOrganizations.OrderBy(x => x.Organization.OrganizationName).ToList();
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

        public bool IsOnActiveProjectsList
        {
            get { return ProjectStage.IsOnActiveProjectsList(); }
        }

        public Person PrimaryContactPerson
        {
            // Primary Contact could very well turn out to be null
            get { return LeadImplementer != null ? (LeadImplementer.PrimaryContactPerson) : null; }
        }

        public decimal? UnfundedNeed
        {
            get { return EstimatedTotalCost - SecuredFunding; }
        }

        public decimal? TotalExpenditures
        {
            get { return ProjectFundingSourceExpenditures.Any() ? ProjectFundingSourceExpenditures.Sum(x => x.ExpenditureAmount) : (decimal?)null; }
        }

        public bool HasProjectLocationPoint
        {
            get { return ProjectLocationPoint != null; }
        }

        //TODO: This could be moved to ProjectLocationSimpleType and made smarter
        public string ProjectLocationTypeDisplay
        {
            get
            {
                if (ProjectLocationAreaID.HasValue && ProjectLocationArea.ProjectLocationAreaGroup.ProjectLocationAreaGroupType == ProjectLocationAreaGroupType.MappedRegion)
                {
                    return ProjectLocationArea.ProjectLocationAreaDisplayName;
                }
                return ViewUtilities.NaString;
            }
        }

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

        public bool IsUpdatableViaProjectUpdateProcess
        {
            get { return ProjectStage.RequiresReportedExpenditures() || ProjectStage.RequiresPerformanceMeasureActuals(); }
        }

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

        private string _projectLocationJurisdiction;
        private bool _hasSetProjectLocationJurisdiction;
        public string ProjectLocationJurisdiction
        {
            get
            {
                if (_hasSetProjectLocationJurisdiction)
                {
                    return _projectLocationJurisdiction;
                }
                SetProjectJurisdiction(HttpRequestStorage.DatabaseEntities.Jurisdictions.GetJurisdictionsWithGeospatialFeatures(), HttpRequestStorage.DatabaseEntities.ProjectLocationAreas.ToDictionary(x => x.ProjectLocationAreaID));
                return _projectLocationJurisdiction;
            }
            set
            {
                _projectLocationJurisdiction = value;
                _hasSetProjectLocationJurisdiction = true;
            }
        }

        public void SetProjectJurisdiction(IEnumerable<Jurisdiction> jurisdictions, Dictionary<int, ProjectLocationArea> projectLocationAreas)
        {
            if (HasProjectLocationPoint)
            {
                var countyOrCity = jurisdictions.FirstOrDefault(x => x.JurisdictionFeature.Intersects(ProjectLocationPoint));
                ProjectLocationJurisdiction = countyOrCity != null ? countyOrCity.Organization.OrganizationName : ViewUtilities.NaString;
            }
            else if (ProjectLocationAreaID.HasValue)
            {
                ProjectLocationJurisdiction = String.Join(", ", projectLocationAreas[ProjectLocationAreaID.Value].ProjectLocationAreaJurisdictions.Select(x => x.Jurisdiction.Organization.OrganizationName));
            }
            else
            {
                ProjectLocationJurisdiction = ViewUtilities.NaString;
            }
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
                SetProjectLocationStateProvince(HttpRequestStorage.DatabaseEntities.StateProvinces.ToList(), HttpRequestStorage.DatabaseEntities.ProjectLocationAreas.ToDictionary(x => x.ProjectLocationAreaID));
                return _projectLocationStateProvince;
            }
            set
            {
                _projectLocationStateProvince = value;
                _hasSetProjectLocationStateProvince = true;
            }
        }

        public void SetProjectLocationStateProvince(IEnumerable<StateProvince> stateProvinces, Dictionary<int, ProjectLocationArea> projectLocationAreas)
        {

            if (HasProjectLocationPoint)
            {
                var stateProvince = stateProvinces.FirstOrDefault(x => x.StateProvinceFeatureForAnalysis.Intersects(ProjectLocationPoint));
                ProjectLocationStateProvince = stateProvince != null ? stateProvince.StateProvinceAbbreviation : ViewUtilities.NaString;
            }
            else if (ProjectLocationAreaID.HasValue)
            {
                ProjectLocationStateProvince = String.Join(", ", projectLocationAreas[ProjectLocationAreaID.Value].ProjectLocationAreaStateProvinces.Select(x => x.StateProvince.StateProvinceAbbreviation));
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
                SetProjectLocationWatershed(HttpRequestStorage.DatabaseEntities.Watersheds.GetWatershedsWithGeospatialFeatures(), HttpRequestStorage.DatabaseEntities.ProjectLocationAreas.ToDictionary(x => x.ProjectLocationAreaID));
                return _projectLocationWatershed;
            }
            set
            {
                _projectLocationWatershed = value;
                _hasSetProjectLocationWatershed = true;
            }
        }

        public void SetProjectLocationWatershed(IEnumerable<Watershed> watersheds, Dictionary<int, ProjectLocationArea> projectLocationAreas)
        {
            if (HasProjectLocationPoint)
            {
                var watershed = watersheds.FirstOrDefault(x => x.WatershedFeature.Intersects(ProjectLocationPoint));
                ProjectLocationWatershed = watershed != null ? watershed.WatershedName : ViewUtilities.NaString;
            }
            else if (ProjectLocationAreaID.HasValue)
            {
                ProjectLocationWatershed = String.Join(", ", projectLocationAreas[ProjectLocationAreaID.Value].ProjectLocationAreaWatersheds.Select(x => x.Watershed.WatershedName));
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
            return IsPersonThePrimaryContact(person) || DoesPersonBelongToProjectLeadImplementingOranization(person);
        }

        public bool IsVisibleToThisPerson(Person person)
        {
            return IsVisibleToEveryone() || IsMyProject(person) || new AdminFeature().HasPermissionByPerson(person);
        }

        public bool IsPersonThePrimaryContact(Person person)
        {
            return PrimaryContactPerson != null && person != null && person.PersonID == PrimaryContactPerson.PersonID;
        }

        public bool DoesPersonBelongToProjectLeadImplementingOranization(Person person)
        {
            return person != null && LeadImplementer != null && LeadImplementer.OrganizationID == person.OrganizationID;
        }

        public List<PerformanceMeasureReportedValue> GetReportedPerformanceMeasures()
        {
            var performanceMeasureReportedValues = PerformanceMeasureActuals.Select(x => x.PerformanceMeasure).Distinct(new HavePrimaryKeyComparer<PerformanceMeasure>()).SelectMany(x => x.GetReportedPerformanceMeasureValues(null)).ToList();
            return performanceMeasureReportedValues.OrderByDescending(pma => pma.CalendarYear).ThenBy(pma => pma.PerformanceMeasureID).ToList();
        }

        public bool HasDependentObjectsThatCount()
        {
            return PerformanceMeasureActuals.Any() || PerformanceMeasureExpecteds.Any() || ProjectFundingSourceExpenditures.Any() || ProjectImages.Any() ||
                   ProjectNotes.Any() || ProjectClassifications.Any() || ProjectExemptReportingYears.Any() || ProjectWatersheds.Any() || ProjectUpdateBatches.Any();
        }

        public PermissionCheckResult CanDelete()
        {
            if (HasDependentObjectsThatCount())
            {
                return new PermissionCheckResult(ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("project"));
            }

            if (!ProjectStage.IsDeletable())
            {
                return new PermissionCheckResult(String.Format("Can't delete project: can only delete when in following stages: {0}.", String.Join(", ", ProjectStage.All.Where(x => x.IsDeletable()).Select(x => x.ProjectStageDisplayName))));
            }
            return new PermissionCheckResult();
        }

        public FeatureCollection SimpleLocationToGeoJsonFeatureCollection(bool addProjectProperties)
        {
            var featureCollection = new FeatureCollection();

            if (ProjectLocationSimpleType == ProjectLocationSimpleType.PointOnMap && HasProjectLocationPoint)
            {
                featureCollection.Features.Add(MakePointFeatureWithRelevantProperties(ProjectLocationPoint, addProjectProperties));
            }
            else if (ProjectLocationSimpleType == ProjectLocationSimpleType.NamedAreas)
            {
                featureCollection.Features.Add(DbGeometryToGeoJsonHelper.FromDbGeometry(ProjectLocationArea.GetGeometry()));
            }
            return featureCollection;
        }

        public ProjectType ProjectType { get { return ProjectType.Project;} }

        public IEnumerable<IQuestionAnswer> GetQuestionAnswers()
        {
            return ProjectAssessmentQuestions;
        }

        public IEnumerable<IProjectLocation> GetProjectLocationDetails()
        {
            return ProjectLocations.ToList();
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
                feature.Properties.Add("ImplementingOrganizationID", String.Join(",", ProjectImplementingOrganizations.Select(x => x.OrganizationID)));
                feature.Properties.Add("FundingOrganizationID", String.Join(",", ProjectFundingOrganizations.Select(x => x.OrganizationID)));
                feature.Properties.Add("PopupUrl", this.GetProjectMapPopupUrl());
            }
            return feature;
        }

        public static FeatureCollection NamedAreasToPointGeoJsonFeatureCollection(List<Project> projects, bool addProjectProperties)
        {
            return NamedAreasToPointGeoJsonFeatureCollection(projects, addProjectProperties, x => x.ProjectStage.ShouldShowOnMap());
        }

        public static FeatureCollection NamedAreasToPointGeoJsonFeatureCollection(List<Project> projects, bool addProjectProperties, Func<Project, bool> filterFunction)
        {
            var featureCollection = new FeatureCollection();
            var namedAreasProjects = projects.Where(x => x.ProjectLocationSimpleType == ProjectLocationSimpleType.NamedAreas).Where(filterFunction).ToList();

            if (!namedAreasProjects.Any())
                return featureCollection;

            foreach (var namedAreaGroup in namedAreasProjects.GroupBy(x => x.ProjectLocationArea.ProjectLocationAreaName))
            {
                var features = LocateNamedAreaPointsAroundCentroid(namedAreaGroup.ToList(), addProjectProperties);
                featureCollection.Features.AddRange(features);
            }
            return featureCollection;
        }

        private static List<Feature> LocateNamedAreaPointsAroundCentroid(List<Project> projects, bool addProjectProperties)
        {
            var features = new List<Feature>();
            const int pointsInFirstRing = 10;
            const int radiusOfFirstRingInFeet = 5000;
            var ringIndex = 0;
            var pointsRemainingInRingCount = 1;
            var remainingProjectCount = projects.Count;
            var deltaTheta = 0d;
            var theta = 0d;

            foreach (var project in projects)
            {
                var spreadRadiusFeet = radiusOfFirstRingInFeet * ringIndex;
                var namedAreaGeometry = project.ProjectLocationArea.GetGeometry();
                var xSpreadLonDegree = DbSpatialHelper.FeetToLonDegree(namedAreaGeometry, spreadRadiusFeet);
                var ySpreadLatDegree = DbSpatialHelper.FeetToLatDegree(namedAreaGeometry, spreadRadiusFeet);

                theta += deltaTheta;

                var x = namedAreaGeometry.Centroid.XCoordinate.Value + Math.Sin(theta) * xSpreadLonDegree;
                var y = namedAreaGeometry.Centroid.YCoordinate.Value + Math.Cos(theta) * ySpreadLatDegree;

                var geom = DbSpatialHelper.MakeDbGeometryFromCoordinates(x, y, namedAreaGeometry.CoordinateSystemId);
                var feature = project.MakePointFeatureWithRelevantProperties(geom, addProjectProperties);
                features.Add(feature);

                pointsRemainingInRingCount--;
                remainingProjectCount--;

                if (pointsRemainingInRingCount == 0)
                {
                    ringIndex++;
                    pointsRemainingInRingCount = Math.Min(remainingProjectCount, pointsInFirstRing * ringIndex);
                    deltaTheta = 2 * Math.PI / pointsRemainingInRingCount;
                    theta = 0d;
                }
            }
            return features;
        }

        public string Duration
        {
            get { return String.Format("{0} - {1}", ImplementationStartYear.HasValue ? ImplementationStartYear.Value.ToString(CultureInfo.InvariantCulture) : "?", CompletionYear.HasValue ? CompletionYear.Value.ToString(CultureInfo.InvariantCulture) : "?"); }
        }

        public string ProjectImplementingOrganizationNames
        {
            get { return ProjectImplementingOrganizations.Any() ? String.Join(", ", ProjectImplementingOrganizations.OrderByDescending(x => x.IsLeadOrganization).ThenBy(x => x.Organization.OrganizationName).Select(x => x.Organization.OrganizationName)) : String.Empty; }
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

        public double? ProjectLocationPointLatitude
        {
            get { return HasProjectLocationPoint ? ProjectLocationPoint.YCoordinate : null; }
        }

        public double? ProjectLocationPointLongitude
        {
            get { return HasProjectLocationPoint ? ProjectLocationPoint.XCoordinate : null; }
        }

        public FancyTreeNode ToFancyTreeNode()
        {
            var fancyTreeNode = new FancyTreeNode(String.Format("{0}", UrlTemplate.MakeHrefString(this.GetFactSheetUrl(), ProjectName, ProjectName)), ProjectID.ToString(), false) { ThemeColor = TaxonomyTierOne.TaxonomyTierTwo.TaxonomyTierThree.ThemeColor, MapUrl = null };
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
            HttpRequestStorage.DatabaseEntities.ProjectImageUpdates.Where(x => x.ProjectImageID.HasValue && projectImageIDsToDelete.Contains(x.ProjectImageID.Value)).Delete();
            HttpRequestStorage.DatabaseEntities.ProjectImages.DeleteProjectImage(projectImageIDsToDelete);
            HttpRequestStorage.DatabaseEntities.FileResources.DeleteFileResource(projectImageFileResourceIDsToDelete);
        }
        }
}