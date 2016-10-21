//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ActionPriority
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ActionPriorityPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ActionPriority>
    {
        public ActionPriorityPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ActionPriorityPrimaryKey(ActionPriority actionPriority) : base(actionPriority){}

        public static implicit operator ActionPriorityPrimaryKey(int primaryKeyValue)
        {
            return new ActionPriorityPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ActionPriorityPrimaryKey(ActionPriority actionPriority)
        {
            return new ActionPriorityPrimaryKey(actionPriority);
        }
    }
}