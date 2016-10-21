//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ActionPriorityImage
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ActionPriorityImagePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ActionPriorityImage>
    {
        public ActionPriorityImagePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ActionPriorityImagePrimaryKey(ActionPriorityImage actionPriorityImage) : base(actionPriorityImage){}

        public static implicit operator ActionPriorityImagePrimaryKey(int primaryKeyValue)
        {
            return new ActionPriorityImagePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ActionPriorityImagePrimaryKey(ActionPriorityImage actionPriorityImage)
        {
            return new ActionPriorityImagePrimaryKey(actionPriorityImage);
        }
    }
}