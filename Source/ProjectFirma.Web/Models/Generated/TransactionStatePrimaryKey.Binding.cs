//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TransactionState
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class TransactionStatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TransactionState>
    {
        public TransactionStatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TransactionStatePrimaryKey(TransactionState transactionState) : base(transactionState){}

        public static implicit operator TransactionStatePrimaryKey(int primaryKeyValue)
        {
            return new TransactionStatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator TransactionStatePrimaryKey(TransactionState transactionState)
        {
            return new TransactionStatePrimaryKey(transactionState);
        }
    }
}