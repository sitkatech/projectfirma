/*-----------------------------------------------------------------------
<copyright file="CkEditorExtensionTest.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using NUnit.Framework;

namespace ProjectFirma.Web.Common
{
    [TestFixture]
    public class CkEditorExtensionTest
    {
        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void GenerateJavascriptWithMinimalToolbarTest()
        {
            const string modelID = "ProgramPageContent";
            var result = CkEditorExtension.GenerateJavascript(modelID,
                CkEditorExtension.CkEditorToolbar.Minimal,
                SitkaRoute<FileResourceController>.BuildUrlFromExpression(c => c.CkEditorUploadFileResource((int?)7, null)), false, null);
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void GenerateJavascriptWithMinimalWithImagesToolbarTest()
        {
            const string modelID = "ProgramPageContent";
            var result = CkEditorExtension.GenerateJavascript(modelID,
                CkEditorExtension.CkEditorToolbar.MinimalWithImages,
                SitkaRoute<FileResourceController>.BuildUrlFromExpression(c => c.CkEditorUploadFileResource((int?)7, null)), false, null);
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void GenerateJavascriptWithNoToolbarTest()
        {
            const string modelID = "ProgramPageContent";
            var result = CkEditorExtension.GenerateJavascript(modelID,
                CkEditorExtension.CkEditorToolbar.None,
                SitkaRoute<FileResourceController>.BuildUrlFromExpression(c => c.CkEditorUploadFileResource((int?)7, null)), false, null);
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void GenerateJavascriptWithAllToolbarsTest()
        {
            const string modelID = "ProgramPageContent";
            var result = CkEditorExtension.GenerateJavascript(modelID,
                CkEditorExtension.CkEditorToolbar.All,
                SitkaRoute<FileResourceController>.BuildUrlFromExpression(c => c.CkEditorUploadFileResource((int?)7, null)), false, null);
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void GenerateJavascriptWithAllOnOneRowToolbarsTest()
        {
            const string modelID = "ProgramPageContent";
            var result = CkEditorExtension.GenerateJavascript(modelID,
                CkEditorExtension.CkEditorToolbar.AllOnOneRow,
                SitkaRoute<FileResourceController>.BuildUrlFromExpression(c => c.CkEditorUploadFileResource((int?)7, null)), false, null);
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void GenerateJavascriptWithAllOnOneRowNoMaximizeToolbarsTest()
        {
            const string modelID = "ProgramPageContent";
            var result = CkEditorExtension.GenerateJavascript(modelID,
                CkEditorExtension.CkEditorToolbar.AllOnOneRowNoMaximize,
                SitkaRoute<FileResourceController>.BuildUrlFromExpression(c => c.CkEditorUploadFileResource((int?)7, null)), false, null);
            Approvals.Verify(result);
        }

    }
}
