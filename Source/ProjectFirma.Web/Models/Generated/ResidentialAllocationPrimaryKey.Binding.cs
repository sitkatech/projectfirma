//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ResidentialAllocation
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ResidentialAllocationPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ResidentialAllocation>
    {
        public ResidentialAllocationPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ResidentialAllocationPrimaryKey(ResidentialAllocation residentialAllocation) : base(residentialAllocation){}

        public static implicit operator ResidentialAllocationPrimaryKey(int primaryKeyValue)
        {
            return new ResidentialAllocationPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ResidentialAllocationPrimaryKey(ResidentialAllocation residentialAllocation)
        {
            return new ResidentialAllocationPrimaryKey(residentialAllocation);
        }
    }
}