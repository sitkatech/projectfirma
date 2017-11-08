/*-----------------------------------------------------------------------
<copyright file="InstructionsViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class InstructionsViewData : ProjectUpdateViewData
    {
        public readonly string PerformanceMeasuresUrl;
        public readonly bool IsNewProjectUpdateBatch;

        public InstructionsViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, UpdateStatus updateStatus, bool isNewProjectUpdateBatch) : base(currentPerson, projectUpdateBatch, ProjectUpdateSectionEnum.Instructions, updateStatus)
        {
            PerformanceMeasuresUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x => x.Index());
            IsNewProjectUpdateBatch = isNewProjectUpdateBatch;
        }
    }
}
