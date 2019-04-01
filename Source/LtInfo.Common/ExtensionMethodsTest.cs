/*-----------------------------------------------------------------------
<copyright file="ExtensionMethodsTest.cs" company="Sitka Technology Group">
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
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace LtInfo.Common
{
    [TestFixture]
    public class ExtensionMethodsTest
    {
        [Test]
        public void IsRegexToFindAbsoluteUrlsWorking()
        {
            var regExToUse = StringFormats.ConstructContainAbsoluteUrlWithApplicationDomainReferenceRegExForApplicationDomain("someapp.somedomain.org");
            var regEx = new Regex(regExToUse, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Trace.WriteLine($"Non-server root relative Regex string: {regExToUse}");
            Assert.That(((string) null).DoesHtmlStringContainAbsoluteUrlWithApplicationDomainReference(regEx), Is.False, "Null string - can't be bad");
            Assert.That("".DoesHtmlStringContainAbsoluteUrlWithApplicationDomainReference(regEx), Is.False, "Empty string - can't be bad");
            Assert.That("ABC".DoesHtmlStringContainAbsoluteUrlWithApplicationDomainReference(regEx), Is.False, "Simple string - can't be bad");
            Assert.That("\"../../SomeAction".DoesHtmlStringContainAbsoluteUrlWithApplicationDomainReference(regEx), Is.False, "not server root relative but we don't care for this case");
            Assert.That("http://sitka.somedomain.org/".DoesHtmlStringContainAbsoluteUrlWithApplicationDomainReference(regEx), Is.False, "should be tolerated -- we allow sitka. domains to be absolute.");
            Assert.That("http://qa.someapp.somedomain.org/".DoesHtmlStringContainAbsoluteUrlWithApplicationDomainReference(regEx), Is.True, "should be bad - not server root relative");
            Assert.That("http://someapp.somedomain.org/".DoesHtmlStringContainAbsoluteUrlWithApplicationDomainReference(regEx), Is.True, "should be bad - not server root relative");
            Assert.That("https://someapp.somedomain.org/".DoesHtmlStringContainAbsoluteUrlWithApplicationDomainReference(regEx), Is.True, "should be bad - not server root relative");
            Assert.That("https://qa.someapp.somedomain.org/".DoesHtmlStringContainAbsoluteUrlWithApplicationDomainReference(regEx), Is.True, "should be bad - not server root relative");
            Assert.That("http://someapp.somedomain.org/Project/Index".DoesHtmlStringContainAbsoluteUrlWithApplicationDomainReference(regEx), Is.True, "should be bad - not server root relative");
            Assert.That("http://qa.someapp.somedomain.org/Project/Index".DoesHtmlStringContainAbsoluteUrlWithApplicationDomainReference(regEx), Is.True, "should be bad - not server root relative");
            Assert.That("https://someapp.somedomain.org/Project/Index".DoesHtmlStringContainAbsoluteUrlWithApplicationDomainReference(regEx), Is.True, "should be bad - not server root relative");
            Assert.That("https://qa.someapp.somedomain.org/Project/Index".DoesHtmlStringContainAbsoluteUrlWithApplicationDomainReference(regEx), Is.True, "should be bad - not server root relative");
            Assert.That("/Project/Index".DoesHtmlStringContainAbsoluteUrlWithApplicationDomainReference(regEx), Is.False, "Should be fine -- is server root relative");
        }

        [Test]
        public void CanSumNull()
        {
            Assert.That(new List<decimal?>().SumNullWhenEmptyOrAllNull(x => x), Is.EqualTo(null), "Empty returns null not zero as with Sum()");
            Assert.That(new List<decimal?>{null}.SumNullWhenEmptyOrAllNull(x => x), Is.EqualTo(null), "Empty returns null not zero as with Sum()");
            Assert.That(new List<decimal?>{null, null}.SumNullWhenEmptyOrAllNull(x => x), Is.EqualTo(null), "Empty returns null not zero as with Sum()");
            Assert.That(new List<decimal?> { 234 }.SumNullWhenEmptyOrAllNull(x => x), Is.EqualTo(234), "Element returns with expected sum()");
            Assert.That(new List<decimal?> { 234, 5 }.SumNullWhenEmptyOrAllNull(x => x), Is.EqualTo(239), "Element returns with expected sum()");
            Assert.That(new List<decimal?> { null, 234, 5 }.SumNullWhenEmptyOrAllNull(x => x), Is.EqualTo(239), "Empty returns null not zero as with Sum()");
        }
    }
}
