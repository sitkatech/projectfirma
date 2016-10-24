//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.IndicatorSubcategory
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class IndicatorSubcategoryPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<IndicatorSubcategory>
    {
        public IndicatorSubcategoryPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public IndicatorSubcategoryPrimaryKey(IndicatorSubcategory indicatorSubcategory) : base(indicatorSubcategory){}

        public static implicit operator IndicatorSubcategoryPrimaryKey(int primaryKeyValue)
        {
            return new IndicatorSubcategoryPrimaryKey(primaryKeyValue);
        }

        public static implicit operator IndicatorSubcategoryPrimaryKey(IndicatorSubcategory indicatorSubcategory)
        {
            return new IndicatorSubcategoryPrimaryKey(indicatorSubcategory);
        }
    }
}