//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TdrTransactionAllocation
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class TdrTransactionAllocationPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TdrTransactionAllocation>
    {
        public TdrTransactionAllocationPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TdrTransactionAllocationPrimaryKey(TdrTransactionAllocation tdrTransactionAllocation) : base(tdrTransactionAllocation){}

        public static implicit operator TdrTransactionAllocationPrimaryKey(int primaryKeyValue)
        {
            return new TdrTransactionAllocationPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TdrTransactionAllocationPrimaryKey(TdrTransactionAllocation tdrTransactionAllocation)
        {
            return new TdrTransactionAllocationPrimaryKey(tdrTransactionAllocation);
        }
    }
}