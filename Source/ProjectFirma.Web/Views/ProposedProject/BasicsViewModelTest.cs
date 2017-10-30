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
using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.ProposedProject
{
    [TestFixture]
    public class BasicsViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var proposedProject = TestFramework.TestProposedProject.Create();

            // Act
            var viewModel = new BasicsViewModel(proposedProject);

            // Assert
            Assert.That(viewModel.ProposedProjectID, Is.EqualTo(proposedProject.ProposedProjectID));
            Assert.That(viewModel.ProjectName, Is.EqualTo(proposedProject.ProjectName));
            Assert.That(viewModel.ProjectDescription, Is.EqualTo(proposedProject.ProjectDescription));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var proposedProject = TestFramework.TestProposedProject.Create();
            var viewModel = new BasicsViewModel(proposedProject);
            viewModel.ProjectName = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.ProjectName), Models.ProposedProject.FieldLengths.ProjectName);
            viewModel.ProjectDescription = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.ProjectDescription), Models.ProposedProject.FieldLengths.ProjectDescription);

            // Act
            viewModel.UpdateModel(proposedProject, TestFramework.TestPerson.Create());

            // Assert
            Assert.That(proposedProject.ProjectName, Is.EqualTo(viewModel.ProjectName));
            Assert.That(proposedProject.ProjectDescription, Is.EqualTo(viewModel.ProjectDescription));
        }
    }
}
