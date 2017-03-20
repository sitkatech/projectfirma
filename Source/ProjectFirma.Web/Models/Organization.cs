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
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class Organization : IAuditableEntity
    {
        public const string OrganizationSitka = "Sitka Technology Group";
        public const string OrganizationUnknown = "(Unknown or Unspecified Organization)";

        public string DisplayName
        {
            get
            {
                return IsUnknown ? OrganizationName : string.Format("{0}{1}{2}", OrganizationName, !string.IsNullOrWhiteSpace(OrganizationAbbreviation) ? string.Format(" ({0})", OrganizationAbbreviation) : string.Empty, !IsActive ? " (Inactive)" : string.Empty);
            }
        }

        public string OrganizationNamePossessive
        {
            get
            {
                if (IsUnknown)
                {
                    return OrganizationName;
                }
                var postFix = OrganizationName.EndsWith("s") ? "'" : "'s";
                return string.Format("{0}{1}", OrganizationName, postFix);
            }
        }

        public string AbbreviationIfAvailable
        {
            get { return OrganizationAbbreviation ?? OrganizationName; }
        }

        public HtmlString PrimaryContactPersonAsUrl
        {
            get { return PrimaryContactPerson != null ? PrimaryContactPerson.GetFullNameFirstLastAsUrl() : new HtmlString(ViewUtilities.NoneString); }
        }

        public HtmlString PrimaryContactPersonWithOrgAsUrl
        {
            get { return PrimaryContactPerson != null ? PrimaryContactPerson.GetFullNameFirstLastAndOrgAsUrl() : new HtmlString(ViewUtilities.NoneString); }
        }

        /// <summary>
        /// Use for security situations where the user summary is not displayable, but the Organization is.
        /// </summary>
        public HtmlString PrimaryContactPersonAsStringAndOrgAsUrl
        {
            get { return PrimaryContactPerson != null ? PrimaryContactPerson.GetFullNameFirstLastAsStringAndOrgAsUrl() : new HtmlString(ViewUtilities.NoneString); }
        }

        public string PrimaryContactPersonWithOrgAsString
        {
            get { return PrimaryContactPerson != null ? PrimaryContactPerson.FullNameFirstLastAndOrg : ViewUtilities.NoneString; }
        }

        public string PrimaryContactPersonAsString
        {
            get { return PrimaryContactPerson != null ? PrimaryContactPerson.FullNameFirstLast : ViewUtilities.NoneString; }
        }

        public bool IsLeadImplementerForOneOrMoreProjects
        {
            get { return GetAllProjectOrganizations().Any(po => po.IsLeadOrganization); }
        }

        public static bool IsOrganizationNameUnique(IEnumerable<Organization> organizations, string organizationName, int currentOrganizationID)
        {
            var organization =
                organizations.SingleOrDefault(x => x.OrganizationID != currentOrganizationID && String.Equals(x.OrganizationName, organizationName, StringComparison.InvariantCultureIgnoreCase));
            return organization == null;
        }

        public static bool IsOrganizationAbbreviationUniqueIfProvided(IEnumerable<Organization> organizations, string organizationAbbreviation, int currentOrganizationID)
        {
            // Nulls don't trip the unique check
            if (organizationAbbreviation == null)
            {
                return true;
            }
            var existingOrganization =
                organizations.SingleOrDefault(
                    x => x.OrganizationID != currentOrganizationID && String.Equals(x.OrganizationAbbreviation, organizationAbbreviation, StringComparison.InvariantCultureIgnoreCase));
            return existingOrganization == null;
        }

        public List<ProjectImplementingOrganizationOrProjectFundingOrganization> GetAllProjectOrganizations()
        {
            var projectsWhereYouAreTheImplementingOrg = ProjectImplementingOrganizations.ToLookup(x => x.ProjectID);
            var projectsWhereYouAreTheFundingOrg = ProjectFundingOrganizations.ToLookup(x => x.ProjectID);
            var allProjects = projectsWhereYouAreTheImplementingOrg.Select(x => x.Key).Union(projectsWhereYouAreTheFundingOrg.Select(x => x.Key)).ToList();
            var projectImplementingOrganizationOrProjectFundingOrganizations =
                allProjects.Select(
                    projectID =>
                        new ProjectImplementingOrganizationOrProjectFundingOrganization(projectsWhereYouAreTheImplementingOrg[projectID].SingleOrDefault(),
                            projectsWhereYouAreTheFundingOrg[projectID].SingleOrDefault())).ToList();
            return projectImplementingOrganizationOrProjectFundingOrganizations.OrderBy(x => x.Project.DisplayName).ToList();
        }

        public string AuditDescriptionString
        {
            get { return OrganizationName; }
        }

        public bool IsInKeystone
        {
            get { return OrganizationGuid.HasValue; }
        }
        public bool IsUnknown
        {
            get { return !string.IsNullOrWhiteSpace(OrganizationName) && OrganizationName.Equals(OrganizationUnknown, StringComparison.InvariantCultureIgnoreCase); }
        }

        public IEnumerable<CalendarYearReportedValue> GetAllCalendarYearExpenditures()
        {
            return ProjectFundingSourceExpenditure.ToCalendarYearReportedValues(FundingSources.SelectMany(x => x.ProjectFundingSourceExpenditures));
        }

        public IEnumerable<CalendarYearReportedValue> GetReportableCalendarYearExpenditures()
        {
            return
                ProjectFundingSourceExpenditure.ToCalendarYearReportedValues(
                    FundingSources.SelectMany(x => x.ProjectFundingSourceExpenditures.Where(exp => exp.Project.ProjectStage.AreExpendituresReportable())));
        }

        public IEnumerable<int> GetCalendarYearsForProjectExpenditures()
        {
            var projectFundingSourceExpenditures = FundingSources.SelectMany(x => x.ProjectFundingSourceExpenditures);
            return projectFundingSourceExpenditures.CalculateCalendarYearRangeForExpenditures(this);
        }
    }
}
