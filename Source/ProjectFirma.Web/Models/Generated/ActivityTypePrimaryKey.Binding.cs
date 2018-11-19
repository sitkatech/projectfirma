//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ActivityType
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ActivityTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ActivityType>
    {
        public ActivityTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ActivityTypePrimaryKey(ActivityType activityType) : base(activityType){}

        public static implicit operator ActivityTypePrimaryKey(int primaryKeyValue)
        {
            return new ActivityTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ActivityTypePrimaryKey(ActivityType activityType)
        {
            return new ActivityTypePrimaryKey(activityType);
        }
    }
}