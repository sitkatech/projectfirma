//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TenantAttribute]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static TenantAttribute GetTenantAttribute(this IQueryable<TenantAttribute> tenantAttributes, int tenantAttributeID)
        {
            var tenantAttribute = tenantAttributes.SingleOrDefault(x => x.TenantAttributeID == tenantAttributeID);
            Check.RequireNotNullThrowNotFound(tenantAttribute, "TenantAttribute", tenantAttributeID);
            return tenantAttribute;
        }

        public static void DeleteTenantAttribute(this List<int> tenantAttributeIDList)
        {
            if(tenantAttributeIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTenantAttributes.RemoveRange(HttpRequestStorage.DatabaseEntities.TenantAttributes.Where(x => tenantAttributeIDList.Contains(x.TenantAttributeID)));
            }
        }

        public static void DeleteTenantAttribute(this ICollection<TenantAttribute> tenantAttributesToDelete)
        {
            if(tenantAttributesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTenantAttributes.RemoveRange(tenantAttributesToDelete);
            }
        }

        public static void DeleteTenantAttribute(this int tenantAttributeID)
        {
            DeleteTenantAttribute(new List<int> { tenantAttributeID });
        }

        public static void DeleteTenantAttribute(this TenantAttribute tenantAttributeToDelete)
        {
            DeleteTenantAttribute(new List<TenantAttribute> { tenantAttributeToDelete });
        }
    }
}