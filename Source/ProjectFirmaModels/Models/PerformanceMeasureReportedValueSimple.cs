namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureReportedValueSimple
    {
        public int CalendarYear { get; set; }

        public double? ReportedValue { get; set; }

        public int PerformanceMeasureID { get; set; }

        public string PerformanceMeasureName { get; set; }
        public string ProjectStage { get; set; }

        public string ProjectName { get; set; }
        public string LeadImplementer { get; set; }
        public string MeasurementUnitType { get; set; }

        public PerformanceMeasureReportedValueSimple()
        {
        }

        public PerformanceMeasureReportedValueSimple(PerformanceMeasureReportedValue performanceMeasureReportedValue)
        {
            PerformanceMeasureID = performanceMeasureReportedValue.PerformanceMeasureID;
            PerformanceMeasureName = performanceMeasureReportedValue.GetPerformanceMeasureName();
            CalendarYear = performanceMeasureReportedValue.CalendarYear;
            ReportedValue = performanceMeasureReportedValue.GetReportedValue();
            MeasurementUnitType = performanceMeasureReportedValue.GetMeasurementUnitType().MeasurementUnitTypeDisplayName;
            ProjectStage = performanceMeasureReportedValue.Project.ProjectStage.ProjectStageDisplayName;
            LeadImplementer = performanceMeasureReportedValue.Project.GetPrimaryContactOrganization().OrganizationShortName;
            ProjectName = performanceMeasureReportedValue.Project.GetDisplayName();
        }
    }
}