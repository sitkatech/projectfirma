//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SnapshotProject
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class SnapshotProjectPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<SnapshotProject>
    {
        public SnapshotProjectPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SnapshotProjectPrimaryKey(SnapshotProject snapshotProject) : base(snapshotProject){}

        public static implicit operator SnapshotProjectPrimaryKey(int primaryKeyValue)
        {
            return new SnapshotProjectPrimaryKey(primaryKeyValue);
        }

        public static implicit operator SnapshotProjectPrimaryKey(SnapshotProject snapshotProject)
        {
            return new SnapshotProjectPrimaryKey(snapshotProject);
        }
    }
}