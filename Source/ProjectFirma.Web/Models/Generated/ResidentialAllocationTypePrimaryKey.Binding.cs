//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ResidentialAllocationType
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ResidentialAllocationTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ResidentialAllocationType>
    {
        public ResidentialAllocationTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ResidentialAllocationTypePrimaryKey(ResidentialAllocationType residentialAllocationType) : base(residentialAllocationType){}

        public static implicit operator ResidentialAllocationTypePrimaryKey(int primaryKeyValue)
        {
            return new ResidentialAllocationTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ResidentialAllocationTypePrimaryKey(ResidentialAllocationType residentialAllocationType)
        {
            return new ResidentialAllocationTypePrimaryKey(residentialAllocationType);
        }
    }
}