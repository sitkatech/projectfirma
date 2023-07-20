//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TrainingVideoRole
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class TrainingVideoRolePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TrainingVideoRole>
    {
        public TrainingVideoRolePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TrainingVideoRolePrimaryKey(TrainingVideoRole trainingVideoRole) : base(trainingVideoRole){}

        public static implicit operator TrainingVideoRolePrimaryKey(int primaryKeyValue)
        {
            return new TrainingVideoRolePrimaryKey(primaryKeyValue);
        }

        public static implicit operator TrainingVideoRolePrimaryKey(TrainingVideoRole trainingVideoRole)
        {
            return new TrainingVideoRolePrimaryKey(trainingVideoRole);
        }
    }
}