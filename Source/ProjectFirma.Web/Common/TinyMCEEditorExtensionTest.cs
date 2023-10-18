/*-----------------------------------------------------------------------
<copyright file="TinyMCEEditorExtensionTest.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
using LtInfo.Common.Mvc;
using NUnit.Framework;

namespace ProjectFirma.Web.Common
{
    [TestFixture]
    public class TinyMCEEditorExtensionTest
    {
        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void GenerateJavascriptWithMinimalToolbarTest()
        {
            const string modelID = "ProgramPageContent";
            var result = TinyMCEExtension.GenerateJavascript(modelID,
                TinyMCEExtension.TinyMCEToolbarStyle.Minimal,
                 false, null);
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void GenerateJavascriptWithMinimalWithImagesToolbarTest()
        {
            const string modelID = "ProgramPageContent";
            var result = TinyMCEExtension.GenerateJavascript(modelID,
                TinyMCEExtension.TinyMCEToolbarStyle.MinimalWithImages,
                 false, null);
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void GenerateJavascriptWithNoToolbarTest()
        {
            const string modelID = "ProgramPageContent";
            var result = TinyMCEExtension.GenerateJavascript(modelID,
                TinyMCEExtension.TinyMCEToolbarStyle.None,
                 false, null);
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void GenerateJavascriptWithAllToolbarsTest()
        {
            const string modelID = "ProgramPageContent";
            var result = TinyMCEExtension.GenerateJavascript(modelID,
                TinyMCEExtension.TinyMCEToolbarStyle.All,
                 false, null);
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void GenerateJavascriptWithAllOnOneRowToolbarsTest()
        {
            const string modelID = "ProgramPageContent";
            var result = TinyMCEExtension.GenerateJavascript(modelID,
                TinyMCEExtension.TinyMCEToolbarStyle.AllOnOneRow,
                 false, null);
            Approvals.Verify(result);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void GenerateJavascriptWithAllOnOneRowNoMaximizeToolbarsTest()
        {
            const string modelID = "ProgramPageContent";
            var result = TinyMCEExtension.GenerateJavascript(modelID,
                TinyMCEExtension.TinyMCEToolbarStyle.AllOnOneRowNoMaximize,
                 false, null);
            Approvals.Verify(result);
        }

    }
}
