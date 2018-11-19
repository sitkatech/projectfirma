//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.StaffTimeActivity
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class StaffTimeActivityPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<StaffTimeActivity>
    {
        public StaffTimeActivityPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public StaffTimeActivityPrimaryKey(StaffTimeActivity staffTimeActivity) : base(staffTimeActivity){}

        public static implicit operator StaffTimeActivityPrimaryKey(int primaryKeyValue)
        {
            return new StaffTimeActivityPrimaryKey(primaryKeyValue);
        }

        public static implicit operator StaffTimeActivityPrimaryKey(StaffTimeActivity staffTimeActivity)
        {
            return new StaffTimeActivityPrimaryKey(staffTimeActivity);
        }
    }
}