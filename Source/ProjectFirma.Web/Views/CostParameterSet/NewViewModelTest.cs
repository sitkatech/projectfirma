/*-----------------------------------------------------------------------
<copyright file="NewViewModelTest.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.CostParameterSet
{
    [TestFixture]
    public class NewViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var BudgetInflation = TestFramework.TestCostParameterSet.Create();

            // Act
            var viewModel = new NewViewModel(BudgetInflation);

            // Assert
            Assert.That(viewModel.InflationRate.ToString(), Is.EqualTo(BudgetInflation.InflationRate.ToStringPercent()));            
            Assert.That(viewModel.Comment, Is.EqualTo(BudgetInflation.Comment));
        }

        [Test]
        public void UpdateModelTest()
        {
            // Arrange
            var BudgetInflation = TestFramework.TestCostParameterSet.Create();
            var viewModel = new NewViewModel(BudgetInflation);
            viewModel.Comment = TestFramework.MakeTestName(GeneralUtility.NameOf(() => viewModel.Comment), Models.CostParameterSet.FieldLengths.Comment);

            // Act
            viewModel.UpdateModel(BudgetInflation, TestFramework.TestPerson.Create());

            // Assert
            Assert.That(BudgetInflation.Comment, Is.EqualTo(viewModel.Comment));
        }

        //[Test]
        //public void CanValidateModelTest()
        //{
        //    // Arrange
        //    var CostParameterSet = TestFramework.TestCostParameterSet.Create();
        //    var viewModel = new EditViewModel(CostParameterSet);
        //    var nameOfBudgetInflationComment = GeneralUtility.NameOf(() => viewModel.Comment);

        //    ICollection<ValidationResult> validationResults;

        //    // Act
        //    DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

        //    // Assert
        //    Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
        //    TestFramework.AssertFieldRequired(validationResults, nameOfBudgetInflationComment);

        //    // Act
        //    // Set string fields to string longer than their max lengths
        //    viewModel.Comment = TestFramework.MakeTestNameLongerThan(nameOfBudgetInflationComment, Models.CostParameterSet.FieldLengths.Comment);
        //    DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

        //    // Assert
        //    Assert.That(validationResults.Count, Is.EqualTo(1), "Expecting certain number of errors");
        //    TestFramework.AssertFieldStringLength(validationResults, nameOfBudgetInflationComment, Models.CostParameterSet.FieldLengths.Comment);

        //    // Act
        //    // Happy path
        //    viewModel.Comment = TestFramework.MakeTestName(nameOfBudgetInflationComment, Models.CostParameterSet.FieldLengths.Comment);
        //    var isValid = DataAnnotationsValidator.TryValidate(viewModel, out validationResults);

        //    viewModel.StartYear = 2011;
        //    viewModel.InflationRate = 0.8m;
        //    // Assert
        //    Assert.That(isValid, Is.True, "Should pass validation");
        //}
    }
}
