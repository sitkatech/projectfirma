//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ThresholdRole
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ThresholdRolePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ThresholdRole>
    {
        public ThresholdRolePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ThresholdRolePrimaryKey(ThresholdRole thresholdRole) : base(thresholdRole){}

        public static implicit operator ThresholdRolePrimaryKey(int primaryKeyValue)
        {
            return new ThresholdRolePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ThresholdRolePrimaryKey(ThresholdRole thresholdRole)
        {
            return new ThresholdRolePrimaryKey(thresholdRole);
        }
    }
}