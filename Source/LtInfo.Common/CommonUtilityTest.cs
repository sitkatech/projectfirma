/*-----------------------------------------------------------------------
<copyright file="CommonUtilityTest.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
    public class CommonUtilityTest
    {
        [Test]
        public void IndentTest()
        {
            Assert.That(CommonUtility.IndentLinesInStringByAmount(null, 3, " "), Is.Null, "Null should return null");
            Assert.That(CommonUtility.IndentLinesInStringByAmount(string.Empty, 3, " "), Is.EqualTo(string.Empty), "Empty string should come back empty");
            Assert.That(CommonUtility.IndentLinesInStringByAmount("A\nB\nC", 0, " "), Is.EqualTo("A\nB\nC"), "Should be able to indent even if it is only one line");
            Assert.That(CommonUtility.IndentLinesInStringByAmount("A", 1, " "), Is.EqualTo(" A"), "Should be able to indent by 1 for one line");
            Assert.That(CommonUtility.IndentLinesInStringByAmount("A\nB\nC", 1, " "), Is.EqualTo(" A\n B\n C"), "Should be able to indent by 1");
            Assert.That(CommonUtility.IndentLinesInStringByAmount("A\r\nB\nC\rD", 1, " "), Is.EqualTo(" A\r\n B\n C\r D"), "Should be able to indent by 1 even with mixed line endings");
            Assert.That(CommonUtility.IndentLinesInStringByAmount("A\nB\nC", 3, " "), Is.EqualTo("   A\n   B\n   C"), "Should be able to indent by 3");
            Assert.That(CommonUtility.IndentLinesInStringByAmount("A\nB\nC", 3, "\t"), Is.EqualTo("\t\t\tA\n\t\t\tB\n\t\t\tC"), "Should be able to indent with other characters");
        }
    }
}
