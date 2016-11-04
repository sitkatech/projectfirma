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