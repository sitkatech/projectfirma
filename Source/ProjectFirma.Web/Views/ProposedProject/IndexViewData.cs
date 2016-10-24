using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.ProposedProject
{
    public class IndexViewData : EIPViewData
    {
        public readonly ProposedProjectGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;
        public readonly bool HasProposeProjectPermissions;
        public readonly string ProposeNewProjectUrl;

        public IndexViewData(Person currentPerson, Models.ProjectFirmaPage projectFirmaPage) : base(currentPerson, projectFirmaPage)
        {
            PageTitle = "Proposed Projects";

            HasProposeProjectPermissions = new ProposedProjectEditFeature().HasPermissionByPerson(CurrentPerson);
            ProposeNewProjectUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(x => x.Instructions(null));

            GridSpec = new ProposedProjectGridSpec(currentPerson) {ObjectNameSingular = "Proposed Project", ObjectNamePlural = "Proposed Projects", SaveFiltersInCookie = true};
            if (new ProposedProjectEditFeature().HasPermissionByPerson(CurrentPerson))
            {
                GridSpec.CreateEntityActionPhrase = "Propose a New Project";
                GridSpec.CreateEntityModalDialogForm = null;
            }
            GridName = "proposedProjectsGrid";
            GridDataUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
        }
    }
}