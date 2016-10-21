//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TdrTransactionTransferWithBonusUnit
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class TdrTransactionTransferWithBonusUnitPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TdrTransactionTransferWithBonusUnit>
    {
        public TdrTransactionTransferWithBonusUnitPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TdrTransactionTransferWithBonusUnitPrimaryKey(TdrTransactionTransferWithBonusUnit tdrTransactionTransferWithBonusUnit) : base(tdrTransactionTransferWithBonusUnit){}

        public static implicit operator TdrTransactionTransferWithBonusUnitPrimaryKey(int primaryKeyValue)
        {
            return new TdrTransactionTransferWithBonusUnitPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TdrTransactionTransferWithBonusUnitPrimaryKey(TdrTransactionTransferWithBonusUnit tdrTransactionTransferWithBonusUnit)
        {
            return new TdrTransactionTransferWithBonusUnitPrimaryKey(tdrTransactionTransferWithBonusUnit);
        }
    }
}