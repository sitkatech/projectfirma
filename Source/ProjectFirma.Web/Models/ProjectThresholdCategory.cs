using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectThresholdCategory : IEntityThresholdCategory, IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get
            {
                var projectDeleted = HttpRequestStorage.DatabaseEntities.Projects.Find(ProjectID);
                var thresholdCategoryDeleted = HttpRequestStorage.DatabaseEntities.ThresholdCategories.Find(ThresholdCategoryID);
                var projectName = projectDeleted != null ? projectDeleted.AuditDescriptionString : ViewUtilities.NotFoundString;
                var thresholdCategoryName = thresholdCategoryDeleted != null ? thresholdCategoryDeleted.AuditDescriptionString : ViewUtilities.NotFoundString;
                return string.Format("Project: {0}, Threshold Category: {1}", projectName, thresholdCategoryName);
            }
        }

        public ProjectThresholdCategory(int projectID, int thresholdCategoryID, string projectThresholdCategoryNotes)
            : this()
        {            
            ProjectID = projectID;
            ThresholdCategoryID = thresholdCategoryID;
            ProjectThresholdCategoryNotes = projectThresholdCategoryNotes;
        }
        
    }
}