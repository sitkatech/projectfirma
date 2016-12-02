using System.Collections.Generic;
using ApprovalUtilities.Utilities;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestPerformanceMeasure
        {
            public static PerformanceMeasure Create()
            {
                var performanceMeasure = new PerformanceMeasure("Foo", "Bar", MeasurementUnitType.Acres, PerformanceMeasureType.Action, 10, string.Empty)
                {
                    PerformanceMeasureSubcategories = new List<PerformanceMeasureSubcategory>()
                };
                return performanceMeasure;
            }

            public static PerformanceMeasure CreateWithSubcategories(int performanceMeasureID, string performanceMeasureName)
            {
                var performanceMeasure = Create();
                var subcategoryIDBase = performanceMeasureID*10;
                var subcategory1 = TestPerformanceMeasureSubcategory.CreateWithSubcategoryOptions(performanceMeasure, subcategoryIDBase + 1, string.Format("{0}Subcategory1", performanceMeasureName));
                var subcategory2 = TestPerformanceMeasureSubcategory.CreateWithSubcategoryOptions(performanceMeasure, subcategoryIDBase + 2, string.Format("{0}Subcategory2", performanceMeasureName));
                var subcategory3 = TestPerformanceMeasureSubcategory.CreateWithSubcategoryOptions(performanceMeasure, subcategoryIDBase + 3, string.Format("{0}Subcategory3", performanceMeasureName));
                performanceMeasure.PerformanceMeasureSubcategories.AddAll(new List<PerformanceMeasureSubcategory> {subcategory1, subcategory2, subcategory3});

                return performanceMeasure;
                
            }
        }
    }
}