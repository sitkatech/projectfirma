using System.Web;
using NUnit.Framework;

namespace LtInfo.Common
{
    [TestFixture]
    public class StringFormatsTest
    {
        [Test]
        public void ParseNullableDecimalFromCurrencyString()
        {
            Assert.That(StringFormats.ParseNullableDecimalFromCurrencyString("$100"), Is.EqualTo(100m));
            Assert.That(StringFormats.ParseNullableDecimalFromCurrencyString("$200,000"), Is.EqualTo(200000m));
            Assert.That(StringFormats.ParseNullableDecimalFromCurrencyString("$100.10"), Is.EqualTo(100.10m));
            Assert.That(StringFormats.ParseNullableDecimalFromCurrencyString("-$100.10"), Is.EqualTo(-100.10m));
            Assert.That(StringFormats.ParseNullableDecimalFromCurrencyString("($100.10)"), Is.EqualTo(-100.10m));
        }

        [Test]
        public void FormatFileSizeHumanReadableTest()
        {
            Assert.That(StringFormats.ToHumanReadableByteSize(0), Is.EqualTo("0 B"));
            Assert.That(StringFormats.ToHumanReadableByteSize(1024), Is.EqualTo("1 KB"));
            Assert.That(StringFormats.ToHumanReadableByteSize(1024 * 1024), Is.EqualTo("1 MB"));
            Assert.That(StringFormats.ToHumanReadableByteSize(1024 * 1024 + 512 * 1024), Is.EqualTo("1.5 MB"));
            Assert.That(StringFormats.ToHumanReadableByteSize(1024 * 1024 + 231 * 1024), Is.EqualTo("1.23 MB"));
            Assert.That(StringFormats.ToHumanReadableByteSize(1024 * 1024 * 1024), Is.EqualTo("1 GB"));
            Assert.That(StringFormats.ToHumanReadableByteSize(1024L * 1024L* 1024L * 1024L), Is.EqualTo("1 TB"));
            Assert.That(StringFormats.ToHumanReadableByteSize(1024L * 1024L* 1024L * 1024L * 1024L), Is.EqualTo("1 PB"));
            Assert.That(StringFormats.ToHumanReadableByteSize(1024L * 1024L* 1024L * 1024L * 1024L * 1024L), Is.EqualTo("1 EB"));
        }

        [Test]
        public void MakeAbsoluteLinksToApplicationDomainRelativeNullTest()
        {
            var result = StringFormats.MakeAbsoluteLinksToApplicationDomainRelative(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void MakeAbsoluteLinksToApplicationDomainRelativeInnerNullTest()
        {
            var htmlString = new HtmlString(null);
            var result = htmlString.MakeAbsoluteLinksToApplicationDomainRelative();

            Assert.That(result, Is.EqualTo(htmlString));
        }

        [Test]
        public void MakeAbsoluteLinksToApplicationDomainRelativeStringEmptyTest()
        {
            var result = new HtmlString(string.Empty).MakeAbsoluteLinksToApplicationDomainRelative();

            Assert.That(result.ToString(), Is.EqualTo(string.Empty));
        }

        [Test]
        public void MakeAbsoluteLinksToApplicationDomainRelativeActualAppDomainTest()
        {
            const string relativeUrl = "/awesome/awesomepage.cshtml";
            var absoluteUrl = string.Format("http://{0}{1}", SitkaWebConfiguration.ApplicationDomain, relativeUrl);
            var result = new HtmlString(absoluteUrl).MakeAbsoluteLinksToApplicationDomainRelative();

            Assert.That(result.ToString(), Is.EqualTo(relativeUrl));
        }

        [Test]
        public void MakeAbsoluteLinksToApplicationDomainRelativeOutsideDomainTest()
        {
            const string relativeUrl = "/awesome/awesomepage.cshtml";
            var absoluteUrl = string.Format("https://{0}{1}", "example.org", relativeUrl);
            var result = new HtmlString(absoluteUrl).MakeAbsoluteLinksToApplicationDomainRelative();

            Assert.That(result.ToString(), Is.EqualTo(absoluteUrl));
        }

    }
}