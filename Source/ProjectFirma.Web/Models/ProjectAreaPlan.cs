using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectLocalAndRegionalPlan : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get
            {
                var project = HttpRequestStorage.DatabaseEntities.Projects.Find(this.ProjectID);
                var localAndRegionalPlan = HttpRequestStorage.DatabaseEntities.LocalAndRegionalPlans.Find(this.LocalAndRegionalPlanID);
                var projectDisplayName = project != null ? project.AuditDescriptionString : ViewUtilities.NotFoundString;
                var localAndRegionalPlanDisplayName = localAndRegionalPlan != null ? localAndRegionalPlan.AuditDescriptionString : ViewUtilities.NotFoundString;
                return string.Format("Project: {0}, Local and Regional Plan: {1}", projectDisplayName, localAndRegionalPlanDisplayName);
            }
        }
    }
}