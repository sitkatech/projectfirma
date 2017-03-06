/*-----------------------------------------------------------------------
<copyright file="NullableRangeTest.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
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

namespace LtInfo.Common
{
    [TestFixture]
    public class NullableRangeTest
    {
        [Test]
        public void ContainsValueTest()
        {
            var intRange = new NullableRange<int>(1, 7);
            Assert.That(intRange.IsValueInRange(0), Is.False);
            Assert.That(intRange.IsValueInRange(1), Is.True);
            Assert.That(intRange.IsValueInRange(2), Is.True);
            Assert.That(intRange.IsValueInRange(3), Is.True);
            Assert.That(intRange.IsValueInRange(7), Is.True);
            Assert.That(intRange.IsValueInRange(8), Is.False);
        }

        [Test]
        public void GivenRangeWithNullLowEndAllLowerNumbersAreIn()
        {
            var intRange = new NullableRange<int>(null, 10);
            Assert.That(intRange.IsValueInRange(int.MinValue), Is.True);
            Assert.That(intRange.IsValueInRange(1), Is.True);
            Assert.That(intRange.IsValueInRange(10), Is.True);
            Assert.That(intRange.IsValueInRange(11), Is.False);
            Assert.That(intRange.IsValueInRange(int.MaxValue), Is.False);
        }

        [Test]
        public void GivenRangeWithNullHighEndEverythingFromThereUpIsIn()
        {
            var intRange = new NullableRange<int>(-1, null);
            Assert.That(intRange.IsValueInRange(int.MinValue), Is.False);
            Assert.That(intRange.IsValueInRange(-5), Is.False);
            Assert.That(intRange.IsValueInRange(-1), Is.True);
            Assert.That(intRange.IsValueInRange(10), Is.True);
            Assert.That(intRange.IsValueInRange(int.MaxValue), Is.True);
        }
        
        [Test]
        public void GivenNullNullRangeAllNumbersAreIn()
        {
            var intRange = new NullableRange<int>(null, null);
            Assert.That(intRange.IsValueInRange(int.MinValue), Is.True);
            Assert.That(intRange.IsValueInRange(-5), Is.True);
            Assert.That(intRange.IsValueInRange(-1), Is.True);
            Assert.That(intRange.IsValueInRange(10), Is.True);
            Assert.That(intRange.IsValueInRange(int.MaxValue), Is.True);
        }

        [Test]
        public void OverlapTest()
        {
            var intRange1 = new NullableRange<int>(1, 7);
            var intRange2 = new NullableRange<int>(3, 10);
            var intRange3 = new NullableRange<int>(8, 12);
            var intRange4 = new NullableRange<int>(7, 9);
            var intRange5 = new NullableRange<int>(0, 1);
            Assert.That(intRange1.OverlapsWithOtherRange(intRange2), Is.True);
            Assert.That(intRange1.OverlapsWithOtherRange(intRange3), Is.False);
            Assert.That(intRange1.OverlapsWithOtherRange(intRange4), Is.True);
            Assert.That(intRange1.OverlapsWithOtherRange(intRange5), Is.True);
        }

        [Test]
        public void OverlapTestWithNull()
        {
            var nullSevenRange = new NullableRange<int>(null, 7);
            var threeNullRange = new NullableRange<int>(3, null);
            var nullNullRange = new NullableRange<int>(null, null);
            var sevenNineRange = new NullableRange<int>(7, 9);
            var eightElevenRange = new NullableRange<int>(8, 11);
            var zeroTwoRange = new NullableRange<int>(0, 2);

            // Self overlap
            // ------------
            AssertOverlapsWithSelf(nullSevenRange);
            AssertOverlapsWithSelf(threeNullRange);
            AssertOverlapsWithSelf(nullNullRange);
            AssertOverlapsWithSelf(sevenNineRange);
            AssertOverlapsWithSelf(eightElevenRange);

            // Overlap with the infinite range
            // -------------------------------
            const string nullRangeOverlapsWithAll = "Null range overlaps with all";
            Assert.That(nullNullRange.OverlapsWithOtherRange(nullNullRange), Is.True, nullRangeOverlapsWithAll);
            Assert.That(nullNullRange.OverlapsWithOtherRange(threeNullRange), Is.True, nullRangeOverlapsWithAll);
            Assert.That(nullNullRange.OverlapsWithOtherRange(nullSevenRange), Is.True, nullRangeOverlapsWithAll);
            Assert.That(nullNullRange.OverlapsWithOtherRange(sevenNineRange), Is.True, nullRangeOverlapsWithAll);
            Assert.That(nullNullRange.OverlapsWithOtherRange(eightElevenRange), Is.True, nullRangeOverlapsWithAll);

            Assert.That(nullNullRange.OverlapsWithOtherRange(nullNullRange), Is.True, nullRangeOverlapsWithAll);
            Assert.That(threeNullRange.OverlapsWithOtherRange(nullNullRange), Is.True, nullRangeOverlapsWithAll);
            Assert.That(nullSevenRange.OverlapsWithOtherRange(nullNullRange), Is.True, nullRangeOverlapsWithAll);
            Assert.That(sevenNineRange.OverlapsWithOtherRange(nullNullRange), Is.True, nullRangeOverlapsWithAll);
            Assert.That(eightElevenRange.OverlapsWithOtherRange(nullNullRange), Is.True, nullRangeOverlapsWithAll);

            // Overlaps
            // --------
            Assert.That(nullSevenRange.OverlapsWithOtherRange(threeNullRange), Is.True);
            Assert.That(nullSevenRange.OverlapsWithOtherRange(sevenNineRange), Is.True);
            Assert.That(nullSevenRange.OverlapsWithOtherRange(eightElevenRange), Is.False);

            Assert.That(threeNullRange.OverlapsWithOtherRange(eightElevenRange), Is.True);
            Assert.That(threeNullRange.OverlapsWithOtherRange(sevenNineRange), Is.True);
            Assert.That(threeNullRange.OverlapsWithOtherRange(zeroTwoRange), Is.False);
        }

        private void AssertOverlapsWithSelf(NullableRange<int> nullableRange)
        {
            Assert.That(nullableRange.OverlapsWithOtherRange(nullableRange), Is.True, "Should always overlap with self");
        }

    }
}
