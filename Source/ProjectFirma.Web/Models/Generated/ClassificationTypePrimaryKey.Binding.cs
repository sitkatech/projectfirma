//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ClassificationType
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ClassificationTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ClassificationType>
    {
        public ClassificationTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ClassificationTypePrimaryKey(ClassificationType classificationType) : base(classificationType){}

        public static implicit operator ClassificationTypePrimaryKey(int primaryKeyValue)
        {
            return new ClassificationTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ClassificationTypePrimaryKey(ClassificationType classificationType)
        {
            return new ClassificationTypePrimaryKey(classificationType);
        }
    }
}