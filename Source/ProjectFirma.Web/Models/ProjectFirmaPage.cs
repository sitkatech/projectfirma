using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectFirmaPage
    {
        public bool HasProjectFirmaPageContent
        {
            get { return !string.IsNullOrWhiteSpace(ProjectFirmaPageContent); }
        }

        public static ProjectFirmaPage GetProjectFirmaPageByPageType(ProjectFirmaPageType projectFirmaPageType)
        {
            var projectFirmaPage = HttpRequestStorage.DatabaseEntities.ProjectFirmaPages.SingleOrDefault(x => x.ProjectFirmaPageTypeID == projectFirmaPageType.ProjectFirmaPageTypeID);
            Check.RequireNotNull(projectFirmaPage);
            return projectFirmaPage;
        }
    }
}