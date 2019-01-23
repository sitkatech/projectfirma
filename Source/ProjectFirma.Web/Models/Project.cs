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
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ProjectFirma.Web.Models
{
    public partial class Project : IAuditableEntity, IProject
    {
        public int GetEntityID() => ProjectID;

        public string GetAuditDescriptionString() => ProjectName;

        public string GetDisplayName() => ProjectName;

        public Organization GetPrimaryContactOrganization()
        {
            return ProjectOrganizations.SingleOrDefault(x => x.RelationshipType.IsPrimaryContact)?.Organization;
        }

        public FileResource GetPrimaryContactOrganizationLogo()
        {
            return GetPrimaryContactOrganization()?.LogoFileResource;
        }

        public Organization GetCanStewardProjectsOrganization()
        {
            return ProjectOrganizations.SingleOrDefault(x => x.RelationshipType.CanStewardProjects)?.Organization;
        }

        public TaxonomyBranch GetCanStewardProjectsTaxonomyBranch()
        {
            return TaxonomyLeaf.TaxonomyBranch;
        }

        public List<GeospatialArea> GetCanStewardProjectsGeospatialAreas()
        {
            return ProjectGeospatialAreas.Select(x => x.GeospatialArea).ToList();
        }

        public Person GetPrimaryContact() => PrimaryContactPerson ??
                                             GetPrimaryContactOrganization()?.PrimaryContactPerson;

        public decimal? UnfundedNeed()
        {
            return EstimatedTotalCost - GetSecuredFunding();
        }

        public decimal? GetSecuredFunding()
        {
            return ProjectFundingSourceRequests.Any() ? (decimal?)ProjectFundingSourceRequests.Sum(x => x.SecuredAmount.GetValueOrDefault()) : null;
        }

        public decimal? GetUnsecuredFunding()
        {
            return ProjectFundingSourceRequests.Any() ? (decimal?)ProjectFundingSourceRequests.Sum(x => x.UnsecuredAmount.GetValueOrDefault()) : null;
        }

        public decimal? GetNoFundingSourceIdentifiedAmount()
        {
            var securedFunding = GetSecuredFunding() == null ? null : GetSecuredFunding();
            var unsecuredFunding = GetUnsecuredFunding() == null ? null : GetUnsecuredFunding();

            var noFundingSourceIdentifiedAmount = (EstimatedTotalCost ?? 0) - (securedFunding + unsecuredFunding ?? 0);
            if (noFundingSourceIdentifiedAmount >= 0)
            {
                return noFundingSourceIdentifiedAmount;
            }

            return null;
        }


        public decimal? TotalExpenditures
        {
            get { return ProjectFundingSourceExpenditures.Any() ? ProjectFundingSourceExpenditures.Sum(x => x.ExpenditureAmount) : (decimal?)null; }
        }

        public bool HasProjectLocationPoint() => ProjectLocationPoint != null;
        public bool HasProjectLocationDetail() => DetailedLocationToGeoJsonFeatureCollection().Features.Any();

        private bool _hasCheckedProjectUpdateHistories;
        private List<ProjectUpdateHistory> _projectUpdateHistories;

        public void SetProjectUpdateHistories(List<ProjectUpdateHistory> value)
        {
            _projectUpdateHistories = value;
            _hasCheckedProjectUpdateHistories = true;
        }

        public List<ProjectUpdateHistory> GetProjectUpdateHistories()
        {
            if (_hasCheckedProjectUpdateHistories)
            {
                return _projectUpdateHistories;
            }

            SetProjectUpdateHistories(ProjectUpdateBatches.SelectMany(x => x.ProjectUpdateHistories).ToList());
            return _projectUpdateHistories;
        }

        public ProjectUpdateBatch GetLatestNotApprovedUpdateBatch()
        {
            return ProjectUpdateBatches.SingleOrDefault(x => x.ProjectUpdateState != ProjectUpdateState.Approved);
        }

        public ProjectUpdateBatch GetLatestApprovedUpdateBatch()
        {
            var projectUpdateBatches = ProjectUpdateBatches.Where(x => x.ProjectUpdateState == ProjectUpdateState.Approved).ToList();
            return projectUpdateBatches.Any() ? projectUpdateBatches.OrderByDescending(x => x.LastUpdateDate).First() : null;
        }

        public ProjectUpdateBatch GetLatestUpdateBatch()
        {
            var projectUpdateBatches = ProjectUpdateBatches.ToList();
            return projectUpdateBatches.Any() ? projectUpdateBatches.OrderByDescending(x => x.LastUpdateDate).First() : null;
        }

        public bool IsUpdateMandatory()
        {
            if (IsPendingProject())
            {
                return false;
            }

            if (!IsUpdatableViaProjectUpdateProcess())
            {
                return false;
            }

            var latestUpdateBatch = GetLatestUpdateBatch();

            if (latestUpdateBatch == null)
            {
                return true;
            }

            if (!latestUpdateBatch.IsApproved)
            {
                return true;
            }

            return false;
        }

        public bool IsUpdatableViaProjectUpdateProcess() => !IsPendingProject() &&
                                                            (ProjectStage.RequiresReportedExpenditures() ||
                                                             ProjectStage.RequiresPerformanceMeasureActuals());

        public DateTime? GetLatestUpdateSubmittalDate()
        {
            var notNullSubmittalDates = ProjectUpdateBatches.Select(x => x.LatestSubmittalDate).Where(x => x.HasValue).ToList();
            return notNullSubmittalDates.Any() ? notNullSubmittalDates.Max() : null;
        }

        public HtmlString GetProjectGeospatialAreaNamesAsHyperlinks(GeospatialAreaType geospatialAreaType)
        {
            var projectGeospatialAreas = ProjectGeospatialAreas.Where(x => x.GeospatialArea.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID).ToList();
            return new HtmlString(projectGeospatialAreas.Any()
                ? string.Join(", ", projectGeospatialAreas.OrderBy(x => x.GeospatialArea.GeospatialAreaName).Select(x => x.GeospatialArea.GetDisplayNameAsUrl()))
                : ViewUtilities.NaString);
        }

        public bool IsMyProject(Person person)
        {
            return !person.IsAnonymousUser() && (IsPersonThePrimaryContact(person) || person.Organization.IsMyProject(this) || person.PersonStewardOrganizations.Any(x=>x.Organization.IsMyProject(this)));
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

        public List<PerformanceMeasureReportedValue> GetNonVirtualPerformanceMeasureReportedValues()
        {
            var performanceMeasureReportedValues = PerformanceMeasureActuals.Select(x => x.PerformanceMeasure)
                .Distinct(new HavePrimaryKeyComparer<PerformanceMeasure>())
                .SelectMany(x => x.GetReportedPerformanceMeasureValues(this)).ToList();
            return performanceMeasureReportedValues.OrderByDescending(pma => pma.CalendarYear).ThenBy(pma => pma.PerformanceMeasureID).ToList();
        }

        public FeatureCollection SimpleLocationToGeoJsonFeatureCollection(bool addProjectProperties)
        {
            var featureCollection = new FeatureCollection();

            if (ProjectLocationSimpleType == ProjectLocationSimpleType.PointOnMap && HasProjectLocationPoint())
            {
                featureCollection.Features.Add(MakePointFeatureWithRelevantProperties(ProjectLocationPoint, addProjectProperties, true));
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

        public DbGeometry GetDefaultBoundingBox()
        {
            return DefaultBoundingBox;
        }

        public IEnumerable<GeospatialArea> GetProjectGeospatialAreas()
        {
            return ProjectGeospatialAreas.Select(x => x.GeospatialArea);
        }

        public FeatureCollection DetailedLocationToGeoJsonFeatureCollection()
        {
            return ProjectLocations.ToGeoJsonFeatureCollection();
        }

        public Feature MakePointFeatureWithRelevantProperties(DbGeometry projectLocationPoint, bool addProjectProperties, bool useDetailedCustomPopup)
        {
            var feature = DbGeometryToGeoJsonHelper.FromDbGeometry(projectLocationPoint);
            feature.Properties.Add("TaxonomyTrunkID", TaxonomyLeaf.TaxonomyBranch.TaxonomyTrunkID.ToString(CultureInfo.InvariantCulture));
            feature.Properties.Add("ProjectStageID", ProjectStageID.ToString(CultureInfo.InvariantCulture));
            feature.Properties.Add("Info", GetDisplayName());
            if (addProjectProperties)
            {
                feature.Properties.Add("ProjectID", ProjectID.ToString(CultureInfo.InvariantCulture));
                feature.Properties.Add("TaxonomyBranchID", TaxonomyLeaf.TaxonomyBranchID.ToString(CultureInfo.InvariantCulture));
                feature.Properties.Add("TaxonomyLeafID", TaxonomyLeafID.ToString(CultureInfo.InvariantCulture));
                feature.Properties.Add("ClassificationID", string.Join(",", ProjectClassifications.Select(x => x.ClassificationID)));
                var associatedOrganizations = this.GetAssociatedOrganizations();
                var relationshipTypeNames = associatedOrganizations.Select(x => x.RelationshipTypeName).Distinct();
                foreach (var relationshipTypeName in relationshipTypeNames)
                {
                    feature.Properties.Add($"{relationshipTypeName}ID", associatedOrganizations.Where(y => y.RelationshipTypeName.Equals(relationshipTypeName)).Select(z => z.Organization.OrganizationID));
                }

                if (useDetailedCustomPopup)
                {
                    feature.Properties.Add("PopupUrl", this.GetProjectMapPopupUrl());
                }
                else
                {
                    feature.Properties.Add("PopupUrl", this.GetProjectSimpleMapPopupUrl());
                }
                
            }
            return feature;
        }

        public string GetDuration()
        {
            if (ImplementationStartYear == CompletionYear && ImplementationStartYear.HasValue)
            {
                return ImplementationStartYear.Value.ToString(CultureInfo.InvariantCulture);
            }

            return
                $"{ImplementationStartYear?.ToString(CultureInfo.InvariantCulture) ?? "?"} - {CompletionYear?.ToString(CultureInfo.InvariantCulture) ?? "?"}";
        }

        /// <summary>
        /// Returns a commma-separated list of organizations that doesn't include the lead implementer or the funders and only includes the relationships that are configured to show on the fact sheet
        /// </summary>
        public string GetProjectOrganizationNamesForFactSheet()
        {
            // get the list of funders so we can exclude any that have other project associations
            var fundingOrganizations = this.GetFundingOrganizations().Select(x => x.Organization.OrganizationID);
            // Don't use GetAssociatedOrganizations because we don't care about funders for this list.
            var associatedOrganizations = ProjectOrganizations
                .Where(x => x.RelationshipType.ShowOnFactSheet && !fundingOrganizations.Contains(x.OrganizationID)).ToList();
            associatedOrganizations.RemoveAll(x => x.OrganizationID == GetPrimaryContactOrganization()?.OrganizationID);
            var organizationNames = associatedOrganizations.OrderByDescending(x => x.RelationshipType.IsPrimaryContact)
                .ThenByDescending(x => x.RelationshipType.CanStewardProjects)
                .ThenBy(x => x.Organization.OrganizationName).Select(x => x.Organization.OrganizationName)
                .Distinct().ToList();
            return organizationNames.Any() ? string.Join(", ", organizationNames) : string.Empty;
        }

        public string GetFundingOrganizationNamesForFactSheet()
        {
            return string.Join(", ",
                this.GetFundingOrganizations().OrderBy(x => x.Organization.OrganizationName)
                    .Select(x => x.Organization.OrganizationName));
        }

        public string AssocatedOrganizationNames(Organization organization)
        {
            return string.Join(", ", this.GetAssociatedOrganizations().Where(x => x.Organization.OrganizationID == organization.OrganizationID).Select(x => x.RelationshipTypeName));
        }

        public ProjectImage GetKeyPhoto()
        {
            return ProjectImages.SingleOrDefault(x => x.IsKeyPhoto);
        }

        public FancyTreeNode ToFancyTreeNode()
        {
            var fancyTreeNode = new FancyTreeNode(
                $"{UrlTemplate.MakeHrefString(this.GetFactSheetUrl(), ProjectName, ProjectName)}", ProjectID.ToString(), false) { ThemeColor = TaxonomyLeaf.TaxonomyBranch.TaxonomyTrunk.ThemeColor, MapUrl = null };
            return fancyTreeNode;
        }

        public IEnumerable<Person> GetProjectStewards()
        {
            return GetCanStewardProjectsOrganization()?.People
                       .Where(y => y.RoleID == Role.ProjectSteward.RoleID)
                       .ToList() ?? new List<Person>();
        }

        public ICollection<IEntityClassification> GetProjectClassificationsForMap() => new List<IEntityClassification>(ProjectClassifications);

        IEnumerable<IProjectCustomAttribute> IProject.GetProjectCustomAttributes() => ProjectCustomAttributes;

        public bool IsActiveProject()
        {
            return !IsProposal() && ProjectApprovalStatus == ProjectApprovalStatus.Approved;
        }

        public bool IsProposal()
        {
            return ProjectStage == ProjectStage.Proposal;
        }

        public bool IsActiveProposal()
        {
            return IsProposal() && ProjectApprovalStatus == ProjectApprovalStatus.PendingApproval;
        }

        public bool IsPendingProject()
        {
            return !IsProposal() && ProjectApprovalStatus != ProjectApprovalStatus.Approved;
        }

        public bool IsRejected()
        {
            return ProjectApprovalStatus == ProjectApprovalStatus.Rejected;
        }

        public bool IsForwardLookingFactSheetRelevant()
        {
            return ProjectStage.ForwardLookingFactSheetProjectStages.Contains(ProjectStage);
        }

        public bool IsBackwardLookingFactSheetRelevant()
        {
            return !IsForwardLookingFactSheetRelevant();
        }

        public bool IsExpectedFundingRelevant()
        {
            // todo: Always relevant for pending projects, otherwise relevant for every stage except terminated/completed
            return true;
        }

        public bool AreReportedPerformanceMeasuresRelevant()
        {
            return ProjectStage != ProjectStage.Proposal && ProjectStage != ProjectStage.PlanningDesign;
        }

        public bool AreReportedExpendituresRelevant()
        {
            return ProjectStage != ProjectStage.Proposal;
        }
    }
}
