//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.Ownership
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class OwnershipPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<Ownership>
    {
        public OwnershipPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public OwnershipPrimaryKey(Ownership ownership) : base(ownership){}

        public static implicit operator OwnershipPrimaryKey(int primaryKeyValue)
        {
            return new OwnershipPrimaryKey(primaryKeyValue);
        }

        public static implicit operator OwnershipPrimaryKey(Ownership ownership)
        {
            return new OwnershipPrimaryKey(ownership);
        }
    }
}