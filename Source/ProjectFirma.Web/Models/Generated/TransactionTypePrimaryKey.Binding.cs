//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TransactionType
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class TransactionTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TransactionType>
    {
        public TransactionTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TransactionTypePrimaryKey(TransactionType transactionType) : base(transactionType){}

        public static implicit operator TransactionTypePrimaryKey(int primaryKeyValue)
        {
            return new TransactionTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator TransactionTypePrimaryKey(TransactionType transactionType)
        {
            return new TransactionTypePrimaryKey(transactionType);
        }
    }
}