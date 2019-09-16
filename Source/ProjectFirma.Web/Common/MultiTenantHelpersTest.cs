using System;
using LtInfo.Common.DesignByContract;
using NUnit.Framework;

namespace ProjectFirma.Web.Common
{
    [TestFixture]
    public class MultiTenantHelpersTest
    {
        [Test]
        public void GetTenantFromHostUrlHandlesOddballInputs()
        {
            // Normal use case that we see on typical web requests
            {
                var tenantFromHostUrl = MultiTenantHelpers.GetTenantFromHostUrl(new Uri("http://sitka.localhost.projectfirma.com"));
                Check.Ensure(tenantFromHostUrl != null && tenantFromHostUrl.TenantName == "SitkaTechnologyGroup");
            }

            // Oddball use case that we've seen coming from Facebook. Never mind that the port is wrong - we should be
            // able to determine the tenant regardless.
            {
                var tenantFromHostUrl = MultiTenantHelpers.GetTenantFromHostUrl(new Uri("http://sitka.localhost.projectfirma.com:80"));
                Check.Ensure(tenantFromHostUrl != null && tenantFromHostUrl.TenantName == "SitkaTechnologyGroup");
            }
        }
    }
}