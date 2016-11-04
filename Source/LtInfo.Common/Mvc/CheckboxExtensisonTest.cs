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