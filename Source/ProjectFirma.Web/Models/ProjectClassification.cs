using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectClassification : IEntityClassification, IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get
            {
                var projectDeleted = HttpRequestStorage.DatabaseEntities.Projects.Find(ProjectID);
                var classificationDeleted = HttpRequestStorage.DatabaseEntities.Classifications.Find(ClassificationID);
                var projectName = projectDeleted != null ? projectDeleted.AuditDescriptionString : ViewUtilities.NotFoundString;
                var classificationName = classificationDeleted != null ? classificationDeleted.AuditDescriptionString : ViewUtilities.NotFoundString;
                return string.Format("Project: {0}, Classification: {1}", projectName, classificationName);
            }
        }

        public ProjectClassification(int projectID, int classificationID, string projectClassificationNotes)
            : this()
        {            
            ProjectID = projectID;
            ClassificationID = classificationID;
            ProjectClassificationNotes = projectClassificationNotes;
        }
        
    }
}