/*-----------------------------------------------------------------------
<copyright file="OrganizationModelExtensions.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.IO;
using System.Linq;
using System.Web;
using GeoJSON.Net.Feature;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.GdalOgr;
using LtInfo.Common.GeoJson;
using LtInfo.Common.Models;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.PerformanceMeasure;
using ProjectFirmaModels.Models;

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

        public static readonly UrlTemplate<int> SummaryUrlTemplate = new UrlTemplate<int>(SitkaRoute<OrganizationController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int)));
        public static string GetDetailUrl(this Organization organization)
        {
            return organization == null ? "" : SummaryUrlTemplate.ParameterReplace(organization.OrganizationID);
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

        public static List<LayerGeoJson> GetBoundaryLayerGeoJson(this IEnumerable<Organization> organizations)
        {
            var organizationsToShow =
                organizations?.Where(x => x.OrganizationBoundary != null && x.OrganizationType != null)
                    .ToList();
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
                    organizationType.ShowOnProjectMaps ? LayerInitialVisibility.Show : LayerInitialVisibility.Hide);
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

        public static  List<Project> GetAllActiveProjectsAndProposals(this Organization organization, Person person)
        {
            return organization.GetAllAssociatedProjects().GetActiveProjectsAndProposals(person.CanViewProposals());
        }

        public static List<Project> GetAllActiveProjects(this Organization organization, Person person)
        {
            return organization.GetAllAssociatedProjects().GetActiveProjects();
        }

        public static List<Project> GetProposalsVisibleToUser(this Organization organization, Person person)
        {
            return organization.GetAllAssociatedProjects().GetProposalsVisibleToUser(person);
        }

        public static List<Project> GetAllPendingProjects(this Organization organization, Person person)
        {
            return organization.GetAllAssociatedProjects().GetPendingProjects(person.CanViewPendingProjects());
        }

        public static List<Project> GetAllActiveProjectsAndProposalsWhereOrganizationIsStewardOrPrimaryContact(this Organization organization, Person person)
        {
            var allActiveProjectsAndProposals = organization.GetAllAssociatedProjects().GetActiveProjectsAndProposals(person.CanViewProposals());

            if (MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
            {
                return allActiveProjectsAndProposals.Where(x => x.GetCanStewardProjectsOrganization() == organization).ToList();
            }

            return allActiveProjectsAndProposals.Where(x => x.GetPrimaryContactOrganization() == organization).ToList();
        }

        public static List<Project> GetAllActiveProjectsWhereOrganizationReportsInAccomplishmentsDashboard(this Organization organization)
        {
            Check.Assert(MultiTenantHelpers.DisplayAccomplishmentDashboard());
            return organization.GetAllAssociatedProjects()
                .GetActiveProjectsAndProposals(MultiTenantHelpers.ShowProposalsToThePublic())
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
            PerformanceMeasure performanceMeasure, Person currentPerson)
        {
            var projects = organization.GetAllActiveProjectsAndProposals(currentPerson).ToList();
            return new PerformanceMeasureChartViewData(performanceMeasure, currentPerson, false, projects);
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
                Ogr2OgrCommandLineRunner.DefaultCoordinateSystemId,
                FirmaWebConfiguration.HttpRuntimeExecutionTimeout.TotalMilliseconds);

            var geoJsons =
                OgrInfoCommandLineRunner.GetFeatureClassNamesFromFileGdb(new FileInfo(FirmaWebConfiguration.OgrInfoExecutable), gisFile, originalFilename, Ogr2OgrCommandLineRunner.DefaultTimeOut)
                    .ToDictionary(x => x, x => ogr2OgrCommandLineRunner.ImportFileGdbToGeoJson(gisFile, x, false))
                    .Where(x => OrganizationBoundaryStaging.IsUsableFeatureCollectionGeoJson(JsonTools.DeserializeObject<FeatureCollection>(x.Value)))
                    .ToDictionary(x => x.Key, x => new FeatureCollection(JsonTools.DeserializeObject<FeatureCollection>(x.Value).Features.Where(OrganizationBoundaryStaging.IsUsableFeatureGeoJson).ToList()).ToGeoJsonString());

            Check.Assert(geoJsons.Count != 0, "Number of usable Feature Classes in uploaded file must be greater than 0.");

            return geoJsons.Select(x => new OrganizationBoundaryStaging(organization, x.Key, x.Value)).ToList();
        }

        public static HtmlString GetPrimaryContactPersonAsUrl(this Organization organization) => organization.PrimaryContactPerson != null
            ? organization.PrimaryContactPerson.GetFullNameFirstLastAsUrl()
            : new HtmlString(ViewUtilities.NoneString);

        public static HtmlString GetPrimaryContactPersonWithOrgAsUrl(this Organization organization) => organization.PrimaryContactPerson != null
            ? organization.PrimaryContactPerson.GetFullNameFirstLastAndOrgAsUrl()
            : new HtmlString(ViewUtilities.NoneString);

        /// <summary>
        /// Use for security situations where the user summary is not displayable, but the Organization is.
        /// </summary>
        public static HtmlString GetPrimaryContactPersonAsStringAndOrgAsUrl(this Organization organization) => organization.PrimaryContactPerson != null
            ? organization.PrimaryContactPerson.GetFullNameFirstLastAsStringAndOrgAsUrl()
            : new HtmlString(ViewUtilities.NoneString);

        public static string GetPrimaryContactPersonWithOrgAsString(this Organization organization) => organization.PrimaryContactPerson != null
            ? organization.PrimaryContactPerson.GetFullNameFirstLastAndOrg()
            : ViewUtilities.NoneString;

        public static string GetPrimaryContactPersonAsString(this Organization organization) => organization.PrimaryContactPerson != null
            ? organization.PrimaryContactPerson.GetFullNameFirstLast()
            : ViewUtilities.NoneString;

    }
}
