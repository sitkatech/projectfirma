using LtInfo.Common.Views;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ProposedProjectWatershed : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get
            {                
                var watershed = Watershed != null ? Watershed.DisplayName : ViewUtilities.NotFoundString;
                var proposedProject = ProposedProject != null ? ProposedProject.DisplayName : ViewUtilities.NotFoundString;
                return $"Watershed: {watershed}, Proposed Project: {proposedProject}";
            }
        }
    }
}