/*-----------------------------------------------------------------------
<copyright file="ProjectUpdateControllerControllerTest.cs" company="Sitka Technology Group">
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
using System.IO;
using NUnit.Framework;

namespace ProjectFirma.Web.Controllers
{
    [TestFixture]
    public class ProjectUpdateControllerControllerTest
    {
        [Test]
        public void PathsToPartialViewsForDiffAreValid()
        {
            Assert.That(File.Exists(WebPathToAbsolutePath(ProjectUpdateController.ProjectUpdateBatchDiffLogPartialViewPath)));
            Assert.That(File.Exists(WebPathToAbsolutePath(ProjectUpdateController.ProjectBasicsPartialViewPath)));
            Assert.That(File.Exists(WebPathToAbsolutePath(ProjectUpdateController.PerformanceMeasureReportedValuesPartialViewPath)));
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
