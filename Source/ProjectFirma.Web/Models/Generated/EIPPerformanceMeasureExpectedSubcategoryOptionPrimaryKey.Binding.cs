//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.EIPPerformanceMeasureExpectedSubcategoryOption
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class EIPPerformanceMeasureExpectedSubcategoryOptionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<EIPPerformanceMeasureExpectedSubcategoryOption>
    {
        public EIPPerformanceMeasureExpectedSubcategoryOptionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public EIPPerformanceMeasureExpectedSubcategoryOptionPrimaryKey(EIPPerformanceMeasureExpectedSubcategoryOption eIPPerformanceMeasureExpectedSubcategoryOption) : base(eIPPerformanceMeasureExpectedSubcategoryOption){}

        public static implicit operator EIPPerformanceMeasureExpectedSubcategoryOptionPrimaryKey(int primaryKeyValue)
        {
            return new EIPPerformanceMeasureExpectedSubcategoryOptionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator EIPPerformanceMeasureExpectedSubcategoryOptionPrimaryKey(EIPPerformanceMeasureExpectedSubcategoryOption eIPPerformanceMeasureExpectedSubcategoryOption)
        {
            return new EIPPerformanceMeasureExpectedSubcategoryOptionPrimaryKey(eIPPerformanceMeasureExpectedSubcategoryOption);
        }
    }
}