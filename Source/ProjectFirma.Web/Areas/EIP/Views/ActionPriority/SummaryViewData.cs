using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Areas.EIP.Security;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Areas.EIP.Views.Map;
using ProjectFirma.Web.Areas.EIP.Views.Project;
using ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectControls;
using ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectLocationControls;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.EIP.Views.ActionPriority
{
    public class SummaryViewData : EIPViewData
    {
        public readonly Models.ActionPriority ActionPriority;
        public readonly bool UserHasActionPriorityManagePermissions;
        public readonly string EditActionPriorityUrl;
        public readonly BasicProjectInfoGridSpec BasicProjectInfoGridSpec;
        public readonly string FiveYearListProjectGridName;
        public readonly string FiveYearListProjectGridDataUrl;
        public readonly ProjectTaxonomyViewData ProjectTaxonomyViewData;
        public readonly string EditDescriptionUrl;

        public readonly ProjectLocationsMapInitJson ProjectLocationsMapInitJson;
        public readonly ProjectLocationsMapViewData ProjectLocationsMapViewData;
        public readonly string EipProjectMapFilteredUrl;

        public SummaryViewData(Person currentPerson,
            Models.ActionPriority actionPriority,
            ProjectLocationsMapInitJson projectLocationsMapInitJson,
            ProjectLocationsMapViewData projectLocationsMapViewData) : base(currentPerson)
        {
            ActionPriority = actionPriority;
            PageTitle = actionPriority.DisplayName;
            EntityName = "Action Priority";

            ProjectLocationsMapInitJson = projectLocationsMapInitJson;
            ProjectLocationsMapViewData = projectLocationsMapViewData;
            EipProjectMapFilteredUrl = ProjectLocationsMapInitJson.ProjectMapCustomization.GetCustomizedUrl();

            UserHasActionPriorityManagePermissions = new ActionPriorityManageFeature().HasPermissionByPerson(CurrentPerson);
            EditActionPriorityUrl = SitkaRoute<ActionPriorityController>.BuildUrlFromExpression(c => c.Edit(actionPriority));

            FiveYearListProjectGridName = "actionPriorityProjectListGrid";
            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true)
            {
                ObjectNameSingular = "Project with this Action Priority",
                ObjectNamePlural = "Projects with this Action Priority",
                SaveFiltersInCookie = true
            };

            FiveYearListProjectGridDataUrl = SitkaRoute<ActionPriorityController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(actionPriority));
            ProjectTaxonomyViewData = new ProjectTaxonomyViewData(actionPriority);
            EditDescriptionUrl = SitkaRoute<ActionPriorityController>.BuildUrlFromExpression(tc => tc.EditDescription(actionPriority));
        }
    }
}