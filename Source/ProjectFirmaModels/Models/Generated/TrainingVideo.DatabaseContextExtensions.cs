//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TrainingVideo]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static TrainingVideo GetTrainingVideo(this IQueryable<TrainingVideo> trainingVideos, int trainingVideoID)
        {
            var trainingVideo = trainingVideos.SingleOrDefault(x => x.TrainingVideoID == trainingVideoID);
            Check.RequireNotNullThrowNotFound(trainingVideo, "TrainingVideo", trainingVideoID);
            return trainingVideo;
        }

    }
}