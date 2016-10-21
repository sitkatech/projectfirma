//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TdrTransactionECMRetirement
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class TdrTransactionECMRetirementPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TdrTransactionECMRetirement>
    {
        public TdrTransactionECMRetirementPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TdrTransactionECMRetirementPrimaryKey(TdrTransactionECMRetirement tdrTransactionECMRetirement) : base(tdrTransactionECMRetirement){}

        public static implicit operator TdrTransactionECMRetirementPrimaryKey(int primaryKeyValue)
        {
            return new TdrTransactionECMRetirementPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TdrTransactionECMRetirementPrimaryKey(TdrTransactionECMRetirement tdrTransactionECMRetirement)
        {
            return new TdrTransactionECMRetirementPrimaryKey(tdrTransactionECMRetirement);
        }
    }
}