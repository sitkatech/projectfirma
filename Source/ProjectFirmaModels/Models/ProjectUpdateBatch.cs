/*-----------------------------------------------------------------------
<copyright file="ProjectUpdateBatch.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public partial class ProjectUpdateBatch : IAuditableEntity
    {
        public bool IsApproved() => ProjectUpdateState == ProjectUpdateState.Approved;

        public bool IsReturned() => ProjectUpdateState == ProjectUpdateState.Returned;

        public bool IsSubmitted() => ProjectUpdateState == ProjectUpdateState.Submitted;

        public bool IsCreated() => ProjectUpdateState == ProjectUpdateState.Created;

        public bool IsNew() => ProjectUpdateState == ProjectUpdateState.Created &&
                               !ModelObjectHelpers.IsRealPrimaryKeyValue(ProjectUpdateBatchID);

        public ProjectUpdateHistory GetLatestProjectUpdateHistorySubmitted() =>
            ProjectUpdateHistories.GetLatestProjectUpdateHistory(ProjectUpdateState.Submitted);

        public ProjectUpdateHistory GetLatestProjectUpdateHistoryReturned() =>
            ProjectUpdateHistories.GetLatestProjectUpdateHistory(ProjectUpdateState.Returned);

        public void SyncPerformanceMeasureActualYearsExemptionExplanation()
        {
            PerformanceMeasureActualYearsExemptionExplanation = Project.PerformanceMeasureActualYearsExemptionExplanation;
        }

        public void SyncExpendituresYearsExemptionExplanation()
        {
            NoExpendituresToReportExplanation = Project.NoExpendituresToReportExplanation;
        }

        public void TickleLastUpdateDate(FirmaSession currentFirmaSession)
        {
            TickleLastUpdateDate(DateTime.Now, currentFirmaSession);
        }

        public void TickleLastUpdateDate(DateTime transitionDate, FirmaSession currentFirmaSession)
        {
            LastUpdateDate = transitionDate;
            LastUpdatePerson = currentFirmaSession.Person;
        }

        public bool NewStageIsPlanningDesign() => ProjectUpdate.ProjectStage == ProjectStage.PlanningDesign;
        public string GetAuditDescriptionString()
        {
            return $"Project Update Batch {ProjectUpdateBatchID} updated";
        }
    }
}
