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
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class Organization : IAuditableEntity
    {
        public string GetDisplayName() => IsUnknown()
            ? "Unknown or unspecified"
            : $"{OrganizationName}{(!String.IsNullOrWhiteSpace(OrganizationShortName) ? $" ({OrganizationShortName})" : String.Empty)}{(!IsActive ? " (Inactive)" : String.Empty)}";

        public string GetDisplayNameWithoutAbbreviation() => IsUnknown()
            ? "Unknown or unspecified"
            : $"{OrganizationName}{(!IsActive ? " (Inactive)" : String.Empty)}";

        public string GetOrganizationNamePossessive()
        {
            if (IsUnknown())
            {
                return OrganizationName;
            }

            var postFix = OrganizationName.EndsWith("s") ? "'" : "'s";
            return $"{OrganizationName}{postFix}";
        }

        public string GetOrganizationShortNameIfAvailable()
        {
            if (IsUnknown())
            {
                return "Unknown or Unassigned";
            }

            return OrganizationShortName ?? OrganizationName;
        }

        public HtmlString GetPrimaryContactPersonAsUrl() => PrimaryContactPerson != null
            ? PrimaryContactPerson.GetFullNameFirstLastAsUrl()
            : new HtmlString(ViewUtilities.NoneString);

        public HtmlString GetPrimaryContactPersonWithOrgAsUrl() => PrimaryContactPerson != null
            ? PrimaryContactPerson.GetFullNameFirstLastAndOrgAsUrl()
            : new HtmlString(ViewUtilities.NoneString);

        /// <summary>
        /// Use for security situations where the user summary is not displayable, but the Organization is.
        /// </summary>
        public HtmlString GetPrimaryContactPersonAsStringAndOrgAsUrl() => PrimaryContactPerson != null
            ? PrimaryContactPerson.GetFullNameFirstLastAsStringAndOrgAsUrl()
            : new HtmlString(ViewUtilities.NoneString);

        public string GetPrimaryContactPersonWithOrgAsString() => PrimaryContactPerson != null
            ? PrimaryContactPerson.GetFullNameFirstLastAndOrg()
            : ViewUtilities.NoneString;

        public string GetPrimaryContactPersonAsString() => PrimaryContactPerson != null
            ? PrimaryContactPerson.GetFullNameFirstLast()
            : ViewUtilities.NoneString;

        public string GetAuditDescriptionString() => OrganizationName;

        public bool IsInKeystone() => OrganizationGuid.HasValue;

        public bool IsUnknown() => !String.IsNullOrWhiteSpace(OrganizationName) &&
                                   OrganizationName.Equals(OrganizationModelExtensions.OrganizationUnknown, StringComparison.InvariantCultureIgnoreCase);

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
    }
}
