//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.IndicatorSubcategoryOption
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class IndicatorSubcategoryOptionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<IndicatorSubcategoryOption>
    {
        public IndicatorSubcategoryOptionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public IndicatorSubcategoryOptionPrimaryKey(IndicatorSubcategoryOption indicatorSubcategoryOption) : base(indicatorSubcategoryOption){}

        public static implicit operator IndicatorSubcategoryOptionPrimaryKey(int primaryKeyValue)
        {
            return new IndicatorSubcategoryOptionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator IndicatorSubcategoryOptionPrimaryKey(IndicatorSubcategoryOption indicatorSubcategoryOption)
        {
            return new IndicatorSubcategoryOptionPrimaryKey(indicatorSubcategoryOption);
        }
    }
}