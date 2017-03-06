/*-----------------------------------------------------------------------
<copyright file="AssertCustom.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System;
using ProjectFirma.Web.Models;
using NUnit.Framework;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static class AssertCustom
    {
        public static void AssertThatIsWithinOnePennyOf(this decimal actualValue, decimal expectedValue, string message = "Actual value not within one penny of expected value.")
        {
            Assert.That(Math.Abs(actualValue - expectedValue), Is.LessThan(0.015m), message);
        }

        public static void AssertThatIsWithinOneDollarOf(this decimal actualValue, decimal expectedValue, string message = "Actual value not within one dollar of expected value.")
        {
            Assert.That(Math.Abs(actualValue - expectedValue), Is.LessThan(1.5m), message);
        }
    }
}
