using NUnit.Framework;

namespace LtInfo.Common
{
    [TestFixture]
    public class ProcessUtilityTest
    {
        [Test]
        public void Test()
        {
            Assert.That(ProcessUtility.EncodeArgumentForCommandLine("A"), Is.EqualTo("A"), "Easy stuff should just go straight across");
            Assert.That(ProcessUtility.EncodeArgumentForCommandLine("With Space"), Is.EqualTo("\"With Space\""), "Space should get double quoted");
            Assert.That(ProcessUtility.EncodeArgumentForCommandLine("With\tTab"), Is.EqualTo("\"With\tTab\""), "Tab should get double quoted");
            Assert.That(ProcessUtility.EncodeArgumentForCommandLine("With\nLF"), Is.EqualTo("\"With\nLF\""), "LF should get double quoted");
            Assert.That(ProcessUtility.EncodeArgumentForCommandLine("With\rCR"), Is.EqualTo("\"With\rCR\""), "CR should get double quoted");

            Assert.That(ProcessUtility.EncodeArgumentForCommandLine(@"BackslashAtEndNoSpacesNoBigDeal\"), Is.EqualTo(@"BackslashAtEndNoSpacesNoBigDeal\"), "Backslash and quotes get tricky");
            Assert.That(ProcessUtility.EncodeArgumentForCommandLine(@"Backslash at end with spaces get funky\"), Is.EqualTo(@"""Backslash at end with spaces get funky\\"""), "Backslash and quotes get tricky");
            Assert.That(ProcessUtility.EncodeArgumentForCommandLine(@"a\""b"), Is.EqualTo("a\\\"b"), "Backslash and quotes get tricky - backslashes before quotes have to be doubled up, plus one blackslash to mark the quote as literal");
            Assert.That(ProcessUtility.EncodeArgumentForCommandLine(@"a\\b c"), Is.EqualTo(@"""a\\b c"""), "Backslash and quotes get tricky");
            Assert.That(ProcessUtility.EncodeArgumentForCommandLine(@"C:\My Path\"), Is.EqualTo(@"""C:\My Path\\"""), "Backslash and quotes get tricky");
            Assert.That(ProcessUtility.EncodeArgumentForCommandLine(@"This is \""My Inner Quote\"" with backslashes"), Is.EqualTo(@"""This is \\\""My Inner Quote\\\"" with backslashes"""), "Backslash and quotes get tricky");
        }
    }
}