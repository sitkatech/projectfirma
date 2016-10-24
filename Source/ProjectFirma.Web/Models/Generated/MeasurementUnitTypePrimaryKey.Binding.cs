//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.MeasurementUnitType
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class MeasurementUnitTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<MeasurementUnitType>
    {
        public MeasurementUnitTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public MeasurementUnitTypePrimaryKey(MeasurementUnitType measurementUnitType) : base(measurementUnitType){}

        public static implicit operator MeasurementUnitTypePrimaryKey(int primaryKeyValue)
        {
            return new MeasurementUnitTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator MeasurementUnitTypePrimaryKey(MeasurementUnitType measurementUnitType)
        {
            return new MeasurementUnitTypePrimaryKey(measurementUnitType);
        }
    }
}