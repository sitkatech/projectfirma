using ProjectFirma.Web.UnitTestCommon;
using NUnit.Framework;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public class PerformanceMeasureTest
    {
        [Test]
        public void HasRealSubcategoriesTest()
        {
            var performanceMeasure = TestFramework.TestPerformanceMeasure.Create();
            Assert.That(performanceMeasure.HasRealSubcategories, Is.False, "No subcategories, should be false");

            var performanceMeasureSubcategory = TestFramework.TestPerformanceMeasureSubcategory.Create(performanceMeasure, "PerformanceMeasureSubcategory 1");

            Assert.That(performanceMeasure.HasRealSubcategories, Is.False, "Only 1 performanceMeasureSubcategory, and performanceMeasureSubcategory has no options, should be false");

            var subcategoryOption1 = TestFramework.TestPerformanceMeasureSubcategoryOption.Create(1, performanceMeasureSubcategory, "Option 1");

            Assert.That(performanceMeasure.HasRealSubcategories, Is.False, "Only 1 performanceMeasureSubcategory, and performanceMeasureSubcategory has one option, should be false");

            var subcategoryOption2 = TestFramework.TestPerformanceMeasureSubcategoryOption.Create(2, performanceMeasureSubcategory, "Option 2");

            Assert.That(performanceMeasure.HasRealSubcategories, Is.True, "Only 1 performanceMeasureSubcategory, and performanceMeasureSubcategory has one option, should be true");
        }
    }
}