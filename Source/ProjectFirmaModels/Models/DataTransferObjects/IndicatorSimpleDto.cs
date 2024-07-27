//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Indicator]
using System;


namespace ProjectFirmaModels.Models.DataTransferObjects
{
    public  class IndicatorSimpleDto
    {
        public int IndicatorID { get; set; }
        public string IndicatorShortName { get; set; }
        public string IndicatorDisplayName { get; set; }
        public int MeasurementUnitTypeID { get; set; }
        public string IndicatorDefinition { get; set; }
        public string DataSourceText { get; set; }
        public string ExternalDataSourceUrl { get; set; }
        public string AssociatedPrograms { get; set; }
        public int IndicatorTypeID { get; set; }
        public string ChartTitle { get; set; }
        public string ChartCaption { get; set; }
        public string ChartDefinitions { get; set; }
        public string ChartNotes { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public bool UseCustomDateRange { get; set; }
        public int IndicatorDataSourceTypeID { get; set; }
        public bool SwapChartAxes { get; set; }
        public bool CanCalculateTotal { get; set; }
        public bool CanBeChartedCumulatively { get; set; }
        public double? Pre2007Value { get; set; }
        public bool IsActive { get; set; }
        public string InactivationReason { get; set; }
        public int? InactivationPersonID { get; set; }
        public DateTime? InactivationDate { get; set; }
        public string ChartSummary { get; set; }
        public string ChartSources { get; set; }
        public int? ChartTypeID { get; set; }
        public int? ChartFileResourceInfoID { get; set; }
        public string ChartSourceURL { get; set; }
    }

}