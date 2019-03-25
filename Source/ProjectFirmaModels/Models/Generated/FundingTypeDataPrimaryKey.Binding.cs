//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FundingTypeData
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class FundingTypeDataPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FundingTypeData>
    {
        public FundingTypeDataPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FundingTypeDataPrimaryKey(FundingTypeData fundingTypeData) : base(fundingTypeData){}

        public static implicit operator FundingTypeDataPrimaryKey(int primaryKeyValue)
        {
            return new FundingTypeDataPrimaryKey(primaryKeyValue);
        }

        public static implicit operator FundingTypeDataPrimaryKey(FundingTypeData fundingTypeData)
        {
            return new FundingTypeDataPrimaryKey(fundingTypeData);
        }
    }
}