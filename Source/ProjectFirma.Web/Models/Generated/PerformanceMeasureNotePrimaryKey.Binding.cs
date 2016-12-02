//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PerformanceMeasureNote
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureNotePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PerformanceMeasureNote>
    {
        public PerformanceMeasureNotePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PerformanceMeasureNotePrimaryKey(PerformanceMeasureNote performanceMeasureNote) : base(performanceMeasureNote){}

        public static implicit operator PerformanceMeasureNotePrimaryKey(int primaryKeyValue)
        {
            return new PerformanceMeasureNotePrimaryKey(primaryKeyValue);
        }

        public static implicit operator PerformanceMeasureNotePrimaryKey(PerformanceMeasureNote performanceMeasureNote)
        {
            return new PerformanceMeasureNotePrimaryKey(performanceMeasureNote);
        }
    }
}