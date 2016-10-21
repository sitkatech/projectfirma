using System;
using System.Linq;
using ProjectFirma.Web.Areas.ParcelTracker.Views.DevelopmentRightPool;
using ProjectFirma.Web.Areas.ParcelTracker.Views.TdrTransaction;
using ProjectFirma.Web.UnitTestCommon;
using MoreLinq;
using NUnit.Framework;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public class ResidentialAllocationTest
    {
        [Test]
        public void TestRANFormatting()
        {
            var person = TestFramework.TestPerson.Create();
            var cp = TestCommodityPool.Create(Commodity.ResidentialAllocation);
            var commodityPoolDisbursementDate = DateTime.Now;
            var cpd = TestCommodityPoolDisbursement.Create(cp, commodityPoolDisbursementDate, 1);
            var viewModel = new Areas.ParcelTracker.Views.CommodityPoolDisbursement.EditViewModel(cpd);
            viewModel.UpdateModel(cpd, person, TestResidentialAllocation.CreateManyResidentialAllocations());
            var ra = cpd.ResidentialAllocations.Single();
            var expected = string.Format("{0}-{1}-{2}-{3}", cp.Jurisdiction.ResidentialAllocationAbbreviation, commodityPoolDisbursementDate.ToString("yy"), ra.ResidentialAllocationType.ResidentialAllocationTypeCode, ra.AllocationSequence.ToString("00"));
            Assert.That(ra.ResidentialAllocationNumber, Is.EqualTo(expected));
        }

        [Test]
        public void TestCantCreateAllocationNumberForNonRA()
        {
            var cp = TestCommodityPool.Create(Commodity.CommercialFloorArea);
            var cpb = TestCommodityPoolDisbursement.Create(cp, DateTime.Now, 10);

            Assert.That(!cpb.ResidentialAllocations.Any(), CommodityPoolDisbursements.CanOnlyHaveResidentialAllocationsIfTheCommodityTypeMatchesMessage);
        }

        [Test]
        public void TestCreateSimpleAllocationNumbers()
        {
            var person = TestFramework.TestPerson.Create();
            var cp = TestCommodityPool.Create(Commodity.ResidentialAllocation);

            var disbursementAmount = 10;
            var commodityPoolDisbursementDate = DateTime.Now;

            var cpd = TestCommodityPoolDisbursement.Create(cp, commodityPoolDisbursementDate, disbursementAmount);
            var viewModel = new Areas.ParcelTracker.Views.CommodityPoolDisbursement.EditViewModel(cpd);
            viewModel.UpdateModel(cpd, person, TestResidentialAllocation.CreateManyResidentialAllocations());

            Assert.That(cpd.ResidentialAllocations.Count, Is.EqualTo(disbursementAmount));

            var expectedRAN = string.Format("{0}-{1}-{2}-{3}", cp.Jurisdiction.ResidentialAllocationAbbreviation,
                commodityPoolDisbursementDate.ToString("yy"), ResidentialAllocationType.Original.ResidentialAllocationTypeCode,
                disbursementAmount);
            Assert.That(cpd.ResidentialAllocations.Last().ResidentialAllocationNumber, Is.EqualTo(expectedRAN));
        }

        [Test]
        public void TestDeallocateRemovesRANAndSetsRANTypeToReissued()
        {
            LtInfo.Common.AssertCustom.IgnoreUntil(DateTime.Parse("11/1/2016 10:00 AM"), "JHB 5/20/2016: Ignore because EditAllocationViewModel is hitting the DB and can't uncouple right now.");
            var person = TestFramework.TestPerson.Create();
            var cp = TestCommodityPool.Create(Commodity.ResidentialAllocation);

            var disbursementAmount = 10;
            var commodityPoolDisbursementDate = DateTime.Now;

            var cpd = TestCommodityPoolDisbursement.Create(cp, commodityPoolDisbursementDate, disbursementAmount);
            var viewModel = new Areas.ParcelTracker.Views.CommodityPoolDisbursement.EditViewModel(cpd);
            viewModel.UpdateModel(cpd, person, TestResidentialAllocation.CreateManyResidentialAllocations());

            var residentialAllocation = cpd.ResidentialAllocations.First();
            var transactionAllocation = TestTdrTransactionAllocation.CreateResidentialTransactionAllocation(cp, DateTime.Now, residentialAllocation, false);

            var editAllocationViewModel = new EditAllocationViewModel(transactionAllocation);
            editAllocationViewModel.UpdateModelImpl(transactionAllocation, residentialAllocation, person);

            Assert.That(residentialAllocation.ResidentialAllocationType, Is.EqualTo(ResidentialAllocationType.Original));
            Assert.That(transactionAllocation.TdrTransaction.TransactionState, Is.EqualTo(TransactionState.Draft));
            Assert.That(residentialAllocation.WithdrawnTdrTransaction, Is.Null);
            Assert.That(transactionAllocation.TdrTransactionID, Is.EqualTo(residentialAllocation.TdrTransactionID));

            var deallocateFromPoolViewModel = new DeallocateFromPoolViewModel(transactionAllocation.TdrTransaction);
            var tdrTransaction = transactionAllocation.TdrTransaction;
            deallocateFromPoolViewModel.UpdateModel(person, tdrTransaction, residentialAllocation);

            Assert.That(residentialAllocation.ResidentialAllocationTypeID, Is.EqualTo(ResidentialAllocationType.Reissued.ResidentialAllocationTypeID));
            Assert.That(transactionAllocation.TdrTransaction.TransactionState, Is.EqualTo(TransactionState.DeAllocated));
            Assert.That(transactionAllocation.TdrTransaction.ResidentialAllocation, Is.Null);
            Assert.That(residentialAllocation.WithdrawnTdrTransaction, Is.EqualTo(tdrTransaction));
        }

        [Test]
        public void AllocationAssignmentSequenceIsCorrect()
        {
            LtInfo.Common.AssertCustom.IgnoreUntil(DateTime.Parse("11/1/2016 10:00 AM"), "JHB 5/20/2016: Ignore because EditAllocationAssignmentViewModel is hitting the DB and can't uncouple right now.");
            var person = TestFramework.TestPerson.Create();
            var cp = TestCommodityPool.Create(Commodity.ResidentialAllocation);
            cp.CommodityPoolID = CommodityPool.TRPAAllocationPoolID;

            Assert.That(cp.IsTRPAAllocationPool);

            var disbursementAmount = 10;
            var commodityPoolDisbursementDate = DateTime.Now;

            var cpd = TestCommodityPoolDisbursement.Create(cp, commodityPoolDisbursementDate, disbursementAmount);
            var viewModel = new Areas.ParcelTracker.Views.CommodityPoolDisbursement.EditViewModel(cpd);
            
            var allResidentialAllocations = TestResidentialAllocation.CreateManyResidentialAllocations();
            viewModel.UpdateModel(cpd, person, allResidentialAllocations);

            var residentialAllocation = cpd.ResidentialAllocations.MaxBy(x => x.AllocationSequence);

            var expectedAllocationSequence = allResidentialAllocations.GetNextAllocationSequence(cpd.CommodityPoolID, cpd.CommodityPoolDisbursementDate.Year) + cpd.CommodityPoolDisbursementAmount - 1;

            var expectedRAN = string.Format("TRPA-{0}-AP-{1}", commodityPoolDisbursementDate.ToString("yy"), expectedAllocationSequence.ToString("00"));
            Assert.That(residentialAllocation.ResidentialAllocationNumber, Is.EqualTo(expectedRAN), "Expected RAN does not match");

            var tdrTransactionAllocationAssignment = TestTdrTransactionAllocationAssignment.Create(cp);
            tdrTransactionAllocationAssignment.TdrTransaction.ResidentialAllocation = residentialAllocation;
            var editAllocationAssignmentViewModel = new EditAllocationAssignmentViewModel(tdrTransactionAllocationAssignment);
            editAllocationAssignmentViewModel.AssignedToJurisdictionID = TestResidentialAllocation.AlreadyAllocatedFromPoolJurisdictionID;
            residentialAllocation.AssignedToJurisdiction = TestJurisdiction.Create();
            residentialAllocation.AssignedToJurisdiction.ResidentialAllocationAbbreviation = TestResidentialAllocation.AlreadyAllocatedFromPoolJurisdictionAbbreviation;
            editAllocationAssignmentViewModel.UpdateModel(person, tdrTransactionAllocationAssignment);

            Assert.That(residentialAllocation.ResidentialAllocationNumber,
                Is.EqualTo(string.Format("{0}-{1}-AP-{2}", TestResidentialAllocation.AlreadyAllocatedFromPoolJurisdictionAbbreviation, commodityPoolDisbursementDate.ToString("yy"), expectedAllocationSequence)),
                "Expected RAN does not match");
        }
    }
}