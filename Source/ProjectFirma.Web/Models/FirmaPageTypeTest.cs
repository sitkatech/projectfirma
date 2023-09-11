﻿using System.Collections.Generic;
using System.Linq;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public class FirmaPageTypeTest
    {
        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void CheckForUncreatedFirmaPageForFirmaPageType()
        {
            var allFirmaPages = HttpRequestStorage.DatabaseEntities.AllFirmaPages.ToList();
            var allFirmaPageTypes = HttpRequestStorage.DatabaseEntities.FirmaPageTypes.ToList();
            var allTenants = Tenant.All;
            string missingPageTypes = string.Empty;

            foreach (var tenant in allTenants)
            {
                List<int> allFirmaPageTypeIDPresentInFirmaPages = allFirmaPages.Where(fp => fp.TenantID == tenant.TenantID).Select(fp => fp.FirmaPageTypeID).Distinct().ToList();
                foreach (var firmaPageType in allFirmaPageTypes)
                {
                    var pageTypeIsPresent = allFirmaPageTypeIDPresentInFirmaPages.Contains(firmaPageType.FirmaPageTypeID);
                    if (!pageTypeIsPresent)
                    {
                        missingPageTypes += $"insert into dbo.FirmaPage(TenantID, FirmaPageTypeID) values ({tenant.TenantID},{firmaPageType.FirmaPageTypeID}) --Could Not find Firma Page Type '{firmaPageType.FirmaPageTypeName}'({firmaPageType.FirmaPageTypeID}) in Firma Pages for Tenant {tenant.TenantName}({tenant.TenantID})\n\r";
                    }

                }
            }
            Approvals.Verify(missingPageTypes);
        }
    }
}