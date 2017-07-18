/*-----------------------------------------------------------------------
<copyright file="ProjectFundingSourceOrganizationTypeExpenditure.cs" company="Tahoe Regional Planning Agency">
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
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public class ProjectFundingSourceOrganizationTypeExpenditure
    {
        public readonly Project Project;
        public readonly FundingSource FundingSource;
        public readonly decimal ExpenditureAmount;

        public ProjectFundingSourceOrganizationTypeExpenditure(Project project, FundingSource fundingSource, decimal expenditureAmount)
        {
            Project = project;
            FundingSource = fundingSource;
            ExpenditureAmount = expenditureAmount;
        }

        public static List<ProjectFundingSourceOrganizationTypeExpenditure> MakeFromProjectFundingSourceExpenditures(List<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures)
        {
            return
                projectFundingSourceExpenditures.GroupBy(x => new {x.Project, x.FundingSource})
                    .Select(x => new ProjectFundingSourceOrganizationTypeExpenditure(x.Key.Project, x.Key.FundingSource, x.Sum(y => y.ExpenditureAmount)))
                    .ToList();
        }
    }
}
