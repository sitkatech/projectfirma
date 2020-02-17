using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    // Not quite a full-fledged feature, but analogous so calling it that
    public class OfferProjectFactSheetLinkFeature
    {
        public static bool OfferProjectFactSheetLink(FirmaSession currentFirmaSession, Project project)
        {
            return project.ProjectStage != ProjectStage.Terminated;
        }
    }
}