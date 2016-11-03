using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using LtInfo.Common;
using LtInfo.Common.GeoJson;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class ProposedProject : IAuditableEntity, IProject
    {
        public int EntityID
        {
            get {  return ProposedProjectID; }
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
            get { return UrlTemplate.MakeHrefString(this.GetSummaryUrl(), DisplayName); }
        }

        public static bool IsProjectNameUnique(IEnumerable<ProposedProject> projects, string projectName, int currentProposedProjectID)
        {
            var project = projects.SingleOrDefault(x => x.ProposedProjectID != currentProposedProjectID && String.Equals(x.ProjectName, projectName, StringComparison.InvariantCultureIgnoreCase));
            return project == null;
        }

        public Person PrimaryContactPerson
        {
            // Primary Contact could very well turn out to be null
            get { return LeadImplementerOrganization != null ? (LeadImplementerOrganization.PrimaryContactPerson) : null; }
        }

        public decimal? UnfundedNeed
        {
            get { return EstimatedTotalCost - SecuredFunding; }
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
                SetProjectLocationJurisdiction(HttpRequestStorage.DatabaseEntities.Jurisdictions.GetJurisdictionsWithGeospatialFeatures());
                return _projectLocationJurisdiction;
            }
            set
            {
                _projectLocationJurisdiction = value;
                _hasSetProjectLocationJurisdiction = true;
            }
        }

        public void SetProjectLocationJurisdiction(IEnumerable<Jurisdiction> jurisdictions)
        {
            if (HasProjectLocationPoint)
            {
                var jurisdiction = jurisdictions.FirstOrDefault(x => x.JurisdictionFeature.Intersects(ProjectLocationPoint));
                ProjectLocationJurisdiction = jurisdiction != null ? jurisdiction.Organization.OrganizationName : ViewUtilities.NaString;
            }
            else if (ProjectLocationAreaID.HasValue)
            {
                ProjectLocationJurisdiction = string.Join(", ", ProjectLocationArea.ProjectLocationAreaJurisdictions.Select(x => x.Jurisdiction.Organization.OrganizationName));
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
            else if (ProjectLocationAreaID.HasValue)
            {
                ProjectLocationStateProvince = string.Join(", ", ProjectLocationArea.ProjectLocationAreaStateProvinces.Select(x => x.StateProvince.StateProvinceAbbreviation));
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
            else if (ProjectLocationAreaID.HasValue)
            {
                ProjectLocationWatershed = string.Join(", ", ProjectLocationArea.ProjectLocationAreaWatersheds.Select(x => x.Watershed.WatershedName));
            }
            else
            {
                ProjectLocationWatershed = ViewUtilities.NaString;
            }
        }

        private Jurisdiction GetJurisdiction(IEnumerable<Jurisdiction> jurisdictions)
        {
            return jurisdictions.FirstOrDefault(x => x.JurisdictionFeature.Intersects(ProjectLocationPoint));
        }

        public bool IsMyProposedProject(Person person)
        {
            return IsPersonThePrimaryContact(person) || DoesPersonBelongToProposedProjectLeadImplementingOranization(person) || person.PersonID == ProposingPersonID;
        }

        public bool IsEditableToThisPerson(Person person)
        {
            return IsMyProposedProject(person) || new ProposedProjectApproveFeature().HasPermissionByPerson(person);
        }

        public bool IsVisibleToThisPerson(Person person)
        {
            return IsMyProposedProject(person) || new ProposedProjectApproveFeature().HasPermissionByPerson(person) || new AdminFeature().HasPermissionByPerson(person);
        }

        public bool IsPersonThePrimaryContact(Person person)
        {
            return PrimaryContactPerson != null && person != null && person.PersonID == PrimaryContactPerson.PersonID;
        }

        public bool DoesPersonBelongToProposedProjectLeadImplementingOranization(Person person)
        {
            return person != null && LeadImplementerOrganizationID == person.OrganizationID;
        }

        public PermissionCheckResult CanDelete()
        {
            return new PermissionCheckResult();
        }

        public ProjectStage ProjectStage
        {
            get { return ProjectStage.PlanningDesign; }
        }

        public ProjectType ProjectType {get { return ProjectType.ProposedProject; }}

        public IEnumerable<IQuestionAnswer> GetQuestionAnswers()
        {
            return ProposedProjectAssessmentQuestions;
        }

        public IEnumerable<IProjectLocation> GetProjectLocationDetails()
        {
            return ProposedProjectLocations.ToList();
        }

        public GeoJSON.Net.Feature.FeatureCollection DetailedLocationToGeoJsonFeatureCollection()
        {
            return ProposedProjectLocations.ToGeoJsonFeatureCollection();
        }

        public GeoJSON.Net.Feature.FeatureCollection SimpleLocationToGeoJsonFeatureCollection(bool addProjectProperties)
        {
            var featureCollection = new GeoJSON.Net.Feature.FeatureCollection();
            if (ProjectLocationSimpleType == ProjectLocationSimpleType.PointOnMap)
            {
                featureCollection.Features.Add(DbGeometryToGeoJsonHelper.FromDbGeometry(ProjectLocationPoint));
            }
            else if (ProjectLocationSimpleType == ProjectLocationSimpleType.NamedAreas)
            {
                featureCollection.Features.Add(DbGeometryToGeoJsonHelper.FromDbGeometry(ProjectLocationArea.GetGeometry()));
            }
            return featureCollection;
        }

        public string Duration
        {
            get
            {
                return string.Format("{0} - {1}",
                    ImplementationStartYear.HasValue ? ImplementationStartYear.Value.ToString(CultureInfo.InvariantCulture) : "?",
                    CompletionYear.HasValue ? CompletionYear.Value.ToString(CultureInfo.InvariantCulture) : "?");
            }
        }

        public Project PromoteToProject(ProposedProject proposedProject)
        {
            var actionPriority = HttpRequestStorage.DatabaseEntities.ActionPriorities.GetActionPriority(proposedProject.ActionPriorityID.Value);
            var nextProjectNumber = Project.GetNextProjectNumber(actionPriority);
            var projectName = proposedProject.ProjectName;

            var project = new Project(proposedProject.ActionPriorityID.Value,
                ProjectStage.PlanningDesign.ProjectStageID,
                nextProjectNumber,
                projectName,
                proposedProject.ProjectDescription,
                false,
                false,
                ProjectLocationSimpleType.ProjectLocationSimpleTypeID,
                FundingType.FundingTypeID)
            {
                PlanningDesignStartYear =  proposedProject.PlanningDesignStartYear,
                ImplementationStartYear =  proposedProject.ImplementationStartYear,
                CompletionYear = proposedProject.CompletionYear,
                EstimatedTotalCost =  proposedProject.EstimatedTotalCost,
                EstimatedAnnualOperatingCost = proposedProject.EstimatedAnnualOperatingCost,
                SecuredFunding= proposedProject.SecuredFunding,
                ProjectLocationPoint = proposedProject.ProjectLocationPoint,
                ProjectLocationAreaID = proposedProject.ProjectLocationAreaID,
                ProjectLocationNotes = proposedProject.ProjectLocationNotes,
            };
            project.ProjectNotes = proposedProject.ProposedProjectNotes.Select(x => new ProjectNote(project, x.Note, x.CreateDate)).ToList();
            project.ProjectThresholdCategories = proposedProject.ProposedProjectThresholdCategories.Select(x => new ProjectThresholdCategory(project.ProjectID, x.ThresholdCategoryID, x.ProposedProjectThresholdCategoryNotes)).ToList();            

            project.ProjectImplementingOrganizations.Add(new ProjectImplementingOrganization(project, proposedProject.LeadImplementerOrganization, true));

            project.ImplementsMultipleProjects = proposedProject.ImplementsMultipleProjects ?? false;

            project.ProjectAssessmentQuestions = proposedProject.ProposedProjectAssessmentQuestions.OrderBy(x => x.AssessmentQuestionID).Select(x => new ProjectAssessmentQuestion(project.ProjectID, x.AssessmentQuestionID) {Answer = x.Answer}).ToList();

            foreach (var performanceMeasureExpectedProposed in proposedProject.PerformanceMeasureExpectedProposeds)
            {
                var performanceMeasureExpected = new PerformanceMeasureExpected(project.ProjectID, performanceMeasureExpectedProposed.PerformanceMeasureID);
                performanceMeasureExpected.ExpectedValue = performanceMeasureExpectedProposed.ExpectedValue;
                foreach (
                    var performanceMeasureExpectedSubcategoryOptionProposed in
                        performanceMeasureExpectedProposed.PerformanceMeasureExpectedSubcategoryOptionProposeds)
                {
                    var performanceMeasureExpectedSubcategoryOption = new PerformanceMeasureExpectedSubcategoryOption(performanceMeasureExpected,
                        performanceMeasureExpectedSubcategoryOptionProposed.IndicatorSubcategoryOption,
                        performanceMeasureExpectedSubcategoryOptionProposed.PerformanceMeasure,
                        performanceMeasureExpectedSubcategoryOptionProposed.IndicatorSubcategory);

                    performanceMeasureExpected.IndicatorSubcategoryOptions.Add(performanceMeasureExpectedSubcategoryOption);
                }
                project.PerformanceMeasureExpecteds.Add(performanceMeasureExpected);
            }

            foreach (var proposedProjectLocation in proposedProject.ProposedProjectLocations)
            {
                var projectLocation = new ProjectLocation(project, proposedProjectLocation.DbGeometry, proposedProjectLocation.Annotation);
                project.ProjectLocations.Add(projectLocation);
            }

            foreach (var proposedProjectImage in proposedProject.ProposedProjectImages)
            {
                var newFileResource = new FileResource(proposedProjectImage.FileResource.FileResourceMimeType, proposedProjectImage.FileResource.OriginalBaseFilename, proposedProjectImage.FileResource.OriginalFileExtension, Guid.NewGuid(), proposedProjectImage.FileResource.FileResourceData, proposedProjectImage.FileResource.CreatePerson, proposedProjectImage.FileResource.CreateDate);
                var newProjectImage = new ProjectImage(newFileResource, project, ProjectImageTiming.Before, proposedProjectImage.Caption, proposedProjectImage.Credit, false, false);
                project.ProjectImages.Add(newProjectImage);
            }

            return project;
        }

        private DateTime _lastUpdateDate;
        private bool _hasCheckedLastUpdateDate;
        
        public DateTime LastUpdateDate
        {
            get
            {
                if (!_hasCheckedLastUpdateDate)
                {
                    LastUpdateDate = HttpRequestStorage.DatabaseEntities.AuditLogs.GetAuditLogEntriesForProposedProject(this).Max(x => x.AuditLogDate);
                }
                return _lastUpdateDate;
            }
            set
            {
                _lastUpdateDate = value;
                _hasCheckedLastUpdateDate = true;
            }
        }
        public bool AreProjectBasicsValid { get; set; }
        public bool ArePerformanceMeasuresValid { get; set; }
        public bool AreExpendituresValid { get; set; }
        public bool AreBudgetsValid { get; set; }
        public bool IsProjectLocationSimpleValid { get; set; }
    }
}