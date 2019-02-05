//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.Notification
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class NotificationPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<Notification>
    {
        public NotificationPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public NotificationPrimaryKey(Notification notification) : base(notification){}

        public static implicit operator NotificationPrimaryKey(int primaryKeyValue)
        {
            return new NotificationPrimaryKey(primaryKeyValue);
        }

        public static implicit operator NotificationPrimaryKey(Notification notification)
        {
            return new NotificationPrimaryKey(notification);
        }
    }
}