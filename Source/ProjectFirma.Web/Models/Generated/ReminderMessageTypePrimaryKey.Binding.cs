//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReminderMessageType
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ReminderMessageTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReminderMessageType>
    {
        public ReminderMessageTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReminderMessageTypePrimaryKey(ReminderMessageType reminderMessageType) : base(reminderMessageType){}

        public static implicit operator ReminderMessageTypePrimaryKey(int primaryKeyValue)
        {
            return new ReminderMessageTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReminderMessageTypePrimaryKey(ReminderMessageType reminderMessageType)
        {
            return new ReminderMessageTypePrimaryKey(reminderMessageType);
        }
    }
}