using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectWatershed : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get
            {
                var project = HttpRequestStorage.DatabaseEntities.Projects.Find(ProjectID);
                var watershed = HttpRequestStorage.DatabaseEntities.Watersheds.Find(WatershedID);
                var projectName = project != null ? project.AuditDescriptionString : ViewUtilities.NotFoundString;
                var watershedName = watershed != null ? watershed.AuditDescriptionString : ViewUtilities.NotFoundString;
                return string.Format("Project: {0}, Watershed: {1}", projectName, watershedName);
            }
        }
    }
}