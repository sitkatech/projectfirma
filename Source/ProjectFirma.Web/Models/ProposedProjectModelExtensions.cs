using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public static class ProposedProjectModelExtensions
    {
        public static readonly UrlTemplate<int> DetailUrlTemplate = new UrlTemplate<int>(SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int)));
        public static string GetDetailUrl(this ProposedProject proposedProject)
        {
            return DetailUrlTemplate.ParameterReplace(proposedProject.ProposedProjectID);
        }

        public static readonly UrlTemplate<int> EditUrlTemplate = new UrlTemplate<int>(SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(t => t.EditBasics(UrlTemplate.Parameter1Int)));
        public static string GetEditUrl(this ProposedProject project)
        {
            return EditUrlTemplate.ParameterReplace(project.ProposedProjectID);
        }

        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(t => t.DeleteProposedProject(UrlTemplate.Parameter1Int)));
        public static string GetDeleteUrl(this ProposedProject project)
        {
            return DeleteUrlTemplate.ParameterReplace(project.ProposedProjectID);
        }
    }
}