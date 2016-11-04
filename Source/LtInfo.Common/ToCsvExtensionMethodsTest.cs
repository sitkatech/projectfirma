using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LtInfo.Common
{
    [TestFixture]
    public class ToCsvExtensionMethodsTest
    {
        [Test]
        public void CanMakeSimpleCsvRowFromStringEnumerable()
        {
            var list = new[] {"a", "b", "c"};
            const string expectedOutput = "\"a\",\"b\",\"c\"";

            var actualOutput = ToCsvExtensionMethods.EnumerableStringToCsvRow(list);
            Assert.That(actualOutput, Is.EqualTo(expectedOutput), "Should be able to turn a string list into a CSV row.");
        }

        [Test]
        public void CanEscape()
        {
            Assert.That(ToCsvExtensionMethods.CsvEscape(null), Is.EqualTo(String.Empty), "null should be empty");
            Assert.That(ToCsvExtensionMethods.CsvEscape(String.Empty), Is.EqualTo(String.Empty), "Empty should be empty");
            Assert.That(ToCsvExtensionMethods.CsvEscape("Simple"), Is.EqualTo("\"Simple\""));
            Assert.That(ToCsvExtensionMethods.CsvEscape("With,Comma"), Is.EqualTo("\"With,Comma\""));
            Assert.That(ToCsvExtensionMethods.CsvEscape("With\"DoubleQuote"), Is.EqualTo("\"With\"\"DoubleQuote\""));
            Assert.That(ToCsvExtensionMethods.CsvEscape("With\r\nNewLine"), Is.EqualTo("\"With\r\nNewLine\""));
            Assert.That(ToCsvExtensionMethods.CsvEscape("With\nNewLine"), Is.EqualTo("\"With\nNewLine\""));
        }

        [Test]
        public void JoinCsvPrefix()
        {
            Assert.That(new List<TestClass>().JoinCsv("/", TestClass.TestClassToString), Is.EqualTo(""), "Empty list gives empty string");
            Assert.That(new List<TestClass> {new TestClass(1, "One")}.JoinCsv("/", TestClass.TestClassToString), Is.EqualTo("/TestClassID: 1"), "One item - always has prefix");
            Assert.That(new List<TestClass> {new TestClass(1, "One"), new TestClass(2, "Two")}.JoinCsv("/", TestClass.TestClassToString), Is.EqualTo("/TestClassID: 1/TestClassID: 2"),
                        "multiple items, prefix before each one");
        }

        [Test]
        public void JoinCsvSuffix()
        {
            Assert.That(new List<TestClass>().JoinCsv(TestClass.TestClassToString, "|"), Is.EqualTo(""), "Empty list gives empty string");
            Assert.That(new List<TestClass> {new TestClass(1, "One")}.JoinCsv(TestClass.TestClassToString, "|"), Is.EqualTo("TestClassID: 1"), "One item - no suffix");
            Assert.That(new List<TestClass> {new TestClass(1, "One"), new TestClass(2, "Two")}.JoinCsv(TestClass.TestClassToString, "|"), Is.EqualTo("TestClassID: 1|TestClassID: 2"),
                        "multiple items, suffix should be in between only");
        }

        [Test]
        public void CanMakeSimpleCsvFromModelObject()
        {
            var list = CreateTestList();

            var csvData = list.ToCsv();
            const string expectedText = @"""TestClassID"",""TestName""
""5"",""Five""
""99"",""Ninety-nine""";
            Assert.AreEqual(expectedText, csvData);
        }

        [Test]
        public void CanMakeSelectiveCsv()
        {
            var list = CreateTestList();
            var csvData = list.ToCsv(new[] { "TestName" });
            const string expectedText = @"""TestName""
""Five""
""Ninety-nine""";
            Assert.AreEqual(expectedText, csvData);
        }

        [Test]
        public void FieldDoesNotExist()
        {
            var list = CreateTestList();
            Assert.Catch(() => list.ToCsv(new[] {"PropertyNotOnObject"}), "Should get an exception if we ask for a field that is not there.");
        }

        [Test]
        public void EscapeSpecialValues()
        {
            var list = new List<TestClass>
            {
                new TestClass(25, "Five \"and twenty\""), // embeded quotes
                new TestClass(99, ""), // empty string
                new TestClass(102, null), // null
            };
            var csvData = list.ToCsv();
            const string expectedText = @"""TestClassID"",""TestName""
""25"",""Five """"and twenty""""""
""99"",
""102"",";
            Assert.AreEqual(expectedText, csvData);
        }

        private static IEnumerable<TestClass> CreateTestList()
        {
            return new List<TestClass>
            {
                new TestClass(5, "Five"),
                new TestClass(99, "Ninety-nine")
            };
        }

        internal class TestClass
        {
            public int TestClassID { get; private set; }
            public string TestName  { get; private set; }

            public TestClass(int testClassID, string testName)
            {
                TestClassID = testClassID;
                TestName = testName;
            }

            public static string TestClassToString(TestClass x)
            {
                return string.Format("TestClassID: {0}", x.TestClassID);
            }
        }
    }
}