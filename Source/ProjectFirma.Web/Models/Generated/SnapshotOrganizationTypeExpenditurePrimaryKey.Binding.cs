//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SnapshotOrganizationTypeExpenditure
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class SnapshotOrganizationTypeExpenditurePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<SnapshotOrganizationTypeExpenditure>
    {
        public SnapshotOrganizationTypeExpenditurePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SnapshotOrganizationTypeExpenditurePrimaryKey(SnapshotOrganizationTypeExpenditure snapshotOrganizationTypeExpenditure) : base(snapshotOrganizationTypeExpenditure){}

        public static implicit operator SnapshotOrganizationTypeExpenditurePrimaryKey(int primaryKeyValue)
        {
            return new SnapshotOrganizationTypeExpenditurePrimaryKey(primaryKeyValue);
        }

        public static implicit operator SnapshotOrganizationTypeExpenditurePrimaryKey(SnapshotOrganizationTypeExpenditure snapshotOrganizationTypeExpenditure)
        {
            return new SnapshotOrganizationTypeExpenditurePrimaryKey(snapshotOrganizationTypeExpenditure);
        }
    }
}