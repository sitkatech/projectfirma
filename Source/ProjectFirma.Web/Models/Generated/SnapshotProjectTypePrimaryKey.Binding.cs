//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SnapshotProjectType
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class SnapshotProjectTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<SnapshotProjectType>
    {
        public SnapshotProjectTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SnapshotProjectTypePrimaryKey(SnapshotProjectType snapshotProjectType) : base(snapshotProjectType){}

        public static implicit operator SnapshotProjectTypePrimaryKey(int primaryKeyValue)
        {
            return new SnapshotProjectTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator SnapshotProjectTypePrimaryKey(SnapshotProjectType snapshotProjectType)
        {
            return new SnapshotProjectTypePrimaryKey(snapshotProjectType);
        }
    }
}