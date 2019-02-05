/*-----------------------------------------------------------------------
<copyright file="EditProjectGeospatialAreasViewModelTest.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ProjectFirma.Web.Common;
using TestFramework = ProjectFirmaModels.UnitTestCommon.TestFramework;

namespace ProjectFirma.Web.Views.Shared.ProjectGeospatialAreaControls
{
    [TestFixture]
    public class EditProjectGeospatialAreasViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var geospatialArea1 = TestFramework.TestGeospatialArea.Create();
            var geospatialArea2 = TestFramework.TestGeospatialArea.Create();
            var geospatialArea3 = TestFramework.TestGeospatialArea.Create();
            var geospatialArea4 = TestFramework.TestGeospatialArea.Create();

            var project = TestFramework.TestProject.Create();
            TestFramework.TestProjectGeospatialArea.Create(project, geospatialArea1);
            TestFramework.TestProjectGeospatialArea.Create(project, geospatialArea2);
            TestFramework.TestProjectGeospatialArea.Create(project, geospatialArea3);
            TestFramework.TestProjectGeospatialArea.Create(project, geospatialArea4);

            var allGeospatialAreas = new List<ProjectFirmaModels.Models.GeospatialArea> { geospatialArea1, geospatialArea2, geospatialArea3, geospatialArea4 };

            // Act
            var viewModel = new EditProjectGeospatialAreasViewModel(project.ProjectGeospatialAreas.Select(x => x.GeospatialAreaID).ToList(), null);

            // Assert
            Assert.That(viewModel.GeospatialAreaIDs, Is.EquivalentTo(allGeospatialAreas.Select(x => x.GeospatialAreaID)));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var geospatialArea1 = TestFramework.TestGeospatialArea.Create();
            var geospatialArea2 = TestFramework.TestGeospatialArea.Create();
            var geospatialArea3 = TestFramework.TestGeospatialArea.Create();
            var geospatialArea4 = TestFramework.TestGeospatialArea.Create();

            var project = TestFramework.TestProject.Create();
            var projectGeospatialArea1 = TestFramework.TestProjectGeospatialArea.Create(project, geospatialArea1);
            var projectGeospatialArea2 = TestFramework.TestProjectGeospatialArea.Create(project, geospatialArea2);

            Assert.That(project.ProjectGeospatialAreas.Select(x => x.GeospatialAreaID), Is.EquivalentTo(new List<int> { projectGeospatialArea1.GeospatialAreaID, projectGeospatialArea2.GeospatialAreaID }));

            var geospatialAreasSelected = new List<ProjectFirmaModels.Models.GeospatialArea> { geospatialArea1, geospatialArea3, geospatialArea4 };

            var viewModel = new EditProjectGeospatialAreasViewModel{ GeospatialAreaIDs = geospatialAreasSelected.Select(x => x.GeospatialAreaID).ToList() };

            // Act
            var currentProjectGeospatialAreas = project.ProjectGeospatialAreas.ToList();
            viewModel.UpdateModel(project, currentProjectGeospatialAreas, HttpRequestStorage.DatabaseEntities.AllProjectGeospatialAreas.Local);

            // Assert
            Assert.That(currentProjectGeospatialAreas.Select(x => x.GeospatialAreaID), Is.EquivalentTo(geospatialAreasSelected.Select(x => x.GeospatialAreaID)));
        }
    }
}
