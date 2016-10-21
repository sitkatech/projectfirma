//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.Indicator
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class IndicatorPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<Indicator>
    {
        public IndicatorPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public IndicatorPrimaryKey(Indicator indicator) : base(indicator){}

        public static implicit operator IndicatorPrimaryKey(int primaryKeyValue)
        {
            return new IndicatorPrimaryKey(primaryKeyValue);
        }

        public static implicit operator IndicatorPrimaryKey(Indicator indicator)
        {
            return new IndicatorPrimaryKey(indicator);
        }
    }
}