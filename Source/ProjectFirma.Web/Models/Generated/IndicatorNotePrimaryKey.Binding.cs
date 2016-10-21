//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.IndicatorNote
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class IndicatorNotePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<IndicatorNote>
    {
        public IndicatorNotePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public IndicatorNotePrimaryKey(IndicatorNote indicatorNote) : base(indicatorNote){}

        public static implicit operator IndicatorNotePrimaryKey(int primaryKeyValue)
        {
            return new IndicatorNotePrimaryKey(primaryKeyValue);
        }

        public static implicit operator IndicatorNotePrimaryKey(IndicatorNote indicatorNote)
        {
            return new IndicatorNotePrimaryKey(indicatorNote);
        }
    }
}