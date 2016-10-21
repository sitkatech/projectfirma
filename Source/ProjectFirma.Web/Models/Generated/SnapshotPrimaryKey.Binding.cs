//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.Snapshot
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class SnapshotPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<Snapshot>
    {
        public SnapshotPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SnapshotPrimaryKey(Snapshot snapshot) : base(snapshot){}

        public static implicit operator SnapshotPrimaryKey(int primaryKeyValue)
        {
            return new SnapshotPrimaryKey(primaryKeyValue);
        }

        public static implicit operator SnapshotPrimaryKey(Snapshot snapshot)
        {
            return new SnapshotPrimaryKey(snapshot);
        }
    }
}