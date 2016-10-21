//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TdrTransaction
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class TdrTransactionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TdrTransaction>
    {
        public TdrTransactionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TdrTransactionPrimaryKey(TdrTransaction tdrTransaction) : base(tdrTransaction){}

        public static implicit operator TdrTransactionPrimaryKey(int primaryKeyValue)
        {
            return new TdrTransactionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TdrTransactionPrimaryKey(TdrTransaction tdrTransaction)
        {
            return new TdrTransactionPrimaryKey(tdrTransaction);
        }
    }
}