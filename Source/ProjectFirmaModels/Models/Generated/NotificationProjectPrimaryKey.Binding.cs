//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.NotificationProject
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class NotificationProjectPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<NotificationProject>
    {
        public NotificationProjectPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public NotificationProjectPrimaryKey(NotificationProject notificationProject) : base(notificationProject){}

        public static implicit operator NotificationProjectPrimaryKey(int primaryKeyValue)
        {
            return new NotificationProjectPrimaryKey(primaryKeyValue);
        }

        public static implicit operator NotificationProjectPrimaryKey(NotificationProject notificationProject)
        {
            return new NotificationProjectPrimaryKey(notificationProject);
        }
    }
}