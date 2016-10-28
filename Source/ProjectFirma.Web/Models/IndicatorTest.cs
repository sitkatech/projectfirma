using ProjectFirma.Web.UnitTestCommon;
using NUnit.Framework;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public class IndicatorTest
    {
        [Test]
        public void HasRealSubcategoriesTest()
        {
            var performanceMeasure = TestFramework.TestPerformanceMeasure.Create();
            Assert.That(performanceMeasure.Indicator.HasRealSubcategories, Is.False, "No subcategories, should be false");

            var indicatorSubcategory = TestFramework.TestIndicatorSubcategory.Create(performanceMeasure, "IndicatorSubcategory 1");

            Assert.That(performanceMeasure.Indicator.HasRealSubcategories, Is.False, "Only 1 indicatorSubcategory, and indicatorSubcategory has no options, should be false");

            var subcategoryOption1 = TestFramework.TestIndicatorSubcategoryOption.Create(1, indicatorSubcategory, "Option 1");

            Assert.That(performanceMeasure.Indicator.HasRealSubcategories, Is.False, "Only 1 indicatorSubcategory, and indicatorSubcategory has one option, should be false");

            var subcategoryOption2 = TestFramework.TestIndicatorSubcategoryOption.Create(2, indicatorSubcategory, "Option 2");

            Assert.That(performanceMeasure.Indicator.HasRealSubcategories, Is.True, "Only 1 indicatorSubcategory, and indicatorSubcategory has one option, should be true");
        }
    }
}