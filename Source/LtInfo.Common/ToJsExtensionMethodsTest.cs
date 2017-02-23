/*-----------------------------------------------------------------------
<copyright file="ToJsExtensionMethodsTest.cs" company="Sitka Technology Group">
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
    public class ToJsExtensionMethodsTest
    {
        [Test]
        public void ShouldEncodeStringsProperly()
        {
            Assert.That("Text".ToJS(), Is.EqualTo("'Text'"), "Should add leading and trailing single quotes");
            Assert.That("Text with ' apostrophe".ToJS(), Is.EqualTo(@"'Text with \u0027 apostrophe'"), "Should properly encode an apostrophe");
            Assert.That("Text with \" double quote".ToJS(), Is.EqualTo(@"'Text with \"" double quote'"), "Should properly encode a double quote");
        }
    }
}
