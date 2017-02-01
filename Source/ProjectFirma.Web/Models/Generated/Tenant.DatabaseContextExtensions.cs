//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Tenant]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static Tenant GetTenant(this IQueryable<Tenant> tenants, int tenantID)
        {
            var tenant = tenants.SingleOrDefault(x => x.TenantID == tenantID);
            Check.RequireNotNullThrowNotFound(tenant, "Tenant", tenantID);
            return tenant;
        }

        public static void DeleteTenant(this IQueryable<Tenant> tenants, List<int> tenantIDList)
        {
            if(tenantIDList.Any())
            {
                tenants.Where(x => tenantIDList.Contains(x.TenantID)).Delete();
            }
        }

        public static void DeleteTenant(this IQueryable<Tenant> tenants, ICollection<Tenant> tenantsToDelete)
        {
            if(tenantsToDelete.Any())
            {
                var tenantIDList = tenantsToDelete.Select(x => x.TenantID).ToList();
                tenants.Where(x => tenantIDList.Contains(x.TenantID)).Delete();
            }
        }

        public static void DeleteTenant(this IQueryable<Tenant> tenants, int tenantID)
        {
            DeleteTenant(tenants, new List<int> { tenantID });
        }

        public static void DeleteTenant(this IQueryable<Tenant> tenants, Tenant tenantToDelete)
        {
            DeleteTenant(tenants, new List<Tenant> { tenantToDelete });
        }
    }
}