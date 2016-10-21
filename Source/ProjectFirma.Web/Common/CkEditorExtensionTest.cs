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