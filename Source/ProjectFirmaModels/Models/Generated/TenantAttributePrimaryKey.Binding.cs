//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TenantAttribute
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class TenantAttributePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TenantAttribute>
    {
        public TenantAttributePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TenantAttributePrimaryKey(TenantAttribute tenantAttribute) : base(tenantAttribute){}

        public static implicit operator TenantAttributePrimaryKey(int primaryKeyValue)
        {
            return new TenantAttributePrimaryKey(primaryKeyValue);
        }

        public static implicit operator TenantAttributePrimaryKey(TenantAttribute tenantAttribute)
        {
            return new TenantAttributePrimaryKey(tenantAttribute);
        }
    }
}