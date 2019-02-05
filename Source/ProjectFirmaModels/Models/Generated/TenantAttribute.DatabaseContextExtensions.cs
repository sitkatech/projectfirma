//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TenantAttribute]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static TenantAttribute GetTenantAttribute(this IQueryable<TenantAttribute> tenantAttributes, int tenantAttributeID)
        {
            var tenantAttribute = tenantAttributes.SingleOrDefault(x => x.TenantAttributeID == tenantAttributeID);
            Check.RequireNotNullThrowNotFound(tenantAttribute, "TenantAttribute", tenantAttributeID);
            return tenantAttribute;
        }

    }
}