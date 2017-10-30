/*-----------------------------------------------------------------------
<copyright file="ProposedProject.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Globalization;
using System.Linq;
using System.Web;
using GeoJSON.Net.Feature;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using LtInfo.Common;
using LtInfo.Common.GeoJson;
using LtInfo.Common.Views;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public partial class ProposedProject : IAuditableEntity, IProject, IMappableProject
    {
        public int EntityID => ProposedProjectID;

        public string AuditDescriptionString => ProjectName;

        public string DisplayName => ProjectName;

        public HtmlString DisplayNameAsUrl => UrlTemplate.MakeHrefString(this.GetDetailUrl(), DisplayName);

        public static bool IsProjectNameUnique(IEnumerable<ProposedProject> projects, string projectName, int currentProposedProjectID)
        {
            if (string.IsNullOrWhiteSpace(projectName))
            {
                return false;
            }

            var project = projects.SingleOrDefault(x => x.ProposedProjectID != currentProposedProjectID && string.Equals(x.ProjectName.Trim(), projectName.Trim(), StringComparison.InvariantCultureIgnoreCase));
            return project == null;
        }

        public Person GetPrimaryContactPerson => PrimaryContactPerson;

        public decimal? UnfundedNeed => EstimatedTotalCost - SecuredFunding;

        public bool HasProjectLocationPoint => ProjectLocationPoint != null;
        public Feature MakePointFeatureWithRelevantProperties(DbGeometry projectLocationPoint, bool addProjectProperties)
        {
            var feature = DbGeometryToGeoJsonHelper.FromDbGeometry(projectLocationPoint);
            feature.Properties.Add("TaxonomyTierThreeID", TaxonomyTierOne.TaxonomyTierTwo.TaxonomyTierThreeID.ToString(CultureInfo.InvariantCulture));
            feature.Properties.Add("ProjectStageID", ProjectStage.ProjectStageID.ToString(CultureInfo.InvariantCulture));
            feature.Properties.Add("Info", DisplayName);
            if (addProjectProperties)
            {
                feature.Properties.Add("ProjectID", (ProjectID != null ? ProjectID.Value : -ProposedProjectID).ToString(CultureInfo.InvariantCulture));
                feature.Properties.Add("TaxonomyTierTwoID", TaxonomyTierOne.TaxonomyTierTwoID.ToString(CultureInfo.InvariantCulture));
                feature.Properties.Add("TaxonomyTierOneID", (TaxonomyTierOneID?? -1).ToString(CultureInfo.InvariantCulture));
                feature.Properties.Add("ClassificationID", string.Join(",", ProposedProjectClassifications.Select(x => x.ClassificationID)));
                foreach (var type in ProposedProjectOrganizations.Select(x => x.RelationshipType).Distinct())
                {
                    feature.Properties.Add($"{type.RelationshipTypeName}ID", ProposedProjectOrganizations.Where(y => y.RelationshipType == type).Select(z => z.OrganizationID));
                }
                // TODO - We probably need this, but ProjectMapPopup isn't implemented for ProposedProject yet.
                feature.Properties.Add("PopupUrl", this.GetProjectMapPopupUrl());
            }
            return feature;
        }

        public bool HasProjectLocationDetail => DetailedLocationToGeoJsonFeatureCollection().Features.Any();

        //TODO: This could be moved to ProjectLocationSimpleType and made smarter
        public string ProjectLocationTypeDisplay => ViewUtilities.NaString;

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

        public bool IsMyProposedProject(Person person)
        {
            return IsPersonThePrimaryContact(person) || person.PersonID == ProposingPersonID;
        }

        public bool IsEditableToThisPerson(Person person)
        {
            return IsMyProposedProject(person) || new ProposedProjectApproveFeature().HasPermission(person, this).HasPermission;
        }

        public bool IsVisibleToThisPerson(Person person)
        {
            return !person.IsAnonymousUser && person.Role != Role.Unassigned;
        }

        public bool IsVisibleToEveryone()
        {
            return true;
        }

        public bool IsPersonThePrimaryContact(Person person)
        {
            return PrimaryContactPerson != null && person != null && person.PersonID == PrimaryContactPerson.PersonID;
        }

        public PermissionCheckResult CanDelete()
        {
            return new PermissionCheckResult();
        }

        public ProjectStage ProjectStage => ProjectStage.Proposed;

        public ICollection<IEntityClassification> ProjectClassificationsForMap => new List<IEntityClassification>(ProposedProjectClassifications);
        public bool HasProjectWatersheds => ProposedProjectWatersheds.Any();

        // Use the negation of the ProposedProjectID to avoid collisions with ProjectIDs in lists of FancyTreeNodes
        public int FancyTreeNodeKey => -ProposedProjectID;

        public ProjectType ProjectType => ProjectType.ProposedProject;

        public IEnumerable<IQuestionAnswer> GetQuestionAnswers()
        {
            return ProposedProjectAssessmentQuestions;
        }

        public IEnumerable<IProjectLocation> GetProjectLocationDetails()
        {
            return ProposedProjectLocations.ToList();
        }

        public IEnumerable<Watershed> GetProjectWatersheds()
        {
            return ProposedProjectWatersheds.Select(x => x.Watershed);
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
            return featureCollection;
        }

        public string Duration =>
            $"{(ImplementationStartYear.HasValue ? ImplementationStartYear.Value.ToString(CultureInfo.InvariantCulture) : "?")} - {(CompletionYear.HasValue ? CompletionYear.Value.ToString(CultureInfo.InvariantCulture) : "?")}";

        public Project PromoteToProject(ProposedProject proposedProject, Person approverPerson)
        {
            var projectName = proposedProject.ProjectName;

            var project = new Project(proposedProject.TaxonomyTierOneID.Value,
                ProjectStage.PlanningDesign.ProjectStageID,
                projectName,
                proposedProject.ProjectDescription,
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
                ProjectLocationNotes = proposedProject.ProjectLocationNotes,
                ProjectWatershedNotes = proposedProject.ProjectWatershedNotes
            };
            project.ProjectNotes = proposedProject.ProposedProjectNotes.Select(x => new ProjectNote(project, x.Note, x.CreateDate)).ToList();
            project.ProjectClassifications = proposedProject.ProposedProjectClassifications.Select(x => new ProjectClassification(project.ProjectID, x.ClassificationID, x.ProposedProjectClassificationNotes)).ToList();

            if (proposedProject.PrimaryContactPerson != null)
            {
                project.PrimaryContactPerson = proposedProject.PrimaryContactPerson;
            }
            
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
                        performanceMeasureExpectedSubcategoryOptionProposed.PerformanceMeasureSubcategoryOption,
                        performanceMeasureExpectedSubcategoryOptionProposed.PerformanceMeasure,
                        performanceMeasureExpectedSubcategoryOptionProposed.PerformanceMeasureSubcategory);

                    performanceMeasureExpected.PerformanceMeasureSubcategoryOptions.Add(performanceMeasureExpectedSubcategoryOption);
                }
                project.PerformanceMeasureExpecteds.Add(performanceMeasureExpected);
            }

            foreach (var proposedProjectLocation in proposedProject.ProposedProjectLocations)
            {
                var projectLocation = new ProjectLocation(project, proposedProjectLocation.DbGeometry, proposedProjectLocation.Annotation);
                project.ProjectLocations.Add(projectLocation);
            }

            foreach (var proposedProjectWatershed in proposedProject.ProposedProjectWatersheds)
            {
                var projectWatershed = new ProjectWatershed(project, proposedProjectWatershed.Watershed);
                project.ProjectWatersheds.Add(projectWatershed);
            }

            foreach (var proposedProjectImage in proposedProject.ProposedProjectImages)
            {
                var newFileResource = new FileResource(proposedProjectImage.FileResource.FileResourceMimeType, proposedProjectImage.FileResource.OriginalBaseFilename, proposedProjectImage.FileResource.OriginalFileExtension, Guid.NewGuid(), proposedProjectImage.FileResource.FileResourceData, proposedProjectImage.FileResource.CreatePerson, proposedProjectImage.FileResource.CreateDate);
                var newProjectImage = new ProjectImage(newFileResource, project, ProjectImageTiming.Before, proposedProjectImage.Caption, proposedProjectImage.Credit, false, false);
                project.ProjectImages.Add(newProjectImage);
            }

            foreach (var proposedProjectOrganization in proposedProject.ProposedProjectOrganizations)
            {
                project.ProjectOrganizations.Add(new ProjectOrganization(project, proposedProjectOrganization.Organization, proposedProjectOrganization.RelationshipType));
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

        public Organization GetPrimaryContactOrganization()
        {
            return ProposedProjectOrganizations.SingleOrDefault(x => x.RelationshipType.IsPrimaryContact)?.Organization;
        }

        public Organization GetCanApproveProjectsOrganization()
        {
            return ProposedProjectOrganizations.SingleOrDefault(x => x.RelationshipType.CanApproveProjects)?.Organization;
        }

        public Person GetPrimaryContact(Person currentPerson) => PrimaryContactPerson ?? GetPrimaryContactOrganization()?.PrimaryContactPerson ?? currentPerson;

        public IEnumerable<Person> GetProjectStewards()
        {
            return GetCanApproveProjectsOrganization()?.People
                       .Where(y => y.RoleID == Role.ProjectSteward.RoleID)
                       .ToList() ?? new List<Person>();
        }

        public FancyTreeNode ToFancyTreeNode()
        {
            
            var fancyTreeNode = new FancyTreeNode(
                
                    $"{UrlTemplate.MakeHrefString(this.GetDetailUrl(), ProjectName, ProjectName)}", FancyTreeNodeKey.ToString(), false)
                { ThemeColor = TaxonomyTierOne.TaxonomyTierTwo.TaxonomyTierThree.ThemeColor, MapUrl = null };
            return fancyTreeNode;
        }
    }
}
