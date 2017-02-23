/*-----------------------------------------------------------------------
<copyright file="ProjectFundingOrganization.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using System.Data.Entity;
using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectFundingOrganization : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get
            {
                var project = HttpRequestStorage.DatabaseEntities.AllProjects.Find(ProjectID);
                var organization = HttpRequestStorage.DatabaseEntities.AllOrganizations.Find(OrganizationID);
                var projectName = project != null ? project.AuditDescriptionString : ViewUtilities.NotFoundString;
                var organizationName = organization != null ? organization.AuditDescriptionString : ViewUtilities.NotFoundString;
                return string.Format("Project: {0}, Organization: {1}", projectName, organizationName);
            }
        }

        public static void SyncProjectFundingOrganizationsWithProjectFundingSourceExpenditures(IEnumerable<int> distinctProjectIDs,
            IEnumerable<IFundingSourceExpenditure> currentProjectFundingSourceExpenditures,
            List<ProjectFundingOrganization> currentProjectFundingOrganizations)
        {
            var distinctFundingSourceIDs = currentProjectFundingSourceExpenditures.Select(x => x.FundingSourceID).Distinct().ToList();
            var distinctOrganizationIDs =
                HttpRequestStorage.DatabaseEntities.FundingSources.Where(x => distinctFundingSourceIDs.Contains(x.FundingSourceID)).Select(x => x.OrganizationID).Distinct().ToList();
            var currentProjectFundingOrganizationsDerivedFromExpenditures = distinctProjectIDs.SelectMany(x => distinctOrganizationIDs.Select(y => new ProjectFundingOrganization(x, y))).ToList();
            var allProjectFundingOrganizations = HttpRequestStorage.DatabaseEntities.AllProjectFundingOrganizations.Local;
            HttpRequestStorage.DatabaseEntities.ProjectFundingOrganizations.Load();
            currentProjectFundingOrganizations.MergeNew(currentProjectFundingOrganizationsDerivedFromExpenditures,
                (x, y) => x.ProjectID == y.ProjectID && x.OrganizationID == y.OrganizationID,
                allProjectFundingOrganizations);
        }
    }
}
