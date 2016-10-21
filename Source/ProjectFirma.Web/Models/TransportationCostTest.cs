using ProjectFirma.Web.Common;
using ProjectFirma.Web.UnitTestCommon;
using NUnit.Framework;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public class TransportationCostTest : ProjectFirmaTestWithContext
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

            var expectedExpenditureYearCostCalculated = ProjectFirmaMathUtilities.FutureValueOfPresentSum(currentYearCost, inflationRate, currentYear, expenditureYear);

            var expectedExpenditureYearCostFromTRPA = 2297371.34m;

            expectedExpenditureYearCostCalculated.AssertThatIsWithinOnePennyOf(expectedExpenditureYearCostFromTRPA, "Future value calculation does not match value derived from TRPA spreadsheet.");
        }

        [Test]
        public void TestProjectExpectedValue()
        {
            var project = TestFramework.TestProject.Create();
            var transporationObjective = TestFramework.TestTransportationObjective.Create();

            project.TransportationObjective = transporationObjective;

            project.EstimatedTotalCost = 2000000m;
            project.ImplementationStartYear = 2013;
            project.CompletionYear = 2020;

            var inflationRate = 0.02m;
            var expectedExpenditureYearCostCalculated = TransportationCostParameterSet.CalculateCapitalCostInYearOfExpenditureImpl(project, inflationRate) ?? 0;

            var expectedExpenditureYearCostFromTRPA = 2164864.32m;
            expectedExpenditureYearCostCalculated.AssertThatIsWithinOnePennyOf(expectedExpenditureYearCostFromTRPA, "Project Cost in Year of Expenditure calculated incorrectly.");
        }

        [Test]
        public void TestCostInYearOfExpenditureHandlesNull()
        {
            var project = TestFramework.TestProject.Create();

            project.EstimatedTotalCost = 2000000m;
            project.ImplementationStartYear = null;
            project.CompletionYear = 2020;

            var inflationRate = 0.02m;

            Assert.That(TransportationCostParameterSet.CalculateCapitalCostInYearOfExpenditureImpl(project, inflationRate), Is.Null, "Incorrect implementation of nullable type.");

            project.EstimatedTotalCost = null;
            project.ImplementationStartYear = 2013;
            project.CompletionYear = 2020;

            Assert.That(TransportationCostParameterSet.CalculateCapitalCostInYearOfExpenditureImpl(project, inflationRate), Is.Null, "Incorrect implementation of nullable type.");
        }

        [Test]
        public void TestTotalOperatingCostFromAnnualOperatingCost()
        {
            var inflationRate = 0.02m;
            var baseYear = 2016;

            var project = TestFramework.TestProject.Create();
            project.ImplementationStartYear = 2017;
            project.CompletionYear = 2035;
            project.EstimatedAnnualOperatingCost = 100000m;
            project.FundingTypeID = FundingType.OperationsAndMaintenance.FundingTypeID;
            project.TransportationObjective = TransportationObjective.CreateNewBlank(TransportationStrategy.CreateNewBlank(), FundingType.OperationsAndMaintenance);

            var expectedTotalOperatingCost = 2329737m; //From Karen Fink's calculations
            var totalOperatingCost = TransportationCostParameterSet.CalculateTotalRemainingOperatingCostImpl(project.EstimatedAnnualOperatingCost.Value,
                inflationRate,
                baseYear,
                project.ImplementationStartYear.Value,
                project.CompletionYear.Value);
            expectedTotalOperatingCost.AssertThatIsWithinOneDollarOf(totalOperatingCost.Value);


            project.ImplementationStartYear = 2020;
            project.CompletionYear = 2040;
            project.EstimatedAnnualOperatingCost = 100000m;

            expectedTotalOperatingCost = 2790869m; //From Karen Fink's calculations
            totalOperatingCost = TransportationCostParameterSet.CalculateTotalRemainingOperatingCostImpl(project.EstimatedAnnualOperatingCost.Value,
                inflationRate,
                baseYear,
                project.ImplementationStartYear.Value,
                project.CompletionYear.Value);
            expectedTotalOperatingCost.AssertThatIsWithinOneDollarOf(totalOperatingCost.Value);
        }
    }
}