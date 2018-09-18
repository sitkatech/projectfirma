//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TrainingVideo]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static TrainingVideo GetTrainingVideo(this IQueryable<TrainingVideo> trainingVideos, int trainingVideoID)
        {
            var trainingVideo = trainingVideos.SingleOrDefault(x => x.TrainingVideoID == trainingVideoID);
            Check.RequireNotNullThrowNotFound(trainingVideo, "TrainingVideo", trainingVideoID);
            return trainingVideo;
        }

        public static void DeleteTrainingVideo(this List<int> trainingVideoIDList)
        {
            if(trainingVideoIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTrainingVideos.RemoveRange(HttpRequestStorage.DatabaseEntities.TrainingVideos.Where(x => trainingVideoIDList.Contains(x.TrainingVideoID)));
            }
        }

        public static void DeleteTrainingVideo(this ICollection<TrainingVideo> trainingVideosToDelete)
        {
            if(trainingVideosToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllTrainingVideos.RemoveRange(trainingVideosToDelete);
            }
        }

        public static void DeleteTrainingVideo(this int trainingVideoID)
        {
            DeleteTrainingVideo(new List<int> { trainingVideoID });
        }

        public static void DeleteTrainingVideo(this TrainingVideo trainingVideoToDelete)
        {
            DeleteTrainingVideo(new List<TrainingVideo> { trainingVideoToDelete });
        }
    }
}