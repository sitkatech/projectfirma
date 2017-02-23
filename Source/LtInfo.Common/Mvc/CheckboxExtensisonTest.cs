/*-----------------------------------------------------------------------
<copyright file="CheckboxExtensisonTest.cs" company="Sitka Technology Group">
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
using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;
using List = DocumentFormat.OpenXml.Office2010.ExcelAc.List;

namespace System.Web.Mvc.Html
{
    [TestFixture]
    public class CheckboxExtensisonTest
    {

        private readonly List<SelectListItem> _testSelectList = new List<SelectListItem>()
        {
            new SelectListItem() {Value = "1_testValue", Text = "someText_1"},
            new SelectListItem() {Value = "2_testValue", Text = "someText_2"},
            new SelectListItem() {Value = "3_testValue", Text = "someText_3"},
            new SelectListItem() {Value = "4_testValue", Text = "someText_4"}
        };

        private readonly List<SelectListItem> _testSelectList2 = new List<SelectListItem>()
        {
            new SelectListItem() {Value = "5_testValue", Text = "someText_5"},
            new SelectListItem() {Value = "6_testValue", Text = "someText_6"},
            new SelectListItem() {Value = "7_testValue", Text = "someText_7"},
            new SelectListItem() {Value = "8_testValue", Text = "someText_8"},
            new SelectListItem() {Value = "9_testValue", Text = "someText_9"}
        };
        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void ListItemToCheckboxTest()
        {
            var result = CheckboxExtensions.ListItemToCheckbox(new SelectListItem() {Value = "someValue", Text = "someText"}, new Dictionary<string, object>(), "someName");
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void BuildItemsTest()
        {
            var result = CheckboxExtensions.BuildItems("testOptionLabel", _testSelectList, new Dictionary<string, object>(), "testFullName");
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void BuildItemsTwoColumnsTest()
        {
            var result = CheckboxExtensions.BuildItems("testOptionLabel", _testSelectList, new Dictionary<string, object>(), "testFullName",CheckboxExtensions.ColNumber.twoCols);
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void BuildItemsTwoColumnsTest_2()
        {
            var result = CheckboxExtensions.BuildItems("testOptionLabel", _testSelectList2, new Dictionary<string, object>(), "testFullName", CheckboxExtensions.ColNumber.twoCols);
            Approvals.Verify(result);
        }
    }
}
