/*-----------------------------------------------------------------------
<copyright file="BasicsViewModelTest.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using LtInfo.Common;
using NUnit.Framework;
using TestFramework = ProjectFirmaModels.UnitTestCommon.TestFramework;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    [TestFixture]
    public class BasicsViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var projectUpdate = TestFramework.TestProjectUpdate.Create();

            // Act
            var viewModel = new BasicsViewModel(projectUpdate, null);

            // Assert
            Assert.That(viewModel.ProjectDescription, Is.EqualTo(projectUpdate.ProjectDescription));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var projectUpdate = TestFramework.TestProjectUpdate.Create();
            var viewModel = new BasicsViewModel(projectUpdate, null);
            viewModel.ProjectDescription = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.ProjectDescription), ProjectFirmaModels.Models.ProjectUpdate.FieldLengths.ProjectDescription);

            // Act
            viewModel.UpdateModel(projectUpdate, TestFramework.TestFirmaSession.Create());

            // Assert
            Assert.That(projectUpdate.ProjectDescription, Is.EqualTo(viewModel.ProjectDescription));
        }
    }
}
