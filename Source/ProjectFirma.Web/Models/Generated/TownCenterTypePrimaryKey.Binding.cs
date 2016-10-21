//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TownCenterType
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class TownCenterTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TownCenterType>
    {
        public TownCenterTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TownCenterTypePrimaryKey(TownCenterType townCenterType) : base(townCenterType){}

        public static implicit operator TownCenterTypePrimaryKey(int primaryKeyValue)
        {
            return new TownCenterTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator TownCenterTypePrimaryKey(TownCenterType townCenterType)
        {
            return new TownCenterTypePrimaryKey(townCenterType);
        }
    }
}