using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.ModalDialog;

namespace ProjectFirma.Web.Views.TransportationObjective
{
    public class IndexViewData : FirmaViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage)
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