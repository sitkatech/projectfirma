/*-----------------------------------------------------------------------
<copyright file="GeneralUtilityTest.cs" company="Sitka Technology Group">
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
using System;
using NUnit.Framework;

namespace LtInfo.Common
{
    [TestFixture]
    public class GeneralUtilityTest
    {

        [Test]
        public void ReverseTest()
        {
            Assert.That(GeneralUtility.Reverse(1234), Is.EqualTo(4321));
            Assert.That(GeneralUtility.Reverse(1), Is.EqualTo(1));
            Assert.That(GeneralUtility.Reverse(0), Is.EqualTo(0));
            Assert.That(GeneralUtility.Reverse(100), Is.EqualTo(1));
            Assert.That(GeneralUtility.Reverse(101), Is.EqualTo(101));
            Assert.That(GeneralUtility.Reverse(102), Is.EqualTo(201));
            Assert.That(GeneralUtility.Reverse(201), Is.EqualTo(102));
            Assert.That(GeneralUtility.Reverse(302), Is.EqualTo(203));
        }

        [Test]
        public void UrlToAbsolutePath()
        {
            Assert.That(GeneralUtility.UrlToAbsolutePath("http://www.example.com/Path1/File.html"), Is.EqualTo("/Path1/File.html"), "Should be able to do full path");
            Assert.That(GeneralUtility.UrlToAbsolutePath("/Path1/File.html"), Is.EqualTo("/Path1/File.html"), "Should be able to do relative path");
            Assert.That(GeneralUtility.UrlToAbsolutePath("Path1/File.html"), Is.EqualTo("/Path1/File.html"), "Should be able to do relative path");
            Assert.That(GeneralUtility.UrlToAbsolutePath("File.html"), Is.EqualTo("/File.html"), "Should be able to do relative path");
        }

        [Test]
        public void CanCalculateTheMidpointForAList()
        {
            Assert.That(GeneralUtility.CalculateIndexOfEndOfFirstHalf(0), Is.EqualTo(0), "If there's nothing in the list after the first item works");
            Assert.That(GeneralUtility.CalculateIndexOfEndOfFirstHalf(1), Is.EqualTo(0), "One item, after the first item is the midpoint");
            Assert.That(GeneralUtility.CalculateIndexOfEndOfFirstHalf(2), Is.EqualTo(0), "Two items, after the first item is still the midpoint");
            Assert.That(GeneralUtility.CalculateIndexOfEndOfFirstHalf(3), Is.EqualTo(1), "Three items, after the second item is the midpoint");
            Assert.That(GeneralUtility.CalculateIndexOfEndOfFirstHalf(4), Is.EqualTo(1), "Four items, after the second item is the midpoint");
            Assert.That(GeneralUtility.CalculateIndexOfEndOfFirstHalf(5), Is.EqualTo(2), "Pattern should continue");
            Assert.That(GeneralUtility.CalculateIndexOfEndOfFirstHalf(6), Is.EqualTo(2), "Pattern should continue");
            Assert.That(GeneralUtility.CalculateIndexOfEndOfFirstHalf(10), Is.EqualTo(4), "Pattern should continue");
            Assert.That(GeneralUtility.CalculateIndexOfEndOfFirstHalf(100), Is.EqualTo(49), "Pattern should continue");
        }

        [Test]
        public void RegexEscape()
        {
            GeneralUtility.RegexEscape(string.Empty);
            Assert.That(GeneralUtility.RegexEscape("abc"), Is.EqualTo("abc"));
            Assert.That(GeneralUtility.RegexEscape("abc]def"), Is.EqualTo(@"abc\]def"), "Should include extra character ]");
            Assert.That(GeneralUtility.RegexEscape("abc}def"), Is.EqualTo(@"abc\}def"), "Should include extra character }");
        }

        [Test]
        public void ReflectionExpressionHelper()
        {
            {
                const string message = "Void Function";
                var answer = GeneralUtility.ParseExpressionParts<TestReflectionClass>(tc => tc.TestMethod());
                Assert.That(answer.DeclaringTypeName, Is.EqualTo("TestReflectionClass"), message);
                Assert.That(answer.MethodOrMemberName, Is.EqualTo("TestMethod"), message);
            }
            {
                const string message = "Void Function with parameters";
                var answer = GeneralUtility.ParseExpressionParts<TestReflectionClass>(tc => tc.TestMethod1(0));
                Assert.That(answer.DeclaringTypeName, Is.EqualTo("TestReflectionClass"), message);
                Assert.That(answer.MethodOrMemberName, Is.EqualTo("TestMethod1"), message);
            }
            {
                const string message = "Function with parameters";
                var answer = GeneralUtility.ParseExpressionParts<TestReflectionClass>(tc => tc.TestFunction());
                Assert.That(answer.DeclaringTypeName, Is.EqualTo("TestReflectionClass"), message);
                Assert.That(answer.MethodOrMemberName, Is.EqualTo("TestFunction"), message);
            }
            {
                const string message = "Function with parameters";
                var answer = GeneralUtility.ParseExpressionParts<TestReflectionClass>(tc => tc.TestFunction1(0));
                Assert.That(answer.DeclaringTypeName, Is.EqualTo("TestReflectionClass"), message);
                Assert.That(answer.MethodOrMemberName, Is.EqualTo("TestFunction1"), message);
            }
            {
                const string message = "Function with parameters";
                var answer = GeneralUtility.ParseExpressionParts<TestReflectionClass>(tc => tc.TestFunction2(0, 1));
                Assert.That(answer.DeclaringTypeName, Is.EqualTo("TestReflectionClass"), message);
                Assert.That(answer.MethodOrMemberName, Is.EqualTo("TestFunction2"), message);
            }
            {
                const string message = "Property with int return";
                var answer1 = GeneralUtility.ParseExpressionParts<TestReflectionClass, int>(tc => tc.TestPropertyInt);
                Assert.That(answer1.DeclaringTypeName, Is.EqualTo("TestReflectionClass"), message);
                Assert.That(answer1.MethodOrMemberName, Is.EqualTo("TestPropertyInt"), message);
            }
            {
                const string message = "Property with string return";
                var answer2 = GeneralUtility.ParseExpressionParts<TestReflectionClass, string>(tc => tc.TestPropertyString);
                Assert.That(answer2.DeclaringTypeName, Is.EqualTo("TestReflectionClass"), message);
                Assert.That(answer2.MethodOrMemberName, Is.EqualTo("TestPropertyString"), message);
            }
            {
                const string message = "Property with DateTime return";
                var answer3 = GeneralUtility.ParseExpressionParts<TestReflectionClass, DateTime>(tc => tc.TestPropertyDateTime);
                Assert.That(answer3.DeclaringTypeName, Is.EqualTo("TestReflectionClass"), message);
                Assert.That(answer3.MethodOrMemberName, Is.EqualTo("TestPropertyDateTime"), message);
            }
            {
                const string message = "Field with int return";
                var answer1 = GeneralUtility.ParseExpressionParts<TestReflectionClass, int>(tc => tc.TestFieldInt);
                Assert.That(answer1.DeclaringTypeName, Is.EqualTo("TestReflectionClass"), message);
                Assert.That(answer1.MethodOrMemberName, Is.EqualTo("TestFieldInt"), message);
            }
            {
                const string message = "Field with int[] return";
                var answer1 = GeneralUtility.ParseExpressionParts<TestReflectionClass, int[]>(tc => tc.TestFieldIntArray);
                Assert.That(answer1.DeclaringTypeName, Is.EqualTo("TestReflectionClass"), message);
                Assert.That(answer1.MethodOrMemberName, Is.EqualTo("TestFieldIntArray"), message);
            }
        }

        public class TestReflectionClass
        {
            public int TestFunction()
            {
                return 0;
            }
            public int TestFunction1(int x)
            {
                return 0;
            }
            public int TestFunction2(int x, int y)
            {
                return 0;
            }
            public void TestMethod() { }
            public void TestMethod1(int param1){}
            
            public int TestFieldInt;
            public int[] TestFieldIntArray;

            public int TestPropertyInt { get { return 0; } }
            public string TestPropertyString { get { return string.Empty; } }
            public DateTime TestPropertyDateTime { get { return DateTime.MinValue; } }
        }
    }
}
