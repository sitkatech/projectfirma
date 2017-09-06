/*-----------------------------------------------------------------------
<copyright file="Organization.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.Linq;
using System.Web;
using GeoJSON.Net.Feature;
using LtInfo.Common.GeoJson;
using LtInfo.Common.Views;
using ProjectFirma.Web.Views.PerformanceMeasure;

namespace ProjectFirma.Web.Models
{
    public partial class Organization : IAuditableEntity
    {
        public const string OrganizationSitka = "Sitka Technology Group";
        public const string OrganizationUnknown = "(Unknown or Unspecified Organization)";

        public string DisplayName => IsUnknown ? OrganizationName : $"{OrganizationName}{(!string.IsNullOrWhiteSpace(OrganizationShortName) ? $" ({OrganizationShortName})" : string.Empty)}{(!IsActive ? " (Inactive)" : string.Empty)}";

        public string OrganizationNamePossessive
        {
            get
            {
                if (IsUnknown)
                {
                    return OrganizationName;
                }
                var postFix = OrganizationName.EndsWith("s") ? "'" : "'s";
                return $"{OrganizationName}{postFix}";
            }
        }

        public string OrganizationShortNameIfAvailable => OrganizationShortName ?? OrganizationName;

        public HtmlString PrimaryContactPersonAsUrl => PrimaryContactPerson != null ? PrimaryContactPerson.GetFullNameFirstLastAsUrl() : new HtmlString(ViewUtilities.NoneString);

        public HtmlString PrimaryContactPersonWithOrgAsUrl => PrimaryContactPerson != null ? PrimaryContactPerson.GetFullNameFirstLastAndOrgAsUrl() : new HtmlString(ViewUtilities.NoneString);

        /// <summary>
        /// Use for security situations where the user summary is not displayable, but the Organization is.
        /// </summary>
        public HtmlString PrimaryContactPersonAsStringAndOrgAsUrl => PrimaryContactPerson != null ? PrimaryContactPerson.GetFullNameFirstLastAsStringAndOrgAsUrl() : new HtmlString(ViewUtilities.NoneString);

        public string PrimaryContactPersonWithOrgAsString => PrimaryContactPerson != null ? PrimaryContactPerson.FullNameFirstLastAndOrg : ViewUtilities.NoneString;

        public string PrimaryContactPersonAsString => PrimaryContactPerson != null ? PrimaryContactPerson.FullNameFirstLast : ViewUtilities.NoneString;

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

        public List<ProjectOrganization> GetAllProjectOrganizations()
        {
            return ProjectOrganizations.OrderBy(x => x.Project.DisplayName).ToList();
        }

        public List<Project> GetAllProjectsIncludingLeadImplementing()
        {
            return ProjectOrganizations.Select(x => x.Project).Distinct().ToList();
        }

        public string AuditDescriptionString => OrganizationName;

        public bool IsInKeystone => OrganizationGuid.HasValue;

        public bool IsUnknown => !string.IsNullOrWhiteSpace(OrganizationName) && OrganizationName.Equals(OrganizationUnknown, StringComparison.InvariantCultureIgnoreCase);

        public FeatureCollection OrganizationBoundaryToFeatureCollection => new FeatureCollection(new List<Feature>
        {
            DbGeometryToGeoJsonHelper.FromDbGeometry(OrganizationBoundary)
        });

        public PerformanceMeasureChartViewData GetPerformanceMeasureChartViewData(PerformanceMeasure performanceMeasure)
        {
            var projectIDs = ProjectOrganizations.Select(x => x.ProjectID).ToList();
            return new PerformanceMeasureChartViewData(performanceMeasure, true, ChartViewMode.Large, projectIDs);
        }
    }
}
