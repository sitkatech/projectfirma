//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TdrTransactionLandBankAcquisition
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class TdrTransactionLandBankAcquisitionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TdrTransactionLandBankAcquisition>
    {
        public TdrTransactionLandBankAcquisitionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TdrTransactionLandBankAcquisitionPrimaryKey(TdrTransactionLandBankAcquisition tdrTransactionLandBankAcquisition) : base(tdrTransactionLandBankAcquisition){}

        public static implicit operator TdrTransactionLandBankAcquisitionPrimaryKey(int primaryKeyValue)
        {
            return new TdrTransactionLandBankAcquisitionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TdrTransactionLandBankAcquisitionPrimaryKey(TdrTransactionLandBankAcquisition tdrTransactionLandBankAcquisition)
        {
            return new TdrTransactionLandBankAcquisitionPrimaryKey(tdrTransactionLandBankAcquisition);
        }
    }
}