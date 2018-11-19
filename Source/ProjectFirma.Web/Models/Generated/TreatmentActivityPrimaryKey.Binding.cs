//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TreatmentActivity
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class TreatmentActivityPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TreatmentActivity>
    {
        public TreatmentActivityPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TreatmentActivityPrimaryKey(TreatmentActivity treatmentActivity) : base(treatmentActivity){}

        public static implicit operator TreatmentActivityPrimaryKey(int primaryKeyValue)
        {
            return new TreatmentActivityPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TreatmentActivityPrimaryKey(TreatmentActivity treatmentActivity)
        {
            return new TreatmentActivityPrimaryKey(treatmentActivity);
        }
    }
}