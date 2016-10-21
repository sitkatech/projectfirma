//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TdrTransactionConversionWithTransfer
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class TdrTransactionConversionWithTransferPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TdrTransactionConversionWithTransfer>
    {
        public TdrTransactionConversionWithTransferPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TdrTransactionConversionWithTransferPrimaryKey(TdrTransactionConversionWithTransfer tdrTransactionConversionWithTransfer) : base(tdrTransactionConversionWithTransfer){}

        public static implicit operator TdrTransactionConversionWithTransferPrimaryKey(int primaryKeyValue)
        {
            return new TdrTransactionConversionWithTransferPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TdrTransactionConversionWithTransferPrimaryKey(TdrTransactionConversionWithTransfer tdrTransactionConversionWithTransfer)
        {
            return new TdrTransactionConversionWithTransferPrimaryKey(tdrTransactionConversionWithTransfer);
        }
    }
}