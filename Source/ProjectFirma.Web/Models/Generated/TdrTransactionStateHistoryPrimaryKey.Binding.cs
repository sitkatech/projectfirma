//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TdrTransactionStateHistory
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class TdrTransactionStateHistoryPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TdrTransactionStateHistory>
    {
        public TdrTransactionStateHistoryPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TdrTransactionStateHistoryPrimaryKey(TdrTransactionStateHistory tdrTransactionStateHistory) : base(tdrTransactionStateHistory){}

        public static implicit operator TdrTransactionStateHistoryPrimaryKey(int primaryKeyValue)
        {
            return new TdrTransactionStateHistoryPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TdrTransactionStateHistoryPrimaryKey(TdrTransactionStateHistory tdrTransactionStateHistory)
        {
            return new TdrTransactionStateHistoryPrimaryKey(tdrTransactionStateHistory);
        }
    }
}