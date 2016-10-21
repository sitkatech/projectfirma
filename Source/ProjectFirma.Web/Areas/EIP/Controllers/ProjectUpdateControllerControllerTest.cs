using System;
using System.IO;
using NUnit.Framework;

namespace ProjectFirma.Web.Areas.EIP.Controllers
{
    [TestFixture]
    public class ProjectUpdateControllerControllerTest
    {
        [Test]
        public void PathsToPartialViewsForDiffAreValid()
        {
            Assert.That(File.Exists(WebPathToAbsolutePath(ProjectUpdateController.ProjectUpdateBatchDiffLogPartialViewPath)));
            Assert.That(File.Exists(WebPathToAbsolutePath(ProjectUpdateController.ProjectBasicsPartialViewPath)));
            Assert.That(File.Exists(WebPathToAbsolutePath(ProjectUpdateController.EIPPerformanceMeasureReportedValuesPartialViewPath)));
            Assert.That(File.Exists(WebPathToAbsolutePath(ProjectUpdateController.ProjectExpendituresPartialViewPath)));
            Assert.That(File.Exists(WebPathToAbsolutePath(ProjectUpdateController.TransporationBudgetsPartialViewPath)));
            Assert.That(File.Exists(WebPathToAbsolutePath(ProjectUpdateController.ImageGalleryPartialViewPath)));
            Assert.That(File.Exists(WebPathToAbsolutePath(ProjectUpdateController.ExternalLinksPartialViewPath)));
            Assert.That(File.Exists(WebPathToAbsolutePath(ProjectUpdateController.EntityNotesPartialViewPath)));
        }

        //TODO: Surely there is a better way to convert the tilde path to a absolute project path
        private static string WebPathToAbsolutePath(string webPath)
        {
            return webPath.Replace("~", AppDomain.CurrentDomain.BaseDirectory).Replace("/", "\\").Replace("\\bin", "");
        }
    }
}