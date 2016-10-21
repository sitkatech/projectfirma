using ProjectFirma.Web.Areas.EIP.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public static class ProjectModelExtensions
    {
        public readonly static UrlTemplate<string> SummaryUrlTemplate = new UrlTemplate<string>(SitkaRoute<ProjectController>.BuildUrlFromExpression(t => t.Summary(UrlTemplate.Parameter1String)));
        public static string GetSummaryUrl(this Project project)
        {
            return SummaryUrlTemplate.ParameterReplace(project.ProjectNumberString);
        }

        public readonly static UrlTemplate<int> EditUrlTemplate = new UrlTemplate<int>(SitkaRoute<ProjectController>.BuildUrlFromExpression(t => t.Edit(UrlTemplate.Parameter1Int)));
        public static string GetEditUrl(this Project project)
        {
            return EditUrlTemplate.ParameterReplace(project.ProjectID);
        }

        public readonly static UrlTemplate<string> FactSheetUrlTemplate = new UrlTemplate<string>(SitkaRoute<ProjectController>.BuildUrlFromExpression(t => t.FactSheet(UrlTemplate.Parameter1String)));
        public static string GetFactSheetUrl(this Project project)
        {
            return FactSheetUrlTemplate.ParameterReplace(project.ProjectNumberString);
        }

        public readonly static UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(SitkaRoute<ProjectController>.BuildUrlFromExpression(t => t.DeleteProject(UrlTemplate.Parameter1Int)));
        public static string GetDeleteUrl(this Project project)
        {
            return DeleteUrlTemplate.ParameterReplace(project.ProjectID);
        }

        public readonly static UrlTemplate<int> ProjectUpdateUrlTemplate = new UrlTemplate<int>(SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(t => t.Instructions(UrlTemplate.Parameter1Int)));
        public static string GetProjectUpdateUrl(this Project project)
        {
            return ProjectUpdateUrlTemplate.ParameterReplace(project.ProjectID);
        }

        public readonly static UrlTemplate<int> ProjectMapPopuUrlTemplate = new UrlTemplate<int>(SitkaRoute<ProjectController>.BuildUrlFromExpression(t => t.ProjectMapPopup(UrlTemplate.Parameter1Int)));
        public static string GetProjectMapPopupUrl(this Project project)
        {
            return ProjectMapPopuUrlTemplate.ParameterReplace(project.ProjectID);
        }
    }
}