//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FocusArea
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class FocusAreaPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FocusArea>
    {
        public FocusAreaPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FocusAreaPrimaryKey(FocusArea focusArea) : base(focusArea){}

        public static implicit operator FocusAreaPrimaryKey(int primaryKeyValue)
        {
            return new FocusAreaPrimaryKey(primaryKeyValue);
        }

        public static implicit operator FocusAreaPrimaryKey(FocusArea focusArea)
        {
            return new FocusAreaPrimaryKey(focusArea);
        }
    }
}