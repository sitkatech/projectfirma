//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.Tenant
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class TenantPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<Tenant>
    {
        public TenantPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TenantPrimaryKey(Tenant tenant) : base(tenant){}

        public static implicit operator TenantPrimaryKey(int primaryKeyValue)
        {
            return new TenantPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TenantPrimaryKey(Tenant tenant)
        {
            return new TenantPrimaryKey(tenant);
        }
    }
}