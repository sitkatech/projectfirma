//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TownCenter
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class TownCenterPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TownCenter>
    {
        public TownCenterPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TownCenterPrimaryKey(TownCenter townCenter) : base(townCenter){}

        public static implicit operator TownCenterPrimaryKey(int primaryKeyValue)
        {
            return new TownCenterPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TownCenterPrimaryKey(TownCenter townCenter)
        {
            return new TownCenterPrimaryKey(townCenter);
        }
    }
}