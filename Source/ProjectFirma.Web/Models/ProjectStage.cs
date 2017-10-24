/*-----------------------------------------------------------------------
<copyright file="ProjectStage.cs" company="Tahoe Regional Planning Agency">
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

namespace ProjectFirma.Web.Models
{
    public partial class ProjectStage
    {
        public static readonly ProjectStageProposal Proposal = ProjectStageProposal.Instance;

        public static readonly List<ProjectStage> AllPlusProposed = new List<ProjectStage> { Proposal, PlanningDesign, Implementation, Completed, Terminated, Deferred, PostImplementation };

        public abstract bool IsOnCompletedList();
        public abstract bool IsDeletable();

        public bool IsVisibleToEveryone()
        {
            return true;
        }

        public abstract bool AreExpendituresReportable();
        public abstract bool ArePerformanceMeasuresReportable();
        public abstract bool RequiresReportedExpenditures();
        public abstract bool RequiresPerformanceMeasureActuals();
        public abstract bool IsStagedIncludedInTransporationCostCalculations();
        public abstract bool ShouldShowOnMap();
    }

    public class ProjectStageProposal : ProjectStage
    {
        private ProjectStageProposal(int projectStageID, string projectStageName, string projectStageDisplayName,
            int sortOrder, string projectStageColor) : base(projectStageID, projectStageName, projectStageDisplayName,
            sortOrder, projectStageColor)
        {
        }

        public static readonly ProjectStageProposal Instance =
            new ProjectStageProposal(1, @"Proposed", @"Proposed", 10, @"#dbbdff");
        public override bool IsOnCompletedList()
        {
            return false;
        }

        public override bool IsDeletable()
        {
            return false;
        }

        public override bool AreExpendituresReportable()
        {
            return true;
        }

        public override bool ArePerformanceMeasuresReportable()
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

        public override bool IsStagedIncludedInTransporationCostCalculations()
        {
            return true;
        }

        public override bool ShouldShowOnMap()
        {
            return true;
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

        public override bool AreExpendituresReportable()
        {
            return true;
        }

        public override bool ArePerformanceMeasuresReportable()
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

        public override bool IsStagedIncludedInTransporationCostCalculations()
        {
            return true;
        }

        public override bool ShouldShowOnMap()
        {
            return true;
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

        public override bool AreExpendituresReportable()
        {
            return true;
        }

        public override bool ArePerformanceMeasuresReportable()
        {
            return true;
        }

        public override bool RequiresReportedExpenditures()
        {
            return true;
        }

        public override bool RequiresPerformanceMeasureActuals()
        {
            return true;
        }

        public override bool IsStagedIncludedInTransporationCostCalculations()
        {
            return true;
        }

        public override bool ShouldShowOnMap()
        {
            return true;
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

        public override bool AreExpendituresReportable()
        {
            return true;
        }

        public override bool ArePerformanceMeasuresReportable()
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

        public override bool IsStagedIncludedInTransporationCostCalculations()
        {
            return false;
        }

        public override bool ShouldShowOnMap()
        {
            return true;
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

        public override bool AreExpendituresReportable()
        {
            return false;
        }

        public override bool ArePerformanceMeasuresReportable()
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

        public override bool IsStagedIncludedInTransporationCostCalculations()
        {
            return false;
        }

        public override bool ShouldShowOnMap()
        {
            return false;
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

        public override bool AreExpendituresReportable()
        {
            return false;
        }

        public override bool ArePerformanceMeasuresReportable()
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

        public override bool IsStagedIncludedInTransporationCostCalculations()
        {
            return true;
        }

        public override bool ShouldShowOnMap()
        {
            return false;
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

        public override bool AreExpendituresReportable()
        {
            return true;
        }

        public override bool ArePerformanceMeasuresReportable()
        {
            return true;
        }

        public override bool RequiresReportedExpenditures()
        {
            return true;
        }

        public override bool RequiresPerformanceMeasureActuals()
        {
            return false;
        }

        public override bool IsStagedIncludedInTransporationCostCalculations()
        {
            return false;
        }

        public override bool ShouldShowOnMap()
        {
            return true;
        }
    }
}
