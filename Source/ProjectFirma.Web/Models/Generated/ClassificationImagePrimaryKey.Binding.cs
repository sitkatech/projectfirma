//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ClassificationImage
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ClassificationImagePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ClassificationImage>
    {
        public ClassificationImagePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ClassificationImagePrimaryKey(ClassificationImage classificationImage) : base(classificationImage){}

        public static implicit operator ClassificationImagePrimaryKey(int primaryKeyValue)
        {
            return new ClassificationImagePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ClassificationImagePrimaryKey(ClassificationImage classificationImage)
        {
            return new ClassificationImagePrimaryKey(classificationImage);
        }
    }
}