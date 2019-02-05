/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureTest.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/

using NUnit.Framework;
using TestFramework = ProjectFirmaModels.UnitTestCommon.TestFramework;

namespace ProjectFirmaModels.Models
{
    [TestFixture]
    public class PerformanceMeasureTest
    {
        [Test]
        public void HasRealSubcategoriesTest()
        {
            var performanceMeasure = TestFramework.TestPerformanceMeasure.Create();
            Assert.That(performanceMeasure.HasRealSubcategories(), Is.False, "No subcategories, should be false");

            var performanceMeasureSubcategory = TestFramework.TestPerformanceMeasureSubcategory.Create(performanceMeasure, "PerformanceMeasureSubcategory 1");

            Assert.That(performanceMeasure.HasRealSubcategories(), Is.False, "Only 1 performanceMeasureSubcategory, and performanceMeasureSubcategory has no options, should be false");

            var subcategoryOption1 = TestFramework.TestPerformanceMeasureSubcategoryOption.Create(1, performanceMeasureSubcategory, "Option 1");

            Assert.That(performanceMeasure.HasRealSubcategories(), Is.False, "Only 1 performanceMeasureSubcategory, and performanceMeasureSubcategory has one option, should be false");

            var subcategoryOption2 = TestFramework.TestPerformanceMeasureSubcategoryOption.Create(2, performanceMeasureSubcategory, "Option 2");

            Assert.That(performanceMeasure.HasRealSubcategories(), Is.True, "Only 1 performanceMeasureSubcategory, and performanceMeasureSubcategory has one option, should be true");
        }
    }
}
