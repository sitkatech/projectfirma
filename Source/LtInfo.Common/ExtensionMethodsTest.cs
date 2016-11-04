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
            Trace.WriteLine(string.Format("Non-server root relative Regex string: {0}", regExToUse));
            Assert.That(((string) null).DoesHtmlStringContainAbsoluteUrlWithApplicationDomainReference(regEx), Is.False, "Null string - can't be bad");
            Assert.That("".DoesHtmlStringContainAbsoluteUrlWithApplicationDomainReference(regEx), Is.False, "Empty string - can't be bad");
            Assert.That("ABC".DoesHtmlStringContainAbsoluteUrlWithApplicationDomainReference(regEx), Is.False, "Simple string - can't be bad");
            Assert.That("\"../../SomeAction".DoesHtmlStringContainAbsoluteUrlWithApplicationDomainReference(regEx), Is.False, "not server root relative but we don't care for this case");
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