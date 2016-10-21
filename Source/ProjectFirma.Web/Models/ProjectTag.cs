using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectTag : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get
            {
                var project = HttpRequestStorage.DatabaseEntities.Projects.Find(ProjectID);
                var tag = HttpRequestStorage.DatabaseEntities.Watersheds.Find(TagID);
                var projectName = project != null ? project.AuditDescriptionString : ViewUtilities.NotFoundString;
                var tagName = tag != null ? tag.AuditDescriptionString : ViewUtilities.NotFoundString;
                return string.Format("Project: {0}, Tag: {1}", projectName, tagName); 
                
            }
        }
    }
}