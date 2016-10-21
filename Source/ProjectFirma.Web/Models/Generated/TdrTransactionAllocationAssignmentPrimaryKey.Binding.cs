//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TdrTransactionAllocationAssignment
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class TdrTransactionAllocationAssignmentPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TdrTransactionAllocationAssignment>
    {
        public TdrTransactionAllocationAssignmentPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TdrTransactionAllocationAssignmentPrimaryKey(TdrTransactionAllocationAssignment tdrTransactionAllocationAssignment) : base(tdrTransactionAllocationAssignment){}

        public static implicit operator TdrTransactionAllocationAssignmentPrimaryKey(int primaryKeyValue)
        {
            return new TdrTransactionAllocationAssignmentPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TdrTransactionAllocationAssignmentPrimaryKey(TdrTransactionAllocationAssignment tdrTransactionAllocationAssignment)
        {
            return new TdrTransactionAllocationAssignmentPrimaryKey(tdrTransactionAllocationAssignment);
        }
    }
}