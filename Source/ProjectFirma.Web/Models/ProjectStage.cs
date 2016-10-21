namespace ProjectFirma.Web.Models
{
    public partial class ProjectStage
    {        
        public abstract bool IsOnCompletedList();
        public abstract bool IsOnFiveYearList();
        public abstract bool IsDeletable();

        public bool IsVisibleToEveryone()
        {
            return true;
        }

        public abstract bool AreExpendituresReportable();
        public abstract bool AreEIPPerformanceMeasuresReportable();
        public abstract bool RequiresReportedExpenditures();
        public abstract bool RequiresEIPPerformanceMeasureActuals();
        public abstract bool ValidForEIPPerformanceMeasure34();
        public abstract bool IsStagedIncludedInTransporationCostCalculations();
        public abstract bool ShouldShowOnMap();
    }

    public partial class ProjectStagePlanningDesign
    {
        public override bool IsOnCompletedList()
        {
            return false;
        }

        public override bool IsOnFiveYearList()
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

        public override bool AreEIPPerformanceMeasuresReportable()
        {
            return false;
        }

        public override bool RequiresReportedExpenditures()
        {
            return true;
        }

        public override bool RequiresEIPPerformanceMeasureActuals()
        {
            return false;
        }

        public override bool ValidForEIPPerformanceMeasure34()
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

        public override bool IsOnFiveYearList()
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

        public override bool AreEIPPerformanceMeasuresReportable()
        {
            return true;
        }

        public override bool RequiresReportedExpenditures()
        {
            return true;
        }

        public override bool RequiresEIPPerformanceMeasureActuals()
        {
            return true;
        }

        public override bool ValidForEIPPerformanceMeasure34()
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

    public partial class ProjectStageCompleted
    {
        public override bool IsOnCompletedList()
        {
            return true;
        }

        public override bool IsOnFiveYearList()
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

        public override bool AreEIPPerformanceMeasuresReportable()
        {
            return true;
        }

        public override bool RequiresReportedExpenditures()
        {
            return false;
        }

        public override bool RequiresEIPPerformanceMeasureActuals()
        {
            return false;
        }

        public override bool ValidForEIPPerformanceMeasure34()
        {
            return true;
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

        public override bool IsOnFiveYearList()
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

        public override bool AreEIPPerformanceMeasuresReportable()
        {
            return false;
        }

        public override bool RequiresReportedExpenditures()
        {
            return false;
        }

        public override bool RequiresEIPPerformanceMeasureActuals()
        {
            return false;
        }

        public override bool ValidForEIPPerformanceMeasure34()
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

        public override bool IsOnFiveYearList()
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

        public override bool AreEIPPerformanceMeasuresReportable()
        {
            return false;
        }

        public override bool RequiresReportedExpenditures()
        {
            return false;
        }

        public override bool RequiresEIPPerformanceMeasureActuals()
        {
            return false;
        }

        public override bool ValidForEIPPerformanceMeasure34()
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

        public override bool IsOnFiveYearList()
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

        public override bool AreEIPPerformanceMeasuresReportable()
        {
            return true;
        }

        public override bool RequiresReportedExpenditures()
        {
            return true;
        }

        public override bool RequiresEIPPerformanceMeasureActuals()
        {
            return false;
        }

        public override bool ValidForEIPPerformanceMeasure34()
        {
            return true;
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