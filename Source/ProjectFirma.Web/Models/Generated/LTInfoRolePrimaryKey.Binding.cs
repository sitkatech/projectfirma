//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.LTInfoRole
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class LTInfoRolePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<LTInfoRole>
    {
        public LTInfoRolePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public LTInfoRolePrimaryKey(LTInfoRole lTInfoRole) : base(lTInfoRole){}

        public static implicit operator LTInfoRolePrimaryKey(int primaryKeyValue)
        {
            return new LTInfoRolePrimaryKey(primaryKeyValue);
        }

        public static implicit operator LTInfoRolePrimaryKey(LTInfoRole lTInfoRole)
        {
            return new LTInfoRolePrimaryKey(lTInfoRole);
        }
    }
}