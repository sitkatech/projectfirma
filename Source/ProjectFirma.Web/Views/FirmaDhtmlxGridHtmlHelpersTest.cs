/*-----------------------------------------------------------------------
<copyright file="FirmaDhtmlxGridHtmlHelpersTest.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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
using ApprovalTests;
using ApprovalTests.Reporters;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;
using NUnit.Framework;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using System.Collections.Generic;

namespace ProjectFirma.Web.Views
{
    [TestFixture]
    public class FirmaDhtmlxGridHtmlHelpersTest
    {
        private const string GridName = "testGridName";

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void CreateFilteredStateHtmlWithFilterBarTest()
        {
            var result = DhtmlxGridHtmlHelpers.CreateFilteredStateHtml(GridName, true);
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void CreateArbitraryHtmlTest()
        {
            var arbitraryHtml = new List<string> {"<button />", "<select><input /></select>", "Some random text"};
            var result = DhtmlxGridHtmlHelpers.CreateArbitraryHtml(arbitraryHtml, "    ");
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void CreateCreateUrlHtmlTestWithCreateUrl()
        {
            const string createUrl = "createUrl";
            const string createUrlClass = "createUrlClass";
            const string actionPhrase = "Add me";
            const string objectNameSingular = "pen";
            var result = DhtmlxGridHtmlHelpers.CreateCreateUrlHtml(createUrl, createUrlClass, null, actionPhrase, objectNameSingular);
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void CreateCreateUrlHtmlTestWithCreatePopupForm()
        {
            const string actionPhrase = "Create this";
            const string objectNameSingular = "pencil";
            var modalDialogForm = new ModalDialogForm("someUrl", 250, "Create this pencil");
            var result = DhtmlxGridHtmlHelpers.CreateCreateUrlHtml(null, null, modalDialogForm, actionPhrase, objectNameSingular);
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void CreateTagUrlHtmlTest()
        {
            var bulkTagModalDialogForm = new BulkTagModalDialogForm("someUrl", $"Tag Checked {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", $"Tag {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}");
            var result = DhtmlxGridHtmlHelpers.CreateTagUrlHtml("someGridName", bulkTagModalDialogForm);
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void CreateViewingRowCountGridHeaderHtmlTest()
        {
            var result = DhtmlxGridHtmlHelpers.CreateViewingRowCountGridHeaderHtml(GridName, "some things");
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void BuildDhtmlxGridHeaderTest()
        {
            var gridSpec = new TestGridSpec();
            var result = DhtmlxGridHtmlHelpers.BuildDhtmlxGridHeader(gridSpec, GridName, FirmaDhtmlxGridHtmlHelpers.ExcelDownloadUrl);
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void CreateFilterIconHtmlWithFilterBarTest()
        {
            const string gridName = "testGridName";
            var result = DhtmlxGridHtmlHelpers.CreateFilterIconHtml(gridName, true);
            Approvals.Verify(result);
        }

        [Test]
        public void CreateFilterIconHtmlWithoutFilterBarTest()
        {
            const string gridName = "testGridName";
            var result = DhtmlxGridHtmlHelpers.CreateFilterIconHtml(gridName, false);
            Assert.That(result, Is.EqualTo(string.Empty), "Should not get the filter icon");
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void CreateClearAllCookiesIconHtmlTest()
        {
            const string gridName = "testGridName";
            var result = DhtmlxGridHtmlHelpers.CreateClearAllCookiesIconHtml(gridName);
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void CreateFilteredExcelDownloadIconHtmlTest()
        {
            const string gridName = "testGridName";
            var result = DhtmlxGridHtmlHelpers.CreateFilteredExcelDownloadIconHtml(gridName, FirmaDhtmlxGridHtmlHelpers.ExcelDownloadUrl);
            Approvals.Verify(result);
        }

        private class TestGridSpec : GridSpec<object>
        {
            public TestGridSpec()
            {
                SaveFiltersInCookie = true;

                ObjectNameSingular = "SOY";
                ObjectNamePlural = "SOYs";

                GridInstructionsWhenEmpty = "I am empty";
            }
        }
    }
}
