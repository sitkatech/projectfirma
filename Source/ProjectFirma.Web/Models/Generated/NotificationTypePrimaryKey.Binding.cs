//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.NotificationType
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class NotificationTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<NotificationType>
    {
        public NotificationTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public NotificationTypePrimaryKey(NotificationType notificationType) : base(notificationType){}

        public static implicit operator NotificationTypePrimaryKey(int primaryKeyValue)
        {
            return new NotificationTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator NotificationTypePrimaryKey(NotificationType notificationType)
        {
            return new NotificationTypePrimaryKey(notificationType);
        }
    }
}