//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.NotificationProposedProject
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class NotificationProposedProjectPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<NotificationProposedProject>
    {
        public NotificationProposedProjectPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public NotificationProposedProjectPrimaryKey(NotificationProposedProject notificationProposedProject) : base(notificationProposedProject){}

        public static implicit operator NotificationProposedProjectPrimaryKey(int primaryKeyValue)
        {
            return new NotificationProposedProjectPrimaryKey(primaryKeyValue);
        }

        public static implicit operator NotificationProposedProjectPrimaryKey(NotificationProposedProject notificationProposedProject)
        {
            return new NotificationProposedProjectPrimaryKey(notificationProposedProject);
        }
    }
}