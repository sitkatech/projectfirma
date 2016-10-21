using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.IndicatorRelationship
{
    public class EditViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly List<IndicatorRelationshipTypeSimple> IndicatorRelationshipTypes;
        public readonly List<ThresholdReportingCategorySimple> AllThresholdReportingCategories;
        public readonly List<IndicatorSimple> AllIndicators;
        public readonly int? IndicatorID;
        public readonly int? ThresholdReportingCategoryID;
        public readonly bool FromIndicator;

        private EditViewData(List<IndicatorSimple> allIndicators, List<ThresholdReportingCategorySimple> allThresholdReportingCategories, List<IndicatorRelationshipTypeSimple> indicatorRelationshipTypes, int? indicatorID, int? thresholdReportingCategoryID)
        {
            AllIndicators = allIndicators;
            AllThresholdReportingCategories = allThresholdReportingCategories;
            IndicatorID = indicatorID;
            ThresholdReportingCategoryID = thresholdReportingCategoryID;
            IndicatorRelationshipTypes = indicatorRelationshipTypes;
            FromIndicator = indicatorID.HasValue;
        }

        public EditViewData(Models.Indicator indicator, List<ThresholdReportingCategorySimple> allThresholdReportingCategories, List<IndicatorRelationshipTypeSimple> indicatorRelationshipTypes)
            : this(new List<IndicatorSimple> {new IndicatorSimple(indicator)}, allThresholdReportingCategories, indicatorRelationshipTypes, indicator.IndicatorID, null)
        {
        }

        public EditViewData(Models.ThresholdReportingCategory thresholdReportingCategory, List<IndicatorSimple> allIndicators, List<IndicatorRelationshipTypeSimple> indicatorRelationshipTypes)
            : this(
                allIndicators,
                new List<ThresholdReportingCategorySimple> {new ThresholdReportingCategorySimple(thresholdReportingCategory)}, indicatorRelationshipTypes, null, thresholdReportingCategory.ThresholdReportingCategoryID)
        {
        }
    }
}