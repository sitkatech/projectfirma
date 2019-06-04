/*-----------------------------------------------------------------------
<copyright file="CostTest.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.Linq;
using NUnit.Framework;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirmaModels.UnitTestCommon;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public class CostTest : FirmaTestWithContext
    {
        [Test]
        public void TestFutureValueFunction()
        {
            var pv = 1000m;
            var i = 0.04m;
            var t = 10;

            var fv = pv*(1 + i).Pow(t);

            fv.AssertThatIsWithinOnePennyOf(1480.24m, "Future value calculation implemented incorrectly.");
        }

        [Test]
        public void TestCostInYearOfExpenditureFunction()
        {
            var currentYear = 2013;
            var expenditureYear = 2020;

            var currentYearCost = 2000000m;

            var inflationRate = 0.02m;

            var expectedExpenditureYearCostCalculated = FirmaMathUtilities.FutureValueOfPresentSum(currentYearCost, inflationRate, currentYear, expenditureYear);

            var expectedExpenditureYearCostExpected = 2297371.34m;

            expectedExpenditureYearCostCalculated.AssertThatIsWithinOnePennyOf(expectedExpenditureYearCostExpected, "Future value calculation does not match expected value.");
        }

        [Test]
        public void TestProjectExpectedValue()
        {
            var project = TestFramework.TestProject.Create();
            project.EstimatedTotalCost = 2000000m;
            project.ImplementationStartYear = 2013;
            project.CompletionYear = 2020;

            var inflationRate = 0.02m;
            var expectedExpenditureYearCostCalculated = CostParameterSetModelExtensions.CalculateCapitalCostInYearOfExpenditureImpl(project, inflationRate, 2016) ?? 0;

            var expectedExpenditureYearCostFromExpected = 2164864.32m;
            expectedExpenditureYearCostCalculated.AssertThatIsWithinOnePennyOf(expectedExpenditureYearCostFromExpected, "Project Cost in Year of Expenditure calculated incorrectly.");
        }

        [Test]
        public void TestCostInYearOfExpenditureHandlesNull()
        {
            var project = TestFramework.TestProject.Create();

            project.EstimatedTotalCost = 2000000m;
            project.ImplementationStartYear = null;
            project.CompletionYear = null;

            var inflationRate = 0.02m;

            Assert.That(CostParameterSetModelExtensions.CalculateCapitalCostInYearOfExpenditureImpl(project, inflationRate, 2016), Is.Null, "Incorrect implementation of nullable type.");

            project.EstimatedTotalCost = null;
            project.ImplementationStartYear = 2013;
            project.CompletionYear = 2020;

            Assert.That(CostParameterSetModelExtensions.CalculateCapitalCostInYearOfExpenditureImpl(project, inflationRate, 2016), Is.Null, "Incorrect implementation of nullable type.");
        }

        [Test]
        public void TestTotalOperatingCostFromAnnualOperatingCost()
        {
            if (!HttpRequestStorage.DatabaseEntities.AllCostParameterSets.Any())
            {
                // Test not meaningful until at least one of these exists. May need fixing/repair should they be introduced, however.
                return;
            }

            var inflationRate = 0.02m;
            var baseYear = 2016;
            var project = TestFramework.TestProject.Create();
            project.ImplementationStartYear = 2017;
            project.CompletionYear = 2035;
            project.EstimatedAnnualOperatingCost = 100000m;
            project.FundingTypeID = (int) FundingTypeEnum.OperationsAndMaintenance;

            var expectedTotalOperatingCost = 2329737m; //From Karen Fink's calculations
            var totalOperatingCost = CostParameterSetModelExtensions.CalculateTotalRemainingOperatingCostImpl(project.EstimatedAnnualOperatingCost.Value,
                inflationRate,
                baseYear,
                project.ImplementationStartYear.Value,
                project.CompletionYear.Value);
            expectedTotalOperatingCost.AssertThatIsWithinOneDollarOf(totalOperatingCost.Value);


            project.ImplementationStartYear = 2020;
            project.CompletionYear = 2040;
            project.EstimatedAnnualOperatingCost = 100000m;

            expectedTotalOperatingCost = 2790869m; //From Karen Fink's calculations
            totalOperatingCost = CostParameterSetModelExtensions.CalculateTotalRemainingOperatingCostImpl(project.EstimatedAnnualOperatingCost.Value,
                inflationRate,
                baseYear,
                project.ImplementationStartYear.Value,
                project.CompletionYear.Value);
            expectedTotalOperatingCost.AssertThatIsWithinOneDollarOf(totalOperatingCost.Value);
        }
    }
}
