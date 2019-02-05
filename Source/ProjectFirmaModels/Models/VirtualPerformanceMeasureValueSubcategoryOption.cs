using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    /// <summary>
    /// This exists so that overrides of <see cref="PerformanceMeasureDataSourceType.GetReportedPerformanceMeasureValues"/> can set their Subcategory/Options in a customized way
    /// </summary>
    public class VirtualPerformanceMeasureValueSubcategoryOption : IPerformanceMeasureValueSubcategoryOption
    {
        public int PerformanceMeasureID => PerformanceMeasure.PerformanceMeasureID;
        public int PerformanceMeasureSubcategoryID => PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryID;
        public PerformanceMeasureSubcategoryOption PerformanceMeasureSubcategoryOption { get; }

        public string GetPerformanceMeasureSubcategoryOptionName()
        {
            return PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName;
        }

        public PerformanceMeasure PerformanceMeasure { get; }
        public PerformanceMeasureSubcategory PerformanceMeasureSubcategory { get; }
        public int PrimaryKey => ModelObjectHelpers.NotYetAssignedID;
        public int PerformanceMeasureSubcategoryOptionID { get; }

        public VirtualPerformanceMeasureValueSubcategoryOption(PerformanceMeasureSubcategory performanceMeasureSubcategory)
        {
            PerformanceMeasureSubcategoryOptionID = ModelObjectHelpers.NotYetAssignedID;
            PerformanceMeasureSubcategory = performanceMeasureSubcategory;
            PerformanceMeasure = PerformanceMeasureSubcategory.PerformanceMeasure;
        }
    }
}