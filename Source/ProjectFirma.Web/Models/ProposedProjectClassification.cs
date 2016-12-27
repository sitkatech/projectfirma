using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class ProposedProjectClassification : IEntityClassification, IAuditableEntity
    {
        //public int ProjectID { get { return ProposedProjectID; }}

        public string AuditDescriptionString
        {
            get
            {
                var project = HttpRequestStorage.DatabaseEntities.ProposedProjects.Find(ProposedProjectID);
                var projectName = project != null ? project.AuditDescriptionString : ViewUtilities.NotFoundString;
                return string.Format("Proposed Project: {0}", projectName);
            }
        }
    }


}