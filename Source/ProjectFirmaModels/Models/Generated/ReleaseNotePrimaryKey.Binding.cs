//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReleaseNote
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReleaseNotePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReleaseNote>
    {
        public ReleaseNotePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReleaseNotePrimaryKey(ReleaseNote releaseNote) : base(releaseNote){}

        public static implicit operator ReleaseNotePrimaryKey(int primaryKeyValue)
        {
            return new ReleaseNotePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReleaseNotePrimaryKey(ReleaseNote releaseNote)
        {
            return new ReleaseNotePrimaryKey(releaseNote);
        }
    }
}