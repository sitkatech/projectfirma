/*-----------------------------------------------------------------------
<copyright file="ExpectedPerformanceMeasureValuesViewData.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class ExpectedPerformanceMeasureValuesViewData : ProjectCreateViewData
    {
        public readonly EditPerformanceMeasureExpectedViewData EditPerformanceMeasureExpectedViewData;

        public ExpectedPerformanceMeasureValuesViewData(Person currentPerson,
            Models.Project project,
            ProposalSectionsStatus proposalSectionsStatus,
            EditPerformanceMeasureExpectedViewData editPerformanceMeasureExpectedViewData)
            : base(currentPerson, project, ProposedProjectSectionEnum.PerformanceMeasures, proposalSectionsStatus)
        {
            EditPerformanceMeasureExpectedViewData = editPerformanceMeasureExpectedViewData;            
        }
    }
}
