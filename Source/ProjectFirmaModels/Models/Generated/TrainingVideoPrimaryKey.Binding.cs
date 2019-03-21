//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TrainingVideo
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class TrainingVideoPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TrainingVideo>
    {
        public TrainingVideoPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TrainingVideoPrimaryKey(TrainingVideo trainingVideo) : base(trainingVideo){}

        public static implicit operator TrainingVideoPrimaryKey(int primaryKeyValue)
        {
            return new TrainingVideoPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TrainingVideoPrimaryKey(TrainingVideo trainingVideo)
        {
            return new TrainingVideoPrimaryKey(trainingVideo);
        }
    }
}