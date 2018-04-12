using System;
using System.Linq;
using NUnit.Framework;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public class TaxonomyLeafPerformanceMeasureTest
    {       
        [Test]
        public void AllTenantsShouldHaveAtLeastOneRootBranchAndLeaf()
        {
            Assert.That(HttpRequestStorage.DatabaseEntities.AllTaxonomyLeafs.GroupBy(x => x.TenantID).Select(x => x.Key), Is.EquivalentTo(Tenant.All.Select(x => x.TenantID)));
        }

        [Test]
        public void ShouldHaveAtLeastOneSupportEmail()
        {
            foreach (var tenantAttribute in HttpRequestStorage.DatabaseEntities.AllTenantAttributes.ToList())
            {
                CheckThatTaxonomyLeafPerformanceMeasuresAreInSync(tenantAttribute.AssociatePerfomanceMeasureTaxonomyLevel);
            }
        }

        private static void CheckThatTaxonomyLeafPerformanceMeasuresAreInSync(TaxonomyLevel taxonomyLevel)
        {
            Func<TaxonomyLeaf, int> keySelector;
            if (taxonomyLevel == TaxonomyLevel.Trunk)
            {
                keySelector = x => x.TaxonomyBranch.TaxonomyTrunkID;
            }
            else if (taxonomyLevel == TaxonomyLevel.Branch)
            {
                keySelector = x => x.TaxonomyBranchID;
            }
            else
            {
                keySelector = x => x.TaxonomyLeafID;
            }

            // for each tenant, all taxonomy leafs under each trunk should have the same performance measure relationships
            var taxonomyLeafGroupedPerTenant =
                HttpRequestStorage.DatabaseEntities.AllTaxonomyLeafs.ToList().GroupBy(x => x.TenantID);
            foreach (var taxonomyLeavesForTenant in taxonomyLeafGroupedPerTenant)
            {
                var taxonomyLeavesGroupedByTrunk = taxonomyLeavesForTenant.GroupBy(keySelector);
                foreach (var taxonomyLeavesForTrunk in taxonomyLeavesGroupedByTrunk)
                {
                    var enumerable = taxonomyLeavesForTrunk.Select(y =>
                        y.TaxonomyLeafPerformanceMeasures.Select(z => z.PerformanceMeasureID).OrderBy(z => z)).ToList();
                    var listToCompareTo = enumerable.First().ToList();
                    var a = enumerable.All(x => x.SequenceEqual(listToCompareTo));
                    Assert.That(a, Is.True,
                        $"Tenant ID {taxonomyLeavesForTenant.Key}, {taxonomyLevel.TaxonomyLevelName} with ID {taxonomyLeavesForTrunk.Key} has mismatched TaxonomyLeafPerformanceMeasure records");
                }
            }
        }
    }
}