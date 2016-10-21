//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TdrTransactionTransfer
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class TdrTransactionTransferPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TdrTransactionTransfer>
    {
        public TdrTransactionTransferPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TdrTransactionTransferPrimaryKey(TdrTransactionTransfer tdrTransactionTransfer) : base(tdrTransactionTransfer){}

        public static implicit operator TdrTransactionTransferPrimaryKey(int primaryKeyValue)
        {
            return new TdrTransactionTransferPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TdrTransactionTransferPrimaryKey(TdrTransactionTransfer tdrTransactionTransfer)
        {
            return new TdrTransactionTransferPrimaryKey(tdrTransactionTransfer);
        }
    }
}