using System;
using ApprovalTests;
using ApprovalTests.Reporters;
using ProjectFirma.Web.UnitTestCommon;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common.DesignByContract;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public class SustainabilityIndicatorTest
    {        
        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void TestGetReportedValuesAsVisualizerArrayWithOneSubcategory()
        {
            var sustainabilityIndicator = TestFramework.TestSustainabilityIndicator.Create();
            sustainabilityIndicator.Indicator.IndicatorDisplayName = "Number of Widgets";

            var sustainabilityIndicatorReportingPeriod2000 = TestFramework.TestSustainabilityIndicatorReportingPeriod.Create(sustainabilityIndicator, new DateTime(2000, 1, 1));
            var sustainabilityIndicatorReportingPeriod2001 = TestFramework.TestSustainabilityIndicatorReportingPeriod.Create(sustainabilityIndicator, new DateTime(2001, 1, 1));
            var sustainabilityIndicatorReportingPeriod2002 = TestFramework.TestSustainabilityIndicatorReportingPeriod.Create(sustainabilityIndicator, new DateTime(2002, 1, 1));

            var indicatorSubcategory = TestFramework.TestIndicatorSubcategory.Create(sustainabilityIndicator, "Category 1");
            var indicatorSubcategoryOption1 = TestFramework.TestIndicatorSubcategoryOption.Create(1, indicatorSubcategory, "Option 1");
            var indicatorSubcategoryOption2 = TestFramework.TestIndicatorSubcategoryOption.Create(2, indicatorSubcategory, "Option 2");

            var sustainabilityIndicatorReported2000Subcategory1Option1 = TestFramework.TestSustainabilityIndicatorReported.Create(sustainabilityIndicator, sustainabilityIndicatorReportingPeriod2000, 10);
            TestFramework.TestSustainabilityIndicatorReportedSubcategoryOption.Create(sustainabilityIndicatorReported2000Subcategory1Option1, indicatorSubcategoryOption1);

            var sustainabilityIndicatorReported2001Subcategory1Option1 = TestFramework.TestSustainabilityIndicatorReported.Create(sustainabilityIndicator, sustainabilityIndicatorReportingPeriod2001, 11);
            TestFramework.TestSustainabilityIndicatorReportedSubcategoryOption.Create(sustainabilityIndicatorReported2001Subcategory1Option1, indicatorSubcategoryOption1);

            var sustainabilityIndicatorReported2002Subcategory1Option1 = TestFramework.TestSustainabilityIndicatorReported.Create(sustainabilityIndicator, sustainabilityIndicatorReportingPeriod2002, 11);
            TestFramework.TestSustainabilityIndicatorReportedSubcategoryOption.Create(sustainabilityIndicatorReported2002Subcategory1Option1, indicatorSubcategoryOption1);

            var sustainabilityIndicatorReported2000Subcategory1Option2 = TestFramework.TestSustainabilityIndicatorReported.Create(sustainabilityIndicator, sustainabilityIndicatorReportingPeriod2000, 7);
            TestFramework.TestSustainabilityIndicatorReportedSubcategoryOption.Create(sustainabilityIndicatorReported2000Subcategory1Option2, indicatorSubcategoryOption2);

            var sustainabilityIndicatorReported2001Subcategory1Option2 = TestFramework.TestSustainabilityIndicatorReported.Create(sustainabilityIndicator, sustainabilityIndicatorReportingPeriod2001, 9);
            TestFramework.TestSustainabilityIndicatorReportedSubcategoryOption.Create(sustainabilityIndicatorReported2001Subcategory1Option2, indicatorSubcategoryOption2);

            var sustainabilityIndicatorReported2002Subcategory1Option2 = TestFramework.TestSustainabilityIndicatorReported.Create(sustainabilityIndicator, sustainabilityIndicatorReportingPeriod2002, 5);
            TestFramework.TestSustainabilityIndicatorReportedSubcategoryOption.Create(sustainabilityIndicatorReported2002Subcategory1Option2, indicatorSubcategoryOption2);

            var result = JObject.FromObject(IndicatorSubcategory.MakeGoogleChartDataTableForIndicatorWithOnlyOneSubcategoryAndNotReportedInEIP(sustainabilityIndicator));

            Approvals.Verify(result);
        }

        [Test]
        public void TestGetReportedValuesAsVisualizerArrayWithTwoSubcategories()
        {
            var sustainabilityIndicator = TestFramework.TestSustainabilityIndicator.Create();
            sustainabilityIndicator.Indicator.MeasurementUnitTypeID = MeasurementUnitType.Number.MeasurementUnitTypeID;
            sustainabilityIndicator.Indicator.IndicatorDisplayName = "Number of Widgets";

            var sustainabilityIndicatorReportingPeriod2000 = TestFramework.TestSustainabilityIndicatorReportingPeriod.Create(sustainabilityIndicator, new DateTime(2000, 1, 1));
            var sustainabilityIndicatorReportingPeriod2001 = TestFramework.TestSustainabilityIndicatorReportingPeriod.Create(sustainabilityIndicator, new DateTime(2001, 1, 1));
            var sustainabilityIndicatorReportingPeriod2002 = TestFramework.TestSustainabilityIndicatorReportingPeriod.Create(sustainabilityIndicator, new DateTime(2002, 1, 1));

            var sustainabilityIndicatorSubcategory1 = TestFramework.TestIndicatorSubcategory.Create(sustainabilityIndicator, "Category 1");
            var sustainabilityIndicatorSubcategory1Option1 = TestFramework.TestIndicatorSubcategoryOption.Create(1, sustainabilityIndicatorSubcategory1, "Option 1.1");
            var sustainabilityIndicatorSubcategory1Option2 = TestFramework.TestIndicatorSubcategoryOption.Create(2, sustainabilityIndicatorSubcategory1, "Option 1.2");


            var sustainabilityIndicatorSubcategory2 = TestFramework.TestIndicatorSubcategory.Create(sustainabilityIndicator, "Category 2");
            var sustainabilityIndicatorSubcategory2Option1 = TestFramework.TestIndicatorSubcategoryOption.Create(3, sustainabilityIndicatorSubcategory2, "Option 2.1");
            var sustainabilityIndicatorSubcategory2Option2 = TestFramework.TestIndicatorSubcategoryOption.Create(4, sustainabilityIndicatorSubcategory2, "Option 2.2");

            var sustainabilityIndicatorReported2000Subcategory1Option1 = TestFramework.TestSustainabilityIndicatorReported.Create(sustainabilityIndicator, sustainabilityIndicatorReportingPeriod2000, 10);
            TestFramework.TestSustainabilityIndicatorReportedSubcategoryOption.Create(sustainabilityIndicatorReported2000Subcategory1Option1, sustainabilityIndicatorSubcategory1Option1);
            TestFramework.TestSustainabilityIndicatorReportedSubcategoryOption.Create(sustainabilityIndicatorReported2000Subcategory1Option1, sustainabilityIndicatorSubcategory2Option1);

            var sustainabilityIndicatorReported2001Subcategory1Option1 = TestFramework.TestSustainabilityIndicatorReported.Create(sustainabilityIndicator, sustainabilityIndicatorReportingPeriod2001, 11);
            TestFramework.TestSustainabilityIndicatorReportedSubcategoryOption.Create(sustainabilityIndicatorReported2001Subcategory1Option1, sustainabilityIndicatorSubcategory1Option1);
            TestFramework.TestSustainabilityIndicatorReportedSubcategoryOption.Create(sustainabilityIndicatorReported2001Subcategory1Option1, sustainabilityIndicatorSubcategory2Option2);

            var sustainabilityIndicatorReported2002Subcategory1Option1 = TestFramework.TestSustainabilityIndicatorReported.Create(sustainabilityIndicator, sustainabilityIndicatorReportingPeriod2002, 11);
            TestFramework.TestSustainabilityIndicatorReportedSubcategoryOption.Create(sustainabilityIndicatorReported2002Subcategory1Option1, sustainabilityIndicatorSubcategory1Option1);
            TestFramework.TestSustainabilityIndicatorReportedSubcategoryOption.Create(sustainabilityIndicatorReported2002Subcategory1Option1, sustainabilityIndicatorSubcategory2Option1);

            var sustainabilityIndicatorReported2000Subcategory1Option2 = TestFramework.TestSustainabilityIndicatorReported.Create(sustainabilityIndicator, sustainabilityIndicatorReportingPeriod2000, 7);
            TestFramework.TestSustainabilityIndicatorReportedSubcategoryOption.Create(sustainabilityIndicatorReported2000Subcategory1Option2, sustainabilityIndicatorSubcategory1Option2);
            TestFramework.TestSustainabilityIndicatorReportedSubcategoryOption.Create(sustainabilityIndicatorReported2000Subcategory1Option2, sustainabilityIndicatorSubcategory2Option2);

            var sustainabilityIndicatorReported2001Subcategory1Option2 = TestFramework.TestSustainabilityIndicatorReported.Create(sustainabilityIndicator, sustainabilityIndicatorReportingPeriod2001, 9);
            TestFramework.TestSustainabilityIndicatorReportedSubcategoryOption.Create(sustainabilityIndicatorReported2001Subcategory1Option2, sustainabilityIndicatorSubcategory1Option2);
            TestFramework.TestSustainabilityIndicatorReportedSubcategoryOption.Create(sustainabilityIndicatorReported2001Subcategory1Option2, sustainabilityIndicatorSubcategory2Option2);

            var sustainabilityIndicatorReported2002Subcategory1Option2 = TestFramework.TestSustainabilityIndicatorReported.Create(sustainabilityIndicator, sustainabilityIndicatorReportingPeriod2002, 5);
            TestFramework.TestSustainabilityIndicatorReportedSubcategoryOption.Create(sustainabilityIndicatorReported2002Subcategory1Option2, sustainabilityIndicatorSubcategory1Option2);
            TestFramework.TestSustainabilityIndicatorReportedSubcategoryOption.Create(sustainabilityIndicatorReported2002Subcategory1Option2, sustainabilityIndicatorSubcategory2Option1);


            Assert.Throws<PreconditionException>(() => JObject.FromObject(IndicatorSubcategory.MakeGoogleChartDataTableForIndicatorWithOnlyOneSubcategoryAndNotReportedInEIP(sustainabilityIndicator)), "Non EIP Indicators only have 1 subcategory and we do not handle ones with multiple subcategories");
        }
    }
}