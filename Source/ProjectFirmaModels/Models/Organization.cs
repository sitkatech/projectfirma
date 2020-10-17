/*-----------------------------------------------------------------------
<copyright file="Organization.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using System.Web;
using GeoJSON.Net.Feature;
using LtInfo.Common.GeoJson;

namespace ProjectFirmaModels.Models
{
    public partial class Organization : IAuditableEntity
    {
        public static bool UseOrganizationBoundaryForMatchmakerDefault = true;

        public const string OrganizationSitka = "Sitka Technology Group";
        public const string OrganizationUnknown = "(Unknown or Unspecified Organization)";

        public const string OrganizationAreaOfInterestMapLayerColor = "purple";

        public bool IsUnknown() => !String.IsNullOrWhiteSpace(this.OrganizationName) &&
                                   this.OrganizationName.Equals(OrganizationUnknown, StringComparison.InvariantCultureIgnoreCase);

        public string GetDisplayName() => this.IsUnknown()
            ? "Unknown or unspecified"
            : $"{this.OrganizationName}{(!String.IsNullOrWhiteSpace(this.OrganizationShortName) ? $" ({this.OrganizationShortName})" : String.Empty)}{(!this.IsActive ? " (Inactive)" : String.Empty)}";


        public string GetAuditDescriptionString() => OrganizationName;

        public bool IsInKeystone() => OrganizationGuid.HasValue;

        public FeatureCollection OrganizationBoundaryToFeatureCollection()
        {
            return DbGeometryToGeoJsonHelper.FeatureCollectionFromDbGeometry(OrganizationBoundary, OrganizationType.OrganizationTypeName, OrganizationName);
        }

        /// <summary>
        /// Intended to mean Organization currently has full edit rights to Project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public bool IsMyProject(Project project)
        {
            // Keep this function 100% aligned with IsMyProject(vProjectDetail projectDetail) for consistency!!!
            bool thisOrgIsPrimaryContactOrganizationForProject = IsPrimaryContactOrganizationForProject(project);
            bool thisOrgIsProjectStewardOrganizationForProject = IsProjectStewardOrganizationForProject(project);
            bool projectPrimaryContactPersonIsInThisOrg = project.PrimaryContactPerson?.OrganizationID == OrganizationID;

            bool thisOrgIsProposingOrganization = IsProposingOrganization(project);
            bool projectIsInStageProposal = project.ProjectStage == ProjectStage.Proposal;
            bool projectIsPendingProject = project.IsPendingProject();

            bool isProposingOrganizationAndThisIsAProposalOrPendingProject = thisOrgIsProposingOrganization && (projectIsInStageProposal || projectIsPendingProject);

            bool isMyProject =  thisOrgIsPrimaryContactOrganizationForProject ||
                                thisOrgIsProjectStewardOrganizationForProject ||
                                projectPrimaryContactPersonIsInThisOrg ||
                                isProposingOrganizationAndThisIsAProposalOrPendingProject;
            return isMyProject;
        }

        // Keep this function 100% aligned with IsMyProject(Project project) for consistency!!!
        public bool IsMyProject(vProjectDetail projectDetail)
        {
            bool thisOrgIsPrimaryContactOrganizationForProject = projectDetail.PrimaryContactOrganizationID == OrganizationID;
            bool thisOrgIsProjectStewardOrganizationForProject = projectDetail.CanStewardProjectsOrganizationID == OrganizationID;
            bool projectPrimaryContactPersonIsInThisOrg = projectDetail.PrimaryContactOrganizationID == OrganizationID;

            bool thisOrgIsProposingOrganization = projectDetail.ProposingOrganizationID == OrganizationID;
            bool projectIsInStageProposal = projectDetail.ProjectStageID == ProjectStage.Proposal.ProjectStageID;
            bool projectIsPendingProject = Project.IsPendingProject(projectDetail.ProjectStageID, projectDetail.ProjectApprovalStatusID);

            bool isProposingOrganizationAndThisIsAProposalOrPendingProject = thisOrgIsProposingOrganization && (projectIsInStageProposal || projectIsPendingProject);

            bool isMyProject = thisOrgIsPrimaryContactOrganizationForProject ||
                               thisOrgIsProjectStewardOrganizationForProject ||
                               projectPrimaryContactPersonIsInThisOrg ||
                               isProposingOrganizationAndThisIsAProposalOrPendingProject;
            return isMyProject;
        }

        private bool IsProposingOrganization(Project project)
        {
            return project.ProposingPerson?.OrganizationID == OrganizationID;
        }

        public bool IsPrimaryContactOrganizationForProject(Project project)
        {
            var primaryContactOrganization = project.GetPrimaryContactOrganization();
            return primaryContactOrganization != null &&
                   primaryContactOrganization.OrganizationID == OrganizationID;
        }

        public bool IsProjectStewardOrganizationForProject(Project project)
        {
            var canStewardProjectsOrganization = project.GetCanStewardProjectsOrganization();
            return canStewardProjectsOrganization != null &&
                   canStewardProjectsOrganization.OrganizationID == OrganizationID;
        }

        public HtmlString GetFirmaPageContentHtmlString() => DescriptionHtmlString;

        public string GetFirmaPageDisplayName() => GetDisplayName();

        public bool HasPageContent() => !string.IsNullOrWhiteSpace(Description);

        /// <summary>
        /// Get the dbGeometries that should be used when doing Match Maker for this particular Organization geospatially.
        /// </summary>
        /// <returns></returns>
        public List<DbGeometry> GetDbGeometriesToUseForMatchMakerMatchingAgainstThisOrganization()
        {
            // If the user wants to use org boundary, we just return whatever that Org boundary currently is.
            // (We do NOT store this separately)
            if (this.UseOrganizationBoundaryForMatchmaker)
            {
                if (this.OrganizationBoundary == null)
                {
                    return new List<DbGeometry>();
                }
                return new List<DbGeometry> {this.OrganizationBoundary};
            }

            // Otherwise, we use the hand-drawn boundary the user opted to use, and also drew on the map (really just one for now, but the data structure supports multiple).
            return MatchMakerAreaOfInterestLocations.Select(aoi => aoi.MatchMakerAreaOfInterestLocationGeometry).Where(x => x != null).ToList();
        }

    }
}
