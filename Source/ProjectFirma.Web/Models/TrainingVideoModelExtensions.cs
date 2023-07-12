using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
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
        public static HtmlString GetViewableRoles(this TrainingVideo trainingVideo)
        {
            var trainingVideoRoles = HttpRequestStorage.DatabaseEntities.TrainingVideoRoles.Where(x => x.TrainingVideoID == trainingVideo.TrainingVideoID).ToList();
            return new HtmlString(trainingVideoRoles.Any()
                ? string.Join(", ", trainingVideoRoles.OrderBy(x => x.Role?.SortOrder).Select(x => x.Role == null ? "Anonymous (Public)" : x.Role.GetRoleDisplayName()).ToList())
                : ViewUtilities.NoAnswerProvided);
        }


        public static bool HasViewPermission(this TrainingVideo trainingVideo, FirmaSession currentFirmaSession)
        {
            var viewTypeRoles = trainingVideo.TrainingVideoRoles;
            return (currentFirmaSession.Person != null &&  viewTypeRoles.Select(x => x.Role).Contains(currentFirmaSession.Role)) ||
                   new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession) ||
                   (currentFirmaSession.Person == null && viewTypeRoles.Any(x => x.Role == null));
        }
    }
}