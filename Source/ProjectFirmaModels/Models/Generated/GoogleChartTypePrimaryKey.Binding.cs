//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.GoogleChartType
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class GoogleChartTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<GoogleChartType>
    {
        public GoogleChartTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public GoogleChartTypePrimaryKey(GoogleChartType googleChartType) : base(googleChartType){}

        public static implicit operator GoogleChartTypePrimaryKey(int primaryKeyValue)
        {
            return new GoogleChartTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator GoogleChartTypePrimaryKey(GoogleChartType googleChartType)
        {
            return new GoogleChartTypePrimaryKey(googleChartType);
        }
    }
}