using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class TrainingVideoModelExtensions
    {
        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(SitkaRoute<TrainingVideoController>.BuildUrlFromExpression(t => t.DeleteTrainingVideo(UrlTemplate.Parameter1Int)));
        public static string GetDeleteUrl(this TrainingVideo trainingVideo)
        {
            return DeleteUrlTemplate.ParameterReplace(trainingVideo.TrainingVideoID);
        }
    }
}