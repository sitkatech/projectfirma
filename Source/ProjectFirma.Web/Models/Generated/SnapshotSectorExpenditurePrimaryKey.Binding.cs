//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SnapshotSectorExpenditure
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class SnapshotSectorExpenditurePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<SnapshotSectorExpenditure>
    {
        public SnapshotSectorExpenditurePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SnapshotSectorExpenditurePrimaryKey(SnapshotSectorExpenditure snapshotSectorExpenditure) : base(snapshotSectorExpenditure){}

        public static implicit operator SnapshotSectorExpenditurePrimaryKey(int primaryKeyValue)
        {
            return new SnapshotSectorExpenditurePrimaryKey(primaryKeyValue);
        }

        public static implicit operator SnapshotSectorExpenditurePrimaryKey(SnapshotSectorExpenditure snapshotSectorExpenditure)
        {
            return new SnapshotSectorExpenditurePrimaryKey(snapshotSectorExpenditure);
        }
    }
}