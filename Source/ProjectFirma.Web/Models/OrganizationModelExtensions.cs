﻿/*-----------------------------------------------------------------------
<copyright file="OrganizationModelExtensions.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using LtInfo.Common.DesignByContract;
using LtInfo.Common.GdalOgr;
using LtInfo.Common.GeoJson;
using LtInfo.Common.Models;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Organization;
using ProjectFirma.Web.Views.PerformanceMeasure;
using ProjectFirmaModels.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using LtInfo.Common.AgGridWrappers;

namespace ProjectFirma.Web.Models
{
    public static class OrganizationModelExtensions
    {
        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(SitkaRoute<OrganizationController>.BuildUrlFromExpression(t => t.DeleteOrganization(UrlTemplate.Parameter1Int)));
        public static string GetDeleteUrl(this Organization organization)
        {
            return DeleteUrlTemplate.ParameterReplace(organization.OrganizationID);
        }

        public static HtmlString GetDisplayNameAsUrl(this Organization organization)
        {          
            return organization != null ? UrlTemplate.MakeHrefString(organization.GetDetailUrl(), organization.GetDisplayName()) : new HtmlString(null);
        }

        public static string GetDisplayNameAsUrlForAgGrid(this Organization organization)
        {

            if (organization != null)
            {
                var displayNameAsUrlForAgGrid = new HtmlLinkObject(organization.GetDisplayName(), organization.GetDetailUrl());
                return displayNameAsUrlForAgGrid.ToJsonObjectForAgGrid();
            }

            return string.Empty;

        }

        public static HtmlString GetDisplayNameWithoutAbbreviationAsUrl(this Organization organization)
        {
            return organization != null
                ? UrlTemplate.MakeHrefString(organization.GetDetailUrl(), organization.GetDisplayNameWithoutAbbreviation())
                : new HtmlString(null);
        }

        public static HtmlString GetShortNameAsUrl(this Organization organization)
        {          
            return organization != null ? UrlTemplate.MakeHrefString(organization.GetDetailUrl(), organization.OrganizationShortName ?? organization.OrganizationName) : new HtmlString(null);
        }
        
        public static string GetShortNameAsUrlForAgGrid(this Organization organization)
        {          
            return organization != null ? new HtmlLinkObject(organization.OrganizationShortName ?? organization.OrganizationName, organization.GetDetailUrl()).ToJsonObjectForAgGrid() : string.Empty;
        }

        public static HtmlString GetShortNameAsUrl(int? organizationID, string organizationDisplayName)
        {
            return organizationID.HasValue ? UrlTemplate.MakeHrefString(SummaryUrlTemplate.ParameterReplace(organizationID.Value), organizationDisplayName) : new HtmlString(null);
        }

        public static readonly UrlTemplate<int> SummaryUrlTemplate = new UrlTemplate<int>(SitkaRoute<OrganizationController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int, null)));
        public static string GetDetailUrl(this Organization organization)
        {
            return organization == null ? "" : SummaryUrlTemplate.ParameterReplace(organization.OrganizationID);
        }

        public static readonly UrlTemplate<int> DetailProfileTabUrlTemplate = new UrlTemplate<int>(SitkaRoute<OrganizationController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int, OrganizationDetailViewData.OrganizationDetailTab.Profile)));
        public static string GetDetailProfileTabUrl(this Organization organization)
        {
            return organization == null ? "" : DetailProfileTabUrlTemplate.ParameterReplace(organization.OrganizationID);
        }
        public static HtmlString GetDisplayNameWithoutAbbreviationAsProfileTabUrl(this Organization organization)
        {
            return organization != null
                ? UrlTemplate.MakeHrefString(organization.GetDetailProfileTabUrl(), organization.GetDisplayNameWithoutAbbreviation())
                : new HtmlString(null);
        }

        public static string GetDisplayNameWithoutAbbreviation(this Organization organization) => organization.IsUnknown()
            ? "Unknown or unspecified"
            : $"{organization.OrganizationName}{(!organization.IsActive ? " (Inactive)" : String.Empty)}";

        public static string GetOrganizationNamePossessive(this Organization organization)
        {
            if (organization.IsUnknown())
            {
                return organization.OrganizationName;
            }

            var postFix = organization.OrganizationName.EndsWith("s") ? "'" : "'s";
            return $"{organization.OrganizationName}{postFix}";
        }

        public static string GetOrganizationShortNameIfAvailable(this Organization organization)
        {
            if (organization.IsUnknown())
            {
                return "Unknown or Unassigned";
            }

            return organization.OrganizationShortName ?? organization.OrganizationName;
        }

        public static string GetOrganizationFullNameIfAvailable(this Organization organization)
        {
            return organization.IsUnknown() ? "Unknown or Unassigned" : organization.OrganizationName;
        }

        public static List<LayerGeoJson> GetConfiguredBoundaryLayersGeoJson(this IEnumerable<Organization> organizations)
        {
            var organizationsToShow =
                organizations?.Where(x => x.OrganizationBoundary != null && x.OrganizationType != null && x.OrganizationType.ShowOnProjectMaps).
                    OrderBy(x => x.OrganizationName).ToList();
            if (organizationsToShow == null || !organizationsToShow.Any())
            {
                return new List<LayerGeoJson>();
            }


            return organizationsToShow.GroupBy(x => x.OrganizationType, (organizationType, organizationList) =>
            {
                return new LayerGeoJson(
                    $"{organizationType.OrganizationTypeName} {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabelPluralized()}",
                    new FeatureCollection(organizationList.Select(organization =>
                    {
                        var feature = DbGeometryToGeoJsonHelper.FromDbGeometry(organization.OrganizationBoundary);
                        feature.Properties.Add("Hover Name", UrlTemplate.MakeHrefString(organization.GetDetailUrl(), organization.OrganizationShortName).ToHtmlString());
                        feature.Properties.Add(organizationType.OrganizationTypeName, UrlTemplate.MakeHrefString(organization.GetDetailUrl(), organization.OrganizationName).ToHtmlString());
                        return feature;
                    }).ToList()),
                    organizationType.LegendColor, 1,
                    LayerInitialVisibility.GetInitialVisibility(organizationType.LayerOnByDefault)
                    );
            }).ToList();
        }

        public static List<Project> GetAllAssociatedProjects(this Organization organization)
        {
            return organization.FundingSources.SelectMany(x => x.ProjectFundingSourceBudgets).Select(x => x.Project)
                .Union(organization.FundingSources.SelectMany(x => x.ProjectFundingSourceExpenditures)
                    .Select(x => x.Project), new HavePrimaryKeyComparer<Project>())
                .Union(organization.ProjectOrganizations.Select(x => x.Project), new HavePrimaryKeyComparer<Project>())
                .ToList();
        }

        public static List<Project> GetAllAssociatedProjects(this Organization organization
           , Dictionary<int, List<FundingSource>> fundingSourceDictionary
           , Dictionary<int, List<ProjectFundingSourceBudget>> projectFundingSourceBudgetsDictionary
           , Dictionary<int, List<ProjectFundingSourceExpenditure>> projectFundingSourceExpendituresDictionary
           , Dictionary<int, Project> projectDictionary)
        {
            var fundingSources = fundingSourceDictionary.ContainsKey(organization.OrganizationID)
                ? fundingSourceDictionary[organization.OrganizationID]
                : new List<FundingSource>();

            return fundingSources.SelectMany(x => x.AssociatedProjectsFromBudget(projectFundingSourceBudgetsDictionary)).Select(x => projectDictionary[x.ProjectID])
                .Union(fundingSources.SelectMany(x => x.AssociatedProjectsFromExpenditures(projectFundingSourceExpendituresDictionary))
                    .Select(x => projectDictionary[x.ProjectID]), new HavePrimaryKeyComparer<Project>())
                .Union(organization.ProjectOrganizations.Select(x => projectDictionary[x.ProjectID]), new HavePrimaryKeyComparer<Project>())
                .ToList();
        }

        public static List<ProjectFundingSourceBudget> AssociatedProjectsFromBudget(this FundingSource fundingSource, Dictionary<int, List<ProjectFundingSourceBudget>> projectFundingSourceBudget)
        {
            var projectFundingSourceBudgets = projectFundingSourceBudget.ContainsKey(fundingSource.FundingSourceID)
                ? projectFundingSourceBudget[fundingSource.FundingSourceID]
                : new List<ProjectFundingSourceBudget>();
            return projectFundingSourceBudgets;
        }

        public static List<ProjectFundingSourceExpenditure> AssociatedProjectsFromExpenditures(this FundingSource fundingSource, Dictionary<int, List<ProjectFundingSourceExpenditure>> projectFundingSourceExpendituresDictionary)
        {
            var projectFundingSourceExpenditures = projectFundingSourceExpendituresDictionary.ContainsKey(fundingSource.FundingSourceID)
                ? projectFundingSourceExpendituresDictionary[fundingSource.FundingSourceID]
                : new List<ProjectFundingSourceExpenditure>();
            return projectFundingSourceExpenditures;
        }

        public static  List<Project> GetAllActiveProjectsAndProposals(this Organization organization, FirmaSession firmaSession)
        {
            return organization.GetAllAssociatedProjects().GetActiveProjectsAndProposals(firmaSession.CanViewProposals(), firmaSession);
        }

        public static List<Project> GetAllActiveProjects(this Organization organization
            , Dictionary<int, List<FundingSource>> fundingSourceDictionary
            , Dictionary<int, List<ProjectFundingSourceBudget>> projectFundingSourceBudgetsDictionary
            , Dictionary<int, List<ProjectFundingSourceExpenditure>> projectFundingSourceExpendituresDictionary
            , Dictionary<int, Project> projectDictionary)
        {
            return organization.GetAllAssociatedProjects(fundingSourceDictionary, projectFundingSourceBudgetsDictionary, projectFundingSourceExpendituresDictionary, projectDictionary).GetActiveProjects();
        }

        public static List<Project> GetAllActiveProjects(this Organization organization)
        {
            return organization.GetAllAssociatedProjects().GetActiveProjects();
        }

        public static List<Project> GetProposalsVisibleToUser(this Organization organization, FirmaSession firmaSession
            , Dictionary<int, List<FundingSource>> fundingSourceDictionary
            , Dictionary<int, List<ProjectFundingSourceBudget>> projectFundingSourceBudgetsDictionary
            , Dictionary<int, List<ProjectFundingSourceExpenditure>> projectFundingSourceExpendituresDictionary
            , Dictionary<int, Project> projectDictionary)
        {
            return organization.GetAllAssociatedProjects(fundingSourceDictionary, projectFundingSourceBudgetsDictionary, projectFundingSourceExpendituresDictionary, projectDictionary).GetProposalsVisibleToUser(firmaSession);
        }

        public static List<Project> GetProposalsVisibleToUser(this Organization organization, FirmaSession firmaSession)
        {
            return organization.GetAllAssociatedProjects().GetProposalsVisibleToUser(firmaSession);
        }

        public static List<Project> GetAllPendingProjects(this Organization organization, FirmaSession firmaSession)
        {
            return organization.GetAllAssociatedProjects().GetPendingProjectsVisibleToUser(firmaSession);
        }

        public static List<Project> GetAllActiveProjectsAndProposalsWhereOrganizationIsStewardOrPrimaryContact(this Organization organization, FirmaSession firmaSession)
        {
            var allActiveProjectsAndProposals = organization.GetAllAssociatedProjects().GetActiveProjectsAndProposals(firmaSession.CanViewProposals(), firmaSession);

            if (MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
            {
                return allActiveProjectsAndProposals.Where(x => x.GetCanStewardProjectsOrganization() == organization).ToList();
            }

            return allActiveProjectsAndProposals.Where(x => x.GetPrimaryContactOrganization() == organization).ToList();
        }

        public static List<Project> GetAllActiveProjectsWhereOrganizationReportsInAccomplishmentsDashboard(
            this Organization organization, FirmaSession firmaSession)
        {
            Check.Assert(MultiTenantHelpers.DisplayAccomplishmentDashboard());
            return organization.GetAllAssociatedProjects()
                .GetActiveProjectsAndProposals(MultiTenantHelpers.ShowProposalsToThePublic(), firmaSession)
                .Where(x => x.GetOrganizationsToReportInAccomplishments().Any(y => y == organization))
                .ToList();
        }

        public static bool CanBeAnApprovingOrganization(this Organization organization)
        {
            return organization.OrganizationType.OrganizationTypeOrganizationRelationshipTypes.Any(x => x.OrganizationRelationshipTypeID == MultiTenantHelpers.GetCanStewardProjectsOrganizationRelationship()?.OrganizationRelationshipTypeID);
        }

        public static bool CanBeReportedInAccomplishmentsDashboard(this Organization organization)
        {
            return organization.OrganizationType.OrganizationTypeOrganizationRelationshipTypes.Any(x =>
                x.OrganizationRelationshipTypeID == MultiTenantHelpers
                    .GetOrganizationRelationshipTypeToReportInAccomplishmentsDashboard()?.OrganizationRelationshipTypeID);
        }

        public static bool CanBeAPrimaryContactOrganization(this Organization organization)
        {
            return organization.OrganizationType.OrganizationTypeOrganizationRelationshipTypes.Any(x => x.OrganizationRelationshipTypeID == MultiTenantHelpers.GetIsPrimaryContactOrganizationRelationship()?.OrganizationRelationshipTypeID);
        }

        public static bool CanStewardProjects(this Organization organization)
        {
            return organization.OrganizationType.OrganizationTypeOrganizationRelationshipTypes.Any(x => x.OrganizationRelationshipTypeID == MultiTenantHelpers.GetCanStewardProjectsOrganizationRelationship()?.OrganizationRelationshipTypeID);
        }

        public static PerformanceMeasureChartViewData GetPerformanceMeasureChartViewData(this Organization organization,
                                                                                         PerformanceMeasure performanceMeasure, 
                                                                                         FirmaSession firmaSession)
        {
            var projects = organization.GetAllActiveProjectsAndProposals(firmaSession).ToList();
            return new PerformanceMeasureChartViewData(performanceMeasure, firmaSession, false, projects, false);
        }

        public static bool IsOrganizationNameUnique(IEnumerable<Organization> organizations, string organizationName, int currentOrganizationID)
        {
            var organization =
                organizations.SingleOrDefault(x => x.OrganizationID != currentOrganizationID && String.Equals(x.OrganizationName, organizationName, StringComparison.InvariantCultureIgnoreCase));
            return organization == null;
        }

        public static bool IsOrganizationShortNameUniqueIfProvided(IEnumerable<Organization> organizations, string organizationShortName, int currentOrganizationID)
        {
            // Nulls don't trip the unique check
            if (organizationShortName == null)
            {
                return true;
            }
            var existingOrganization =
                organizations.SingleOrDefault(
                    x => x.OrganizationID != currentOrganizationID && String.Equals(x.OrganizationShortName, organizationShortName, StringComparison.InvariantCultureIgnoreCase));
            return existingOrganization == null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gisFile"></param>
        /// <param name="originalFilename">This is the original name of the file as it appeared on the users file system. It is provided just for error messaging purposes.</param>
        /// <param name="organization"></param>
        /// <returns></returns>
        public static List<OrganizationBoundaryStaging> CreateOrganizationBoundaryStagingStagingListFromGdb(FileInfo gisFile, string originalFilename, Organization organization)
        {
            var ogr2OgrCommandLineRunner = new Ogr2OgrCommandLineRunner(FirmaWebConfiguration.Ogr2OgrExecutable,
                LtInfoGeometryConfiguration.DefaultCoordinateSystemId,
                FirmaWebConfiguration.HttpRuntimeExecutionTimeout.TotalMilliseconds);

            var geoJsons =
                OgrInfoCommandLineRunner.GetFeatureClassNamesFromFileGdb(new FileInfo(FirmaWebConfiguration.OgrInfoExecutable), gisFile, originalFilename, Ogr2OgrCommandLineRunner.DefaultTimeOut)
                    .ToDictionary(x => x, x => ogr2OgrCommandLineRunner.ImportFileGdbToGeoJson(gisFile, x, false))
                    .Where(x => OrganizationBoundaryStaging.IsUsableFeatureCollectionGeoJson(JsonTools.DeserializeObject<FeatureCollection>(x.Value)))
                    .ToDictionary(x => x.Key, x => new FeatureCollection(JsonTools.DeserializeObject<FeatureCollection>(x.Value).Features.Where(OrganizationBoundaryStaging.IsUsableFeatureGeoJson).ToList()).ToGeoJsonString());

            Check.Assert(geoJsons.Count != 0, "Number of usable Feature Classes in uploaded file must be greater than 0.");

            return geoJsons.Select(x => new OrganizationBoundaryStaging(organization, x.Key, x.Value)).ToList();
        }

        public static HtmlString GetPrimaryContactPersonAsUrl(this Organization organization, FirmaSession currentFirmaSession) => organization.PrimaryContactPerson != null
            ? organization.PrimaryContactPerson.GetFullNameFirstLastAsUrl(currentFirmaSession)
            : new HtmlString(ViewUtilities.NoneString);

        public static HtmlString GetPrimaryContactPersonWithOrgAsUrl(this Organization organization, FirmaSession currentFirmaSession) => organization.PrimaryContactPerson != null
            ? organization.PrimaryContactPerson.GetFullNameFirstLastAndOrgAsUrl(currentFirmaSession)
            : new HtmlString(ViewUtilities.NoneString);

        public static string GetPrimaryContactPersonWithOrgAsString(this Organization organization) => organization.PrimaryContactPerson != null
            ? organization.PrimaryContactPerson.GetFullNameFirstLastAndOrg()
            : ViewUtilities.NoneString;

        public static string GetPrimaryContactPersonAsString(this Organization organization) => organization.PrimaryContactPerson != null
            ? organization.PrimaryContactPerson.GetFullNameFirstLast()
            : ViewUtilities.NoneString;

        public static List<TaxonomyTier> GetMatchmakerTaxonomyTiers(this Organization organization, TaxonomyLevel taxonomyLevel)
        {
            switch (taxonomyLevel.ToEnum)
            {
                case TaxonomyLevelEnum.Leaf:
                    return organization.MatchmakerOrganizationTaxonomyLeafs.ToList().Select(x => new TaxonomyTier(x.TaxonomyLeaf)).ToList();
                case TaxonomyLevelEnum.Branch:
                    return organization.MatchmakerOrganizationTaxonomyBranches.ToList().Select(x => new TaxonomyTier(x.TaxonomyBranch)).ToList();
                case TaxonomyLevelEnum.Trunk:
                    return organization.MatchmakerOrganizationTaxonomyTrunks.ToList().Select(x => new TaxonomyTier(x.TaxonomyTrunk)).ToList();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string GetOptInHasContentString(this Organization organization)
        {
            bool optIn = organization.MatchmakerOptIn.HasValue && organization.MatchmakerOptIn.Value;
            bool hasContent = optIn && organization.HasMatchmakerProfileContent();

            if (!optIn)
            {
                return "Opt-out";
            }

            if (hasContent)
            {
                return "Opt-in, has content";
            }
            return "Opt-in, no content";
        }

        public static bool HasMatchmakerProfileContent(this Organization organization)
        {
            // TODO check all profile sections once they are built
            bool hasMatchmakerTaxonomyContent = HasMatchmakerTaxonomyContent(organization);
            bool hasMatchmakerAreaOfInterestContent = HasMatchmakerAreaOfInterestContent(organization);
            bool hasMatchmakerKeywordContent = HasMatchmakerKeywordContent(organization);
            bool hasMatchmakerClassificationsContent = HasMatchmakerClassificationsContent(organization);
            bool hasMatchmakerPerformanceMeasuresContent = HasMatchmakerPerformanceMeasureContent(organization);

            return hasMatchmakerTaxonomyContent ||
                   hasMatchmakerAreaOfInterestContent ||
                   hasMatchmakerKeywordContent ||
                   hasMatchmakerClassificationsContent ||
                   hasMatchmakerPerformanceMeasuresContent;
        }

        private static bool HasMatchmakerTaxonomyContent(this Organization organization)
        {
            return organization.MatchmakerOrganizationTaxonomyLeafs.Any() || organization.MatchmakerOrganizationTaxonomyBranches.Any() || organization.MatchmakerOrganizationTaxonomyTrunks.Any();
        }

        private static bool HasMatchmakerAreaOfInterestContent(this Organization organization)
        {
            // Custom, user-defined location selected and set
            bool setToUseUserDrawnAreaOfInterestAndOneIsDrawnAndSaved = !organization.UseOrganizationBoundaryForMatchmaker && organization.MatchMakerAreaOfInterestLocations.Any();
            // Organization boundary selected and such a boundary is set for Organization
            bool setToUseOrganizationBoundaryAndOneIsDefined = organization.UseOrganizationBoundaryForMatchmaker && organization.OrganizationBoundary != null;

            return setToUseUserDrawnAreaOfInterestAndOneIsDrawnAndSaved ||
                   setToUseOrganizationBoundaryAndOneIsDefined;
        }

        private static bool HasMatchmakerKeywordContent(this Organization organization)
        {
            // Are any Matchmaker Keywords defined for this Organization?
            return organization.OrganizationMatchmakerKeywords.Any();
        }

        private static bool HasMatchmakerClassificationsContent(this Organization organization)
        {
            return organization.MatchmakerOrganizationClassifications.Any();
        }

        private static bool HasMatchmakerPerformanceMeasureContent(this Organization organization)
        {
            return organization.MatchmakerOrganizationPerformanceMeasures.Any();
        }

        public static string GetMatchmakerResourcesAsString(this Organization organization)
        {
            var resourcesSelected = new List<string>();
            if (organization.MatchmakerCash ?? false)
            {
                resourcesSelected.Add(FieldDefinitionEnum.OrganizationCash.ToType().GetFieldDefinitionLabel());
            }
            if (organization.MatchmakerInKindServices ?? false)
            {
                resourcesSelected.Add(FieldDefinitionEnum.OrganizationInKindServices.ToType().GetFieldDefinitionLabel());
            }
            if (organization.MatchmakerCommercialServices ?? false)
            {
                resourcesSelected.Add(FieldDefinitionEnum.OrganizationCommercialServices.ToType().GetFieldDefinitionLabel());
            }

            if (resourcesSelected.Any())
            {
                return string.Join(", ", resourcesSelected);
            }

            return null;
        }

        public static Dictionary<MatchmakerSubScoreTypeEnum, bool>
            GetMatchmakerOrganizationProfileCompletionDictionary(this Organization organization)
        {
            var allSubScoreTypes = Enum.GetValues(typeof(MatchmakerSubScoreTypeEnum)).OfType<MatchmakerSubScoreTypeEnum>();

            var returnDict = new Dictionary<MatchmakerSubScoreTypeEnum, bool>();

            foreach (var subScoreType in allSubScoreTypes)
            {
                switch (subScoreType)
                {
                    case MatchmakerSubScoreTypeEnum.MatchmakerKeyword:
                        returnDict.Add(MatchmakerSubScoreTypeEnum.MatchmakerKeyword, organization.HasMatchmakerKeywordContent());
                        break;
                    case MatchmakerSubScoreTypeEnum.AreaOfInterest:
                        returnDict.Add(MatchmakerSubScoreTypeEnum.AreaOfInterest, organization.HasMatchmakerAreaOfInterestContent());
                        break;
                    case MatchmakerSubScoreTypeEnum.TaxonomySystem:
                        returnDict.Add(MatchmakerSubScoreTypeEnum.TaxonomySystem, organization.HasMatchmakerTaxonomyContent());
                        
                        break;
                    case MatchmakerSubScoreTypeEnum.Classification:
                        returnDict.Add(MatchmakerSubScoreTypeEnum.Classification, organization.HasMatchmakerClassificationsContent());
                        break;
                    case MatchmakerSubScoreTypeEnum.PerformanceMeasure:
                        if (MultiTenantHelpers.TrackAccomplishments())
                        {
                            returnDict.Add(MatchmakerSubScoreTypeEnum.PerformanceMeasure, organization.HasMatchmakerPerformanceMeasureContent());
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                       
                }
            }

            return returnDict;

        }

    }
}
