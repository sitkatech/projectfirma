using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.LocalAndRegionalPlan
{
    public class SummaryViewData : EIPViewData
    {
        public readonly Models.LocalAndRegionalPlan LocalAndRegionalPlan;
        public readonly string EditLocalAndRegionalPlanUrl;
        public readonly string IndexUrl;

        public readonly bool UserHasLocalAndRegionalPlanManagePermissions;
        public readonly BasicProjectInfoGridSpec BasicProjectInfoGridSpec;
        public readonly string BasicProjectInfoGridName;
        public readonly string BasicProjectInfoGridDataUrl;
        public readonly TransportationListProjectGridSpec TransportationListProjectGridSpec;
        public readonly string TransportationListProjectGridName;
        public readonly string TransportationListProjectGridDataUrl;
        public readonly bool IsTransportationPlan;

        public SummaryViewData(Person currentPerson, Models.LocalAndRegionalPlan localAndRegionalPlan) : base(currentPerson)
        {
            LocalAndRegionalPlan = localAndRegionalPlan;
            PageTitle = localAndRegionalPlan.LocalAndRegionalPlanName;
            EntityName = "Local and Regional Plan";
            
            EditLocalAndRegionalPlanUrl = SitkaRoute<LocalAndRegionalPlanController>.BuildUrlFromExpression(c => c.Edit(localAndRegionalPlan.LocalAndRegionalPlanID));
            IndexUrl = SitkaRoute<LocalAndRegionalPlanController>.BuildUrlFromExpression(c => c.Index());

            UserHasLocalAndRegionalPlanManagePermissions = new LocalAndRegionalPlanManageFeature().HasPermissionByPerson(currentPerson);

            IsTransportationPlan = localAndRegionalPlan.IsTransportationPlan;

            BasicProjectInfoGridName = "localAndRegionalPlanProjectListGrid";
            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(CurrentPerson, false)
            {
                ObjectNameSingular = "Project with this Local and Regional Plan",
                ObjectNamePlural = "Projects with this Local and Regional Plan",
                SaveFiltersInCookie = true
            };
            BasicProjectInfoGridDataUrl = SitkaRoute<LocalAndRegionalPlanController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(localAndRegionalPlan));
            
            TransportationListProjectGridName = "localAndRegionalPlanProjectListGrid";
            TransportationListProjectGridSpec = new TransportationListProjectGridSpec(CurrentPerson)
            {
                ObjectNameSingular = "Project with this Local and Regional Plan",
                ObjectNamePlural = "Projects with this Local and Regional Plan",
                SaveFiltersInCookie = true
            };
            TransportationListProjectGridDataUrl = SitkaRoute<LocalAndRegionalPlanController>.BuildUrlFromExpression(tc => tc.TransportationProjectsGridJsonData(localAndRegionalPlan));
        }
    }
}