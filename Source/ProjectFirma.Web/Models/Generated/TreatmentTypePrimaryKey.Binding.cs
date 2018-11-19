//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TreatmentType
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class TreatmentTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TreatmentType>
    {
        public TreatmentTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TreatmentTypePrimaryKey(TreatmentType treatmentType) : base(treatmentType){}

        public static implicit operator TreatmentTypePrimaryKey(int primaryKeyValue)
        {
            return new TreatmentTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator TreatmentTypePrimaryKey(TreatmentType treatmentType)
        {
            return new TreatmentTypePrimaryKey(treatmentType);
        }
    }
}