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
using System.Web;
using GeoJSON.Net.Feature;
using LtInfo.Common.GeoJson;

namespace ProjectFirmaModels.Models
{
    public partial class Organization : IAuditableEntity
    {
        public const string OrganizationSitka = "Sitka Technology Group";
        public const string OrganizationUnknown = "(Unknown or Unspecified Organization)";

        public bool IsUnknown() => !String.IsNullOrWhiteSpace(this.OrganizationName) &&
                                                                        this.OrganizationName.Equals(OrganizationUnknown, StringComparison.InvariantCultureIgnoreCase);

        public string GetDisplayName() => this.IsUnknown()
            ? "Unknown or unspecified"
            : $"{this.OrganizationName}{(!String.IsNullOrWhiteSpace(this.OrganizationShortName) ? $" ({this.OrganizationShortName})" : String.Empty)}{(!this.IsActive ? " (Inactive)" : String.Empty)}";


        public string GetAuditDescriptionString() => OrganizationName;

        public bool IsInKeystone() => OrganizationGuid.HasValue;

        public FeatureCollection OrganizationBoundaryToFeatureCollection()
        {
            var feature = DbGeometryToGeoJsonHelper.FromDbGeometry(OrganizationBoundary);
            feature.Properties.Add(OrganizationType.OrganizationTypeName, OrganizationName);
            return new FeatureCollection(new List<Feature> { feature });
        }

        public bool IsMyProject(Project project)
        {
            return IsLeadImplementingOrganizationForProject(project) ||
                   IsProjectStewardOrganizationForProject(project) ||
                   IsProposingOrganization(project);
        }

        public bool IsMyProject(vProjectDetail projectDetail)
        {
            var isLeadImplementingOrganizationForProject = projectDetail.PrimaryContactOrganizationID == OrganizationID;
            var isProjectStewardOrganizationForProject = projectDetail.CanStewardProjectsOrganizationID == OrganizationID;
            var isProposingOrganization = projectDetail.ProposingOrganizationID == OrganizationID;
            return isLeadImplementingOrganizationForProject ||
                   isProjectStewardOrganizationForProject ||
                   isProposingOrganization;
        }

        private bool IsProposingOrganization(Project project)
        {
            return project.ProposingPerson?.OrganizationID == OrganizationID;
        }

        public bool IsLeadImplementingOrganizationForProject(Project project)
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
    }
}
