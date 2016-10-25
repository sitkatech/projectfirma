using System.Web;

namespace ProjectFirma.Web.Views.ProjectFirmaPage
{
    public class ProjectFirmaPageDetailsViewData : FirmaUserControlViewData
    {
        public readonly HtmlString ProjectFirmaPageContent;

        public ProjectFirmaPageDetailsViewData(HtmlString projectFirmaPageContent)
        {
            ProjectFirmaPageContent = projectFirmaPageContent;
        }
    }
}