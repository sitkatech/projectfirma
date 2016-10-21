//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TransactionTypeCommodity
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class TransactionTypeCommodityPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TransactionTypeCommodity>
    {
        public TransactionTypeCommodityPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TransactionTypeCommodityPrimaryKey(TransactionTypeCommodity transactionTypeCommodity) : base(transactionTypeCommodity){}

        public static implicit operator TransactionTypeCommodityPrimaryKey(int primaryKeyValue)
        {
            return new TransactionTypeCommodityPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TransactionTypeCommodityPrimaryKey(TransactionTypeCommodity transactionTypeCommodity)
        {
            return new TransactionTypeCommodityPrimaryKey(transactionTypeCommodity);
        }
    }
}