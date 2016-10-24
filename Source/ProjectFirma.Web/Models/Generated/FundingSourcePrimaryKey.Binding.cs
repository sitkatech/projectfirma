//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FundingSource
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class FundingSourcePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FundingSource>
    {
        public FundingSourcePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FundingSourcePrimaryKey(FundingSource fundingSource) : base(fundingSource){}

        public static implicit operator FundingSourcePrimaryKey(int primaryKeyValue)
        {
            return new FundingSourcePrimaryKey(primaryKeyValue);
        }

        public static implicit operator FundingSourcePrimaryKey(FundingSource fundingSource)
        {
            return new FundingSourcePrimaryKey(fundingSource);
        }
    }
}