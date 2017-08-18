/*-----------------------------------------------------------------------
<copyright file="ProjectOrganizationsGridSpec.cs" company="Tahoe Regional Planning Agency">
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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.Organization
{
    public class ProjectsIncludingLeadImplementingGridSpec : GridSpec<Models.Project>
    {
        public ProjectsIncludingLeadImplementingGridSpec(Models.Organization organization)
        {
            Add(Models.FieldDefinition.Project.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.GetDetailUrl(), a.DisplayName), 350, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.ProjectStage.ToGridHeaderString(), a => a.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(Models.FieldDefinition.ProjectRelationshipType.ToGridHeaderStringPlural(Models.FieldDefinition.ProjectRelationshipType.GetFieldDefinitionLabelPluralized()),
                a => a.AssocatedOrganizationNames(organization), 100, DhtmlxGridColumnFilterType.None);
            foreach (var year in organization.GetCalendarYearsForProjectExpenditures())
            {
                var calendarYear = year;
                Add(calendarYear.ToString(CultureInfo.InvariantCulture),
                    a =>
                        organization.FundingSources.SelectMany(x => x.ProjectFundingSourceExpenditures.Where(pfse => pfse.CalendarYear == calendarYear && pfse.ProjectID == a.ProjectID))
                            .Sum(pfse => pfse.ExpenditureAmount),
                    100,
                    DhtmlxGridColumnFormatType.Currency,
                    DhtmlxGridColumnAggregationType.Total);
            }
        }
    }
}
