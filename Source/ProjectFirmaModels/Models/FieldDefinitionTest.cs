using System.Linq;
using ApprovalTests.Reporters;
using NUnit.Framework;
using ProjectFirmaModels.UnitTestCommon;
using ApprovalTests;
namespace ProjectFirmaModels.Models
{
    [TestFixture]
    public class FieldDefinitionTest : DatabaseDirectAccessTestFixtureBase
    {

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            BaseFixtureSetup();
        }

        [TestFixtureTearDown]
        public void TestFixtureTeardown()
        {
            BaseFixtureTeardown();
        }

        [Test]
        [Ignore("Probably won't use this one, but SLG is sentimental. Kill this when he isn't looking.")]
        [UseReporter(typeof(DiffReporter))]
        public void NoDuplicateFieldDefinitionsPerTenant()
        {
            // We get all the FieldDefinitionDatas, *ACROSS ALL TENANTS*, then look for duplication WITHIN each tenant
            var fieldDefinitionDatas = HttpRequestStorageForTest.DatabaseEntities.AllFieldDefinitionDatas.ToList();
            var fieldDefinitionDatasGroupedByTenant = fieldDefinitionDatas.GroupBy(fdd => fdd.Tenant);

            foreach (var fddTenantGroup in fieldDefinitionDatasGroupedByTenant)
            {
                var currentTenant = fddTenantGroup.Key;
                var currentFdds = fddTenantGroup.ToList();

                var allRealFddLabels = currentFdds.Where(fdd => !string.IsNullOrWhiteSpace(fdd.FieldDefinitionLabel)).Select(fdd => fdd.FieldDefinitionLabel).OrderBy(fdlabel => fdlabel).ToList();
                var allRealFddsAsCommaDelimitedString = string.Join(", ", allRealFddLabels);
                Assert.That(allRealFddLabels.Distinct().Count() == allRealFddLabels.Count(), $"Repeated FieldDefinitionLabels for Tenant {currentTenant.TenantID}: {currentTenant.TenantName} - {allRealFddsAsCommaDelimitedString}");
            }
        }

        /// <summary>
        /// If this test starts failing, go to the Field Definition index page for the given tenant (for example, "https://actionagendatracker.localhost.projectfirma.com/FieldDefinition/Index",
        /// and look for problematic fields.
        ///
        /// There may be no easy answer to the issue, in which case you'll likely want to accept these new results. But if you can work something out with the user/Tenant, you might want to try to.
        /// -- SLG & TK - 2/18/2020
        /// </summary>
        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void WarnAboutAnyTenantOverridesThatCollideWithDifferentSystemFieldDefinitions()
        {
            const string sqlQueryString = @"
select compareQuery.* from 
(
	select 
	  fd.FieldDefinitionID as fieldDefinitionDefinitionID
	, fd.FieldDefinitionDisplayName as DefaultSystemFieldDefinitionDisplayName	
	, fddata.FieldDefinitionID as dataFieldDefinitionID
	, fddata.FieldDefinitionDataID 
	, fddata.TenantID
	, fddata.FieldDefinitionLabel as TenantOverriddenFieldDefinitionDisplayName
from
	dbo.FieldDefinitionData as fddata
	cross join dbo.FieldDefinition as fd --on fddata.FieldDefinitionID = fd.FieldDefinitionID	
where
	fddata.FieldDefinitionLabel is not null	 

) as compareQuery
where 
--TenantID = 11 and
fieldDefinitionDefinitionID != dataFieldDefinitionID and DefaultSystemFieldDefinitionDisplayName = TenantOverriddenFieldDefinitionDisplayName
order by TenantID";
            var result = ExecAdHocSql(sqlQueryString);
            Approvals.Verify(result.TableToHumanReadableString());
        }

    }
}