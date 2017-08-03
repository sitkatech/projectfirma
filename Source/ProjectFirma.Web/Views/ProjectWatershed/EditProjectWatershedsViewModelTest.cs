/*-----------------------------------------------------------------------
<copyright file="EditProjectWatershedsViewModelTest.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common.Models;
using NUnit.Framework;

//namespace ProjectFirma.Web.Views.ProjectWatershed
//{
//    [TestFixture]
//    public class EditProjectWatershedsViewModelTest
//    {
//        [Test]
//        public void AllViewModelFieldsAreSetFromConstructorTest()
//        {
//            // Arrange
//            var watershed1 = TestFramework.TestWatershed.Create();
//            var watershed2 = TestFramework.TestWatershed.Create();
//            var watershed3 = TestFramework.TestWatershed.Create();
//            var watershed4 = TestFramework.TestWatershed.Create();

//            var project = TestFramework.TestProject.Create();
//            TestFramework.TestProjectWatershed.Create(project, watershed1);
//            TestFramework.TestProjectWatershed.Create(project, watershed2);
//            TestFramework.TestProjectWatershed.Create(project, watershed3);
//            TestFramework.TestProjectWatershed.Create(project, watershed4);

//            var allWatersheds = new List<Models.Watershed> {watershed1, watershed2, watershed3, watershed4};

//            // Act
//            var viewModel = new EditProjectWatershedsViewModel(project.ProjectWatersheds.Select(x => new ProjectWatershedSimple(x)).ToList());

//            // Assert
//            Assert.That(viewModel.ProjectWatersheds.Select(x => x.WatershedID), Is.EquivalentTo(allWatersheds.Select(x => x.WatershedID)));
//        }

//        [Test]
//        public void UpdateModelTest()
//        {
//            // Arrange
//            var watershed1 = TestFramework.TestWatershed.Create();
//            var watershed2 = TestFramework.TestWatershed.Create();
//            var watershed3 = TestFramework.TestWatershed.Create();
//            var watershed4 = TestFramework.TestWatershed.Create();

//            var project = TestFramework.TestProject.Create();
//            var projectWatershed1 = TestFramework.TestProjectWatershed.Create(project, watershed1);
//            var projectWatershed2 = TestFramework.TestProjectWatershed.Create(project, watershed2);

//            Assert.That(project.ProjectWatersheds.Select(x => x.WatershedID), Is.EquivalentTo(new List<int> {projectWatershed1.WatershedID, projectWatershed2.WatershedID}));

//            var watershedsSelected = new List<Models.Watershed> {watershed1, watershed3, watershed4};
//            var allProjectWatersheds = new List<Models.ProjectWatershed> {projectWatershed1, projectWatershed2};

//            var viewModel = new EditProjectWatershedsViewModel();
//            viewModel.ProjectWatersheds = watershedsSelected.Select(x => new ProjectWatershedSimple(ModelObjectHelpers.NotYetAssignedID, project.ProjectID, x.WatershedID)).ToList();

//            // Act
//            viewModel.UpdateModel(project.ProjectWatersheds.ToList(), allProjectWatersheds);

//            // Assert
//            Assert.That(allProjectWatersheds.Select(x => x.WatershedID), Is.EquivalentTo(watershedsSelected.Select(x => x.WatershedID)));
//        }
//    }
//}
