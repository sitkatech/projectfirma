/*-----------------------------------------------------------------------
<copyright file="ProjectStage.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

namespace ProjectFirmaModels.Models
{
    public partial class ProjectStage
    {
        public abstract bool IsOnCompletedList();
        public abstract bool IsDeletable();

        public abstract bool RequiresReportedExpenditures();
        public abstract bool RequiresPerformanceMeasureActuals();
        public abstract bool IsStageIncludedInCostCalculations();
        public abstract bool ShouldShowOnMap();

        public abstract IEnumerable<ProjectStage> GetProjectStagesThatProjectCanUpdateTo();

        // ReSharper disable once InconsistentNaming
        public static IEnumerable<ProjectStage> _forwardLookingFactSheetProjectStages;

        public static IEnumerable<ProjectStage> ForwardLookingFactSheetProjectStages => 
            _forwardLookingFactSheetProjectStages ?? (_forwardLookingFactSheetProjectStages =
            new List<ProjectStage>
            {
                Proposal,
                Deferred,
                PlanningDesign
            });
    }

    public partial class ProjectStageProposal
    {
        public override bool IsOnCompletedList()
        {
            return false;
        }

        public override bool IsDeletable()
        {
            return false;
        }

        public override bool RequiresReportedExpenditures()
        {
            return false;
        }

        public override bool RequiresPerformanceMeasureActuals()
        {
            return false;
        }

        public override bool IsStageIncludedInCostCalculations()
        {
            return true;
        }

        public override bool ShouldShowOnMap()
        {
            return true;
        }

        public override IEnumerable<ProjectStage> GetProjectStagesThatProjectCanUpdateTo()
        {
            return new List<ProjectStage>();
        }
    }


    public partial class ProjectStagePlanningDesign
    {
        public override bool IsOnCompletedList()
        {
            return false;
        }

        public override bool IsDeletable()
        {
            return false;
        }

        public override bool RequiresReportedExpenditures()
        {
            return true;
        }

        public override bool RequiresPerformanceMeasureActuals()
        {
            return false;
        }

        public override bool IsStageIncludedInCostCalculations()
        {
            return true;
        }

        public override bool ShouldShowOnMap()
        {
            return true;
        }

        public override IEnumerable<ProjectStage> GetProjectStagesThatProjectCanUpdateTo()
        {
            return All.Except(new[]
            {
                Proposal
            });
        }
    }

    public partial class ProjectStageImplementation
    {
        public override bool IsOnCompletedList()
        {
            return false;
        }

        public override bool IsDeletable()
        {
            return false;
        }

        public override bool RequiresReportedExpenditures()
        {
            return true;
        }

        public override bool RequiresPerformanceMeasureActuals()
        {
            return true;
        }

        public override bool IsStageIncludedInCostCalculations()
        {
            return true;
        }

        public override bool ShouldShowOnMap()
        {
            return true;
        }

        public override IEnumerable<ProjectStage> GetProjectStagesThatProjectCanUpdateTo()
        {
            return All.Except(new ProjectStage[] {PlanningDesign, Proposal});
        }
    }

    public partial class ProjectStageCompleted
    {
        public override bool IsOnCompletedList()
        {
            return true;
        }

        public override bool IsDeletable()
        {
            return false;
        }

        public override bool RequiresReportedExpenditures()
        {
            return false;
        }

        public override bool RequiresPerformanceMeasureActuals()
        {
            return false;
        }

        public override bool IsStageIncludedInCostCalculations()
        {
            return false;
        }

        public override bool ShouldShowOnMap()
        {
            return true;
        }

        public override IEnumerable<ProjectStage> GetProjectStagesThatProjectCanUpdateTo()
        {
            return new[] { Completed };
        }
    }

    public partial class ProjectStageTerminated
    {
        public override bool IsOnCompletedList()
        {
            return false;
        }


        public override bool IsDeletable()
        {
            return false;
        }

        public override bool RequiresReportedExpenditures()
        {
            return false;
        }

        public override bool RequiresPerformanceMeasureActuals()
        {
            return false;
        }

        public override bool IsStageIncludedInCostCalculations()
        {
            return false;
        }

        public override bool ShouldShowOnMap()
        {
            return false;
        }

        public override IEnumerable<ProjectStage> GetProjectStagesThatProjectCanUpdateTo()
        {
            return new[] { Terminated };
        }
    }

    public partial class ProjectStageDeferred
    {
        public override bool IsOnCompletedList()
        {
            return false;
        }

        public override bool IsDeletable()
        {
            return true;
        }

        public override bool RequiresReportedExpenditures()
        {
            return false;
        }

        public override bool RequiresPerformanceMeasureActuals()
        {
            return false;
        }

        public override bool IsStageIncludedInCostCalculations()
        {
            return true;
        }

        public override bool ShouldShowOnMap()
        {
            return false;
        }

        public override IEnumerable<ProjectStage> GetProjectStagesThatProjectCanUpdateTo()
        {
            return new[] { Deferred };
        }
    }

    public partial class ProjectStagePostImplementation
    {
        public override bool IsOnCompletedList()
        {
            return true;
        }

        public override bool IsDeletable()
        {
            return false;
        }

        public override bool RequiresReportedExpenditures()
        {
            return true;
        }

        public override bool RequiresPerformanceMeasureActuals()
        {
            return false;
        }

        public override bool IsStageIncludedInCostCalculations()
        {
            return false;
        }

        public override bool ShouldShowOnMap()
        {
            return true;
        }

        public override IEnumerable<ProjectStage> GetProjectStagesThatProjectCanUpdateTo()
        {
            return All.Except(new List<ProjectStage> { Proposal, PlanningDesign, Implementation });
        }
    }
}
