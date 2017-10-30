/*-----------------------------------------------------------------------
<copyright file="ProjectFundingSourceExpenditureUpdate.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectFundingSourceExpenditureUpdate : IFundingSourceExpenditure
    {
        public decimal? MonetaryAmount
        {
            get { return ExpenditureAmount; }
        }

        public string ExpenditureAmountDisplay
        {
            get { return ExpenditureAmount.ToStringCurrency(); }
        }

        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectFundingSourceExpenditureUpdates =
                project.ProjectFundingSourceExpenditures.Select(
                    projectFundingSourceExpenditure =>
                        new ProjectFundingSourceExpenditureUpdate(projectUpdateBatch,
                            projectFundingSourceExpenditure.FundingSource,
                            projectFundingSourceExpenditure.CalendarYear,
                            projectFundingSourceExpenditure.ExpenditureAmount)).ToList();
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, IList<ProjectFundingSourceExpenditure> allProjectFundingSourceExpenditures)
        {
            var project = projectUpdateBatch.Project;
            var projectFundingSourceExpendituresFromProjectUpdate =
                projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.Select(
                    x => new ProjectFundingSourceExpenditure(project.ProjectID, x.FundingSource.FundingSourceID, x.CalendarYear, x.ExpenditureAmount)).ToList();
            project.ProjectFundingSourceExpenditures.Merge(projectFundingSourceExpendituresFromProjectUpdate,
                allProjectFundingSourceExpenditures,
                (x, y) => x.ProjectID == y.ProjectID && x.CalendarYear == y.CalendarYear && x.FundingSourceID == y.FundingSourceID,
                (x, y) => x.ExpenditureAmount = y.ExpenditureAmount);
        }
    }
}
