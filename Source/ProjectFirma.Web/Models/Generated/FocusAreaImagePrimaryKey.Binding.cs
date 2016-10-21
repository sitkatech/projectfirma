//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FocusAreaImage
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class FocusAreaImagePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FocusAreaImage>
    {
        public FocusAreaImagePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FocusAreaImagePrimaryKey(FocusAreaImage focusAreaImage) : base(focusAreaImage){}

        public static implicit operator FocusAreaImagePrimaryKey(int primaryKeyValue)
        {
            return new FocusAreaImagePrimaryKey(primaryKeyValue);
        }

        public static implicit operator FocusAreaImagePrimaryKey(FocusAreaImage focusAreaImage)
        {
            return new FocusAreaImagePrimaryKey(focusAreaImage);
        }
    }
}