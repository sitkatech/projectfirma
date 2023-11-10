﻿/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.PartnerFinder;
using ProjectFirma.Web.Views.PerformanceMeasure;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.MatchmakerOrganizationControls;

namespace ProjectFirma.Web.Views.Organization
{
    public class OrganizationDetailViewData : FirmaViewData
    {
        public enum OrganizationDetailTab
        {
            Overview,
            Profile
        }

        public readonly ProjectFirmaModels.Models.Organization Organization;
        public readonly bool UserHasOrganizationManagePermissions;
        public readonly bool UserHasOrganizationManagePrimaryContactPermissions;
        public readonly string EditOrganizationUrl;
        public readonly string EditBoundaryUrl;
        public readonly string DeleteOrganizationBoundaryUrl;
        public readonly string EditOrganizationPrimaryContactUrl;

        public readonly ProjectsIncludingLeadImplementingGridSpec ProjectsIncludingLeadImplementingGridSpec;
        public readonly string ProjectOrganizationsGridName;
        public readonly string ProjectOrganizationsGridDataUrl;

        public readonly ProjectsIncludingLeadImplementingGridSpec ProposalsGridSpec;
        public readonly string ProposalsGridName;
        public readonly string ProposalsGridDataUrl;

        public readonly ProjectsIncludingLeadImplementingGridSpec PendingProjectsGridSpec;
        public readonly string PendingProjectsGridName;
        public readonly string PendingProjectsGridDataUrl;

        public readonly ViewGoogleChartViewData ExpendituresDirectlyFromOrganizationViewGoogleChartViewData;
        public readonly ViewGoogleChartViewData ExpendituresReceivedFromOtherOrganizationsViewGoogleChartViewData;
        public readonly ProjectFundingSourceExpendituresForOrganizationGridSpec ProjectFundingSourceExpendituresForOrganizationGridSpec;
        public readonly string ProjectFundingSourceExpendituresForOrganizationGridName;
        public readonly string ProjectFundingSourceExpendituresForOrganizationGridDataUrl;

        public readonly string ManageFundingSourcesUrl;
        public readonly string IndexUrl;

        public readonly MapInitJson MapInitJson;
        public readonly LayerGeoJson ProjectLocationsLayerGeoJson;
        public readonly bool HasSpatialData;

        public readonly List<PerformanceMeasureChartViewData> PerformanceMeasureChartViewDatas;
        public readonly string NewFundingSourceUrl;
        public readonly bool CanCreateNewFundingSource;

        public readonly string ProjectStewardOrLeadImplementorFieldDefinitionName;

        public readonly bool ShowProposals;
        public readonly string ProposalsPanelHeader;

        public readonly bool ShowPendingProjects;

        public readonly string OrganizationKeystoneGuidDisplayString;

        public bool TenantHasCanStewardProjectsOrganizationRelationship { get; }
        public int NumberOfStewardedProjects { get; }
        public int NumberOfLeadImplementedProjects { get; }
        public int NumberOfProjectsContributedTo { get; }
        public ViewPageContentViewData DescriptionViewData { get; }

        public bool UserHasViewEditProfilePermission { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForProject { get; }
        public string EditProfileMatchmakerOptIn { get; }
        public string EditProfileSupplementalInformationUrl { get; }
        public string EditProfileTaxonomyUrl { get; }

        public string EditAreaOfInterestUrl { get; }
        public string EditAreaOfInterestDialogFormID { get; }

        // Might not need these next two?
        public string EditMatchmakerKeywordsUrl { get; }
        public string EditMatchmakerKeywordDialogFormID { get; }
        public OrganizationMatchmakerKeywordsViewData OrganizationMatchmakerKeywordsViewData { get; }

        public string EditOrgClassificationsUrl { get; }
        public string EditOrgPerformanceMeasuresUrl { get; }
        public List<MatchmakerTaxonomyTier> TopLevelMatchmakerTaxonomyTier { get; }
        public string TaxonomyTrunkDisplayName { get; }
        public string TaxonomyBranchDisplayName { get; }
        public string TaxonomyLeafDisplayName { get; }
        public TaxonomyLevel TaxonomyLevel { get; }
        public int MaximumTaxonomyLeaves { get; }
        public OrganizationDetailTab ActiveTab { get; }
        public bool HasAreaOfInterest { get; set; }

        public bool ShowMatchmakerProfileTab { get; }
        public bool ShowMatchmakerProfileTabDetails { get; }
        public string ProjectFinderPageUrl { get; }
        public Dictionary<MatchmakerSubScoreTypeEnum, bool> MatchmakerProfileCompletionDictionary { get; }
        public bool MatchmakerProjectFinderButtonDisabled { get; set; }
        public bool MatchmakerProfileIncomplete { get; set; }

        public readonly MapInitJson AreaOfInterestMapInitJson;
        public readonly LayerGeoJson AreaOfInterestLayerGeoJson;

        public readonly List<IGrouping<ProjectFirmaModels.Models.ClassificationSystem, MatchmakerOrganizationClassification>> MatchmakerClassificationsGroupedByClassificationSystem;
        public readonly List<ProjectFirmaModels.Models.ClassificationSystem> AllClassificationSystems;

        public bool ShouldShowBackgroundTab { get; }
        public string MatchmakerProjectFinderButtonContent { get; }
        public bool ShowFundingSources { get; }
        public bool UserHasESAAdminPermissions { get; }

        public OrganizationDetailViewData(FirmaSession currentFirmaSession,
            ProjectFirmaModels.Models.Organization organization,
            MapInitJson mapInitJson,
            LayerGeoJson projectLocationsLayerGeoJson,
            bool hasSpatialData,
            List<ProjectFirmaModels.Models.PerformanceMeasure> performanceMeasures,
            ViewGoogleChartViewData expendituresDirectlyFromOrganizationViewGoogleChartViewData,
            ViewGoogleChartViewData expendituresReceivedFromOtherOrganizationsViewGoogleChartViewData,
            List<MatchmakerTaxonomyTier> topLevelMatchmakerTaxonomyTier,
            int maximumTaxonomyLeaves,
            OrganizationDetailTab activeTab, MapInitJson matchMakerAreaOfInterestInitJson,
            List<IGrouping<ProjectFirmaModels.Models.ClassificationSystem, MatchmakerOrganizationClassification>>
                matchmakerClassificationsGroupedByClassificationSystem,
            List<ProjectFirmaModels.Models.ClassificationSystem> allClassificationSystems) : base(currentFirmaSession)
        {
            Organization = organization;
            PageTitle = organization.GetDisplayName();
            EntityName = $"{FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()}";
            UserHasOrganizationManagePermissions = new OrganizationManageFeature().HasPermissionByFirmaSession(currentFirmaSession);
            UserHasOrganizationManagePrimaryContactPermissions = new OrganizationPrimaryContactManageFeature().HasPermissionByFirmaSession(currentFirmaSession);

            EditOrganizationUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.Edit(organization));
            EditBoundaryUrl =
                SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.EditBoundary(organization));
            DeleteOrganizationBoundaryUrl =
                SitkaRoute<OrganizationController>.BuildUrlFromExpression(
                    c => c.DeleteOrganizationBoundary(organization));
            EditOrganizationPrimaryContactUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.EditPrimaryContact(organization));

            ProjectsIncludingLeadImplementingGridSpec =
                new ProjectsIncludingLeadImplementingGridSpec(organization, currentFirmaSession, false)
                {
                    ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}",
                    ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} associated with {organization.GetDisplayName()}",
                    SaveFiltersInCookie = true
                };

            ProjectOrganizationsGridName = "projectOrganizationsFromOrganizationGrid";
            ProjectOrganizationsGridDataUrl =
                SitkaRoute<OrganizationController>.BuildUrlFromExpression(
                    tc => tc.ProjectsIncludingLeadImplementingGridJsonData(organization));

            ProjectStewardOrLeadImplementorFieldDefinitionName = MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship()
                ? FieldDefinitionEnum.ProjectsStewardOrganizationRelationshipToProject.ToType().GetFieldDefinitionLabel()
                : "Lead Implementer";

            ProjectFundingSourceExpendituresForOrganizationGridSpec =
                new ProjectFundingSourceExpendituresForOrganizationGridSpec(organization)
                {
                    ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {FieldDefinitionEnum.ReportedExpenditure.ToType().GetFieldDefinitionLabel()}",
                    ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} {FieldDefinitionEnum.ReportedExpenditure.ToType().GetFieldDefinitionLabelPluralized()}",
                    SaveFiltersInCookie = true
                };

            ProjectFundingSourceExpendituresForOrganizationGridName = "projectCalendarYearExpendituresForOrganizationGrid";
            ProjectFundingSourceExpendituresForOrganizationGridDataUrl =
                SitkaRoute<OrganizationController>.BuildUrlFromExpression(
                    tc => tc.ProjectFundingSourceExpendituresForOrganizationGridJsonData(organization));

            ManageFundingSourcesUrl = SitkaRoute<FundingSourceController>.BuildUrlFromExpression(c => c.Index());
            IndexUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.Index());

            MapInitJson = mapInitJson;
            ProjectLocationsLayerGeoJson = projectLocationsLayerGeoJson;
            HasSpatialData = hasSpatialData;
            ExpendituresDirectlyFromOrganizationViewGoogleChartViewData = expendituresDirectlyFromOrganizationViewGoogleChartViewData;
            ExpendituresReceivedFromOtherOrganizationsViewGoogleChartViewData = expendituresReceivedFromOtherOrganizationsViewGoogleChartViewData;

            PerformanceMeasureChartViewDatas = performanceMeasures.Select(x => organization.GetPerformanceMeasureChartViewData(x, currentFirmaSession)).ToList();

            NewFundingSourceUrl = SitkaRoute<FundingSourceController>.BuildUrlFromExpression(c => c.New());
            CanCreateNewFundingSource = new FundingSourceCreateFeature().HasPermissionByFirmaSession(currentFirmaSession) &&
                                        (currentFirmaSession.Person.RoleID != ProjectFirmaModels.Models.Role.ProjectSteward.RoleID || // If person is project steward, they can only create funding sources for their organization
                                         currentFirmaSession.Person.OrganizationID == organization.OrganizationID);
            ShowProposals = currentFirmaSession.CanViewProposals();
            ProposalsPanelHeader = MultiTenantHelpers.ShowProposalsToThePublic()
                ? FieldDefinitionEnum.Proposal.ToType().GetFieldDefinitionLabelPluralized()
                : $"{FieldDefinitionEnum.Proposal.ToType().GetFieldDefinitionLabelPluralized()} (Not Visible to the Public)";

            ProposalsGridSpec =
                new ProjectsIncludingLeadImplementingGridSpec(organization, currentFirmaSession, true)
                {
                    ObjectNameSingular = $"{FieldDefinitionEnum.Proposal.ToType().GetFieldDefinitionLabel()}",
                    ObjectNamePlural = $"{FieldDefinitionEnum.Proposal.ToType().GetFieldDefinitionLabelPluralized()} associated with {organization.GetDisplayName()}",
                    SaveFiltersInCookie = true
                };

            ProposalsGridName = "proposalsGrid";
            ProposalsGridDataUrl =
                SitkaRoute<OrganizationController>.BuildUrlFromExpression(
                    tc => tc.ProposalsGridJsonData(organization));

            ShowPendingProjects = currentFirmaSession.Person.CanViewPendingProjects();

            // If they have no permissions, just say "yes" or "no" if GUID set.
            // If they have manage permissions, show the GUID, otherwise "None". 
            bool hasKeystoneOrganizationGuid = (organization.KeystoneOrganizationGuid != null);
            string hasKeystoneOrganizationGuidBooleanAsString = hasKeystoneOrganizationGuid.ToYesNo();
            string organizationKeystoneGuidAsStringOrNone = hasKeystoneOrganizationGuid ? organization.KeystoneOrganizationGuid.ToString() : "None";
            OrganizationKeystoneGuidDisplayString = UserHasOrganizationManagePermissions ? organizationKeystoneGuidAsStringOrNone : hasKeystoneOrganizationGuidBooleanAsString;

            PendingProjectsGridSpec =
                new ProjectsIncludingLeadImplementingGridSpec(organization, currentFirmaSession, true)
                {
                    ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}",
                    ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} associated with {organization.GetDisplayName()}",
                    SaveFiltersInCookie = true
                };

            PendingProjectsGridName = "pendingProjectsGrid";
            PendingProjectsGridDataUrl =
                SitkaRoute<OrganizationController>.BuildUrlFromExpression(
                    tc => tc.PendingProjectsGridJsonData(organization));

            TenantHasCanStewardProjectsOrganizationRelationship = MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship();
            var allAssociatedProjects = Organization.GetAllAssociatedProjects();
            NumberOfStewardedProjects = allAssociatedProjects.Count(x => x.IsActiveProject() && x.GetCanStewardProjectsOrganization() == Organization);
            NumberOfLeadImplementedProjects = allAssociatedProjects.Count(x => x.IsActiveProject() && x.GetPrimaryContactOrganization() == Organization);
            NumberOfProjectsContributedTo = allAssociatedProjects.ToList().GetActiveProjects().Count;
            DescriptionViewData = new ViewPageContentViewData(organization, currentFirmaSession);

            UserHasViewEditProfilePermission = new OrganizationProfileViewEditFeature().HasPermission(currentFirmaSession, organization).HasPermission;

            bool matchmakerEnabledForTenant = MultiTenantHelpers.GetTenantAttributeFromCache().EnableMatchmaker;
            bool matchmakerOptedInForThisOrganization = Organization.MatchmakerOptIn.HasValue && Organization.MatchmakerOptIn.Value;
            ShowMatchmakerProfileTab = matchmakerEnabledForTenant;
            ShowMatchmakerProfileTabDetails = matchmakerEnabledForTenant && (UserHasViewEditProfilePermission || matchmakerOptedInForThisOrganization);

            FieldDefinitionForProject = FieldDefinitionEnum.Project.ToType();
            EditProfileMatchmakerOptIn = SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.EditProfileMatchmakerOptIn(organization));
            EditProfileSupplementalInformationUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.EditProfileSupplementalInformation(organization));
            EditProfileTaxonomyUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.EditProfileTaxonomy(organization));
            EditAreaOfInterestUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.EditMatchMakerAreaOfInterest(organization));
            EditAreaOfInterestDialogFormID = OrganizationController.GenerateEditOrganizationMatchMakerAreaOfInterestFormID(organization);
            HasAreaOfInterest = (Organization.UseOrganizationBoundaryForMatchmaker && Organization.OrganizationBoundary != null) || (!Organization.UseOrganizationBoundaryForMatchmaker && Organization.MatchMakerAreaOfInterestLocations.Any());
            AreaOfInterestMapInitJson = matchMakerAreaOfInterestInitJson;

            OrganizationMatchmakerKeywordsViewData = new OrganizationMatchmakerKeywordsViewData(organization);
            EditMatchmakerKeywordsUrl = SitkaRoute<KeywordController>.BuildUrlFromExpression(c => c.EditMatchMakerKeywordsModal(organization));
            EditMatchmakerKeywordDialogFormID = OrganizationMatchmakerKeywordsViewData.EditMatchmakerKeywordDialogFormID;

            TopLevelMatchmakerTaxonomyTier = topLevelMatchmakerTaxonomyTier;
            TaxonomyTrunkDisplayName = FieldDefinitionEnum.TaxonomyTrunk.ToType().GetFieldDefinitionLabel();
            TaxonomyBranchDisplayName = FieldDefinitionEnum.TaxonomyBranch.ToType().GetFieldDefinitionLabel();
            TaxonomyLeafDisplayName = FieldDefinitionEnum.TaxonomyLeaf.ToType().GetFieldDefinitionLabel();
            TaxonomyLevel = MultiTenantHelpers.GetTaxonomyLevel();
            MaximumTaxonomyLeaves = maximumTaxonomyLeaves;
            ActiveTab = activeTab;

            EditOrgClassificationsUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.EditMatchMakerClassifications(organization));
            MatchmakerClassificationsGroupedByClassificationSystem = matchmakerClassificationsGroupedByClassificationSystem;
            AllClassificationSystems = allClassificationSystems;

            EditOrgPerformanceMeasuresUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.EditMatchMakerPerformanceMeasures(organization));
            ProjectFinderPageUrl = SitkaRoute<ProjectFinderController>.BuildUrlFromExpression(c => c.Organization(organization));
            MatchmakerProfileCompletionDictionary = organization.GetMatchmakerOrganizationProfileCompletionDictionary();

            MatchmakerProfileIncomplete = !MatchmakerProfileCompletionDictionary.Values.Any(x => x);
            MatchmakerProjectFinderButtonDisabled = !organization.MatchmakerOptIn.HasValue || !organization.MatchmakerOptIn.Value || MatchmakerProfileIncomplete;
            ShouldShowBackgroundTab = DescriptionViewData.HasPageContent || new OrganizationBackgroundEditFeature().HasPermission(currentFirmaSession, organization).HasPermission;
            MatchmakerProjectFinderButtonContent = GetMatchmakerProjectFinderButtonContent(organization, MatchmakerProfileCompletionDictionary);

            ShowFundingSources = Organization.FundingSources.Any() || new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);

            UserHasESAAdminPermissions = new SitkaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);
        }

        private string GetMatchmakerProjectFinderButtonContent(ProjectFirmaModels.Models.Organization organization, Dictionary<MatchmakerSubScoreTypeEnum, bool> matchmakerProfileCompletionDictionary)
        {
            if (!matchmakerProfileCompletionDictionary.Values.Any(x => x))
            {
                return
                    $"Your profile is empty, so it is not possible to identify {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} matches. Please fill out your profile as completely as possible before using the {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Finder.";
            }

            return $"This {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} has not opted in to the Matchmaker service.";
        }
    }
}
