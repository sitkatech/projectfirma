using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Areas.EIP.Security;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using LtInfo.Common;
using LtInfo.Common.ModalDialog;

namespace ProjectFirma.Web.Areas.EIP.Views.TransportationObjective
{
    public class IndexViewData : EIPViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson, Models.ProjectFirmaPage projectFirmaPage) : base(currentPerson, projectFirmaPage)
        {
            PageTitle = "Transportation Objectives";

            var hasTransportationObjectiveManagePermissions = new TransportationObjectiveManageFeature().HasPermissionByPerson(currentPerson);
            GridSpec = new IndexGridSpec(hasTransportationObjectiveManagePermissions)
            {
                ObjectNameSingular = "Transportation Objective",
                ObjectNamePlural = "Transportation Objectives",
                SaveFiltersInCookie = true
            };

            if (hasTransportationObjectiveManagePermissions)
            {
                GridSpec.CreateEntityModalDialogForm = new ModalDialogForm(SitkaRoute<TransportationObjectiveController>.BuildUrlFromExpression(t => t.New()), "Create a new Transportation Objective");
            }

            GridName = "transportationObjectivesGrid";
            GridDataUrl = SitkaRoute<TransportationObjectiveController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
        }
    }
}