//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.LandCapabilityType
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class LandCapabilityTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<LandCapabilityType>
    {
        public LandCapabilityTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public LandCapabilityTypePrimaryKey(LandCapabilityType landCapabilityType) : base(landCapabilityType){}

        public static implicit operator LandCapabilityTypePrimaryKey(int primaryKeyValue)
        {
            return new LandCapabilityTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator LandCapabilityTypePrimaryKey(LandCapabilityType landCapabilityType)
        {
            return new LandCapabilityTypePrimaryKey(landCapabilityType);
        }
    }
}