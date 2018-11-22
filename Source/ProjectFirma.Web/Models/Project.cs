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
using ProjectFirma.Web.Views.ProjectUpdate;

namespace ProjectFirma.Web.Models
{
    public partial class Project : IAuditableEntity, IMappableProject
    {
        public const int MaxLengthForProjectDescription = 700;

        public int EntityID => ProjectID;

        public string AuditDescriptionString => ProjectName;

        public string DisplayName => ProjectName;

        public HtmlString DisplayNameAsUrl => UrlTemplate.MakeHrefString(this.GetDetailUrl(), DisplayName);

        public static bool IsProjectNameUnique(IEnumerable<Project> projects, string projectName, int? currentProjectID)
        {
            if (string.IsNullOrWhiteSpace(projectName))
            {
                return false;
            }
            var project = projects.SingleOrDefault(x => x.ProjectID != (currentProjectID ?? 0) && string.Equals(x.ProjectName.Trim(), projectName.Trim(), StringComparison.InvariantCultureIgnoreCase));
            return project == null;
        }

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
            var organization = ProjectOrganizations.SingleOrDefault(x => x.RelationshipType.CanStewardProjects)?.Organization;
            return organization;
        }

        public TaxonomyBranch GetCanStewardProjectsTaxonomyBranch()
        {
            var taxonomyBranch = TaxonomyLeaf.TaxonomyBranch;
            return taxonomyBranch;
        }

        public List<GeospatialArea> GetCanStewardProjectsGeospatialAreas()
        {
            return ProjectGeospatialAreas.Select(x => x.GeospatialArea).ToList();
        }

        public IEnumerable<Organization> GetOrganizationsToReportInAccomplishments()
        {
            if (MultiTenantHelpers.GetRelationshipTypeToReportInAccomplishmentsDashboard() == null)
            {
                // Default is Funding Organizations
                var organizations = ProjectFundingSourceExpenditures.Select(x => x.FundingSource.Organization)
                    .Union(ProjectFundingSourceRequests.Select(x => x.FundingSource.Organization))
                    .Distinct(new HavePrimaryKeyComparer<Organization>());
                return organizations;
            }
            else
            {
                return ProjectOrganizations.Where(x => x.RelationshipType.ReportInAccomplishmentsDashboard)
                    .Select(x => x.Organization).ToList();
            }
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
            decimal? securedFunding = GetSecuredFunding() == null ? null : GetSecuredFunding();
            decimal? unsecuredFunding = GetUnsecuredFunding() == null ? null : GetUnsecuredFunding();

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

        public ProjectUpdateBatch GetLatestUpdateBatch()
        {
            var projectUpdateBatches = ProjectUpdateBatches.ToList();

            return projectUpdateBatches.Any() ? projectUpdateBatches.MaxBy(x => x.LastUpdateDate) : null;
        }

        public bool IsUpdateMandatory
        {
            get
            {
                if (IsPendingProject())
                {
                    return false;
                }

                if (!IsUpdatableViaProjectUpdateProcess)
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
        }

        public bool IsUpdatableViaProjectUpdateProcess => !IsPendingProject() && (ProjectStage.RequiresReportedExpenditures() || ProjectStage.RequiresPerformanceMeasureActuals());

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

        public GeospatialAreaValidationResult ValidateProjectGeospatialArea(GeospatialAreaType geospatialAreaType)
        {
            var noProjectGeospatialAreas = ProjectGeospatialAreas.All(x => x.GeospatialArea?.GeospatialAreaTypeID != geospatialAreaType.GeospatialAreaTypeID);
            var projectGeospatialAreaNotes = ProjectGeospatialAreaTypeNotes.Where(x => x.ProjectID == ProjectID && x.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID ).Select(x => x.Notes).ToString();
            var incomplete = noProjectGeospatialAreas && string.IsNullOrWhiteSpace(projectGeospatialAreaNotes);
            return new GeospatialAreaValidationResult(incomplete, geospatialAreaType);
        }

        public bool IsProjectGeospatialAreaValid(GeospatialAreaType geospatialAreaType)
        {
            return ValidateProjectGeospatialArea(geospatialAreaType).IsValid;
        }

        public HtmlString GetProjectGeospatialAreaNamesAsHyperlinks(GeospatialAreaType geospatialAreaType)
        {
            var projectGeospatialAreas = ProjectGeospatialAreas.Where(x => x.GeospatialArea.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID).ToList();
            return new HtmlString(projectGeospatialAreas.Any()
                ? string.Join(", ", projectGeospatialAreas.OrderBy(x => x.GeospatialArea.GeospatialAreaName).Select(x => x.GeospatialArea.GetDisplayNameAsUrl()))
                : ViewUtilities.NaString);
        }

        public string GetProjectGeospatialAreaNamesAsString()
        {
            return ProjectGeospatialAreas.Any()
                ? string.Join(", ", ProjectGeospatialAreas.OrderBy(x => x.GeospatialArea.GeospatialAreaName).Select(x => x.GeospatialArea.GeospatialAreaName))
                : ViewUtilities.NaString;
        }

        public bool IsMyProject(Person person)
        {
            return !person.IsAnonymousUser && (IsPersonThePrimaryContact(person) || person.Organization.IsMyProject(this) || person.PersonStewardOrganizations.Any(x=>x.Organization.IsMyProject(this)));
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
            var reportedPerformanceMeasures = GetNonVirtualPerformanceMeasureReportedValues();

            // Idaho's special PM.
            // There Might Be A Better Way To Do This™
            var technicalAssistanceValue = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.SingleOrDefault(x =>
                x.PerformanceMeasureDataSourceTypeID == PerformanceMeasureDataSourceType.TechnicalAssistanceValue
                    .PerformanceMeasureDataSourceTypeID);
            if (technicalAssistanceValue != null)
            {
                reportedPerformanceMeasures.AddRange(technicalAssistanceValue.GetReportedPerformanceMeasureValues(this));
            }

            return reportedPerformanceMeasures.OrderByDescending(pma => pma.CalendarYear).ThenBy(pma => pma.PerformanceMeasureID).ToList();
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

            if (ProjectLocationSimpleType == ProjectLocationSimpleType.PointOnMap && HasProjectLocationPoint)
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

        public static FeatureCollection MappedPointsToGeoJsonFeatureCollection(List<IMappableProject> projects, bool addProjectProperties, bool useDetailedCustomPopup)
        {
            var featureCollection = new FeatureCollection();
            var filteredProjectList = projects.Where(x1 => x1.HasProjectLocationPoint).Where(x => x.ProjectStage.ShouldShowOnMap()).ToList();
            featureCollection.Features.AddRange(filteredProjectList.Select(project => project.MakePointFeatureWithRelevantProperties(project.ProjectLocationPoint, addProjectProperties, useDetailedCustomPopup)).ToList());
            return featureCollection;
        }

        public Feature MakePointFeatureWithRelevantProperties(DbGeometry projectLocationPoint, bool addProjectProperties, bool useDetailedCustomPopup)
        {
            var feature = DbGeometryToGeoJsonHelper.FromDbGeometry(projectLocationPoint);
            feature.Properties.Add("TaxonomyTrunkID", TaxonomyLeaf.TaxonomyBranch.TaxonomyTrunkID.ToString(CultureInfo.InvariantCulture));
            feature.Properties.Add("ProjectStageID", ProjectStageID.ToString(CultureInfo.InvariantCulture));
            feature.Properties.Add("Info", DisplayName);
            if (addProjectProperties)
            {
                feature.Properties.Add("ProjectID", ProjectID.ToString(CultureInfo.InvariantCulture));
                feature.Properties.Add("TaxonomyBranchID", TaxonomyLeaf.TaxonomyBranchID.ToString(CultureInfo.InvariantCulture));
                feature.Properties.Add("TaxonomyLeafID", TaxonomyLeafID.ToString(CultureInfo.InvariantCulture));
                feature.Properties.Add("ClassificationID", string.Join(",", ProjectClassifications.Select(x => x.ClassificationID)));
                var associatedOrganizations = this.GetAssociatedOrganizations();
                foreach (var type in associatedOrganizations.Select(x => x.RelationshipType).Distinct())
                {
                    feature.Properties.Add($"{type.RelationshipTypeName}ID", associatedOrganizations.Where(y => y.RelationshipType == type).Select(z => z.Organization.OrganizationID));
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

        public string Duration
        {
            get
            {
                if (ImplementationStartYear == CompletionYear && ImplementationStartYear.HasValue)
                {
                    return ImplementationStartYear.Value.ToString(CultureInfo.InvariantCulture);
                }

                return
                    $"{ImplementationStartYear?.ToString(CultureInfo.InvariantCulture) ?? "?"} - {CompletionYear?.ToString(CultureInfo.InvariantCulture) ?? "?"}";
            }
        }

        /// <summary>
        /// Returns a commma-separated list of organizations that doesn't include the lead implementer or the funders and only includes the relationships that are configured to show on the fact sheet
        /// </summary>
        public string ProjectOrganizationNamesForFactSheet
        {
            get
            {
                // get the list of funders so we can exclude any that have other project associations
                var fundingOrganizations = this.GetFundingOrganizations().Select(x => x.Organization.OrganizationID);
                // Don't use GetAssociatedOrganizations because we don't care about funders for this list.
                var associatedOrganizations = ProjectOrganizations.Where(x=>x.RelationshipType.ShowOnFactSheet && !fundingOrganizations.Contains(x.OrganizationID)).ToList();
                associatedOrganizations.RemoveAll(x=>x.OrganizationID == GetPrimaryContactOrganization()?.OrganizationID);
                var organizationNames = associatedOrganizations.OrderByDescending(x => x.RelationshipType.IsPrimaryContact)
                    .ThenByDescending(x => x.RelationshipType.CanStewardProjects)
                    .ThenBy(x => x.Organization.OrganizationName).Select(x => x.Organization.OrganizationName)
                    .Distinct().ToList();
                return organizationNames.Any() ? string.Join(", ", organizationNames) : string.Empty;
            }
        }

        public string FundingOrganizationNamesForFactSheet
        {
            get
            {
                return string.Join(", ", this.GetFundingOrganizations().OrderBy(x => x.Organization.OrganizationName).Select(x => x.Organization.OrganizationName));
            }
        }

        public string AssocatedOrganizationNames(Organization organization)
        {
            var projectOrganizationAssocationNames = new List<string>();
            this.GetAssociatedOrganizations().Where(x => x.Organization == organization).ForEach(x => projectOrganizationAssocationNames.Add(x.RelationshipType.RelationshipTypeName));
            return string.Join(", ", projectOrganizationAssocationNames);
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
                $"{UrlTemplate.MakeHrefString(this.GetFactSheetUrl(), ProjectName, ProjectName)}", FancyTreeNodeKey.ToString(), false) { ThemeColor = TaxonomyLeaf.TaxonomyBranch.TaxonomyTrunk.ThemeColor, MapUrl = null };
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

        public IEnumerable<Person> GetProjectStewards()
        {
            return GetCanStewardProjectsOrganization()?.People
                       .Where(y => y.RoleID == Role.ProjectSteward.RoleID)
                       .ToList() ?? new List<Person>();
        }

        public ICollection<IEntityClassification> ProjectClassificationsForMap =>
            new List<IEntityClassification>(ProjectClassifications);

        public bool HasProjectGeospatialAreas => ProjectGeospatialAreas.Any();
        public int FancyTreeNodeKey => ProjectID;

        IEnumerable<IProjectCustomAttribute> IProject.ProjectCustomAttributes
        {
            get => ProjectCustomAttributes;
            set => ProjectCustomAttributes = (ICollection<ProjectCustomAttribute>) value;
        }

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
                var sectorColorHsl = new HslColor(sectorColor.R, sectorColor.G, sectorColor.B);

                groupingFundingSource.OrderBy(x => x.FundingSourceName)
                    .ForEach((fundingSource, index) =>
                    {
                        var luminosity = 100.0 * (groupingFundingSource.Count() - index - 1) /
                                         groupingFundingSource.Count() + 120;
                        var color = ColorTranslator.ToHtml(new HslColor(sectorColorHsl.Hue, sectorColorHsl.Saturation,
                            luminosity));

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
            var noFundingSourceIdentifiedAmount = Convert.ToDouble(EstimatedTotalCost ?? 0) - requestAmountsDictionary.Sum(x => x.Value);
            if (noFundingSourceIdentifiedAmount > 0)
            {
                var sortOrder = requestAmountsDictionary.Any() ? requestAmountsDictionary.Max(x => x.SortOrder) + 1 : 0;
                requestAmountsDictionary.Add(new GooglePieChartSlice("No Funding Source Identified", noFundingSourceIdentifiedAmount, sortOrder, "#dbdbdb"));
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

        public bool IsNotApprovedProposal()
        {
            return IsProposal() && ProjectApprovalStatus != ProjectApprovalStatus.Approved;
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

        public static List<ProjectSectionSimple> GetApplicableProposalWizardSections(Project project)
        {
            return ProjectWorkflowSectionGrouping.All.SelectMany(x => x.GetProjectCreateSections(project)).OrderBy(x => x.ProjectWorkflowSectionGrouping.SortOrder).ThenBy(x => x.SortOrder).ToList();
        }

        public string GetPlanningDesignStartYear()
        {
            return PlanningDesignStartYear.HasValue ? MultiTenantHelpers.FormatReportingYear(PlanningDesignStartYear.Value) : null;
        }
        public string GetCompletionYear()
        {
            return CompletionYear.HasValue ? MultiTenantHelpers.FormatReportingYear(CompletionYear.Value) : null;
        }
        public string GetImplementationStartYear()
        {
            return ImplementationStartYear.HasValue ? MultiTenantHelpers.FormatReportingYear(ImplementationStartYear.Value) : null;
        }
    }
}
