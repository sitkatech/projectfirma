/*-----------------------------------------------------------------------
<copyright file="FundingSource.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using System.Web;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public partial class FundingSource : IAuditableEntity
    {
        public string EditUrl
        {
            get { return SitkaRoute<FundingSourceController>.BuildUrlFromExpression(t => t.Edit(FundingSourceID)); }
        }

        public string DeleteUrl
        {
            get { return SitkaRoute<FundingSourceController>.BuildUrlFromExpression(c => c.DeleteFundingSource(FundingSourceID)); }
        }

        public HtmlString DisplayNameAsUrl => UrlTemplate.MakeHrefString(SummaryUrl, DisplayName);

        public string DisplayName =>
            $"{FundingSourceName} ({Organization.OrganizationShortNameIfAvailable}){(!IsActive ? " (Inactive)" : string.Empty)}";

        public string FixedLengthDisplayName
        {
            get
            {
                if (Organization.IsUnknown)
                {
                    return Organization.OrganizationShortNameIfAvailable;
                }
                var organizationShortNameIfAvailable = $"({Organization.OrganizationShortNameIfAvailable})";
                return $"{FundingSourceName.ToEllipsifiedString(60 - organizationShortNameIfAvailable.Length)} {organizationShortNameIfAvailable}";
            }
        }


        public string SummaryUrl
        {
            get { return SitkaRoute<FundingSourceController>.BuildUrlFromExpression(x => x.Detail(FundingSourceID)); }
        }

        public static bool IsFundingSourceNameUnique(IEnumerable<FundingSource> fundingSources, string fundingSourceName, int currentFundingSourceID)
        {
            var fundingSource =
                fundingSources.SingleOrDefault(x => x.FundingSourceID != currentFundingSourceID && String.Equals(x.FundingSourceName, fundingSourceName, StringComparison.InvariantCultureIgnoreCase));
            return fundingSource == null;
        }

        public int? ProjectsWhereYouAreTheFundingSourceMinCalendarYear
        {
            get { return ProjectFundingSourceExpenditures.Any() ? ProjectFundingSourceExpenditures.Min(x => x.CalendarYear) : (int?) null; }
        }

        public int? ProjectsWhereYouAreTheFundingSourceMaxCalendarYear
        {
            get { return ProjectFundingSourceExpenditures.Any() ? ProjectFundingSourceExpenditures.Max(x => x.CalendarYear) : (int?) null; }
        }

        public string AuditDescriptionString => FundingSourceName;

        public List<Project> AssociatedProjects
        {
            get { return ProjectFundingSourceExpenditures.Select(x => x.Project).Distinct(new HavePrimaryKeyComparer<Project>()).OrderBy(x => x.DisplayName).ToList(); }
        }
    }
}
