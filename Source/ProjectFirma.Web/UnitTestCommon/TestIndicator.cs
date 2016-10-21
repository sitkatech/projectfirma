using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestIndicator
        {
            public static Indicator Create()
            {
                var indicator = new Indicator(MakeTestIndicatorName(), null, MeasurementUnitType.Acres, 1, IndicatorType.Action, null)
                {
                    IndicatorDefinition = MakeTestIndicatorDefinition(),
                    IndicatorSubcategories = new List<IndicatorSubcategory>()
                };
                return indicator;
            }

            private static string MakeTestIndicatorDefinition()
            {
                return MakeTestName("Test Indicator Definition", 200);
            }

            private static string MakeTestIndicatorName()
            {
                return MakeTestName("Test Indicator Name", Indicator.FieldLengths.IndicatorName);
            }
        }
    }
}