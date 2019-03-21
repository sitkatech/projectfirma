//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.Classification
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ClassificationPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<Classification>
    {
        public ClassificationPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ClassificationPrimaryKey(Classification classification) : base(classification){}

        public static implicit operator ClassificationPrimaryKey(int primaryKeyValue)
        {
            return new ClassificationPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ClassificationPrimaryKey(Classification classification)
        {
            return new ClassificationPrimaryKey(classification);
        }
    }
}